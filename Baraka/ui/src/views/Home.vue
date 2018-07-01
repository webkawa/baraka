<template>
    <div class="home">
        <h2>Choisis ta vue mec</h2>
        <div v-for="view in views" :key="view.id">
            <h3>{{ view }}</h3>
        </div>
    </div>
</template>

<script>
    import axios from 'axios'

    export default {
        name: 'home',
        data: function () {
            return {
                views: []
            }
        },
        created: function () {
            alert("bam");
            var source = this;
            axios
                .get("/views/get")
                .then(function (response) {
                    source.views = response.data;
                });
        }
    }
</script>
