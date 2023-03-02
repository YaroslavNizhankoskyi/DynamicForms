import { Flex, HStack, Select } from "@chakra-ui/react";
import React from "react";

function FormFilters({ filters, onFilterChange }) {
  return (
    <Flex
      boxShadow={"md"}
      rounded="md"
      bg="#fcfcfc"
      gap={4}
      w={"100%"}
      p={"10px"}
    >
      <HStack width={"inherit"}>
        <Flex width={"30%"}>
          <Select
            variant={"outline"}
            placeholder="Filters"
            bg="#A0AEC0"
            color={"white"}
            fontWeight={"bold"}
            focusBorderColor="black"
          />
        </Flex>
        <Flex width={"30%"}></Flex>
        <Flex width={"30%"}></Flex>
      </HStack>
    </Flex>
  );
}

export default FormFilters;
