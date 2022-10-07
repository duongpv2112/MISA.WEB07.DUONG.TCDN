<template>
    <div class="modal fade">
        <div class="modal drag">
            <div class="modal__dialog modal__lg">
                <div class="modal__header cursor-grab">
                    <div class="modal__tittle">{{ titleHeader }}</div>
                    <div class="modal__option">
                        <div class="option-item px-6">
                            <label for="isGroup">
                                <input
                                    type="radio"
                                    name="typeSuppier"
                                    id="isGroup"
                                    checked
                                />
                                <div class="modal__radio cursor-pointer"></div>
                            </label>
                            <label
                                class="modal__lable cursor-pointer"
                                for="isGroup"
                            >
                                {{ RESOURCE.SUPPLIER_GROUP_RADIO }}
                            </label>
                        </div>
                        <div class="option-item px-6">
                            <label for="isIndividual">
                                <input
                                    type="radio"
                                    name="typeSuppier"
                                    id="isIndividual"
                                />
                                <div class="modal__radio cursor-pointer"></div>
                            </label>
                            <label
                                class="modal__lable cursor-pointer"
                                for="isIndividual"
                            >
                                {{ RESOURCE.SUPPLIER_INDIVIDUAL_RADIO }}
                            </label>
                        </div>
                    </div>
                    <div class="option-item ml-20 px-6">
                        <label for="isCustomer">
                            <input
                                type="checkbox"
                                name="isCustomer"
                                id="isCustomer"
                            />
                            <div class="modal__checkbox cursor-pointer"></div>
                        </label>
                        <label
                            class="modal__lable cursor-pointer"
                            for="isCustomer"
                        >
                            {{ RESOURCE.SUPPLIER_COSTOMER_CHECKBOX }}
                        </label>
                    </div>
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
</style>
