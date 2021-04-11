import Vue from "vue";
import App from "./App.vue";

import store from "./store";

import router from "./router";

import axios from 'axios'
import VueAxios from 'vue-axios'


import OhVueIcon from "oh-vue-icons";

import { FcMenu } from "oh-vue-icons/icons";
OhVueIcon.add(FcMenu);

Vue.component("v-icon", OhVueIcon);

Vue.use(VueAxios, axios)

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");
