import Vue from "vue";
import App from "./App.vue";
import VueRouter from "vue-router";
import axios from "axios";
import VueAxios from "vue-axios";
import Login from "./components/Login";
import Mainpage from "./components/Mainpage";
import vuetify from "./plugins/vuetify";
import 'material-design-icons-iconfont/dist/material-design-icons.css'

Vue.config.productionTip = false;
Vue.use(VueRouter);
Vue.use(VueAxios, axios);
Vue.use(vuetify);

const router = new VueRouter({
  routes: [
    {
      path: '/',
      component: Login
    },
    {
      path: '/mainpage',
      component: Mainpage
    },
    {
      path: '*',
      component: Login
    }
  ],
  mode: "history"
});

new Vue({
  router,
  vuetify,
  render: h => h(App)
}).$mount("#app");
