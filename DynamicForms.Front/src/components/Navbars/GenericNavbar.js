import React from "react";
import { HStack, Box } from "@chakra-ui/react";

function GenericNavbar(props) {
  return (
    <Box
      h={"100px"}
      w="100%"
      bg={"whiteAlpha.800"}
      rounded={"md"}
      display={"flex"}
      {...props}
    >
      <Box
        mx="auto"
        display="flex"
        w="100%"
        px="20px"
        alignItems={"center"}
        {...props}
      >
        {props.children}
      </Box>
    </Box>
  );
}

export default GenericNavbar;
