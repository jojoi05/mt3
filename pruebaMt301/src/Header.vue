<template>
    <div id="titulo">
        Joss's Program
        <router-view/>
    </div>
</template>

<script>
export default {
    name: 'Header'
}
</script>

<style>
#titulo {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    text-align: center;
    margin-top: 20px;
    width: 100%;
    font-size: 30px;
}
</style>
