import React from "react";
import {
  Grid,
  Box,
  GridItem,
  Heading,
  Button,
  Center,
  SimpleGrid,
  Text,
  Link,
} from "@chakra-ui/react";
import { ChevronRightIcon } from "@chakra-ui/icons";
import { MdDynamicForm, MdOutlineShortcut } from "react-icons/md";
import { NavLink } from "react-router-dom";
import { v4 as uuidv4 } from "uuid";

function HomeHeaderNav() {
  const newFormId = uuidv4();

  return (
    <Grid
      templateRows="repeat(2, 1fr)"
      templateColumns="repeat(8, 1fr)"
      gap={4}
      h={200}
    >
      <GridItem
        rowSpan={2}
        colSpan={6}
        alignItems={"center"}
        bg="#FFDEE9"
        bgGradient="linear-gradient(0deg, #FFDEE9 0%, #B5FFFC 100%)"
        boxShadow="md"
        rounded="md"
      >
        <Box
          filter={"auto"}
          backdropBlur="8px"
          h={"100%"}
          p={2}
          alignItems={"center"}
        >
          <Center>
            <SimpleGrid columns={1} spacing={10}>
              <Heading size={"md"} textAlign={"center"}>
                Dynamic Forms Builder
              </Heading>
              <Text size={"xs"} textAlign={"center"}>
                Start building forms now!
              </Text>
              <Link
                textAlign={"center"}
                as={NavLink}
                to={`/form/${newFormId}/builder`}
              >
                <Button
                  leftIcon={<MdDynamicForm />}
                  variant="outline"
                  color="#4fd1c5"
                  bg="white"
                  colorScheme="#4fd1c5"
                  size={"lg"}
                >
                  Go to resource.
                </Button>
              </Link>
            </SimpleGrid>
          </Center>
        </Box>
      </GridItem>
      <GridItem rowSpan={1} colSpan={2}>
        <Box
          display="flex"
          textAlign="center"
          boxShadow="md"
          alignItems="center"
          justifyContent="center"
          p="10px"
          h={"100%"}
          borderRadius="lg"
          bgColor={"whiteAlpha.800"}
          _hover={{
            background: "gray.500",
            color: "white",
            transition: ".15s ease-in-out",
          }}
        >
          {" "}
          <MdOutlineShortcut />
          <Text margin={2} size="sm">
            View own forms
          </Text>
        </Box>
      </GridItem>
      <GridItem rowSpan={1} colSpan={2}>
        <Box
          display="flex"
          textAlign="center"
          boxShadow="md"
          alignItems="center"
          justifyContent="center"
          p="10px"
          h={"100%"}
          borderRadius="lg"
          bgColor={"whiteAlpha.800"}
          _hover={{
            background: "gray.500",
            color: "white",
            transition: ".15s ease-in-out",
          }}
        >
          <MdOutlineShortcut />
          <Text margin={2}>View public forms</Text>
        </Box>
      </GridItem>
    </Grid>
  );
}

export default HomeHeaderNav;
