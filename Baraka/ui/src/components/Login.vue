<template>
    <form v-on:submit="connect(formular)">
        <label>Login</label>
        <input type="text" v-model="formular.login" />
        <label>Mot de passe</label>
        <input type="password" v-model="formular.password" />
        <input type="submit" />
    </form>
</template>

<script>
    import Auth from "../mixins/authentication"

    export default {
        name: 'login',
        data: function () {
            return {
                formular: {
                    login: "",
                    password: ""
                }
            };
        },
        mixins: [
            Auth
        ]
    }
</script>