<template>
    <div class="modal fade">
        <div class="modal drag">
            <div class="modal__dialog modal__lg">
                <div class="modal__header cursor-grab">
                    <div class="modal__tittle">{{ titleHeader }}</div>
                    <slot name="header"></slot>
                </div>
                <div class="modal__body">
                    <div class="line-bottom">
                        <slot name="body"></slot>
                    </div>
                </div>
                <div class="modal__footer">
                    <div class="modal__footer--left">
                        <BaseButton
                            :title="RESOURCE.SUPPLIER_CANCEL_BTN"
                            :className="[
                                'button-text-13',
                                'button-text-bold',
                                'button-border-modal',
                            ]"
                            :functionz="onClose"
                        />
                    </div>
                    <div class="modal__footer--right">
                        <BaseButton
                            :title="RESOURCE.SUPPLIER_SAVE_BTN"
                            :className="[
                                'button-text-13',
                                'button-text-bold',
                                'button-border-modal',
                                'mr-12',
                            ]"
                        />
                        <BaseButton
                            :title="RESOURCE.SUPPLIER_SAVE_ADN_ADD_BTN"
                            :className="[
                                'button-text-13',
                                'button-primary',
                                'button-text-bold',
                            ]"
                        />
                    </div>
                </div>
                <div class="modal__action">
                    <button class="modal__button modal__button--support">
                        <i class="square-24 icon icon-support"></i>
                    </button>
                    <button
                        class="modal__button modal__button--close"
                        @click="onClose"
                    >
                        <i class="square-24 icon icon-times"></i>
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import BaseButton from "../BaseButton/BaseButton.vue";
import { SUPPLIER_TEXT_CONFIG } from "@/views/Supplier/constants/resource";
export default {
    name: "BaseModal",
    props: {
        titleHeader: String,
        onClose: Function,
    },
    components: { BaseButton },

    data() {
        return {
            RESOURCE: SUPPLIER_TEXT_CONFIG,
        };
    },
};
</script>
<style scoped>
@import url("./modal.css");
@import url("../../../css/flexbox.css");
</style>
