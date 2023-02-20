import * as yup from "yup";
import getValidatorsData from "./getControlValidators";

export function buildControlSchema(control) {
  const {
    validation: { validatorsData, validationType },
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

  control.validation.schema = validator;
}

export function setupDefaultValidation(control) {
  const validatorsData = getValidatorsData(control.validation.usedValidators);

  control.validation.validatorsData = validatorsData;
}
