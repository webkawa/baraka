<template>
    <div id="app">
        <h1 v-on:click="credentials.connected = true">baraka <small>for {{ credentials }}</small></h1>
        <div v-if="!credentials.connected">
            <Login></Login>
        </div>
        <div v-if="credentials.connected">
            <router-view />
        </div>
    </div>
</template>

<script>
    import Login from '@/components/Login.vue'
    import Auth from "@/mixins/authentication"

    export default {
        name: 'app',
        data: function () {
            return {};
        },
        methods: {
        },
        mixins: [
            Auth
        ],
        components: {
            Login
        }
    }
</script>

<style lang="less">
    #app {
        background: pink;
    }
</style>
