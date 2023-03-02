// Chakra imports
import { Flex, Button, Text } from "@chakra-ui/react";
import React from "react";
import { useSelector } from "react-redux";
import FormsTable from "./components/Forms/FormsTable";
import FormFilters from "./components/Forms/FormFilters";
import TableFormRow from "components/Tables/TableFormRow";
import { MdDynamicForm } from "react-icons/md";
import { formatIsoDate } from "common/helpers/isoDateFormatter";

function Forms() {
  const forms = useSelector((state) => state.userForms);

  return (
    <Flex direction="column" pt={{ base: "120px", md: "75px" }} minH={"1000px"}>
      <Flex mb="20px" right={"0px"} left={"0px"} float={"right"} minH={"100px"}>
        <FormFilters></FormFilters>
      </Flex>
      <Flex width={"auto"} p={"10px"}>
        <FormsTable
          title={"Forms Table"}
          captions={[
            "Name",
            "Domain",
            "Status",
            "Created",
            "Modified",
            "Actions",
          ]}
          forms={forms}
        >
          {forms.map((form) => {
            return (
              <TableFormRow
                key={form.id}
                id={form.id}
                name={form.name}
                logo={MdDynamicForm}
                domain={form.domain}
                status={form.status}
                created={formatIsoDate(form.created)}
                modified={formatIsoDate(form.modified)}
              >
                <Button p="0px" bg="transparent" variant="no-hover">
                  <Text
                    fontSize="md"
                    color="gray.400"
                    fontWeight="bold"
                    cursor="pointer"
                  >
                    Edit
                  </Text>
                </Button>
              </TableFormRow>
            );
          })}
        </FormsTable>
      </Flex>
    </Flex>
  );
}

export default Forms;
