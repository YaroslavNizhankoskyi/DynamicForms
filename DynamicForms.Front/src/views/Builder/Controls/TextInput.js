import { Input, InputGroup } from "@chakra-ui/react";
import React from "react";

function TextInput({ control, value, onChange }) {
  return (
    <InputGroup>
      <Input
        {...control.inputConfig}
        name={control.id}
        value={value ? value : ""}
        onChange={(e) => onChange(control.id, e.target.value)}
      />
    </InputGroup>
  );
}

export default TextInput;
