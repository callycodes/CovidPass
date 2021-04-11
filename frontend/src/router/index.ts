import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import Home from "../views/Home.vue";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/profile",
    name: "Profile",
    component: () => import("../views/Profile.vue"),
  },
  {
    path: "/log",
    name: "Log",
    component: () => import("../views/Log.vue"),
  },
  {
    path: "/passport",
    name: "Passport",
    component: () => import("../views/Passport.vue"),
  },
  {
    path: "/scan",
    name: "Scan",
    component: () => import("../views/Scan.vue"),
  },
  {
    path: "/login",
    name: "Login",
    component: () => import("../views/auth/Login.vue"),
  },
  {
    path: "/register",
    name: "Register",
    component: () => import("../views/auth/Register.vue"),
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL ? process.env.BASE_URL : "",
  routes,
});

export default router;
