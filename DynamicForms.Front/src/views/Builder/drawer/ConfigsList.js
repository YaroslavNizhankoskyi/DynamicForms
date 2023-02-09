import React, { useEffect, useState, createElement } from "react";
import { VStack, FormControl, FormLabel, Input } from "@chakra-ui/react";
import getEditableComponentByType from "common/builder/getEditableComponentByType";

function ConfigList({ control, formik }) {
  const [configEditables, setConfigEditables] = useState([]);

  useEffect(() => getConfigEditables(), []);

  const addValueToFormik = (name, value) => {
    let initValues = formik.initialValues;
    initValues[name] = value;
    formik.initialValues = initValues;
  };

  const mapValidationConfigToFormik = () => {
    let validatorsData = control.validation.validatorsData;

    return validatorsData.map((validator) => {
      const { type, text, valueType, params } = validator;

      let value = params.length == 1 ? params[0] : params;

      addValueToFormik(type, value);

      let config = {
        name: type,
        component: getEditableComponentByType(valueType),
        value: formik.values[type],
        onChange: formik.handleChange,
        text,
        valueType,
      };

      return config;
    });
  };

  const getConfigEditables = () => {
    let configs = [];

    for (const property in control.inputConfig) {
      let value = control.inputConfig[property];

      addValueToFormik(property, value);
      let valueType = typeof value;

      let config = {
        name: property,
        component: getEditableComponentByType(valueType),
        value: formik.values[property],
        onChange: formik.handleChange,
        text: property,
        valueType,
      };

      configs.push(config);
    }

    let validatorConfigs = mapValidationConfigToFormik();

    setConfigEditables(configs.concat(validatorConfigs));
  };

  const onChangeEditable = (e) => {
    let editables = [...configEditables];
    let value = null;

    if (e.target.type && e.target.type == "checkbox") {
      value = e.target.checked;
    } else {
      value = e.target.value;
    }

    let editable = editables.find((el) => el.name == e.target.name);
    editable.value = value;

    setConfigEditables(editables);

    formik.handleChange(e);
  };

  return (
    <VStack gap={4}>
      {configEditables.map((el, idx) => {
        let valueObject =
          el.valueType == "boolean"
            ? { checked: el.value }
            : { value: el.value };
        return (
          <FormControl key={idx}>
            <FormLabel>{el.text}</FormLabel>
            {createElement(el.component, {
              onChange: onChangeEditable,
              name: el.name,
              ...valueObject,
            })}
          </FormControl>
        );
      })}
    </VStack>
  );
}

export default ConfigList;
