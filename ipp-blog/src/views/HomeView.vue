<script setup lang="ts">
import ItemPost from "@/components/ItemPost.vue";
import {usePostStore} from "@/stores/post";
import {computed, onMounted} from "vue";
import SendPost from "@/components/sendPost.vue";
const postStore = usePostStore()
onMounted(async ()=>{
    await postStore.refreshPostPool()
})
const props = defineProps({user: {type:Object, required: true}});
const postPool = computed(()=>postStore.getPosts)
</script>

<template>
  <main class="main">
      <div class="main__container">
          <div v-for="post in postPool" :key="post.id">
              <ItemPost :post="post"/>
          </div>
          
      </div>
  </main>
</template>

<style scoped lang="scss">
.main {
  display: block;
  margin: auto;
}
.main__container {
  max-width: 100%;
  margin: 0 10rem;
  background: $app-color-transparency;
  align-content: center;
}
</style>
