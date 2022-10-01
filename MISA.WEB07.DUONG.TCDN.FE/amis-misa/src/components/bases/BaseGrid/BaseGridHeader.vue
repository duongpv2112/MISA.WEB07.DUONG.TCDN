<template>
    <thead class="table-head">
        <tr>
            <th scope="col">
                <input type="checkbox" id="checkAll" />
                <label class="table-checkbox" for="checkAll">
                    <div class="table-checkbox__icon"></div>
                </label>
            </th>
            <th
                scope="col"
                v-for="column in columns"
                :key="column.fieldName"
                @click="sortField(column.dataField)"
            >
                <div class="d-flex">
                    {{ column.fieldName }}
                    <span
                        v-if="true"
                        class="square-16-inline icon icon-dropdown-grey-triangle"
                        :class="{
                            'rotate-180': false,
                        }"
                    >
                    </span>
                </div>
            </th>
            <th scope="col">Chức năng</th>
        </tr>
    </thead>
</template>
<script>
export default {
    name: "BaseGridHeader",
    props: {
        columns: Array,
    },
    methods: {},
};
</script>
<style scoped></style>
