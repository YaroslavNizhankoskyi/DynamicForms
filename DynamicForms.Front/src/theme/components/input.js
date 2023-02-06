import { inputAnatomy } from "@chakra-ui/anatomy";
import { createMultiStyleConfigHelpers } from "@chakra-ui/react";

const { definePartsStyle, defineMultiStyleConfig } =
  createMultiStyleConfigHelpers(inputAnatomy.keys);

export const InputField = {
  background: "white",
  borderBottom: "1px solid",
  border: "2px",
  _hover: {
    borderColor: "#41c7bf",
    boxShadow: "base",
  },
  _active: {
    borderColor: "#41c7bf",
  },
};

const variantControl = definePartsStyle({
  field: InputField,
  addon: {
    backround: "#41c7bf",
    border: "0px solid",
    borderColor: "transparent",
    borderTopLeftRadius: "full",
    borderBottomLeftRadius: "full",
    color: "black",
  },
});

export const textInputTheme = {
  components: {
    Input: defineMultiStyleConfig({
      variants: { control: variantControl },
    }),
  },
};
