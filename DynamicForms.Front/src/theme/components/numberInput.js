import { numberInputAnatomy as parts } from "@chakra-ui/anatomy";
import { createMultiStyleConfigHelpers } from "@chakra-ui/styled-system";
import { InputField } from "./input";

const { definePartsStyle, defineMultiStyleConfig } =
  createMultiStyleConfigHelpers(parts.keys);

const variantControl = definePartsStyle({
  field: {
    isValidCharacter: "/^d*.?d*$/",
    ...InputField,
  },
});

export const numberInputTheme = {
  components: {
    NumberInput: defineMultiStyleConfig({
      variants: { control: variantControl },
    }),
  },
};
