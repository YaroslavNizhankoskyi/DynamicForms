import {
  VStack,
  FormControl as ChakraControl,
  FormLabel,
  Text,
} from "@chakra-ui/react";
import React, { createElement, useEffect, useMemo, useState } from "react";
import { useFormik } from "formik";
import { getControlsInitialValues } from "common/helpers/formikHelpers";
import * as yup from "yup";
import controlsData from "variables/controls";
import { buildControlSchema } from "common/builder/validation/yupSchemaCreator";

function ControlPreviewList({ controls }) {
  const memoizedFormConfig = useMemo(() => {
    const initialValues = getControlsInitialValues(controls);

    const yupSchema = controls.reduce(buildControlSchema, {});
    const validationSchema = yup.object().shape(yupSchema);

    return { initialValues, validationSchema };
  }, controls);

  const formik = useFormik({
    initialValues: memoizedFormConfig.initialValues,
    validationSchema: memoizedFormConfig.validationSchema,
    onSubmit: (values) => console.log(values),
  });

  const getControlComponent = (control) => {
    let controlData = controlsData.find((el) => el.type == control.type);
    return controlData.component;
  };

  const getControl = (control) => {
    let component = getControlComponent(control);
    return (
      <>
        {createElement(component, { control, formik })}
        {formik.touched[control.id] && formik.errors[control.id] && (
          <Text variant="validation">{formik.errors[control.id]}</Text>
        )}
      </>
    );
  };

  console.log(formik.touched);
  console.log(formik.errors);

  return (
    <VStack p={"10"}>
      {controls.map((el) => {
        return (
          <ChakraControl {...el.inputConfig} key={el.id}>
            <FormLabel>{el.name}</FormLabel>
            {getControl(el)}
          </ChakraControl>
        );
      })}
    </VStack>
  );
}

export default ControlPreviewList;
