import Vue from 'vue'
import Store from 'vuex'
import Home from './views/Home.vue'

Vue.use(Vuex)
export default new Store({
    state: {
        credentials: {
            connected: false
        }
    },
    getters: {
        credentials() {
            return state.credentials;
        }
    },
    methods: {
        mutations(data) {
            state.credentials = data;
        }
    }
})
