import React from "react";
import { Input } from "@chakra-ui/react";

function EmailInput({ control, formik }) {
  return (
    <Input
      {...control.inputConfig}
      onChange={formik?.handleChange}
      name={control.id}
      type="email"
    ></Input>
  );
}

export default EmailInput;
