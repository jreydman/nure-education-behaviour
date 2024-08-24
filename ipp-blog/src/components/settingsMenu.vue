<script setup lang="ts">
import {ref} from "vue"
import SendPost from "@/components/sendPost.vue";
const postBannerFlag = ref(false)
</script>

<template>
    <div class="settings-wrapper">
        <div class="settings-menu">
            <div class="settings-menu__container">
                <button @click="postBannerFlag=!postBannerFlag" class="settings-menu__element link">New Post</button>
                <router-link :to="{name:'profile'}" class="settings-menu__element link">Settings</router-link>
                <button class="settings-menu__element link">Chat</button>
            </div>
        </div>
        <SendPost @update:banner-flag="newFlag=>postBannerFlag=newFlag" v-model:bannerFlag="postBannerFlag"/>
    </div>
</template>

<style scoped lang="scss">
.settings-menu {
    z-index: 2;
    margin-top: 1.5rem;
    margin-left: -3rem;
    position: absolute;
    @include text-label-2
}

.settings-menu__container {
    background: rgba(165,240,204,0.5);
    backdrop-filter: blur(8px);
    border-radius: 1rem;
    padding: 0.5rem 1rem 1rem;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: flex-start;
    
}
</style>