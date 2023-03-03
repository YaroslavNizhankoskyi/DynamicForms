import { HStack, Button, Box } from "@chakra-ui/react";
import NavImageLink from "components/Sidebar/NavImageLink";
import React from "react";
import { CreativeTimLogo } from "components/Icons/Icons";
import { FaRegEye } from "react-icons/fa";
import { useDispatch } from "react-redux";
import GenericNavbar from "components/Navbars/GenericNavbar";
import { updateUserForm, addUserForms } from "common/redux/stores/userForms";
import { MdSettings } from "react-icons/md";

function BuilderNavbar({ form, formExists }) {
  let views = ["builder", "preview", "settings"];
  let [selectedView] = views.filter((el) => location.pathname.includes(el));

  const dispatch = useDispatch();

  const handleOpenPreview = () => {
    const serializableControls = form.controls.map((el) => {
      return { ...el, icon: undefined, component: undefined };
    });

    const formCopy = { ...form, controls: serializableControls };

    if (formExists) {
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
          link={`/${form.id}/preview`}
          iconSize="25px"
        ></NavImageLink>
      </Box>
      <Box onClick={handleOpenPreview}>
        <NavImageLink
          logoText={"Settings"}
          logo={MdSettings}
          link={`/${form.id}/settings`}
          iconSize="25px"
        ></NavImageLink>
      </Box>
    </GenericNavbar>
  );
}

export default BuilderNavbar;
