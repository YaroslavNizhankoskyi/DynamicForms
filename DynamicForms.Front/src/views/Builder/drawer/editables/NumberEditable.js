import React from "react";
import { NumberInput, NumberInputField } from "@chakra-ui/react";

function NumberEditable(props) {
  return (
    <NumberInput {...props}>
      <NumberInputField onChange={(e) => props.onChange(e)} />
    </NumberInput>
  );
}

export default NumberEditable;
