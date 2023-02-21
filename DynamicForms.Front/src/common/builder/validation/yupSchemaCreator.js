import * as yup from "yup";
import getValidatorsData from "./getControlValidators";

export function buildControlSchema(schema, control) {
  const {
    validation: { validatorsData, validationType },
    id,
  } = control;

  if (!validatorsData) {
    return null;
  }

  if (!yup[validationType]) {
    return null;
  }

  let validator = yup[validationType]();

  validatorsData.forEach((validation) => {
    const { params, type, error } = validation;

    if (!validator[type]) {
      return;
    }

    validator = validator[type](...params, error);
  });

  schema[id] = validator;
  return schema;
}

export function setupDefaultValidation(control) {
  const validatorsData = getValidatorsData(control.validation.usedValidators);

  control.validation.validatorsData = validatorsData;
}
