import {
  NumberInputField,
  NumberInput as ChakraNumberInput,
  NumberIncrementStepper,
  NumberInputStepper,
  NumberDecrementStepper,
} from "@chakra-ui/react";
import React from "react";

function NumberInput({ control, formik }) {
  return (
    <ChakraNumberInput allowMouseWheel {...control.inputConfig}>
      <NumberInputField
        onChange={formik?.handleChange}
        onBlur={formik?.handleBlur}
        name={control.id}
        value={formik.values[control.id]}
      />
      <NumberInputStepper>
        <NumberIncrementStepper />
        <NumberDecrementStepper />
      </NumberInputStepper>
    </ChakraNumberInput>
  );
}

export default NumberInput;
