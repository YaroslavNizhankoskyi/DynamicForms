import React from "react";
import { Box } from "@chakra-ui/react";
import "theme/css/scrollbar.css";

function FormViewVariant(props) {
  return (
    <Box
      backgroundClip={"content-box"}
      minW={"300px"}
      w={props.width}
      h="90%"
      padding="30px"
      borderRadius={"10px"}
      boxShadow={"inset 0 0 0 30px #3b3a3a"}
      backgroundColor={"#d3dbdd"}
    >
      <Box
        w="100%"
        h="100%"
        overflowY={"scroll"}
        borderRadius={"10px"}
        className="hideScroll"
      >
        {props.children}
      </Box>
    </Box>
  );
}

export default FormViewVariant;
