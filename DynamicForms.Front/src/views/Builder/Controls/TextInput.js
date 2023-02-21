import { Input, InputGroup } from "@chakra-ui/react";
import React from "react";

function TextInput({ control, formik }) {
  return (
    <InputGroup>
      <Input
        {...control.inputConfig}
        onChange={formik?.handleChange}
        name={control.id}
      />
    </InputGroup>
  );
}

export default TextInput;
