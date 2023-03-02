import {
  Badge,
  Flex,
  Icon,
  Td,
  Text,
  Tr,
  useColorModeValue,
} from "@chakra-ui/react";
import React from "react";

function RecentFormsRow(props) {
  const { logo, name, status, modified } = props;
  const textColor = useColorModeValue("gray.700", "white");
  const bgStatus = useColorModeValue("gray.400", "#1a202c");
  const colorStatus = useColorModeValue("white", "gray.400");
  return (
    <Tr>
      <Td minWidth={{ sm: "250px" }} pl="0px">
        <Flex align="center" py="5px" minWidth="100%" flexWrap="nowrap">
          <Icon
            as={logo}
            borderRadius="12px"
            color="blue.300"
            me="18px"
            boxSize={"35px"}
          />
          <Flex direction="column">
            <Text
              fontSize="md"
              color={textColor}
              fontWeight="bold"
              minWidth="100%"
            >
              {name}
            </Text>
          </Flex>
        </Flex>
      </Td>
      <Td>
        <Badge
          bg={status === "Online" ? "green.400" : bgStatus}
          color={status === "Online" ? "white" : colorStatus}
          fontSize="16px"
          p="3px 10px"
          borderRadius="8px"
        >
          {status}
        </Badge>
      </Td>
      <Td>
        <Text fontSize="md" color={textColor} fontWeight="bold" pb=".5rem">
          {modified}
        </Text>
      </Td>
      <Td>{props.children}</Td>
    </Tr>
  );
}

export default RecentFormsRow;
