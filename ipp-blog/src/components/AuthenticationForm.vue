<script setup lang="ts">
    import {ref} from "vue";
    import {useMainStore} from "@/stores/store";
    import '@/assets/scripts/error.js'
    import serializeResponseError from "@/assets/scripts/error";
    
    const mainStore = useMainStore()
    
    const form = ref({
        username: "",
        password: ""
    })
    
    const authError = ref()
    
    const authHandler = async () =>{
        try {
            authError.value = null
            console.clear()
            await mainStore.signin(form.value.username,form.value.password)
        } catch (err) {
            authError.value = serializeResponseError(err)
        }
    } 
    
</script>

<template>
    <form class="authentication__form" @submit.prevent="authHandler">
        <input class="authentication__element input" type="text" placeholder="username" v-model="form.username">
        <input class="authentication__element input" type="password" placeholder="password" v-model="form.password">
        <input class="authentication__element submit-button" type="submit" value="Login">
        <div class="authentication__error-banner">
            <span class="error-message">{{authError?authError.message:""}}</span>
        </div>
    </form>
</template>

<style scoped lang="scss">
.authentication-form {
    display: inline-flex;
}
.authentication__element {
    margin: auto 0.5rem;
}
.authentication__error-banner {
    position: relative;
}
.error-message {
    margin: 0 4rem;
    color: $app-color-prime;
}
</style>