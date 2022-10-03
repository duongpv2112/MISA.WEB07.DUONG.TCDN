<!-- 
 -- Layout Header
 -- Author: DUONGPV (05/08/2022)
-->
<template>
    <header
        class="header-page"
        :class="{ 'header-page__responsive': isResponsive }"
    >
        <div class="header-left">
            <a
                href="#"
                class="header-left__icon icon icon-square-menu"
                v-if="!isResponsive"
            ></a>
            <div class="header-left__logo" v-if="!isResponsive">
                <a href="#">
                    <img
                        src="../../../assets/img/Logo_Module_TiengViet_White.66947422.svg"
                    />
                </a>
            </div>
            <div
                class="square-24 cursor-pointer icon icon-bars-responsive"
                @click="setIsResponsive"
                v-if="isResponsive"
            ></div>
        </div>
        <div class="header-right">
            <div class="branch-name">
                <div class="branch-name__icon">
                    <div
                        class="square-24 cursor-pointer icon icon-bars"
                        @click="setIsResponsive"
                        v-if="!isResponsive"
                    ></div>
                </div>
                <select name="listRestaurant" class="branch-name__combobox">
                    <option value="1">CÔNG TY CỔ PHẦN MISA</option>
                </select>
            </div>
            <div class="account-info">
                <div class="account-button account-button__category bg-succes">
                    <div
                        class="square-24 cursor-pointer icon icon-category-header"
                    ></div>
                </div>
                <div class="account-button account-button__setting">
                    <div
                        class="square-24 cursor-pointer icon icon-setting-header"
                    ></div>
                </div>
                <div class="account-button account-button__chat">
                    <div
                        class="square-24 cursor-pointer icon icon-chat-header"
                    ></div>
                </div>
                <div class="account-button account-button__help">
                    <div
                        class="square-24 cursor-pointer icon icon-help-header"
                    ></div>
                </div>
                <div class="account-button account-button__notice">
                    <div
                        class="square-24 cursor-pointer icon icon-notice"
                    ></div>
                </div>
                <div class="d-flex flex-center pr-20">
                    <div class="account-info__avatar">
                        <img src="../../../assets/default-avatar.jpg" alt="" />
                    </div>
                    <div class="account-info__name">
                        <div class="drop-down">
                            <div class="drop-down__content">
                                <div class="drop-down__content--show">
                                    <span>Phạm Việt Dương</span>
                                    <span class="icon icon-down"></span>
                                </div>
                                <div class="drop-down__content--hidden">
                                    <ul class="drop-down__sub-content">
                                        <li class="drop-down__sub-item">
                                            Thông tin tài khoản
                                        </li>
                                        <li class="drop-down__sub-item">
                                            Cài đặt
                                        </li>
                                        <hr />
                                        <li class="drop-down__sub-item">
                                            Đăng xuất
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </header>
</template>

<script>
export default {
    name: "TheHeader",
    props: {
        isResponsive: Boolean,
    },
    emits: ["setIsResponsive"],
    methods: {
        /**
         * Thay đổi giá trị isResponsive
         * AUTHOR: DUONGPV(12/09/2022)
         */
        setIsResponsive() {
            this.$emit("setIsResponsive");
        },
    },
};
</script>

<style scoped>
@import url("./header.css");
</style>
