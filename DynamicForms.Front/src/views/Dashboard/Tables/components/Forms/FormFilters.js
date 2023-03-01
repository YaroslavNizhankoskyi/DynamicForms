import { Flex, HStack } from "@chakra-ui/react";
import React from "react";

function FormFilters({ filters, onFilterChange }) {
  return (
    <Flex width={"100%"} shadow={"xl"} rounded="md" bg="gray.50" gap={4}>
      <HStack>
        <Flex width={"30%"}></Flex>
        <Flex width={"30%"}></Flex>
        <Flex width={"30%"}></Flex>
      </HStack>
    </Flex>
  );
}

export default FormFilters;
