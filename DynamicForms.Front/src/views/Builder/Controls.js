import { Box, Divider, SimpleGrid, Text, Stack } from "@chakra-ui/react";
import React from "react";
import Control from "./Controls/Control";
import controls from "variables/controls";

function Controls() {
  return (
    <Stack
      display={"flex"}
      columns={1}
      spacing={"3"}
      p="10px"
      pt="20px"
      direction={"column"}
      justifyItems={"center"}
      textAlign={"center"}
    >
      <Box>
        <Text fontSize={"22"} fontWeight={"bold"} color={"#4fd1c5"}>
          CONTROLS
        </Text>
      </Box>
      <Divider borderTop={"1px solid #a1a1a1"}></Divider>
      {controls.map((el) => (
        <Control control={el} key={el.type} />
      ))}
    </Stack>
  );
}

export default Controls;
