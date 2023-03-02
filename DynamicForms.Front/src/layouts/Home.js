import React, { useState } from "react";
import Sidebar from "components/Sidebar";
import MainPanel from "./../components/Layout/MainPanel";
import { Portal, useDisclosure, Flex, Heading } from "@chakra-ui/react";
import Configurator from "components/Configurator/Configurator";
import Navbar from "components/Navbars/Navbar";
import PanelContent from "components/Layout/PanelContent";
import { isActiveNavbar } from "common/routing/routingHelper";
import HomeHeaderNav from "views/Home/HomeHeaderNav";
import PanelContainer from "components/Layout/PanelContainer";
import HomeStatistics from "views/Home/HomeStatistics";
import RecentForms from "views/Home/RecentForms";

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
      <MainPanel
        w={{
          base: "100%",
          xl: "calc(100% - 275px)",
        }}
      >
        <Portal>
          <Navbar onOpen={onOpen} logoText={"Dynamic Forms"} fixed={fixed} />
        </Portal>
        <PanelContent>
          <PanelContainer>
            <Flex flexDirection="column" pt={{ base: "120px", md: "75px" }}>
              <HomeHeaderNav />
            </Flex>
            <Flex
              flexDir={"column"}
              width={"auto"}
              minH={"100px"}
              mt={"25"}
              p={"10px"}
            >
              <RecentForms />
            </Flex>
            <Flex width={"auto"} mt={"25px"}>
              <HomeStatistics />
            </Flex>
          </PanelContainer>
        </PanelContent>
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
