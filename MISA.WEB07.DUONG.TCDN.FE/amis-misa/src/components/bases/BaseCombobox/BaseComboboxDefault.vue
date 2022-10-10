<template>
    <div class="combobox border-radius-2" :class="className">
        <div
            class="combobox-selected"
            :class="{ 'combobox-loading-bg': isLoading }"
        >
            <div class="combobox-selected--input">
                <input
                    v-model="textInput"
                    type="text"
                    :placeholder="placeholder"
                    :tabindex="tabindex"
                    :readonly="isReadOnly"
                    @input="onHandleInputChange"
                    @click="isLoading || !isReadOnly ? null : btnShowListData()"
                />
            </div>
            <div
                class="combobox-selected--icon"
                @click="isLoading ? null : btnShowListData()"
            >
                <i
                    class="icon icon-dropdown square-16"
                    :class="{
                        'rotate-0': !isShowListData,
                        'rotate-180': isShowListData,
                    }"
                ></i>
            </div>
        </div>
        <div
            v-if="isShowListData"
            class="combobox-data combobox-data__default"
            v-clickoutside="hideListData"
            :class="{ 'absolute-top': isTop, 'absolute-bottom': isBottom }"
        >
            <ul class="combobox-options">
                <li
                    v-for="(item, index) of dataFilter"
                    :key="index"
                    class="combobox-options__item"
                    :class="{
                        'combobox-options__item--active':
                            currentPageRecords == item[dataField],
                    }"
                    @click="onHandleSelected(item[dataField], dataField)"
                >
                    {{ item.value_show }}
                </li>
            </ul>
        </div>
    </div>
</template>
<script>
import { common } from "@/libs/common/common";

export default {
    name: "BaseComboboxDefault",

    props: {
        value: String,
        dataField: String,
        placeholder: String,
        tabindex: Number,
        isReadOnly: Boolean,
        isTop: Boolean,
        isBottom: Boolean,
        listData: Array,
        currentPageRecords: Number,
        onHandleEvent: Function,
        className: Array,
        isComboboxTable: Boolean,
        isLoading: Boolean,
        nameTemp: String,
    },

    emits: ["setValue"],

    methods: {
        /**
         * Nhấn vào button thì hiển thị hoặc ẩn List Item
         * @author: DUONGPV (08/09/2022)
         */
        btnShowListData() {
            this.dataFilter = this.listData;
            this.isShowListData = !this.isShowListData;
        },

        /**
         * Nhấn vào button thì hiển thị hoặc ẩn List Item
         * @author: DUONGPV (08/09/2022)
         */
        onHandleSelected(item, dataField) {
            try {
                this.isShowListData = false;
                this.$emit("setValue", item, dataField);
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Nhấn vào button thì hiển thị hoặc ẩn List Item
         * @author: DUONGPV (08/09/2022)
         */
        hideListData() {
            this.isShowListData = false;
        },

        onHandleInputChange() {
            try {
                this.dataFilter = this.listData.filter((e) => {
                    let text = common
                        .removeVietnameseTones(this.textInput)
                        .toLowerCase()
                        .replace(" ", "");
                    let textOfItem = common
                        .removeVietnameseTones(e.value_show)
                        .toLowerCase()
                        .replace(" ", "");
                    return textOfItem.includes(text);
                });
                this.isShowListData = true;
            } catch (error) {
                console.log(error);
            }
        },
    },
    created() {
        try {
            if (this.url) {
                fetch(this.url)
                    .then((res) => res.json())
                    .then((res) => {
                        this.dataCombobox = res;
                    })
                    .catch((res) => {
                        console.log(res);
                    });
            } else {
                this.dataCombobox = this.listData;
            }
            if (this.value) {
                this.textInput = this.value;
            } else {
                this.textInput = "";
            }
        } catch (error) {
            console.log(error);
        }
    },
    beforeUpdate() {
        if (this.value) {
            this.textInput = this.value;
        }
    },
    data() {
        return {
            dataCombobox: Array,
            textInput: String,
            isShowListData: Boolean,
            dataFilter: Array,
        };
    },
    mounted() {
        this.isShowListData = false;
    },
};
</script>
<style scoped>
@import url("./combobox.css");
</style>
