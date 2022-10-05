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
        <div v-show="data.length == 0" class="table-nodata">
            <div class="d-flex flex-center table-nodata__content">
                <img
                    src="../../../assets/img/bg_report_nodata.76e50bd8.svg"
                    alt=""
                />
                <span>Không có dữ liệu</span>
            </div>
        </div>
    </div>
    <div class="table-navigation" v-show="data.length != 0">
        <span class="navigation-total">
            Tổng số: <strong>{{ total }}</strong> bản ghi
        </span>
        <div class="navigation-action">
            <BasePagination
                :total="total"
                :pageSize="pageSize"
                :currentPage="currentPage"
                :dataReady="dataReady"
            />
        </div>
    </div>
</template>
<script>
import BaseGridHeader from "./BaseGridHeader.vue";
import BaseGridRow from "./BaseGridRow.vue";
import BasePagination from "./BasePagination.vue";

export default {
    name: "BaseGrid",
    components: { BaseGridHeader, BaseGridRow, BasePagination },
    props: {
        columns: Array,
        data: Array,
        total: Number,
        dataReady: Boolean,
        currentPage: Number,
        pageSize: Number,
    },
};
</script>
<style scoped></style>
