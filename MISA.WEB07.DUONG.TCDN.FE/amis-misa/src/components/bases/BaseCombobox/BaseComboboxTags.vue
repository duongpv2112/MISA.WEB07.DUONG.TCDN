<template>
    <div class="combobox border-radius-2 combobox-tag p-relative">
        <div
            class="combobox-selected tooltip"
            :class="[
                className,
                isReadOnly ? 'bg-readonly' : '',
                checkData.isInValid ? 'border-red' : '',
                borderFocus ? 'border-focus' : '',
            ]"
        >
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
                            @click="!isReadOnly ? onHandleRemoveItemSelected(item) : null"
                        ></div>
                    </div>
                </div>
                <input
                    type="text"
                    :tabindex="tabindex"
                    :readonly="isReadOnly"
                    :placeholder="dataInput.length > 0 ? '' : placeholder"
                    :ref="propValue"
                    @keyup="onHandleSearch($event.target.value)"
                    @keydown="selecItemUpDown"
                    @input="onHandleChangeInputData"
                    @blur="this.borderFocus = false"
                    @focus="this.borderFocus = true"
                />
            </div>
            <div class="d-flex">
                <div class="combobox-selected--icon combobox-selected--icon-br">
                    <i class="icon icon-plus--success square-16"></i>
                </div>
                <div
                    class="combobox-selected--icon"
                    @click="!isReadOnly ? btnSelectDataOnClick() : null"
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
            <BaseTooltip
                v-if="checkData.isInValid"
                :content="checkData.errorMessage"
                :className="['tooltip-default', 'tooltip-input__validate']"
            />
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
                            :style="item.stypeColumn"
                            :key="index"
                        >
                            {{ item.fieldName }}
                        </th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr
                        v-for="(data, index) in dataCombobox"
                        :key="'row_' + index"
                        :ref="'toFocus_' + index"
                        :class="{
                            'combobox__item--focus': index == indexItemFocus,
                        }"
                        @click="onHandleSelected(data)"
                    >
                        <td
                            v-for="(col, colIndex) in nameRow"
                            :key="'col_' + colIndex"
                        >
                            {{ data[col.dataField] }}
                        </td>
                        <td>
                            <div
                                class="icon square-16 icon-selected--tags selected-item__icon"
                                v-if="
                                    listSelected &&
                                    listSelected.includes(data[propText])
                                "
                            ></div>
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
import BaseTooltip from "../BaseTooltip/BaseTooltip.vue";

