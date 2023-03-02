import React from "react";
import FormsTable from "views/Dashboard/Tables/components/Forms/FormsTable";
import { Button, Text } from "@chakra-ui/react";
import { useSelector } from "react-redux";
import { compareDesc } from "date-fns";
import RecentFormsRow from "components/Tables/RecentFormsRow";
import { MdDynamicForm } from "react-icons/md";
import { formatIsoDate } from "common/helpers/isoDateFormatter";

function RecentForms() {
  const forms = useSelector((store) => {
    return [...store.userForms]
      .sort((a, b) => {
        return compareDesc(new Date(a.modified), new Date(b.modified));
      })
      .slice(0, 3);
  });

  return (
    <FormsTable
      title={"Recent Forms"}
      captions={["Name", "Status", "Modified", "Actions"]}
      forms={forms}
    >
      {forms.map((form) => {
        return (
          <RecentFormsRow
            name={form.name}
            logo={MdDynamicForm}
            status={form.status}
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
          </RecentFormsRow>
        );
      })}
    </FormsTable>
  );
}

export default RecentForms;
