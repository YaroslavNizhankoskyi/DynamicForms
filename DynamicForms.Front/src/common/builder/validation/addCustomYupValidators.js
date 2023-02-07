import * as Yup from "yup";
import boolRequired from "./custom/boolRequired";

const addBooleanRequired = () => {
  Yup.addMethod(Yup.mixed, "boolRequired", boolRequired);
};

export const addCustomYupValidators = () => {
  addBooleanRequired();
};
