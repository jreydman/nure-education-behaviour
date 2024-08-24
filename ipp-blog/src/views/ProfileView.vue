<script setup>
import router from "@/router";
import {onMounted} from "vue";
const props = defineProps({user: {type:Object, required: true}});
onMounted(()=>{
    if (props.user==null) router.push("/")
})
</script>

<template>
<div class="profile" v-if="user">
    <div class="profile__banner">
        <div class="profile__section profile__infobar">
            <labal class="profile__field">Username: {{user.username}}</labal>
            <labal class="profile__field">Email: {{user.email}}</labal>
            <labal class="profile__field">Group: 
                <span v-for="group in user.groups" key="group.id">{{group.groupname}}</span>
            </labal>
        </div>
        <div class="profile__section profile__toolbar">
            <button class="profile__field submit-button">Edit</button>
        </div>
    </div>
</div>
</template>

<style scoped lang="scss">
.profile {
    margin: auto;
    height: 25rem;
}
.profile__banner {
    @include text-label-2;
    display: flex;
    flex-direction: column;
    margin: 2rem auto;
    border: 0.2rem solid rgba(37,42,52,0.2);
    border-radius: 0.5rem;
    padding: 2rem;
    max-width: 30rem;
    background: $app-color-transparency;
}
.profile__section {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    align-content: center;
    flex-wrap: wrap;
}
.profile__field {
    margin-top: 1rem;
}
</style>