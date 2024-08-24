<script setup lang="ts">
import {ref} from "vue";

const props = defineProps({
    post: {
        type: Object,
        required: true
    },
})

//const user = ref({
//    username: "Jreydman",
//    avatarUrl: "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/d185eeed-8088-4286-9e4c-f5c7710bef03/de00n2e-d4ebf442-2289-4411-85e0-716f1157c54f.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcL2QxODVlZWVkLTgwODgtNDI4Ni05ZTRjLWY1Yzc3MTBiZWYwM1wvZGUwMG4yZS1kNGViZjQ0Mi0yMjg5LTQ0MTEtODVlMC03MTZmMTE1N2M1NGYucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.nOGgB-ex7VgJ9LpyCPXAUkVitMWxnxki1YxAc7DmZb0"
//})
</script>

<template>
    <article class="post">
        <div class="post__section post__aside">
            <div class="post__element image-container"
                 :style="{'background-image': 'url(' + post.author.avatarUrl + ')'}"/>
        </div>
        <div class="post__section post__block">
            <div class="post__header">
                <span class="post__element author">{{post.author.username}}</span>
                <span class="post__element title">{{post.title}}</span>
                <span class="post__element datetime">{{post.created}}</span>
            </div>
            <hr>
            <div class="post__body">
                <p>{{post.body}}</p>
            </div>
            <div class="post__footer">
                <button class="post__element submit-button">0 Likes</button>
                <button class="post__element submit-button">0 Comments</button>
                <button class="post__element submit-button">0 Shares</button>
            </div>
        </div>
    </article>
</template>

<style scoped lang="scss">

.post__block {
    width: 100%;
}

.post {
    display: flex;
    flex-direction: row;
    flex-wrap: nowrap;
    column-gap: 1.5rem;
    margin: 2.5rem auto auto;
    max-width: 40rem;
    border: 0.2rem solid rgba(37,42,52,0.2);
    border-radius: 0.5rem;
    padding: 1rem;
}

.post__header {
    display: flex;
    justify-content: space-around;
}

.post__header .post__element {
    margin-right: 1rem;
}

.post__footer {
    margin: 1rem auto;
    text-align: center;
}

.post__footer .post__element {
    margin: auto 1.5rem;
}

.post__aside .image-container {
        width: 3rem;
        height: 3rem;
        background-position: center;
        background-repeat: no-repeat;
        background-size: cover;
        border-radius: 1.3rem;
}
</style>