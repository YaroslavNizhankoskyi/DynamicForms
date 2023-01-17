// import
import Dashboard from "views/Dashboard/Dashboard";
import Tables from "views/Dashboard/Tables";
import Billing from "views/Dashboard/Billing";
import Profile from "views/Dashboard/Profile";
import SignIn from "views/Auth/SignIn.js";
import SignUp from "views/Auth/SignUp.js";
import Auth from "layouts/Auth.js";
import Admin from "layouts/Admin.js";

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

export const routes = [
  {
    path: "/admin",
    name: "Admin",
    component: Admin,
    children: [
      {
        path: "/admin/dashboard",
        name: "Dashboard",
        icon: <HomeIcon color="inherit" />,
        component: Dashboard,
      },
      {
        path: "/admin/tables",
        name: "Tables",
        icon: <StatsIcon color="inherit" />,
        component: Tables,
      },
      {
        path: "/admin/billing",
        name: "Billing",
        icon: <CreditIcon color="inherit" />,
        component: Billing,
      },
    ],
  },
  {
    path: "/account",
    name: "Account",
    component: Profile,
    children: [
      {
        path: "/account/profile",
        name: "Profile",
        icon: <PersonIcon color="inherit" />,
        secondaryNavbar: true,
        component: Profile,
      },
    ],
  },
  {
    path: "/auth",
    name: "Auth",
    component: Auth,
    children: [
      {
        path: "/auth/signin",
        name: "Sign In",
        icon: <DocumentIcon color="inherit" />,
        component: SignIn,
      },
      {
        path: "/auth/signup",
        name: "Sign Up",
        icon: <RocketIcon color="inherit" />,
        secondaryNavbar: true,
        component: SignUp,
      },
    ],
  },
  {
    path: "/",
    name: "Home",
    component: Home,
  },
];

export const sidebar = [
  {
    category: "Admin",
    children: [
      {
        path: "/admin/dashboard",
        name: "Dashboard",
        icon: <HomeIcon color="inherit" />,
        component: Dashboard,
      },
      {
        path: "/admin/tables",
        name: "Tables",
        icon: <StatsIcon color="inherit" />,
        component: Tables,
      },
      {
        path: "/admin/billing",
        name: "Billing",
        icon: <CreditIcon color="inherit" />,
        component: Billing,
      },
    ],
  },
  {
    category: "Account",
    children: [
      {
        path: "/account/profile",
        name: "Profile",
        icon: <PersonIcon color="inherit" />,
        secondaryNavbar: true,
        component: Profile,
      },
    ],
  },
  {
    path: "/auth/signin",
    name: "Sign In",
    icon: <DocumentIcon color="inherit" />,
    component: SignIn,
  },
  {
    path: "/auth/signup",
    name: "Sign Up",
    icon: <RocketIcon color="inherit" />,
    secondaryNavbar: true,
    component: SignUp,
  },
];
