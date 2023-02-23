import {
  VStack,
  FormControl as ChakraControl,
  FormLabel,
  Button,
} from "@chakra-ui/react";
import React, { createElement, useEffect, useMemo, useState } from "react";
import { useFormik } from "formik";
import { buildControlSchema } from "common/builder/validation/yupSchemaCreator";
import * as yup from "yup";
import controlsData from "variables/controls";

function ControlPreviewList({ controls }) {
  const memoizedFormConfig = useMemo(() => {
    let initialValues = controls.reduce((init, el) => {
      const id = el.id;
      return { ...init, [id]: "" };
    }, {});

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
          <span className="text-red-400">{formik.errors[control.id]}</span>
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
