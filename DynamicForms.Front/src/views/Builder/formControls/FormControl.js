import React, { useState, useRef, createElement } from "react";
import {
  Text,
  FormControl as ChakraControl,
  FormLabel,
  HStack,
  VStack,
  IconButton,
  Box,
  useDisclosure,
} from "@chakra-ui/react";
import { MdSettingsApplications, MdOutlineDeleteForever } from "react-icons/md";
import ConfigDrawer from "../drawer/ConfigDrawer";

function FormControl({ control, onDelete, value, onChange }) {
  const btnRef = useRef();
  const disclosure = useDisclosure();
  const [isFocused, setIsFocused] = useState(false);

  const handleOnBlur = (event) => {
    setTimeout(() => setIsFocused(false), 200);
  };
  return (
    <HStack p="10px" onFocus={() => setIsFocused(true)} onBlur={handleOnBlur}>
      <ChakraControl {...control.inputConfig}>
        <FormLabel>{control.name}</FormLabel>
        {createElement(control.component, { control, value, onChange })}
      </ChakraControl>
      <Box w={"33px"}>
        <VStack display={isFocused ? "inherit" : "none"}>
          <IconButton
            bg="blue.400"
            aria-label="Settigns"
            icon={<MdSettingsApplications size={"32px"} />}
            size={"sm"}
            rounded="6px"
            onClick={disclosure.onOpen}
            ref={btnRef}
          />
          <IconButton
            bg={"red.400"}
            aria-label="Delete"
            icon={<MdOutlineDeleteForever size={"32px"} />}
            size={"sm"}
            rounded={"6px"}
            onClick={(e) => onDelete(e, control.id)}
          />
        </VStack>
      </Box>
      <ConfigDrawer
        btnRef={btnRef}
        disclosure={disclosure}
        control={control}
      ></ConfigDrawer>
    </HStack>
  );
}

export default FormControl;
