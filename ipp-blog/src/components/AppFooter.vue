<script setup lang="ts">

</script>

<template>
<footer class="footer">
    <hr>
    <div class="footer__container">
        <div class="footer__element logotype"><strong>Blog<span>ik</span></strong></div>
        <div class="footer__annotations">
            <a href="/about" class="footer__element link">About</a>
            <a href="#" class="footer__element link">Support</a>
            <a href="#" class="footer__element link">Contacts</a>
        </div>
    </div>
</footer>
</template>

<style scoped lang="scss">
.footer {
    background: $app-color-footer;
}

.footer__container {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    margin: auto 4rem;
}
.footer__annotations {
    @include text-label-2;
    display: flex;
    flex-direction: row;
    align-items: center;
    column-gap: 2rem;
}
</style>