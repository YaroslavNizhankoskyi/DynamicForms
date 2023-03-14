import {
  NumberInputField,
  NumberInput as ChakraNumberInput,
  NumberIncrementStepper,
  NumberInputStepper,
  NumberDecrementStepper,
} from "@chakra-ui/react";
import React from "react";

function NumberInput({ control, value, onChange, onBlur }) {
  const handleNumberChange = (value) => {
    onChange(control.id, parseInt(value));
  };

  return (
    <ChakraNumberInput
      value={value}
      allowMouseWheel
      onChange={handleNumberChange}
      onBlur={onBlur ?? (() => {})}
      name={control.id}
      {...control.inputConfig}
    >
      <NumberInputField />
      <NumberInputStepper>
        <NumberIncrementStepper />
        <NumberDecrementStepper />
      </NumberInputStepper>
    </ChakraNumberInput>
  );
}

export default NumberInput;
