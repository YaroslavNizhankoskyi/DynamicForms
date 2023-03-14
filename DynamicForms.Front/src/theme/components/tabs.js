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
      borderColor: "transparent",
      bg: "#41c7bf",
      borderTopRadius: "lg",
      borderBottom: "none",
      _selected: {
        bg: "#fff",
        color: "#41c7bf",
        borderColor: "inherit",
        borderBottom: "none",
        mb: "-2px",
      },
    },
    tablist: {
      borderBottom: "2x solid",
      borderColor: "inherit",
    },
    tabpanel: {
      border: "2px solid",
      borderColor: "inherit",
      borderBottomRadius: "lg",
      borderTopRightRadius: "lg",
    },
  };
});

const variants = {
  settings: settingsVariant,
};

const defaultProps = {
  size: "md",
  variant: "settings",
  colorScheme: "#41c7bf",
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
