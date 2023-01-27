import { Box, Text, Divider, Stack } from "@chakra-ui/react";
import React from "react";

function FormBuilder() {
  return (
    <Stack
      px={"30px"}
      pt="20px"
      justifyContent={"start"}
      h={"100%"}
      alignContent={"start"}
    >
      <Text
        fontSize={"22"}
        fontWeight={"bold"}
        textAlign={"center"}
        color="#4fd1c5"
      >
        FORM
      </Text>
      <Divider borderTop={"1px solid #a1a1a1"}></Divider>
      <Box display={"flex"} minH={"80%"} w={"100%"} bg={"gray.200"}>
        {" "}
      </Box>
    </Stack>
  );
}

export default FormBuilder;
