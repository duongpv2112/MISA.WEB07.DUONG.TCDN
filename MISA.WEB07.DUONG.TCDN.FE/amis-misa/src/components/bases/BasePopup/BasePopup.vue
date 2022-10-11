<template>
    <div class="popup fade">
        <div class="popup__dialog">
            <div class="popup__content">
                <div class="popup__header"></div>
                <div class="popup__body">
                    <div class="popup__notice">
                        <span class="popup__icon text-danger">
                            <i
                                class="square-48 icon"
                                :class="{
                                    'icon-question':
                                        typePopup == POPUP_TYPE.POPUP_TYPE_INFO,
                                    'icon-exclamation-error':
                                        typePopup ==
                                        POPUP_TYPE.POPUP_TYPE_DANGER,
                                    'icon-exclamation-warning':
                                        typePopup ==
                                        POPUP_TYPE.POPUP_TYPE_WARNING,
                                }"
                            >
                            </i>
                        </span>
                        <span class="popup__desc">
                            {{ noticeMessage }}
                        </span>
                    </div>
                </div>
                <div
                    class="popup__footer"
                    :class="{
                        'justify-space-between':
                            footerPopup.footerRight.length > 0,
                        'flex-center': footerPopup.footerRight.length == 0,
                    }"
                >
                    <div
                        class="d-flex footer-content__left"
                        v-if="footerPopup.footerLeft.length > 0"
                    >
                        <button
                            v-for="(button, index) in footerPopup.footerLeft"
                            class="popup__button"
                            :key="'button_left_' + index"
                            @click="button.buttonAction"
                        >
                            {{ button.buttonName }}
                        </button>
                    </div>
                    <div
                        class="d-flex footer-content__right"
                        v-if="footerPopup.footerRight.length > 0"
                    >
                        <button
                            v-for="(button, index) in footerPopup.footerRight"
                            class="popup__button button-right"
                            :class="button.classButton"
                            :key="'button_right_' + index"
                            @click="button.buttonAction(button.valueFunction)"
                        >
                            {{ button.buttonName }}
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import { POPUP_TYPE } from "./popup";
export default {
    name: "BasePopup",

    props: {
        noticeMessage: String,
        typePopup: Number,
        footerPopup: Object,
    },

    methods: {},

    data() {
        return {
            POPUP_TYPE: POPUP_TYPE,
        };
    },
};
</script>
<style scoped>
@import url("./popup.css");
</style>
