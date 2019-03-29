import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import router from './router'
import { store } from './store'
import { sync } from 'vuex-router-sync'
import { ChangeMyColor } from "./shared/directive/color-directive"
import App from 'components/app-root'
import Datepicker from 'vuejs-datepicker';
import BootstrapVue from 'bootstrap-vue'

Vue.use(BootstrapVue)

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.prototype.$http = axios;
Vue.directive('change-color', ChangeMyColor);
sync(store, router);
Vue.use(Vuex);
const app = new Vue({
    store,
    router,
    ...App
});

export {
    app,
    router,
    store,
    Datepicker
}
