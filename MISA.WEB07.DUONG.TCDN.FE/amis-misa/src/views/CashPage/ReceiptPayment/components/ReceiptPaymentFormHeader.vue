<template>
    <BaseModalHeader>
        <div class="pl-24">
            <BaseComboboxDefault
                :className="['m-w-350']"
                :dataField="'type_voucher'"
                :value="stringTypeVoucher"
                :listData="listDataCombobox"
                :isHideLable="true"
                :isBottom="true"    
            />
        </div>
    </BaseModalHeader>
</template>
<script>
import BaseModalHeader from "@/components/bases/BaseModal/BaseModalHeader.vue";
import BaseComboboxDefault from "@/components/bases/BaseCombobox/BaseComboboxDefault.vue";
export default {
    name: "ReceiptPaymentFormHeader",
    components: { BaseModalHeader, BaseComboboxDefault },

    props: {
        isViewDetail: Boolean,
        listDataCombobox: Array,
        stringTypeVoucher: String,
    },

    emits: ["setValue"],

    data() {
        return {};
    },

    created() {},
};
</script>
<style scoped></style>
