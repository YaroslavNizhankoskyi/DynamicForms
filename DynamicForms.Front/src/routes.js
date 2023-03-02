// import
import Dashboard from "views/Dashboard/Dashboard";
import Billing from "views/Dashboard/Billing";
import Profile from "views/Dashboard/Profile";
import SignIn from "views/Auth/SignIn.js";
import SignUp from "views/Auth/SignUp.js";
import Auth from "layouts/Auth.js";
import Admin from "layouts/Admin.js";
import SignOut from "views/Auth/SignOut";
import { MdLogout, MdDynamicForm } from "react-icons/md";

import {
  HomeIcon,
  StatsIcon,
  CreditIcon,
  PersonIcon,
  DocumentIcon,
  RocketIcon,
  SupportIcon,
} from "components/Icons/Icons";
import Home from "layouts/Home";
import Guards from "common/models/Guards";
import DynamicFormsBuilder from "views/Builder";
import Preview from "views/Preview";
import Forms from "views/Dashboard/Tables";
import Form from "layouts/Form";

export const routes = [
  {
    path: "/admin",
    name: "Admin",
    guard: Guards.NONE,
    component: Admin,
    children: [
      {
        path: "/admin/dashboard",
        name: "Dashboard",
        icon: <HomeIcon color="inherit" />,
        component: Dashboard,
        guard: Guards.NONE,
      },
      {
        path: "/admin/forms",
        name: "Forms",
        icon: <StatsIcon color="inherit" />,
        component: Forms,
        guard: Guards.NONE,
      },
      {
        path: "/admin/billing",
        name: "Billing",
        icon: <CreditIcon color="inherit" />,
        component: Billing,
        guard: Guards.NONE,
      },
    ],
  },
  {
    path: "/account",
    name: "Account",
    component: Profile,
    guard: Guards.NONE,
    children: [
      {
        path: "/account/profile",
        name: "Profile",
        icon: <PersonIcon color="inherit" />,
        secondaryNavbar: true,
        guard: Guards.NONE,
        component: Profile,
      },
    ],
  },
  {
    path: "/auth",
    name: "Auth",
    component: Auth,
    guard: Guards.NONE,
    children: [
      {
        path: "/auth/signin",
        name: "Sign In",
        icon: <DocumentIcon color="inherit" />,
        component: SignIn,
        guard: Guards.NONE,
      },
      {
        path: "/auth/signup",
        name: "Sign Up",
        icon: <RocketIcon color="inherit" />,
        secondaryNavbar: true,
        guard: Guards.NONE,
        component: SignUp,
      },
    ],
  },
  {
    path: "/form",
    name: "Form",
    component: Form,
    guard: Guards.NONE,
    children: [
      {
        path: "/form/:formId/builder",
        name: "Form Builder",
        component: DynamicFormsBuilder,
        guard: Guards.NONE,
      },
      {
        path: "/form/:formId/preview",
        name: "Preview",
        component: Preview,
        guard: Guards.NONE,
      },
    ],
  },
  {
    path: "/",
    name: "Home",
    component: Home,
    guard: Guards.NONE,
  },
];

export const sidebar = [
  {
    category: "Admin",
    guard: Guards.NONE,
    children: [
      {
        path: "/admin/dashboard",
        name: "Dashboard",
        icon: <HomeIcon color="inherit" />,
        component: Dashboard,
        guard: Guards.NONE,
      },
      {
        path: "/admin/forms",
        name: "Forms",
        icon: <StatsIcon color="inherit" />,
        component: Forms,
        guard: Guards.NONE,
      },
      {
        path: "/admin/billing",
        name: "Billing",
        icon: <CreditIcon color="inherit" />,
        component: Billing,
        guard: Guards.NONE,
      },
    ],
  },
  {
    category: "Account",
    guard: Guards.NONE,
    children: [
      {
        path: "/account/profile",
        name: "Profile",
        icon: <PersonIcon color="inherit" />,
        secondaryNavbar: true,
        component: Profile,
        guard: Guards.NONE,
      },
    ],
  },
  {
    category: "Sign",
    guard: Guards.NONE,
    children: [
      {
        path: "/auth/signin",
        name: "Sign In",
        icon: <DocumentIcon color="inherit" />,
        guard: Guards.NONE,
        component: SignIn,
      },
      {
        path: "/auth/signup",
        name: "Sign Up",
        icon: <RocketIcon color="inherit" />,
        secondaryNavbar: true,
        guard: Guards.NONE,
        component: SignUp,
      },
      {
        name: "Sign Out",
        icon: <MdLogout color="inherit" />,
        secondaryNavbar: true,
        guard: Guards.NONE,
        onClick: SignOut,
      },
    ],
  },
];
