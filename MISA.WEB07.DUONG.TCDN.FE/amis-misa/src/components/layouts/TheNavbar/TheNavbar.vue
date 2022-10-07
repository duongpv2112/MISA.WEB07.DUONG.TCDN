<!-- 
 -- Layout Navbar
 -- Author: DUONGPV (05/08/2022)
-->
<template>
    <section class="navbar-page">
        <ul class="navbar-list">
            <li class="navbar-item">
                <router-link :to="{ name: 'dashboard' }" class="tooltip">
                    <div class="navbar-item__icon icon icon-dashboard"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Tổng quan
                    </span>
                </router-link>
            </li>
            <li class="navbar-item">
                <router-link :to="{ name: 'app' }" class="tooltip">
                    <div class="navbar-item__icon icon icon-cash"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Tiền mặt
                    </span>
                </router-link>
            </li>
            <li class="navbar-item">
                <a href="#" class="tooltip">
                    <div class="navbar-item__icon icon icon-deposits"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Tiền gửi
                    </span>
                </a>
            </li>
            <li class="navbar-item">
                <a href="#" class="tooltip">
                    <div class="navbar-item__icon icon icon-buy"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Mua hàng
                    </span>
                </a>
            </li>
            <li class="navbar-item">
                <a href="#" class="tooltip">
                    <div class="navbar-item__icon icon icon-sell"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Bán hàng
                    </span>
                </a>
            </li>
            <li class="navbar-item">
                <a href="#" class="tooltip">
                    <div class="navbar-item__icon icon icon-invoice"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Quản lý hóa đơn
                    </span>
                </a>
            </li>
            <li class="navbar-item">
                <a href="#" class="tooltip">
                    <div class="navbar-item__icon icon icon-warehouse"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Kho
                    </span>
                </a>
            </li>
            <li class="navbar-item">
                <a href="#" class="tooltip">
                    <div class="navbar-item__icon icon icon-tool"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Công cụ dụng cụ
                    </span>
                </a>
            </li>
            <li class="navbar-item">
                <a href="#" class="tooltip">
                    <div class="navbar-item__icon icon icon-fixed-assets"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Tài sản cố định
                    </span>
                </a>
            </li>
            <li class="navbar-item">
                <a href="#" class="tooltip">
                    <div class="navbar-item__icon icon icon-tax"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Thuế
                    </span>
                </a>
            </li>
            <li class="navbar-item">
                <a href="#" class="tooltip">
                    <div class="navbar-item__icon icon icon-price"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Giá thành
                    </span>
                </a>
            </li>
            <li class="navbar-item">
                <a href="#" class="tooltip">
                    <div class="navbar-item__icon icon icon-synthesize"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Tổng hợp
                    </span>
                </a>
            </li>
            <li class="navbar-item">
                <a href="#" class="tooltip">
                    <div class="navbar-item__icon icon icon-budget"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Ngân sách
                    </span>
                </a>
            </li>
            <li class="navbar-item">
                <a href="#" class="tooltip">
                    <div class="navbar-item__icon icon icon-report"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Báo cáo
                    </span>
                </a>
            </li>
            <li class="navbar-item">
                <a href="#" class="tooltip">
                    <div
                        class="navbar-item__icon icon icon-financial-analysis"
                    ></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Phân tích tài chính
                    </span>
                </a>
            </li>
        </ul>
    </section>
</template>

<script>
export default {
    name: "TheNavbar",
    props: {
        isResponsive: Boolean,
    },
};
</script>

<style scoped>
@import url("./navbar.css");
</style>
