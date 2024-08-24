<script setup>
import { RouterLink, RouterView } from 'vue-router'
import AppHeader from "@/components/AppHeader.vue";
import {useMainStore} from "@/stores/store";
import {computed, onBeforeMount, onMounted, ref} from "vue";
import AppFooter from "@/components/AppFooter.vue";
import axios from "axios";
const mainStore = useMainStore()

//await axios.post("/user/authorization",{username:"jreydman",password:"alternativeWorld"})
//axios.get("/post",).then(post=>console.log(post))
onMounted(async ()=>{
    try {
        await mainStore.refreshUser()
    } catch (err){console.log(err)}
})

const user = computed(()=>mainStore.getUser)
</script>

<template>
    <AppHeader :user="user"/>
    <RouterView :user="user"/>
    <AppFooter/>
</template>

<style scoped lang="scss">

</style>
