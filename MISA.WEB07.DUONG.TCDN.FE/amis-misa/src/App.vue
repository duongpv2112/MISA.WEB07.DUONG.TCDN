<template>
    <div class="main" :class="{ main__responsive: isResponsive }">
        <TheHeader
            :isResponsive="isResponsive"
            @setIsResponsive="setIsResponsive"
        />
        <TheNavbar :isResponsive="isResponsive" />
        <TheContainer />
    </div>
</template>

<script>
import TheHeader from "./components/layouts/TheHeader/TheHeader.vue";
import TheNavbar from "./components/layouts/TheNavbar/TheNavbar.vue";
import TheContainer from "./components/layouts/TheContainer/TheContainer.vue";

export default {
    name: "App",
    components: {
        TheHeader,
        TheNavbar,
        TheContainer,
    },
    data() {
        return {
            isResponsive: false,
        };
    },
    methods: {
        /**
         * Sự kiện cập nhật giá trị isResponsive
         */
        setIsResponsive() {
            this.isResponsive = !this.isResponsive;
        },
    },
};
</script>

<style scoped>
@import url("./css/main.css");
@import url("./css/base.css");
@import url("./css/icon.css");
</style>
