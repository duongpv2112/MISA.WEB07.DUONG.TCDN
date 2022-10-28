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
        onEdit: Function,
        onDelete: Function,
        onDetail: Function,
        onReplication: Function,
        columns: Array,
    },
    data() {
        return {
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
@import url("../../../css/table.css");
</style>
