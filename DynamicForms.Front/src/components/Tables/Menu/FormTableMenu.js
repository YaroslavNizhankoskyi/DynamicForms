import React from "react";
import {
  Menu,
  MenuButton,
  MenuList,
  MenuItem,
  IconButton,
  useDisclosure,
} from "@chakra-ui/react";
import { FaRegEye } from "react-icons/fa";
import { MdOutlineModeEdit } from "react-icons/md";
import { HamburgerIcon } from "@chakra-ui/icons";
import { NavLink } from "react-router-dom/cjs/react-router-dom.min";
import { DeleteIcon } from "@chakra-ui/icons";
import DeleteModal from "components/Modals/DeleteModal";
import { useDispatch } from "react-redux";
import { removeUserForm } from "common/redux/stores/userForms";

function FormTableMenu({ formId }) {
  const disclosure = useDisclosure();
  const dispatcher = useDispatch();

  const handleDelete = () => {
    dispatcher(removeUserForm(id));
  };
  return (
    <Menu>
      <MenuButton
        as={IconButton}
        aria-label="Options"
        icon={<HamburgerIcon />}
        variant="outline"
      />
      <MenuList>
        <MenuItem
          as={NavLink}
          to={`${formId}/builder`}
          icon={<MdOutlineModeEdit />}
        >
          Edit
        </MenuItem>
        <MenuItem as={NavLink} to={`${formId}/preview`} icon={<FaRegEye />}>
          View
        </MenuItem>
        <MenuItem onClick={disclosure.onOpen} icon={<DeleteIcon />}>
          Delete
        </MenuItem>
        <DeleteModal
          onDelete={handleDelete}
          name={"form"}
          disclosure={disclosure}
        />
      </MenuList>
    </Menu>
  );
}

export default FormTableMenu;
