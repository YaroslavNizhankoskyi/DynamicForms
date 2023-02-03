import { formAnatomy as parts } from "@chakra-ui/anatomy";
import { createMultiStyleConfigHelpers } from "@chakra-ui/styled-system";

const {
  definePartsStyle,
  defineMultiStyleConfig,
} = createMultiStyleConfigHelpers(parts.keys);

const variantControl = definePartsStyle({
  container: {
    border: "1px",
    borderColor: "gray.500",
    padding: "8px",
    borderRadius: "5px",
    _hover: {
      boxShadow: "md",
    },
  },
});

export const formControlTheme = {
  components: {
    Form: defineMultiStyleConfig({
      variants: { control: variantControl },
    }),
  },
};
