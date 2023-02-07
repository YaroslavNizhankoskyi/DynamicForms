import * as Yup from "yup";

function boolRequired(isRequired, error) {
  return isRequired ? this.required(error) : this.optional();
}

export default boolRequired;
