<template>
    <BaseGrid
        :columns="columns"
        :data="data"
        :dataReady="dataReady"
        :total="totalCount"
        :currentPage="currentPage"
        :pageSize="currentRecord"
        :onHandlePageChange="onHandlePageChange"
        :onHandlePageSizeChange="onHandlePageSizeChange"
    />
</template>
<script>
import BaseGrid from "@/components/bases/BaseGrid/BaseGrid.vue";

export default {
    name: "SupplierGrid",
    components: { BaseGrid },
    props: {
        dataReady: Boolean,
        data: Array,
        totalCount: Number,
        currentPage: Number,
        currentRecord: Number,
        onHandlePageChange: Function,
        onHandlePageSizeChange: Function,
    },
    data() {
        return {
            columns: [
                {
                    fieldName: "Mã nhà cung cấp",
                    dataField: "account_object_code",
                    styleObject: {
                        "min-width": "237px !important",
                    },
                    isHidden: false,
                },
                {
                    fieldName: "Tên nhà cung cấp",
                    dataField: "account_object_name",
                    styleObject: {
                        "min-width": "237px !important",
                    },
                    isHidden: false,
                },
                {
                    fieldName: "Địa chỉ",
                    dataField: "address",
                    styleObject: {
                        "min-width": "237px !important",
                    },
                    isHidden: false,
                },
                {
                    fieldName: "Mã số thuế",
                    dataField: "tax_code",
                    styleObject: {
                        "min-width": "237px !important",
                    },
                    isHidden: false,
                },
                {
                    fieldName: "Điện thoại",
                    dataField: "phone_number",
                    styleObject: {
                        "min-width": "140px !important",
                    },
                    isHidden: false,
                },
                {
                    fieldName: "Website",
                    dataField: "website",
                    styleObject: {
                        "min-width": "120px !important",
                    },
                    isHidden: false,
                },
                {
                    fieldName: "Số CMND",
                    dataField: "identity_number",
                    styleObject: {
                        "min-width": "100px !important",
                    },
                    isHidden: false,
                },
            ],
        };
    },
};
</script>
<style scoped>
@import url("../../../css/table.css");
</style>