const keyCode = {
    Enter: 13,
    ArrowUp: 38,
    ArrowDown: 40,
    ESC: 27,
    Tab: 9,
    Backspace: 8,
};

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
        isFieldErrorFocus: Boolean,
    },
    emits: ["setValueList", "setValidateData"],
    created() {
        this.pageNumber = 1;
        this.pageSize = 20;
        this.getData(this.pageNumber);
        if (this.value) {
            this.dataInput = this.value;
            this.listSelected = this.value.map((e) => {
                return e.valueShow;
            });
        }
    },
    mounted() {
        this.borderFocus = false;
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
            borderFocus: Boolean,
            listSelected: [],
            indexItemFocus: null,
            indexItemSelected: null,
            checkData: {
                isInValid: false,
                errorMessage: "",
            },
        };
    },
    watch: {
        isFieldErrorFocus(newValue) {
            if (newValue) {
                this.$refs[this.propValue].focus();
            }
        },
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
        onHandleScroll() {
            if (
                this.$refs.scrollComponent.scrollTop +
                    this.$refs.scrollComponent.clientHeight >=
                    this.$refs.scrollComponent.scrollHeight - 2 &&
                !this.isDataNull
            ) {
                this.pageNumber += 1;
                this.getData(this.pageNumber, this.keyWord, true);
            }
        },
        async onHandleSearch(keyWord) {
            if (
                event.keyCode != keyCode.ArrowDown &&
                event.keyCode != keyCode.ArrowUp &&
                event.keyCode != keyCode.Enter &&
                event.keyCode != keyCode.ESC &&
                event.keyCode != keyCode.Tab
            ) {
                if (this.timer) {
                    clearTimeout(this.timer);
                    this.timer = null;
                }
                this.timer = setTimeout(async () => {
                    this.pageNumber = 1;
                    await this.getData(this.pageNumber, keyWord, false);
                    this.isShowListData = true;
                }, 400);
            }
        },
        /**
         * Nhấn vào button thì hiển thị hoặc ẩn List Item
         * @author: DUONGPV (08/09/2022)
         */
        btnSelectDataOnClick() {
            this.isShowListData = !this.isShowListData;
            this.$refs[this.propValue].focus();
        },
        /**
         * Nhấn vào button thì hiển thị hoặc ẩn List Item
         * @author: DUONGPV (08/09/2022)
         */
        onHandleChangeInputData() {
            this.$emit("setValueList", []);
            if (event.target.value) {
                this.checkData.isInValid = true;
                this.checkData.errorMessage = `Dữ liệu <${this.placeholder}> không có trong danh mục.`;
                this.$emit(
                    "setValidateData",
                    true,
                    this.checkData.errorMessage,
                    this.propValue
                );
            } else {
                this.checkData.isInValid = false;
                this.checkData.errorMessage = "";
                this.$emit(
                    "setValidateData",
                    false,
                    this.checkData.errorMessage,
                    this.propValue
                );
            }
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
                    this.listSelected.push(item[this.propText]);
                } else {
                    var indexValue = this.dataInput.findIndex((e) => {
                        return e.valueShow == item[this.propText];
                    });
                    var indexSelectedValue = this.listSelected.findIndex(
                        (e) => {
                            return e == item[this.propText];
                        }
                    );
                    this.dataInput.splice(indexValue, 1);
                    this.listSelected.splice(indexSelectedValue, 1);
                }
                this.$emit("setValueList", this.dataInput);
                this.checkData.isInValid = false;
                this.checkData.errorMessage = "";
                this.$emit(
                    "setValidateData",
                    false,
                    this.checkData.errorMessage,
                    this.propValue
                );
            } catch (error) {
                console.log(error);
            }
        },
        /**
         * Nhấn vào button thì hiển thị hoặc ẩn List Item
         * @author: DUONGPV (08/09/2022)
         */
        onHandleRemoveItemSelected(item) {
            try {
                if (this.checkValueInclude(item.valueShow, this.dataInput)) {
                    var indexValue = this.dataInput.findIndex((e) => {
                        return e.valueShow == item.valueShow;
                    });
                    var indexSelectedValue = this.listSelected.findIndex(
                        (e) => {
                            return e == item.valueShow;
                        }
                    );
                    this.dataInput.splice(indexValue, 1);
                    this.listSelected.splice(indexSelectedValue, 1);
                    this.$emit("setValueList", this.dataInput);
                }
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
        /**
         * Lựa chọn item bằng cách nhấn các phím lên, xuống trên bàn phím
         * @author: DUONGPV (08/09/2022)
         */
        selecItemUpDown() {
            try {
                var keyCodePress = event.keyCode;
                var elToFocus = null;
                switch (keyCodePress) {
                    case keyCode.ESC:
                        this.isShowListData = false;
                        break;
                    case keyCode.Backspace:
                        this.dataInput.splice(this.dataInput.length - 1, 1);
                        this.listSelected.splice(
                            this.listSelected.length - 1,
                            1
                        );
                        break;
                    case keyCode.ArrowDown:
                        this.isShowListData = true;
                        elToFocus =
                            this.$refs[`toFocus_${this.indexItemFocus + 1}`];
                        if (
                            this.indexItemFocus == null ||
                            !elToFocus ||
                            elToFocus.length == 0
                        ) {
                            this.indexItemFocus = 0;
                        } else {
                            this.indexItemFocus += 1;
                            this.fixScrolling();
                        }
                        break;
                    case keyCode.ArrowUp:
                        this.isShowListData = true;
                        elToFocus =
                            this.$refs[`toFocus_${this.indexItemFocus - 1}`];
                        if (
                            this.indexItemFocus == null ||
                            !elToFocus ||
                            elToFocus.length == 0
                        ) {
                            this.indexItemFocus = this.dataFilter.length - 1;
                        } else {
                            this.indexItemFocus -= 1;
                            this.fixScrolling();
                        }
                        break;
                    case keyCode.Enter:
                        elToFocus =
                            this.$refs[`toFocus_${this.indexItemFocus}`];
                        if (elToFocus && elToFocus.length > 0) {
                            elToFocus[0].click();
                        }
                        break;
                    default:
                        break;
                }
            } catch (error) {
                console.log(error);
            }
        },
        fixScrolling() {
            var height =
                this.$refs[`toFocus_${this.indexItemFocus}`][0].clientHeight;
            this.$refs.scrollComponent.scrollTop = height * this.indexItemFocus;
        },
    },
    components: { BaseTooltip },
};
</script>
<style scoped></style>
