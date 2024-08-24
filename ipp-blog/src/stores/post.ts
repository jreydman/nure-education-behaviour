import {defineStore} from "pinia";
import {ref, computed} from "vue"
import axios from "axios";
import {useMainStore} from "@/stores/store";

export const usePostStore = defineStore("post",()=>{
    
    const mainStore = useMainStore()
    const posts = ref([])
    const getPosts = computed(()=>posts.value)
    async function refreshPostPool(){
        const response = await axios.get("/post")
        if (response) {
            posts.value = response.data
            posts.value = posts.value.map(post =>{
                if (!('avatarUrl' in post.author))
                    post.author.avatarUrl = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/d185eeed-8088-4286-9e4c-f5c7710bef03/de00n2e-d4ebf442-2289-4411-85e0-716f1157c54f.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcL2QxODVlZWVkLTgwODgtNDI4Ni05ZTRjLWY1Yzc3MTBiZWYwM1wvZGUwMG4yZS1kNGViZjQ0Mi0yMjg5LTQ0MTEtODVlMC03MTZmMTE1N2M1NGYucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.nOGgB-ex7VgJ9LpyCPXAUkVitMWxnxki1YxAc7DmZb0"
                return post
            })
            
        }
    }
    async function sendPost(title, body) {
        const response = await axios.post("/post",
            {title, body, author: mainStore.getUser.id,},
            {headers: {Authorization: `Bearer ${mainStore.getAccessToken}`}}
        )
    }
    return {getPosts, refreshPostPool,sendPost}
})
