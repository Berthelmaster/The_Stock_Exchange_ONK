import Vue from "vue";
import App from "./App.vue";
import VueRouter from "vue-router";
import axios from "axios";
import VueAxios from "vue-axios";
import Login from "./components/Login";
import Mainpage from "./components/Mainpage";

Vue.config.productionTip = false;
Vue.use(VueRouter)
Vue.use(VueAxios, axios)

const router = new VueRouter({
  routes: [
    {
      path: '/', component: Login
    },
    {
      path: '/mainpage', component: Mainpage
    },
  ],
  mode: 'history'
});


new Vue({
  router,

  render: h => h(App)
}).$mount("#app");
