import React from "react";
import { Flex, TabPanel } from "@chakra-ui/react";

function SettingsPanel(props) {
  return (
    <TabPanel>
      <Flex
        py={"10px"}
        px={"10px"}
        h="600px"
        bg="white"
        rounded={"15px"}
        justifyContent={"center"}
      >
        {props.children}
      </Flex>
    </TabPanel>
  );
}

export default SettingsPanel;
