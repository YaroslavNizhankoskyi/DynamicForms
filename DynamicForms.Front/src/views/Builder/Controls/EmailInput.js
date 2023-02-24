import React from "react";
import { Input } from "@chakra-ui/react";

function EmailInput({ control, formik }) {
  return (
    <Input
      {...control.inputConfig}
      onChange={formik?.handleChange}
      onBlur={formik?.handleBlur}
      name={control.id}
      value={formik.values[control.id]}
      type="email"
    ></Input>
  );
}

export default EmailInput;
