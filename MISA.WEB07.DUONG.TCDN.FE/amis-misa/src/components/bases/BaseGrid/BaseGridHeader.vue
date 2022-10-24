<template>
    <thead
        class="table-head"
        v-if="
            columns.filter((item) => {
                return item.isShow == true;
            }).length > 0
        "
    >
        <tr>
            <th scope="col">
                <input type="checkbox" id="checkAll" />
                <label class="table-checkbox" for="checkAll">
                    <div class="table-checkbox__icon"></div>
                </label>
            </th>
            <th
                scope="col"
                v-for="column in columns.filter((item) => {
                    return item.isShow == true;
                })"
                :key="column.fieldName"
                :style="[
                    column.styleObject,
                    {
                        'min-width': `${column.width}px !important`,
                    },
                ]"
            >
                <div
                    class="d-flex"
                    :class="{
                        'flex-center': column.isCenter,
                        'flex-end': column.isRight,
                    }"
                >
                    {{ column.fieldName }}
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
            <th scope="col" class="text-center">Chức năng</th>
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
