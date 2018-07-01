import axios from 'axios'

// Gestion de l'authentification
export default {
    /*data: function () {
        return {
            credentials: authStore.state
        };
    },*/
    props: ['credentials'],
    methods: {
        connect: function (data) {
            var source = this;
            axios
                .get("/auth/connect?name=" + data.login + "&password=" + data.password)
                .then(function (response) {
                    source.credentials.fill(response.data);
                    axios.defaults.headers.common["token"] = source.credentials.token;
                });
        }
    }
}