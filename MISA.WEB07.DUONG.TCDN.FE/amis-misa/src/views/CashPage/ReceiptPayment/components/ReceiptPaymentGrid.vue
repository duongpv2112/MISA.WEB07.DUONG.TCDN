<template>
    <BaseGrid
        :columns="columns"
        :columnActions="columnActions"
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
    name: "ReceiptPaymentGrid",
    components: { BaseGrid },
    props: {
        dataReady: Boolean,
        data: Array,
        totalCount: Number,
        currentPage: Number,
        currentRecord: Number,
        onHandlePageChange: Function,
        onHandlePageSizeChange: Function,
        onEdit: Function,
        onDelete: Function,
        onDetail: Function,
        onReplication: Function,
    },
    data() {
        return {
            columns: [
                {
                    fieldName: "Ngày hạch toán",
                    dataField: "accounting_date",
                    styleObject: {
                        "min-width": "180px !important",
                    },
                    isHidden: false,
                },
                {
                    fieldName: "Ngày chứng từ",
                    dataField: "receipt_payment_date",
                    styleObject: {
                        "min-width": "180px !important",
                    },
                    isHidden: false,
                },
                {
                    fieldName: "Số chứng từ",
                    dataField: "receipt_payment_number",
                    styleObject: {
                        "min-width": "150px !important",
                    },
                    isHidden: false,
                },
                {
                    fieldName: "Diễn giải",
                    dataField: "reason",
                    styleObject: {
                        "min-width": "237px !important",
                    },
                    isHidden: false,
                },
                {
                    fieldName: "Số tiền",
                    dataField: "total_money",
                    styleObject: {
                        "min-width": "140px !important",
                    },
                    isHidden: false,
                },
                {
                    fieldName: "Mã đối tượng",
                    dataField: "account_object_code",
                    styleObject: {
                        "min-width": "120px !important",
                    },
                    isHidden: false,
                },
                {
                    fieldName: "Đối tượng",
                    dataField: "account_object_name",
                    styleObject: {
                        "min-width": "200px !important",
                    },
                    isHidden: false,
                },
                {
                    fieldName: "Địa chỉ",
                    dataField: "address",
                    styleObject: {
                        "min-width": "250px !important",
                    },
                    isHidden: false,
                },
            ],

            columnActions: {
                actionPrimary: {
                    nameAction: "Sửa",
                    functionAction: this.onEdit,
                },
                actionChild: [
                    {
                        nameAction: "Xem",
                        functionAction: this.onDetail,
                    },
                    {
                        nameAction: "Xóa",
                        functionAction: this.onDelete,
                    },
                    {
                        nameAction: "Nhân bản",
                        functionAction: this.onReplication,
                    },
                ],
            },
        };
    },
};
</script>
<style scoped>
@import url("../../../../css/table.css");
</style>
