import { tabsAnatomy } from "@chakra-ui/anatomy";
import { createMultiStyleConfigHelpers } from "@chakra-ui/react";
import { extendTheme } from "@chakra-ui/react";

const { definePartsStyle, defineMultiStyleConfig } =
  createMultiStyleConfigHelpers(tabsAnatomy.keys);

const baseStyle = definePartsStyle({
  // define the part you're going to style
  tab: {
    fontWeight: "semibold", // change the font weight
  },
  tabpanel: {
    fontFamily: "mono", // change the font family
  },
});

const settingsVariant = definePartsStyle((props) => {
  return {
    tab: {
      border: "2px solid",
      borderColor: "gray.300",
      borderWidth: "0.5px",
      bg: "#95e6e1",
      borderTopRadius: "lg",
      _selected: {
        bg: "#fff",
        color: "#41c7bf",
        borderBottom: "none",
        mb: "-2px",
      },
    },
    tablist: {
      borderColor: "inherit",
    },
    tabpanel: {
      border: "2px solid",
      borderTop: "none",
      borderColor: "inherit",
      borderBottomRadius: "lg",
    },
  };
});

const variants = {
  settings: settingsVariant,
};

const defaultProps = {
  size: "md",
  variant: "settings",
  colorScheme: "#95e6e1",
};

const tabsConfig = defineMultiStyleConfig({
  baseStyle,
  variants,
  defaultProps,
});

export const tabsTheme = extendTheme({
  components: {
    Tabs: tabsConfig,
  },
});
