import { NumberInputField } from "@chakra-ui/react";
import React from "react";

function NumberInput() {
  return (
    <NumberInput allowMouseWheel>
      <NumberInputField />
      <NumberInputStepper>
        <NumberIncrementStepper />
        <NumberDecrementStepper />
      </NumberInputStepper>
    </NumberInput>
  );
}

export default NumberInput;
