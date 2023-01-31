import { Box, Text, Divider, Stack } from "@chakra-ui/react";
import { DragDropContext, Droppable } from "@hello-pangea/dnd";
import React, { useState } from "react";
import controls from "variables/controls";

function FormBuilder({ controls }) {
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
      <Droppable droppableId="formBuilder">
        {(provided) => {
          return (
            <div
              style={{
                minHeight: "80%px",
                width: "100%",
                backgroundColor: "gray.200",
                display: "flex",
              }}
              {...provided.droppableProps}
              ref={provided.innerRef}
            >
              <Box>
                {controls.map((el, idx) => {
                  return <p key={idx}>{el}</p>;
                })}
                {provided.placeholder}
              </Box>
            </div>
          );
        }}
      </Droppable>
    </Stack>
  );
}

export default FormBuilder;
