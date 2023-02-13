const validators = {
  isRequired: {
    type: "isRequired",
    text: "Required",
    error: "Given value is required",
    valueType: "boolean",
    params: [true],
  },
  number_max: {
    type: "max",
    text: "Max number value",
    error: "Entered number is too big",
    valueType: "number",
    params: [1000000],
  },
  string_max: {
    type: "max",
    text: "Max text length",
    error: "Too long text input",
    valueType: "number",
    params: [1000],
  },
  email_max: {
    type: "max",
    text: "Max email length",
    error: "Too long email",
    valueType: "number",
    params: [100],
  },
  number_min: {
    type: "min",
    text: "Min number value",
    error: "Entered number is too small",
    valueType: "number",
    params: [-1000000],
  },
  string_min: {
    type: "min",
    text: "Min text length",
    error: "Too short text input",
    valueType: "number",
    params: [0],
  },
  email_min: {
    type: "min",
    text: "min email length",
    error: "Too short email",
    valueType: "number",
    params: [5],
  },
};

export default validators;
