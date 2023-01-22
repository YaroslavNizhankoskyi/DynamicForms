import React, { useState } from "react";
import Sidebar from "components/Sidebar";
import MainPanel from "./../components/Layout/MainPanel";
import { Portal, useDisclosure } from "@chakra-ui/react";
import Configurator from "components/Configurator/Configurator";
import Navbar from "components/Navbars/Navbar";
import PanelContent from "components/Layout/PanelContent";
import { isActiveNavbar } from "common/routing/routingHelper";

function Home() {
  const [sidebarVariant, setSidebarVariant] = useState("opaque");
  const [fixed, setFixed] = useState(false);
  const { isOpen, onOpen, onClose } = useDisclosure();
  return (
    <>
      <Sidebar
        logoText={"Dynamic Forms"}
        display="none"
        sidebarVariant={sidebarVariant}
      />
      <MainPanel>
        <Portal>
          <Navbar onOpen={onOpen} logoText={"Dynamic Forms"} fixed={fixed} />
        </Portal>
        <PanelContent></PanelContent>
        <Configurator
          secondary={isActiveNavbar()}
          isOpen={isOpen}
          onClose={onClose}
          isChecked={fixed}
          onSwitch={(value) => {
            setFixed(value);
          }}
          onOpaque={() => setSidebarVariant("opaque")}
          onTransparent={() => setSidebarVariant("transparent")}
        />
      </MainPanel>
    </>
  );
}

export default Home;
