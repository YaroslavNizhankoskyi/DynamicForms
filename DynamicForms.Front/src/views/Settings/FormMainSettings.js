import {
  Button,
  Divider,
  FormControl,
  FormErrorMessage,
  FormLabel,
  Heading,
  Input,
  Switch,
  Textarea,
  VStack,
} from "@chakra-ui/react";
import axios from "axios";
import { getFormikValues } from "common/helpers/formAccess/getFormikValues";
import { getApiSavableForm } from "common/helpers/formHelpers";
import { getSaveableForm } from "common/helpers/formHelpers";
import { updateUserForm } from "common/redux/stores/userForms";
import { useFormik } from "formik";
import React from "react";
import { useDispatch } from "react-redux";
import * as Yup from "yup";

function FormMainSettings({ form, setForm }) {
  const formMainProperties = ["name", "domain", "description", "visibility"];
  const dispatcher = useDispatch();
  const formSchema = Yup.object().shape({
    name: Yup.string()
      .required("Name is required")
      .min(3, "Name too small")
      .max(100, "Name too big"),
    domain: Yup.string()
      .required("Domain is required")
      .min(3, "Domain too small")
      .max(100, "Domain too big"),
    visibility: Yup.boolean(),
    description: Yup.string().max(500, "Description is too big"),
  });

  const saveDataChangesLocaly = (form) => {
    dispatcher(updateUserForm(getSaveableForm(form)));
  };

  const saveDataChangesToAPI = (form) => {
    let readyToSaveForm = getApiSavableForm(form);
    let url = process.env.REACT_APP_APIUrl + "/forms";

    axios.post(url, readyToSaveForm).then((response) => {
      console.log(response);
    });
  };

  const formik = useFormik({
    initialValues: getFormikValues(form, formMainProperties),
    validationSchema: formSchema,
    onSubmit: (values) => {
      formMainProperties.forEach((propName) => {
        form[propName] = values[propName];
      });

      console.log(form);

      saveDataChangesLocaly(form);
      saveDataChangesToAPI(form);
    },
  });

  return (
    <VStack gap={"4"}>
      <Heading color={"#41c7bf"}>Main Information</Heading>
      <Divider mb={"10px"} />

      <FormControl isInvalid={formik.errors.name && formik.touched.name}>
        <FormLabel textTransform={"capitalize"}>Name</FormLabel>
        <Input
          value={formik.values.name}
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
          name={"name"}
        />
        {formik.errors.name && formik.touched.name && (
          <FormErrorMessage>{formik.errors.name}</FormErrorMessage>
        )}
      </FormControl>

      <FormControl isInvalid={formik.errors.domain && formik.touched.domain}>
        <FormLabel textTransform={"capitalize"}>Domain</FormLabel>
        <Input
          value={formik.values.domain}
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
          name={"domain"}
        />
        {formik.errors.domain && formik.touched.domain && (
          <FormErrorMessage>{formik.errors.domain}</FormErrorMessage>
        )}
      </FormControl>

      <FormControl
        isInvalid={formik.errors.description && formik.touched.description}
      >
        <FormLabel textTransform={"capitalize"}>Description</FormLabel>
        <Textarea
          value={formik.values.description}
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
          name={"description"}
        />
        {formik.errors.description && formik.touched.description && (
          <FormErrorMessage>{formik.errors.description}</FormErrorMessage>
        )}
      </FormControl>

      <FormControl
        display="flex"
        alignItems="center"
        isInvalid={formik.errors.visibility && formik.touched.visibility}
      >
        <FormLabel textTransform={"capitalize"}>Visibility</FormLabel>
        <Switch
          isChecked={formik.values.visibility}
          value={formik.values.visibility}
          onChange={(e) =>
            formik.setFieldValue("visibility", !formik.values.visibility)
          }
          onBlur={formik.handleBlur}
          name={"visibility"}
        />
        {formik.errors.visibility && formik.touched.visibility && (
          <FormErrorMessage>{formik.errors.visibility}</FormErrorMessage>
        )}
      </FormControl>

      <Button onClick={formik.handleSubmit} bg={"#41c7bf"}>
        Save
      </Button>
    </VStack>
  );
}

export default FormMainSettings;
