import { HStack, Button, Box } from "@chakra-ui/react";
import NavImageLink from "components/Sidebar/NavImageLink";
import React from "react";
import { CreativeTimLogo } from "components/Icons/Icons";
import { FaRegEye } from "react-icons/fa";
import { useParams } from "react-router-dom";
import { useDispatch } from "react-redux";
import { addUserForms, resetUserForms } from "common/redux/stores/userForms";

function BuilderNavbar({ controls }) {
  const { formId } = useParams();
  const dispatch = useDispatch();

  const handleOpenPreview = () => {
    dispatch(resetUserForms());

    const serializableControls = controls.map((el) => {
      return { ...el, icon: undefined, component: undefined };
    });

    const form = { id: formId, controls: serializableControls };

    dispatch(addUserForms(form));
  };

  return (
    <HStack
      col={8}
      spacing={10}
      justifyContent={"left"}
      alignItems={"center"}
      mx="auto"
      display="flex"
      w="100%"
      px="20px"
    >
      <NavImageLink
        logoText={"Home"}
        logo={CreativeTimLogo}
        link="/home"
      ></NavImageLink>
      <Box onClick={handleOpenPreview}>
        <NavImageLink
          logoText={"Preview Form"}
          logo={FaRegEye}
          link={`/${formId}/preview`}
          iconSize="25px"
        ></NavImageLink>
      </Box>
    </HStack>
  );
}

export default BuilderNavbar;
