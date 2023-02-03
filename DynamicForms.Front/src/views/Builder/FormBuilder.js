import { Box, Text, Divider, Stack } from "@chakra-ui/react";
import { Droppable } from "@hello-pangea/dnd";
import React from "react";
import FormControl from "./controls/FormControl";
import controls from "variables/controls";

function FormBuilder({ controls, setControls, openSetup }) {
  const onDeleteControl = (id) => {
    let copy = [...controls];
    const controlIndex = copy.findIndex((el) => el.id === id);
    copy.splice(controlIndex, 1);
    setControls(copy);
  };

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
      <Divider></Divider>
      <Box pt="20px" bg="whiteAlpha.800" h={"90%"}>
        <Droppable droppableId="formBuilder">
          {(provided) => {
            return (
              <div
                style={{
                  minHeight: "80%",
                  width: "100%",
                  backgroundColor: "gray.200",
                  display: "flex",
                  justifyContent: "center",
                }}
                {...provided.droppableProps}
                ref={provided.innerRef}
              >
                <Stack direction={"column"} w="100%">
                  {controls.map((el, idx) => {
                    return (
                      <FormControl
                        control={el}
                        key={idx}
                        onDelete={onDeleteControl}
                        openSetup={openSetup}
                      />
                    );
                  })}
                  {provided.placeholder}
                </Stack>
              </div>
            );
          }}
        </Droppable>
      </Box>
    </Stack>
  );
}

export default FormBuilder;