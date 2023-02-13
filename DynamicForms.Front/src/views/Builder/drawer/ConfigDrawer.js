import React from "react";
import {
  Drawer,
  DrawerBody,
  DrawerFooter,
  DrawerHeader,
  DrawerOverlay,
  DrawerContent,
  DrawerCloseButton,
  Input,
  Button,
  VStack,
} from "@chakra-ui/react";
import ConfigList from "./ConfigsList";
import { useFormik, validateYupSchema } from "formik";

function ConfigDrawer({ btnRef, disclosure, control }) {
  const { isOpen, onOpen, onClose } = disclosure;

  const formik = useFormik({
    initialValues: { ...control.inputConfig },
    onSubmit: (values) => {
      console.log(control);

      for (let key in values) {
        if (control.inputConfig[key]) {
          control.inputConfig[key] = values[key];
        }

        let validator = control.validation.validatorsData.find(
          (el) => el.type == key
        );

        if (validator) {
          validator.params = Array.isArray(values[key])
            ? values[key]
            : [values[key]];
        }
      }

      console.log(control);
    },
  });

  const onSave = (e) => {
    formik.handleSubmit(e);
    onClose(e);
  };

  return (
    <>
      <Drawer
        isOpen={isOpen}
        placement="right"
        onClose={onClose}
        finalFocusRef={btnRef}
      >
        <DrawerOverlay />
        <DrawerContent>
          <DrawerCloseButton />
          <DrawerHeader>Config control</DrawerHeader>

          <DrawerBody>
            <ConfigList control={control} formik={formik} />
          </DrawerBody>

          <DrawerFooter>
            <Button variant="outline" mr={3} onClick={onClose}>
              Cancel
            </Button>
            <Button onClick={onSave} colorScheme="blue">
              Save
            </Button>
          </DrawerFooter>
        </DrawerContent>
      </Drawer>
    </>
  );
}

export default ConfigDrawer;
