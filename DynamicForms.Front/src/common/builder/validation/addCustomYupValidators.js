import * as Yup from "yup";
import boolRequired from "./custom/boolRequired";

const addBooleanRequired = () => {
  Yup.addMethod(Yup.mixed, "isRequired", boolRequired);
};

export const addCustomYupValidators = () => {
  addBooleanRequired();
};
