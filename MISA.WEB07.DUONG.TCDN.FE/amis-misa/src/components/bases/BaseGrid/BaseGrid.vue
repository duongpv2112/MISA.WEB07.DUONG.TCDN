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
            <BaseComboboxDefault
                style="height: 100%; border: 1px solid #ccc"
                :value="pageSize + ' bản ghi trên 1 trang'"
                :isReadOnly="true"
                :isTop="true"
                :dataField="'number_page_size'"
                :isLoading="!dataReady"
                :listData="listRecordsPage"
                :currentPageRecords="pageSize"
                :onHandleEvent="onHandlePageSizeChange"
                :nameTemp="'bản ghi trên 1 trang'"
                @setValue="onHandlePageSizeChange"
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
import BaseComboboxDefault from "../BaseCombobox/BaseComboboxDefault.vue";

export default {
    name: "BaseGrid",
    components: {
        BaseGridHeader,
        BaseGridRow,
        BasePagination,
        BaseComboboxDefault,
    },
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
            listRecordsPage: [
                {
                    number_page_size: 10,
                    value_show: "10 bản ghi trên một trang",
                },
                {
                    number_page_size: 20,
                    value_show: "20 bản ghi trên một trang",
                },
                {
                    number_page_size: 30,
                    value_show: "30 bản ghi trên một trang",
                },
                {
                    number_page_size: 50,
                    value_show: "50 bản ghi trên một trang",
                },
                {
                    number_page_size: 100,
                    value_show: "100 bản ghi trên một trang",
                },
            ],
        };
    },
};
</script>
<style scoped></style>
