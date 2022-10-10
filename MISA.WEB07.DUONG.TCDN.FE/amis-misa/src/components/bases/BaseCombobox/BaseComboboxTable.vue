<template>
    <div class="combobox border-radius-2" :class="className">
        <div class="combobox-selected">
            <div class="combobox-selected--input">
                <input
                    v-model="textInput"
                    type="text"
                    :placeholder="placeholder"
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

export default {
    name: "BaseComboboxTable",

    props: {
        url: String,
        value: String,
        dataField: String,
        dataText: String,
        propValue: String,
        propText: String,
        placeholder: String,
        tabindex: Number,
        isReadOnly: Boolean,
        isTop: Boolean,
        isBottom: Boolean,
        listData: Array,
        className: Array,
        nameRow: Array,
    },

    emits: ["setValue"],

    created() {
        this.pageNumber = 1;
        this.pageSize = 20;
        this.getData(this.pageNumber);
    },

    beforeUpdate() {
        if (this.value) {
            this.textInput = this.value;
        }
    },

    data() {
        return {
            dataCombobox: [],
            textInput: null,
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
                } else {
                    this.dataCombobox = this.listData;
                }

                if (this.value) {
                    this.textInput = this.value;
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
                const text = item[this.dataText];
                const value = item[this.dataField];
                this.textInput = text;
                this.isShowListData = false;
                this.isShowListData = false;
                this.$emit("setValue", value, this.propValue);
                if (this.propText) {
                    this.$emit("setValue", text, this.propText);
                }
            } catch (error) {
                console.log(error);
            }
        },
    },
};
</script>
<style scoped></style>
