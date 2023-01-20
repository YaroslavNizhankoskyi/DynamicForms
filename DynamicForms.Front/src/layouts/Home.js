import React, { useState } from "react";
import Sidebar from "components/Sidebar";
import MainPanel from "./../components/Layout/MainPanel";

function Home() {
  const [sidebarVariant, setSidebarVariant] = useState("opaque");

  return (
    <>
      <Sidebar
        logoText={"Dynamic Forms"}
        display="none"
        sidebarVariant={sidebarVariant}
      />
      <MainPanel></MainPanel>
    </>
  );
}

export default Home;
