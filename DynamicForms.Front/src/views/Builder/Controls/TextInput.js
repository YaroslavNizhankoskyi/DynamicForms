import { Input, InputGroup } from "@chakra-ui/react";
import React from "react";

function TextInput({ control, formik }) {
  return (
    <InputGroup>
      <Input
        {...control.inputConfig}
        onChange={formik?.handleChange}
        name={control.id}
        onBlur={formik?.handleBlur}
        value={formik.values[control.id]}
      />
    </InputGroup>
  );
}

export default TextInput;
