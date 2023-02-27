import {
  NumberInputField,
  NumberInput as ChakraNumberInput,
  NumberIncrementStepper,
  NumberInputStepper,
  NumberDecrementStepper,
} from "@chakra-ui/react";
import React from "react";

function NumberInput({ control, formik }) {
  const handleNumberChange = (value) => {
    formik.setFieldValue(control.id, parseInt(value));
  };

  return (
    <ChakraNumberInput
      value={formik.values[control.id]}
      allowMouseWheel
      onChange={handleNumberChange}
      onBlur={formik?.handleBlur}
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
