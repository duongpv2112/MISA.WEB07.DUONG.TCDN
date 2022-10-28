<template>
    <tfoot
        class="table-foot"
        v-if="
            columns.filter((item) => {
                return item.isShow == true;
            }).length > 0
        "
    >
        <tr>
            <th scope="col"></th>
            <th
                scope="col"
                v-for="column in columns.filter((item) => {
                    return item.isShow == true;
                })"
                :key="'col_' + column.dataField"
            >
                <div
                    class="d-flex"
                    :class="{
                        'flex-center':
                            column.dataField == firstColumn.nameColumn,
                        'flex-end': column.dataField == columnShow,
                    }"
                >
                    {{
                        column.dataField == firstColumn.nameColumn && dataReady
                            ? firstColumn.valueColumn
                            : ""
                    }}
                    {{
                        column.dataField == columnShow && dataReady ? data : ""
                    }}
                    <span
                        v-if="false"
                        class="square-16-inline icon icon-dropdown-grey-triangle"
                        :class="{
                            'rotate-180': false,
                        }"
                    >
                    </span>
                </div>
            </th>
            <th></th>
        </tr>
    </tfoot>
</template>
<script>
export default {
    name: "BaseGridFooter",
    props: {
        columns: Array,
        firstColumn: Object,
        columnShow: String,
        dataReady: Boolean,
        data: null,
    },
    data() {
        return {};
    },
};
</script>
<style scoped>
@import url("../../../css/table.css");

.table-foot tr {
    position: sticky;
    bottom: 0;
    z-index: 9;
}

.table-foot th {
    font-size: 12px;
    height: 35px !important;
    background-color: #e5e8ec;
    text-transform: uppercase;
    padding: 0 10px;
    cursor: pointer;
    border-bottom: none !important;
    border-right: none !important;
}

.table-foot th:first-child {
    position: sticky;
    left: 0;
    z-index: 9;
}

.table-foot th:last-child {
    position: sticky;
    right: 0;
    z-index: 9;
}
</style>
