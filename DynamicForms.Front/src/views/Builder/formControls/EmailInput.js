import React from "react";
import { Input } from "@chakra-ui/react";

function EmailInput({ control, value, onChange, onBlur }) {
  return (
    <Input
      {...control.inputConfig}
      onChange={(e) => onChange(control.id, e.target.value)}
      name={control.id}
      value={value}
      onBlur={onBlur ?? (() => {})}
      type="email"
    ></Input>
  );
}

export default EmailInput;
