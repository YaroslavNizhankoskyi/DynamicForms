import React from "react";
// Chakra imports
import {
  Box,
  Flex,
  Button,
  FormControl,
  FormLabel,
  Heading,
  Input,
  Link,
  Switch,
  Text,
  useColorModeValue,
} from "@chakra-ui/react";
// Assets
import signInImage from "assets/img/signInImage.png";
import { useFormik } from "formik";
import * as Yup from "yup";
import axios from "axios";
import { setAuthToken } from "common/auth/headers/authHeader";

function SignIn() {
  // Chakra color mode
  const titleColor = useColorModeValue("teal.300", "teal.200");
  const textColor = useColorModeValue("gray.400", "white");

  const url = process.env.REACT_APP_APIUrl + "/auth/login";
  const errorBorder = "red.300";

  const signInSchema = Yup.object().shape({
    email: Yup.string()
      .email()
      .required("Email is required")
      .min(5, "Invalid email"),
    password: Yup.string().required("Password is required"),
  });

  const fk = useFormik({
    //development only values
    initialValues: {
      email: "seed2.df@gmail.com",
      password: "SeedPass1*",
    },
    validationSchema: signInSchema,
    onSubmit: (values) => {
      axios.post(url, values).then((response) => {
        if (response.data.token) {
          localStorage.setItem("userData", JSON.stringify(response.data));
          localStorage.setItem("token", response.data.token);
          setAuthToken(response.data.token);
          window.location.replace("/");
        } else {
          alert("Login failed");
        }
      });
    },
  });

  return (
    <Flex position="relative" mb="40px">
      <Flex
        h={{ sm: "initial", md: "75vh", lg: "85vh" }}
        w="100%"
        maxW="1044px"
        mx="auto"
        justifyContent="space-between"
        mb="30px"
        pt={{ sm: "100px", md: "0px" }}
      >
        <Flex
          alignItems="center"
          justifyContent="start"
          style={{ userSelect: "none" }}
          w={{ base: "100%", md: "50%", lg: "42%" }}
        >
          <Flex
            direction="column"
            w="100%"
            background="transparent"
            p="48px"
            mt={{ md: "150px", lg: "80px" }}
          >
            <Heading color={titleColor} fontSize="32px" mb="10px">
              Welcome Back
            </Heading>
            <Text
              mb="36px"
              ms="4px"
              color={textColor}
              fontWeight="bold"
              fontSize="14px"
            >
              Enter your email and password to sign in
            </Text>
            <FormControl isInvalid={fk.errors.email && fk.touched.email}>
              <FormLabel ms="4px" fontSize="sm" fontWeight="normal">
                Email
              </FormLabel>
              <Input
                borderRadius="15px"
                mb="24px"
                fontSize="sm"
                name="email"
                type="text"
                placeholder="Your email adress"
                errorBorderColor={errorBorder}
                value={fk.values.email}
                onChange={fk.handleChange}
                size="lg"
              />
              <p>{fk.errors.email}</p>
            </FormControl>
            <FormControl isInvalid={fk.errors.password && fk.touched.password}>
              <FormLabel ms="4px" fontSize="sm" fontWeight="normal">
                Password
              </FormLabel>
              <Input
                borderRadius="15px"
                mb="36px"
                fontSize="sm"
                type="password"
                name="password"
                placeholder="Your password"
                value={fk.values.password}
                onChange={fk.handleChange}
                errorBorderColor={errorBorder}
                size="lg"
              />
              <FormControl display="flex" alignItems="center">
                <Switch id="remember-login" colorScheme="teal" me="10px" />
                <FormLabel
                  htmlFor="remember-login"
                  mb="0"
                  ms="1"
                  fontWeight="normal"
                >
                  Remember me
                </FormLabel>
              </FormControl>
              <Button
                onClick={fk.handleSubmit}
                //disabled={!(fk.dirty && fk.isValid)}
                disabled={!fk.isValid}
                fontSize="10px"
                type="submit"
                bg="teal.300"
                w="100%"
                h="45"
                mb="20px"
                color="white"
                mt="20px"
                _hover={{
                  bg: "teal.200",
                }}
                _active={{
                  bg: "teal.400",
                }}
              >
                SIGN IN
              </Button>
            </FormControl>
            <Flex
              flexDirection="column"
              justifyContent="center"
              alignItems="center"
              maxW="100%"
              mt="0px"
            >
              <Text color={textColor} fontWeight="medium">
                Don't have an account?
                <Link color={titleColor} as="span" ms="5px" fontWeight="bold">
                  Sign Up
                </Link>
              </Text>
            </Flex>
          </Flex>
        </Flex>
        <Box
          display={{ base: "none", md: "block" }}
          overflowX="hidden"
          h="100%"
          w="40vw"
          position="absolute"
          right="0px"
        >
          <Box
            bgImage={signInImage}
            w="100%"
            h="100%"
            bgSize="cover"
            bgPosition="50%"
            position="absolute"
            borderBottomLeftRadius="20px"
          ></Box>
        </Box>
      </Flex>
    </Flex>
  );
}

export default SignIn;
