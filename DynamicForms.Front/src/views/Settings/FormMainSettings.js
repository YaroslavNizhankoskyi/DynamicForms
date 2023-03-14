import { Divider, Heading, Input, VStack } from "@chakra-ui/react";
import React from "react";

function FormMainSettings() {
  return (
    <VStack gap={"4"}>
      <Heading color={"#41c7bf"}>Main Information</Heading>
      <Divider mb={"10px"}></Divider>
      <Input></Input>
      <Input></Input>
      <Input></Input>
    </VStack>
  );
}

export default FormMainSettings;
