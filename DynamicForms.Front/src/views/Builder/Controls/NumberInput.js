import {
  NumberInputField,
  NumberInput as ChakraNumberInput,
  NumberIncrementStepper,
  NumberInputStepper,
  NumberDecrementStepper,
} from "@chakra-ui/react";
import React from "react";

function NumberInput() {
  return (
    <ChakraNumberInput allowMouseWheel variant={"control"}>
      <NumberInputField />
      <NumberInputStepper>
        <NumberIncrementStepper />
        <NumberDecrementStepper />
      </NumberInputStepper>
    </ChakraNumberInput>
  );
}

export default NumberInput;
