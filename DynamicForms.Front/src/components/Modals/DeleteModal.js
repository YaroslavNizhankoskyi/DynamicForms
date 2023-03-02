import React from "react";
import { useDisclosure } from "@chakra-ui/react";
import {
  Modal,
  ModalOverlay,
  ModalContent,
  ModalHeader,
  ModalFooter,
  ModalBody,
  ModalCloseButton,
  Button,
} from "@chakra-ui/react";

function DeleteModal({ onDelete, name, disclosure }) {
  const handleDelete = (e) => {
    onDelete();
    disclosure.onClose();
  };

  return (
    <Modal onClose={disclosure.onClose} size={"xs"} isOpen={disclosure.isOpen}>
      <ModalOverlay />
      <ModalContent>
        <ModalHeader>Are you sure you want to delete {name}?</ModalHeader>
        <ModalCloseButton />
        <ModalBody></ModalBody>
        <ModalFooter>
          <Button onClick={(e) => handleDelete(e)}>Delete</Button>
          <Button onClick={disclosure.onClose}>Cancel</Button>
        </ModalFooter>
      </ModalContent>
    </Modal>
  );
}

export default DeleteModal;
