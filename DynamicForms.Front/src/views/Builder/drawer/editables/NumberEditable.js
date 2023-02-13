import React from "react";
import { NumberInput, NumberInputField } from "@chakra-ui/react";

function NumberEditable(props) {
  //chakra numberInput onChange returns event and then number value
  //probably multithreading issue

  return (
    <NumberInput {...props}>
      <NumberInputField onChange={(e) => props.onChange(e)} />
    </NumberInput>
  );
}

export default NumberEditable;
