import { Flex, Icon, Text } from "@chakra-ui/react";
import { Draggable } from "@hello-pangea/dnd";
import React from "react";

function ControlIcon({ control, index }) {
  return (
    <Draggable draggableId={control.id} index={index}>
      {(provided) => {
        return (
          <div
            {...provided.draggableProps}
            ref={provided.innerRef}
            {...provided.dragHandleProps}
          >
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
          </div>
        );
      }}
    </Draggable>
  );
}

export default ControlIcon;
