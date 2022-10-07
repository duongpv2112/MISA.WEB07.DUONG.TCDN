<template>
    <div class="table-container">
        <table class="table">
            <BaseGridHeader :columns="columns" />
            <BaseGridRow
                :data="data"
                :columns="columns"
                :dataReady="dataReady"
            />
        </table>
        <div v-if="dataReady && data.length == 0" class="table-nodata">
            <div class="d-flex flex-center table-nodata__content">
                <img
                    src="../../../assets/img/bg_report_nodata.76e50bd8.svg"
                    alt=""
                />
                <span>Không có dữ liệu</span>
            </div>
        </div>
    </div>
    <div class="table-navigation">
        <span class="navigation-total">
            Tổng số: <strong>{{ total }}</strong> bản ghi
        </span>
        <div class="navigation-action">
            <BaseCombobox
                style="height: 100%; border: 1px solid #ccc"
                :value="pageSize + ' bản ghi trên 1 trang'"
                :isReadOnly="true"
                :isTop="true"
                :listData="listRecordsPage"
                :currentPageRecords="pageSize"
                :onHandleEvent="onHandlePageSizeChange"
            />
            <BasePagination
                :total="total"
                :pageSize="pageSize"
                :currentPage="currentPage"
                :dataReady="dataReady"
                :onHandlePageChange="onHandlePageChange"
            />
        </div>
    </div>
</template>
<script>
import BaseGridHeader from "./BaseGridHeader.vue";
import BaseGridRow from "./BaseGridRow.vue";
import BasePagination from "./BasePagination.vue";
import BaseCombobox from "../BaseCombobox/BaseCombobox.vue";

export default {
    name: "BaseGrid",
    components: { BaseGridHeader, BaseGridRow, BasePagination, BaseCombobox },
    props: {
        columns: Array,
        data: Array,
        total: Number,
        dataReady: Boolean,
        currentPage: Number,
        pageSize: Number,
        onHandlePageChange: Function,
        onHandlePageSizeChange: Function,
    },
    data() {
        return {
            listRecordsPage: [10, 20, 30, 50, 100],
        };
    },
};
</script>
<style scoped></style>
