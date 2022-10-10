<template>
    <div class="combobox border-radius-2 combobox-tag" :class="className">
        <div class="combobox-selected">
            <div class="combobox-selected--input">
                <div
                    class="selected-item"
                    v-for="(item, index) in dataInput"
                    :key="'select_item_' + index"
                >
                    <div class="selected-item__content">
                        <div class="selected-item__text">
                            {{ item.valueShow }}
                        </div>
                        <div
                            class="icon square-16 icon-close--small selected-item__icon"
                        ></div>
                    </div>
                </div>
                <input
                    type="text"
                    :tabindex="tabindex"
                    :readonly="isReadOnly"
                    @keypress.enter="onHandleSearch($event.target.value)"
                    @input="onHandleChangeInputData"
                />
            </div>
            <div class="d-flex">
                <div class="combobox-selected--icon combobox-selected--icon-br">
                    <i class="icon icon-plus--success square-16"></i>
                </div>
                <div
                    class="combobox-selected--icon"
                    @click="btnSelectDataOnClick"
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
        </div>
        <div
            v-if="isShowListData"
            class="combobox-data"
            v-clickoutside="hideListData"
            :class="{ 'absolute-bottom': isBottom }"
            ref="scrollComponent"
            @scroll="onHandleScroll"
        >
            <table class="combobox-table">
                <thead>
                    <tr>
                        <th
                            scope="col"
                            v-for="(item, index) in nameRow"
                            :key="index"
                        >
                            {{ item.fieldName }}
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr
                        v-for="(data, index) in dataCombobox"
                        :key="'row_' + index"
                        @click="onHandleSelected(data)"
                    >
                        <td
                            v-for="(col, colIndex) in nameRow"
                            :key="'col_' + colIndex"
                        >
                            {{ data[col.dataField] }}
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>
<script>
import api from "@/services/api";
import { common } from "@/libs/common/common";

export default {
    name: "BaseComboboxTable",

    props: {
        url: String,
        value: Array,
        dataField: String,
        propValue: String,
        propText: String,
        placeholder: String,
        tabindex: Number,
        isReadOnly: Boolean,
        isTop: Boolean,
        isBottom: Boolean,
        className: Array,
        nameRow: Array,
    },

    emits: ["setValueList"],

    created() {
        this.pageNumber = 1;
        this.pageSize = 20;
        this.getData(this.pageNumber);
        if (this.value) {
            this.dataInput = this.value;
        }
    },

    data() {
        return {
            dataCombobox: [],
            dataInput: [],
            isShowListData: false,
            pageNumber: Number,
            pageSize: Number,
            keyWord: String,
            isDataNull: Boolean,
        };
    },

    methods: {
        async getData(pageNumber, keyword, isScroll) {
            try {
                if (this.url) {
                    let urlFilter = `${this.url}?pageSize=${this.pageSize}&pageNumber=${pageNumber}`;
                    if (keyword) {
                        urlFilter += `&keyword=${keyword}`;
                    }
                    await api.get(urlFilter).then((response) => {
                        if (!isScroll) {
                            this.dataCombobox = response.data;
                        } else {
                            const newData = response.data;
                            this.dataCombobox =
                                this.dataCombobox.concat(newData);
                        }
                        this.keyWord = response.keyWord;
                        this.isDataNull = response.data.length == 0;
                    });
                }
            } catch (error) {
                console.log(error);
            }
        },

        onHandleScroll({ target: { scrollTop, clientHeight, scrollHeight } }) {
            if (
                scrollTop + clientHeight >= scrollHeight - 10 &&
                !this.isDataNull
            ) {
                this.pageNumber += 1;
                this.getData(this.pageNumber, this.keyWord, true);
            }
        },

        onHandleSearch(keyWord) {
            this.pageNumber = 1;
            this.getData(this.pageNumber, keyWord, false);
        },

        /**
         * Nhấn vào button thì hiển thị hoặc ẩn List Item
         * @author: DUONGPV (08/09/2022)
         */
        btnSelectDataOnClick() {
            this.isShowListData = !this.isShowListData;
        },

        /**
         * Nhấn vào button thì hiển thị hoặc ẩn List Item
         * @author: DUONGPV (08/09/2022)
         */
        onHandleChangeInputData() {
            this.isShowListData = true;
        },

        /**
         * Nhấn vào button thì hiển thị hoặc ẩn List Item
         * @author: DUONGPV (08/09/2022)
         */
        hideListData() {
            this.isShowListData = false;
        },

        /**
         * Nhấn vào button thì hiển thị hoặc ẩn List Item
         * @author: DUONGPV (08/09/2022)
         */
        onHandleSelected(item) {
            try {
                if (
                    !this.checkValueInclude(item[this.propText], this.dataInput)
                ) {
                    this.dataInput.push({
                        valueField: item[this.dataField],
                        valueShow: item[this.propText],
                    });
                } else {
                    var indexValue = this.dataInput.findIndex((e) => {
                        return e.valueShow == item[this.propText];
                    });
                    this.dataInput.splice(indexValue, 1);
                }
                this.$emit("setValueList", this.dataInput);
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Check giá trị nhập input có tồn tại giá trị trong data không
         * @param {*} value Dữ liệu cần check tồn tại khi người dùng nhập
         * @author: DUONGPV (08/09/2022)
         */
        checkValueInclude(value, data) {
            try {
                if (data.length > 0) {
                    var newArray = data.filter((e) => {
                        let text = common
                            .removeVietnameseTones(value)
                            .toLowerCase()
                            .replace(" ", "");
                        let textOfItem = common
                            .removeVietnameseTones(e.valueShow)
                            .toLowerCase()
                            .replace(" ", "");
                        return textOfItem.includes(text);
                    });
                    if (newArray.length > 0) {
                        return true;
                    } else return false;
                }
                return false;
            } catch (error) {
                console.log(error);
            }
        },
    },
};
</script>
<style scoped></style>
