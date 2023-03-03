import { Input, InputGroup } from "@chakra-ui/react";
import React from "react";

function TextInput({ control, value, onChange, onBlur }) {
  return (
    <InputGroup>
      <Input
        {...control.inputConfig}
        name={control.id}
        value={value ?? ""}
        onBlur={onBlur ?? (() => {})}
        onChange={(e) => onChange(control.id, e.target.value)}
      />
    </InputGroup>
  );
}

export default TextInput;
