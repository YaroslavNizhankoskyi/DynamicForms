import React, { useState } from "react";
import { Grid, GridItem } from "@chakra-ui/react";
import Controls from "./Controls";
import FormBuilder from "./FormBuilder";
import BuilderNavbar from "./BuilderNavbar";
import MainPanel from "components/Layout/MainPanel";
import { DragDropContext } from "@hello-pangea/dnd";

function DynamicFormsBuilder() {
  let [controls, setControls] = useState([]);

  const handleOnDragEnd = (result) => {
    console.log(result);
    let items = Array.from(controls);
    items.push(result.draggableId);
    setControls(items);
  };

  return (
    <DragDropContext onDragEnd={handleOnDragEnd}>
      <Grid
        bg={"blackAlpha.200"}
        p={"10px"}
        templateRows={"repeat(8, 1fr)"}
        templateColumns={"repeat(6, 1fr)"}
        gap={4}
        h={"100vh"}
      >
        <GridItem
          rowSpan={1}
          colSpan={6}
          bg={"whiteAlpha.800"}
          rounded={"md"}
          display={"flex"}
        >
          <BuilderNavbar />
        </GridItem>
        <GridItem rowSpan={7} colSpan={1} bg={"whiteAlpha.800"} rounded={"md"}>
          <Controls />
        </GridItem>
        <GridItem rowSpan={7} colSpan={5} bg={"whiteAlpha.800"} rounded={"md"}>
          <FormBuilder controls={controls} />
        </GridItem>
      </Grid>
    </DragDropContext>
  );
}

export default DynamicFormsBuilder;
