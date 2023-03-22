export const getControlsValues = (controlIds) => {
  return controlIds.reduce((init, id) => {
    return { ...init, [id]: "" };
  }, {});
};

export const getControlValidationValue = (validatorName, control) => {
  if (control.validation.validatorsData) {
    var validator = control.validation.validatorsData.find(
      (x) => x.type == validatorName
    );

    return validator.params;
  }

  return null;
};
