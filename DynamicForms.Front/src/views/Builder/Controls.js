import { Box, Divider, SimpleGrid, Text, Stack } from "@chakra-ui/react";
import React from "react";
import ControlIcon from "./Controls/ControlIcon";
import controls from "variables/controls";
import { DragDropContext, Droppable } from "@hello-pangea/dnd";

function Controls() {
  return (
    <Droppable droppableId="controls">
      {(provided) => {
        return (
          <div {...provided.droppableProps} ref={provided.innerRef}>
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
              {controls.map((el, idx) => (
                <ControlIcon key={el.id} index={idx} control={el} />
              ))}
              {provided.placeholder}
            </Stack>
          </div>
        );
      }}
    </Droppable>
  );
}

export default Controls;
