import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import axios from "axios";
import {useRoute} from "vue-router";

export const useMainStore = defineStore("main",()=> {
    const user = ref()
    const accessToken = ref()
    const getUser = computed(()=>user.value)
    const getAccessToken = computed(()=>accessToken.value)
    function removeUser(){user.value=null}
    function removeAccessToken(){accessToken.value=null}
    async function refreshUser() {
        const response = await axios.get("/user/token/refresh")
            .catch((error) => {user.value=null})
        if (response) {
            user.value = response.data.user
            accessToken.value = response.data.accessToken
        }
    }
    async function signout() {
        await axios.post("/user/logout")
        removeUser()
        removeAccessToken()
    }
    async function signin(username, password) {
        const response = await axios.post("/user/authorization",{username, password})
        if (response) {
            user.value = response.data.user
            if (user.value.avatarUrl == undefined)
                user.value.avatarUrl = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/d185eeed-8088-4286-9e4c-f5c7710bef03/de00n2e-d4ebf442-2289-4411-85e0-716f1157c54f.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcL2QxODVlZWVkLTgwODgtNDI4Ni05ZTRjLWY1Yzc3MTBiZWYwM1wvZGUwMG4yZS1kNGViZjQ0Mi0yMjg5LTQ0MTEtODVlMC03MTZmMTE1N2M1NGYucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.nOGgB-ex7VgJ9LpyCPXAUkVitMWxnxki1YxAc7DmZb0"
            accessToken.value = response.data.accessToken
        }
    }
    async function getUserById(id) {
        const response = await axios.get(`/user/${id}`)
        if (response) return response.data
    }
    
    return{getUser,getAccessToken,refreshUser,signin,signout,getUserById}
})
