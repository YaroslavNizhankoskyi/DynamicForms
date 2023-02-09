import { Input, InputGroup } from "@chakra-ui/react";
import React from "react";

function TextInput({ control }) {
  return (
    <InputGroup>
      <Input {...control.inputConfig} />
    </InputGroup>
  );
}

export default TextInput;
