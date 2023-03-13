import { getRoutesFor } from "common/routing/routingHelper";
import React, { useState, useEffect } from "react";
import { Switch, Redirect } from "react-router-dom";
import { routes } from "routes.js";
import { useParams } from "react-router-dom";
import BuilderNavbar from "views/Builder/BuilderNavbar";
import { useDispatch, useSelector } from "react-redux";
import { addOrUpdateForm } from "common/redux/stores/userForms";
import { refillFormData } from "common/helpers/formHelpers";

function Form() {
  const dispatch = useDispatch();
  const { formId } = useParams();

  const initialForm = {
    id: formId,
    controls: [],
    name: "unset",
    domain: "unset",
    created: new Date(),
    modified: new Date(),
    status: "unsaved",
  };

  const [form, setForm] = useState(initialForm);

  const getChosenPage = () => {
    const pages = ["builder", "preview", "settings"];
    let includingPage = "";
    pages.forEach((page) => {
      if (location.pathname.includes(page)) includingPage = page;
    });
    return includingPage;
  };

  const activePage = getChosenPage();

  useEffect(() => {
    const intervalId = setInterval(() => {
      if (activePage == "builder" || activePage == "settings") {
        dispatch(addOrUpdateForm(structuredClone(form)));
      }
    }, 10000);

    return () => {
      clearInterval(intervalId);
    };
  }, []);

  let existingForm = useSelector((state) =>
    state.userForms.find((el) => el.id == form.id)
  );

  useEffect(() => {
    if (existingForm) {
      const filledForm = refillFormData(existingForm);
      setForm(filledForm);
    }
  }, []);

  return (
    <>
      <BuilderNavbar
        form={form}
        setForm={setForm}
        formExists={existingForm && true}
      />
      <Switch>
        {getRoutesFor(routes, `/form/${form.id}`, { form, setForm })}
        <Redirect from="/admin" to="/home" />
      </Switch>
    </>
  );
}

export default Form;
