<script setup lang="ts">
import {ref} from "vue"
import SettingsIcon from "@/components/icons/settingsIcon.vue";
import ExitIcon from "@/components/icons/exitIcon.vue";
import axios from "axios";
import {useMainStore} from "@/stores/store";
import SettingsMenu from "@/components/settingsMenu.vue";
const mainStore = useMainStore()
const props = defineProps({user: {type:Object, required: true},});
const SignOutHandler = async ()=> {
    await mainStore.signout()
    window.location.reload()
}

const settingsMenuFlag = ref(true)
const settingsMenuHandler = ()=> settingsMenuFlag.value=!settingsMenuFlag.value
</script>

<template>
<div class="profile-card">
    <div class="profile-card__element image-container"
         :style="{'background-image': 'url(' + user.avatarUrl + ')'}"/>
    <h2 class="profile-card__element link">@<span>{{user.username}}</span></h2>
    <div class="profile-card__section">
        <button @click="settingsMenuHandler" class="profile-card__element"><SettingsIcon class="icon--active"/></button>
        <SettingsMenu :class="{'element--hide': settingsMenuFlag}"/>
        <button @click="SignOutHandler" class="profile-card__element"><ExitIcon class="icon--active"/></button>
    </div>
</div>
</template>

<style scoped lang="scss">
.profile-card {
    z-index: 1;
    display: inline-flex;
    align-items: center;
    align-content: center;
    justify-content: center;
    flex-direction: row;
    flex-wrap: nowrap;
}
.profile-card__section {
    border-left: 0.1rem solid $app-color-text-dark;
    margin: auto 1rem;
    display: inherit;
    align-items: center;
}
.profile-card__element {
    max-height: 2.2rem;
    margin: auto 0.2rem;
    border: none;
    background: transparent;
}
.profile-card__element.image-container {
    width: 2.2rem;
    height: 2.2rem;
    background-position: center;
    background-repeat: no-repeat;
    background-size: cover;
    border-radius: 1rem;
}
</style>