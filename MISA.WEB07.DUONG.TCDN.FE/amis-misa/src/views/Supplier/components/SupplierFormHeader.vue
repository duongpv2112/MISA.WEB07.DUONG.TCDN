<template>
    <BaseModalHeader>
        <div
            class="option-item px-3"
            :class="{ 'pointer-event-none': isViewDetail }"
        >
            <label for="isGroup">
                <input
                    v-model="typeVendor"
                    type="radio"
                    name="typeSuppier"
                    id="isGroup"
                    :readonly="isViewDetail"
                    :value="0"
                />
                <div class="modal__radio cursor-pointer"></div>
            </label>
            <label class="modal__lable cursor-pointer" for="isGroup">
                {{ RESOURCE.SUPPLIER_GROUP_RADIO }}
            </label>
        </div>
        <div
            class="option-item px-3"
            :class="{ 'pointer-event-none': isViewDetail }"
        >
            <label for="isIndividual">
                <input
                    v-model="typeVendor"
                    type="radio"
                    name="typeSuppier"
                    id="isIndividual"
                    :readonly="isViewDetail"
                    :value="1"
                />
                <div class="modal__radio cursor-pointer"></div>
            </label>
            <label class="modal__lable cursor-pointer" for="isIndividual">
                {{ RESOURCE.SUPPLIER_INDIVIDUAL_RADIO }}
            </label>
        </div>
        <div class="option-item ml-20 px-6">
            <label for="isCustomer">
                <input type="checkbox" name="isCustomer" id="isCustomer" />
                <div class="modal__checkbox cursor-pointer"></div>
            </label>
            <label class="modal__lable cursor-pointer" for="isCustomer">
                {{ RESOURCE.SUPPLIER_COSTOMER_CHECKBOX }}
            </label>
        </div>
    </BaseModalHeader>
</template>
<script>
import { SUPPLIER_TEXT_CONFIG } from "@/views/Supplier/constants/resource";
import BaseModalHeader from "@/components/bases/BaseModal/BaseModalHeader.vue";
export default {
    name: "SupplierFormHeader",
    components: { BaseModalHeader },

    props: {
        typeSupplier: Number,
        isViewDetail: Boolean,
    },

    emits: ["setValue"],

    data() {
        return {
            RESOURCE: SUPPLIER_TEXT_CONFIG,
            typeVendor: Number,
        };
    },

    methods: {},

    mounted() {
        this.typeVendor = this.typeSupplier;
    },

    watch: {
        typeVendor(newValue) {
            this.$emit("setValue", newValue);
        },
    },
};
</script>
