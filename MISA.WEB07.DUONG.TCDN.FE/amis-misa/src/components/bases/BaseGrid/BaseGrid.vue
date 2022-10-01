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
    </div>
</template>
<script>
import BaseGridHeader from "./BaseGridHeader.vue";
import BaseGridRow from "./BaseGridRow.vue";

export default {
    name: "BaseGrid",
    components: { BaseGridHeader, BaseGridRow },
    props: {
        columns: Array,
        data: Array,
        dataReady: Boolean,
    },
};
</script>
<style scoped></style>
