import { HStack, Button, Box } from "@chakra-ui/react";
import NavImageLink from "components/Sidebar/NavImageLink";
import React from "react";
import { CreativeTimLogo } from "components/Icons/Icons";
import { FaRegEye } from "react-icons/fa";
import { useParams } from "react-router-dom";
import { useDispatch } from "react-redux";
import GenericNavbar from "components/Navbars/GenericNavbar";
import { useSelector } from "react-redux";
import { updateUserForm, addUserForms } from "common/redux/stores/userForms";

function BuilderNavbar({ form }) {
  const { formId } = useParams();
  const dispatch = useDispatch();

  let existingForm = useSelector((state) =>
    state.userForms.forms.find((el) => el.id == formId)
  );

  const handleOpenPreview = () => {
    const serializableControls = form.controls.map((el) => {
      return { ...el, icon: undefined, component: undefined };
    });

    const formCopy = { id: formId, controls: serializableControls };

    if (existingForm) {
      dispatch(updateUserForm(formCopy));
    } else {
      dispatch(addUserForms(formCopy));
    }
  };

  return (
    <GenericNavbar gap={"20px"}>
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
    </GenericNavbar>
  );
}

export default BuilderNavbar;
