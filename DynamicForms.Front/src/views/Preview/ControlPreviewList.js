import {
  VStack,
  FormControl as ChakraControl,
  FormLabel,
} from "@chakra-ui/react";
import React, { createElement, useState, useEffect } from "react";
import { useFormik } from "formik";
import { buildControlSchema } from "common/builder/validation/yupSchemaCreator";
import * as yup from "yup";
import controlsData from "variables/controls";

function ControlPreviewList({ controls }) {
  const [formik, setFormik] = useState(null);

  const getControlComponent = (control) => {
    let controlData = controlsData.find((el) => el.type == control.type);
    return controlData.component;
  };

  const getFormik = (newFormik) => {};

  const getControl = (control) => {
    let component = getControlComponent(control);
    return (
      <>
        {createElement(component, { control, formik })}
        {formik.touched[control.id] && formik.errors[control.id] && (
          <span className="text-red-400">{formik.errors[control.id]}</span>
        )}
      </>
    );
  };

  if (!formik) {
    let initialValues = controls.reduce((init, el) => {
      const id = el.id;
      return { ...init, [id]: "" };
    }, {});

    const yupSchema = controls.reduce(buildControlSchema, {});
    const validationSchema = yup.object().shape(yupSchema);
    const newFormik = useFormik({
      initialValues,
      validationSchema,
      onSubmit: (values) => console.log(values),
    });

    setFormik(newFormik);
  }

  useEffect(getFormik, []);

  return (
    <VStack p={"10"}>
      {controls.map((el) => {
        return (
          <ChakraControl {...el.inputConfig} key={el.id}>
            <FormLabel>{el.id}</FormLabel>
            {formik ? getControl(el) : <></>}
          </ChakraControl>
        );
      })}
    </VStack>
  );
}

export default ControlPreviewList;
