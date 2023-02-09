import React from "react";
import { Input } from "@chakra-ui/react";

function EmailInput({ control }) {
  return <Input {...control.inputConfig} type="email"></Input>;
}

export default EmailInput;
