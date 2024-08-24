<script setup>
import {ref, computed} from "vue"
import {usePostStore} from "@/stores/post";
const postStore = usePostStore()
const props = defineProps({bannerFlag: {type: Boolean, required: true}})
const emit = defineEmits(['update:bannerFlag'])

const postSkeleton = ref({
    title: "",
    body: ""
})

const sendPostHandler = async ()=>{
    try {
        await postStore.sendPost(postSkeleton.value.title,postSkeleton.value.body)
    } catch (err) {}
    window.location.reload()
}

const flag = computed({
    get() {return props.bannerFlag},
    set(value) {emit('update:bannerFlag', value)}
})
const closeBannerHandler = ()=> {
    postSkeleton.value.title=""
    postSkeleton.value.body=""
    flag.value = !flag.value
}

</script>

<template>
    <Transition>
        <div class="send-post__banner" v-if="flag">
            <div v-if="flag" class="banner-transparency">
                <div class="send-post__container">
                    <div class="send-post__section post-block">
                        <label class="send-post__element">Title:</label>
                        <input class="send-post__element" name="send-post__title" v-model="postSkeleton.title">
                        <label class="send-post__element">Text:</label>
                        <textarea class="send-post__element" name="post__body" cols="50" rows="10" v-model="postSkeleton.body" style="resize: none;"></textarea>
                    </div>
                    <div class="send-post__section action-block">
                        <button class="send-post__element submit-button" type="submit" @click="sendPostHandler">Отправить</button>
                        <button class="send-post__element submit-button" @click="closeBannerHandler">Закрыть</button>
                    </div>
                    </div>
            </div>
        </div>
    </Transition>
</template>

<style scoped lang="scss">
input, textarea {
    background: $app-color-generic;
}
.send-post__banner {
  position:absolute;
  top:0;
  bottom: 0;
  left: 0;
  right: 0;
  height: 100vh;
  width: 100vw;
  background-color: rgba(0, 0, 0, 0.35);
}

.send-post__banner .banner-transparency {
  width: 400px;
  border: 1px solid;
  background-color:coral;
  position: absolute;
  top:30%; left:36%;
  box-shadow: 0 0 0 1px #1A1A1A, 0 8px 20px 6px #888;
}

.send-post__container {
  padding: 0.7rem;
}

.send-post__container .post-block {
  display: flex;
  flex-direction: column;
  align-content: center;
}
.send-post__element {
    margin: 0.5rem 1rem 0.5rem;
}
</style>