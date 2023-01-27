import { Flex, Icon, Text } from "@chakra-ui/react";
import React from "react";

function Control({ control }) {
  return (
    <Flex
      gap={3}
      rounded={"lg"}
      bg={"gray.200"}
      justifyContent={"left"}
      alignItems={"center"}
      px={"6px"}
      h={"40px"}
    >
      <Icon h={"60%"} w={"20%"} as={control.icon}></Icon>
      <Text>{control.name}</Text>
    </Flex>
  );
}

export default Control;
