<template>
    <div
        v-if="isShow"
        class="combobox-data combobox-data__default"
        :class="{ 'absolute-top': isTop }"
    >
        <ul class="combobox-options">
            <li
                v-for="(item, index) of listData"
                :key="index"
                class="combobox-options__item"
                :class="{
                    'combobox-options__item--active':
                        currentPageRecords == item,
                }"
                @click="selectedItem(item)"
            >
                {{ item }} bản ghi trên 1 trang
            </li>
        </ul>
    </div>
</template>
<script>
export default {
    name: "BaseComboboxDefault",
    props: {
        listData: Array,
        isShow: Boolean,
        isTop: Boolean,
        currentPageRecords: Number,
        onHandleEvent: Function,
    },
    emits: ["hideListData"],
    methods: {
        selectedItem(item) {
            this.onHandleEvent(item);
            this.$emit("hideListData");
        },
    },
};
</script>
<style scoped>
@import url("./combobox.css");
</style>
