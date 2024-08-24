<script setup lang="ts">
    import AuthenticationForm from "@/components/AuthenticationForm.vue";
    import ProfileCard from "@/components/ProfileCard.vue";
    const props = defineProps({user: {type:Object, required: true}});
</script>

<template>
  <header class="header">
      <div class="header__navbar">
          <div class="navbar__section logotype">
              <strong>Blog<span>ik</span></strong>
          </div>
          <div class="navbar__section navigation">
              <nav class="navbar__element navigation__container">
                  <router-link class="navigation__element link" :to="{name: 'home'}">My Blog</router-link>
                  <router-link class="navigation__element link" :to="{name: 'profile'}">Profile</router-link>
                  <router-link class="navigation__element link" :to="{name: 'home'}">Trends</router-link>
                  <router-link class="navigation__element link" :to="{name: 'home'}">Top Blogers</router-link>
              </nav>
          </div>
          <div class="navbar__section authentication">
              <AuthenticationForm v-if="!user||!Object.keys(user).length"/>
              <ProfileCard v-else :user="user"/>
          </div>
      </div>
      <div class="header__banner container"></div>
  </header>
</template>

<style scoped lang="scss">
    .header__navbar {
        display: flex;
        flex-direction: row;
        justify-content: space-around;
        align-items: center;
        align-content: center;
        padding: 0.4rem 0;
    }
    .navigation__element {
        margin: auto 1.5rem;
    }
    
    .navigation__container {
        @include text-label-1();
        display: inline-flex;
        flex-wrap: nowrap;
    }

    .header__banner.container {
        width: 100%;
        height: 15rem;
        background-position: center;
        background-repeat: no-repeat;
        background-size: cover;
        background-image:  url("@/assets/images/header-banner.png");
    }
    
</style>