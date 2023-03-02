import React from "react";
import { Grid } from "@chakra-ui/react";
import ActiveUsers from "views/Dashboard/Dashboard/components/ActiveUsers";
import SalesOverview from "views/Dashboard/Dashboard/components/SalesOverview";
import BarChart from "components/Charts/BarChart";
import LineChart from "components/Charts/LineChart";

function HomeStatistics() {
  return (
    <Grid
      templateColumns={{ sm: "1fr", lg: "1.3fr 1.7fr" }}
      templateRows={{ sm: "repeat(2, 1fr)", lg: "1fr" }}
      gap="24px"
      mb={{ lg: "26px" }}
      left="0"
      width={"100%"}
    >
      <ActiveUsers
        title={"Active Users"}
        percentage={23}
        chart={<BarChart />}
      />
      <SalesOverview
        title={"Sales Overview"}
        percentage={5}
        chart={<LineChart />}
      />
    </Grid>
  );
}

export default HomeStatistics;
