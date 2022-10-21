<!-- 
 -- Layout Navbar
 -- Author: DUONGPV (05/08/2022)
-->
<template>
    <section class="navbar-page">
        <ul class="navbar-list">
            <li class="navbar-item tooltip" @mouseover="hoverTooltip">
                <router-link :to="{ name: 'dashboard' }">
                    <div class="navbar-item__icon icon icon-dashboard"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Tổng quan
                    </span>
                </router-link>
                <BaseTooltip
                    :content="'Tổng quan'"
                    :styleObject="styleObject"
                />
            </li>
            <li class="navbar-item tooltip" @mouseover="hoverTooltip">
                <router-link :to="{ name: 'app' }">
                    <div class="navbar-item__icon icon icon-cash"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Tiền mặt
                    </span>
                </router-link>
                <BaseTooltip :content="'Tiền mặt'" :styleObject="styleObject" />
            </li>
            <li class="navbar-item tooltip" @mouseover="hoverTooltip">
                <a href="#">
                    <div class="navbar-item__icon icon icon-deposits"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Tiền gửi
                    </span>
                </a>
                <BaseTooltip :content="'Tiền gửi'" :styleObject="styleObject" />
            </li>
            <li class="navbar-item tooltip" @mouseover="hoverTooltip">
                <a href="#">
                    <div class="navbar-item__icon icon icon-buy"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Mua hàng
                    </span>
                </a>
                <BaseTooltip :content="'Mua hàng'" :styleObject="styleObject" />
            </li>
            <li class="navbar-item tooltip" @mouseover="hoverTooltip">
                <a href="#">
                    <div class="navbar-item__icon icon icon-sell"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Bán hàng
                    </span>
                </a>
                <BaseTooltip :content="'Bán hàng'" :styleObject="styleObject" />
            </li>
            <li class="navbar-item tooltip" @mouseover="hoverTooltip">
                <a href="#">
                    <div class="navbar-item__icon icon icon-invoice"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Quản lý hóa đơn
                    </span>
                </a>
                <BaseTooltip
                    :content="'Quản lý hóa đơn'"
                    :styleObject="styleObject"
                />
            </li>
            <li class="navbar-item tooltip" @mouseover="hoverTooltip">
                <a href="#">
                    <div class="navbar-item__icon icon icon-warehouse"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Kho
                    </span>
                </a>
                <BaseTooltip :content="'Kho'" :styleObject="styleObject" />
            </li>
            <li class="navbar-item tooltip" @mouseover="hoverTooltip">
                <a href="#">
                    <div class="navbar-item__icon icon icon-tool"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Công cụ dụng cụ
                    </span>
                </a>
                <BaseTooltip
                    :content="'Công cụ dụng cụ'"
                    :styleObject="styleObject"
                />
            </li>
            <li class="navbar-item tooltip" @mouseover="hoverTooltip">
                <a href="#">
                    <div class="navbar-item__icon icon icon-fixed-assets"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Tài sản cố định
                    </span>
                </a>
                <BaseTooltip
                    :content="'Tài sản cố định'"
                    :styleObject="styleObject"
                />
            </li>
            <li class="navbar-item tooltip" @mouseover="hoverTooltip">
                <a href="#">
                    <div class="navbar-item__icon icon icon-tax"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Thuế
                    </span>
                </a>
                <BaseTooltip :content="'Thuế'" :styleObject="styleObject" />
            </li>
            <li class="navbar-item tooltip" @mouseover="hoverTooltip">
                <a href="#">
                    <div class="navbar-item__icon icon icon-price"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Giá thành
                    </span>
                </a>
                <BaseTooltip
                    :content="'Giá thành'"
                    :styleObject="styleObject"
                />
            </li>
            <li class="navbar-item tooltip" @mouseover="hoverTooltip">
                <a href="#">
                    <div class="navbar-item__icon icon icon-synthesize"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Tổng hợp
                    </span>
                </a>
                <BaseTooltip :content="'Tổng hợp'" :styleObject="styleObject" />
            </li>
            <li class="navbar-item tooltip" @mouseover="hoverTooltip">
                <a href="#">
                    <div class="navbar-item__icon icon icon-budget"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Ngân sách
                    </span>
                </a>
                <BaseTooltip
                    :content="'Ngân sách'"
                    :styleObject="styleObject"
                />
            </li>
            <li class="navbar-item tooltip" @mouseover="hoverTooltip">
                <a href="#">
                    <div class="navbar-item__icon icon icon-report"></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Báo cáo
                    </span>
                </a>
                <BaseTooltip :content="'Báo cáo'" :styleObject="styleObject" />
            </li>
            <li class="navbar-item tooltip" @mouseover="hoverTooltip">
                <a href="#">
                    <div
                        class="navbar-item__icon icon icon-financial-analysis"
                    ></div>
                    <span class="navbar-item__name" v-if="!isResponsive">
                        Phân tích tài chính
                    </span>
                </a>
                <BaseTooltip
                    :content="'Phân tích tài chính'"
                    :styleObject="styleObject"
                />
            </li>
        </ul>
    </section>
</template>

<script>
import BaseTooltip from "@/components/bases/BaseTooltip/BaseTooltip.vue";
export default {
    name: "TheNavbar",
    props: {
        isResponsive: Boolean,
    },
    components: { BaseTooltip },

    data() {
        return {
            styleObject: null,
        };
    },

    methods: {
        hoverTooltip() {
            try {
                this.styleObject = {
                    top: `${event.clientY + 5}px`,
                    left: `${event.clientX + 5}px`,
                    position: "fixed",
                    "z-index": "111",
                };
            } catch (error) {
                console.log(error);
            }
        },
    },
};
</script>

<style scoped>
@import url("./navbar.css");
</style>
