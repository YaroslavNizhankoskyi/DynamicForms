import {
  NumberInputField,
  NumberInput as ChakraNumberInput,
  NumberIncrementStepper,
  NumberInputStepper,
  NumberDecrementStepper,
} from "@chakra-ui/react";
import React from "react";

function NumberInput({ control }) {
  return (
    <ChakraNumberInput allowMouseWheel {...control.inputConfig}>
      <NumberInputField />
      <NumberInputStepper>
        <NumberIncrementStepper />
        <NumberDecrementStepper />
      </NumberInputStepper>
    </ChakraNumberInput>
  );
}

export default NumberInput;
