import validators from "variables/validators";

const getValidatorsData = (validatorsNames) => {
  let controlValidators = [];

  validatorsNames.forEach((el) => {
    let validator = validators[el];
    if (validator) controlValidators.push(validator);
  });

  return controlValidators;
};

export default getValidatorsData;
