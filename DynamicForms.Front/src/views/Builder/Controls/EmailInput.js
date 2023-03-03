import React from "react";
import { Input } from "@chakra-ui/react";

function EmailInput({ control, value, onChange }) {
  return (
    <Input
      {...control.inputConfig}
      onChange={(e) => onChange(control.id, e.target.value)}
      name={control.id}
      value={value}
      type="email"
    ></Input>
  );
}

export default EmailInput;
