const validators = {
  required: {
    type: "boolRequired",
    name: "Required",
    error: "Given value is required",
    valueType: Boolean,
    params: [true],
  },
  number_max: {
    type: "max",
    name: "Max number value",
    error: "Entered number is too big",
    valueType: Number,
    params: [Number.MAX_VALUE],
  },
  string_max: {
    type: "max",
    name: "Max text length",
    error: "Too long text input",
    valueType: Number,
    params: [1000],
  },
  email_max: {
    type: "max",
    name: "Max email length",
    error: "Too long email",
    valueType: Number,
    params: [100],
  },
  number_min: {
    type: "min",
    name: "Min number value",
    error: "Entered number is too small",
    valueType: Number,
    params: [Number.MIN_VALUE],
  },
  string_min: {
    type: "min",
    name: "Min text length",
    error: "Too short text input",
    valueType: Number,
    params: [0],
  },
  email_min: {
    type: "min",
    name: "min email length",
    error: "Too short email",
    valueType: Number,
    params: [5],
  },
};

export default validators;
