import {
  Flex,
  VStack,
  Tabs,
  TabList,
  Tab,
  TabPanels,
  Text,
} from "@chakra-ui/react";
import React from "react";
import FormMainSettings from "./FormMainSettings";
import SettingsPanel from "./SettingsPanel";

function FormSettings() {
  return (
    <Flex justifyContent={"center"}>
      <VStack mt={"30px"} mx="100px">
        <Flex>
          <Tabs isFitted w={"800px"}>
            <TabList>
              <Tab>Main</Tab>
              <Tab>Effects</Tab>
              <Tab>Share</Tab>
            </TabList>

            <TabPanels>
              <SettingsPanel>
                <FormMainSettings />
              </SettingsPanel>
              <SettingsPanel>
                <Text>2</Text>
              </SettingsPanel>
              <SettingsPanel>
                <Text>3</Text>
              </SettingsPanel>
            </TabPanels>
          </Tabs>
        </Flex>
      </VStack>
    </Flex>
  );
}

export default FormSettings;
