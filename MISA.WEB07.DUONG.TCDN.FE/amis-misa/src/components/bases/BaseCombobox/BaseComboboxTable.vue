<template>
    <div
        class="combobox border-radius-2"
        :class="{
            'p-relative': isAbsoluteLayer,
        }"
    >
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
                <input
                    class="combobox__control"
                    v-model="textInput"
                    type="text"
                    :placeholder="placeholder"
                    :tabindex="tabindex"
                    :readonly="isReadOnly"
                    :ref="propValue"
                    @input="onHandleChangeInputData"
                    @keyup="onHandleSearch($event.target.value)"
                    @keydown="selecItemUpDown"
                    @blur="this.borderFocus = false"
                    @focus="this.borderFocus = true"
                />
            </div>
            <div class="d-flex">
                <div
                    class="combobox-selected--icon combobox-selected--icon-br"
                    v-if="!isHideIconPlus"
                >
                    <i class="icon icon-plus--success square-16"></i>
                </div>
                <div
                    class="combobox-selected--icon"
                    @click="isReadOnly ? null : btnSelectDataOnClick()"
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
            :class="[classListData, isBottom ? 'absolute-bottom' : '']"
            :style="!isAbsoluteLayer ? styleListData : null"
            ref="scrollComponent"
            @scroll="onHandleScroll"
        >
            <table class="combobox-table">
                <thead>
                    <tr>
                        <th
                            scope="col"
                            v-for="(item, index) in nameRow"
                            :style="item.styleObject ? item.styleObject : null"
                            :key="index"
                        >
                            {{ item.fieldName }}
                        </th>
                    </tr>
                </thead>
                <BaseLoading v-if="isLoading" />
                <tbody v-if="!isLoading">
                    <tr
                        v-for="(data, index) in dataCombobox"
                        :key="'row_' + index"
                        :ref="'toFocus_' + index"
                        :class="{
                            'combobox__item--focus': index == indexItemFocus,
                            'combobox__item--selected':
                                index == indexItemSelected ||
                                data[dataText] == textInput,
                        }"
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
import BaseTooltip from "../BaseTooltip/BaseTooltip.vue";
import BaseLoading from "../BaseLoading/BaseLoading.vue";

const keyCode = {
    Enter: 13,
    ArrowUp: 38,
    ArrowDown: 40,
    ESC: 27,
    Tab: 9,
};

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
        isFieldErrorFocus: Boolean,
        isHideIconPlus: Boolean,
        isAbsoluteLayer: Boolean,
        isAbsoluteFull: Boolean,
        classListData: Array,
    },
    emits: ["setValue", "setValidateData"],

    created() {
        this.pageNumber = 1;
        this.pageSize = 20;
    },

    mounted() {
        this.borderFocus = false;
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
            borderFocus: Boolean,
            indexItemFocus: null,
            indexItemSelected: null,
            checkData: {
                isInValid: false,
                errorMessage: "",
            },
            styleListData: Object,
            isLoading: true,
        };
    },

    watch: {
        isFieldErrorFocus(newValue) {
            if (newValue) {
                console.log(newValue);
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
                    this.isLoading = false;
                } else {
                    this.dataCombobox = this.listData;
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
            if (!this.isAbsoluteLayer) {
                this.styleListData = {
                    top: `${
                        event.target.parentElement.offsetParent.offsetTop +
                        event.target.parentElement.offsetParent.offsetHeight +
                        5
                    }px`,
                    left: `${event.target.parentElement.offsetParent.offsetLeft}px`,
                    "max-width": "382px",
                    "z-index": "999999",
                };

                if (this.isAbsoluteFull) {
                    this.styleListData = {
                        top: `${
                            event.target.parentElement.offsetParent.offsetTop +
                            event.target.parentElement.offsetParent
                                .offsetHeight +
                            6
                        }px`,
                        "z-index": "99",
                        right: "0",
                        "min-width": "1000px",
                        "max-width": "1000px",
                    };
                }
            }

            this.isShowListData = !this.isShowListData;
            this.$refs[this.propValue].focus();
            if (this.dataCombobox.length == 0) {
                this.getData(this.pageNumber);
            }
        },

        /**
         * Nhấn vào button thì hiển thị hoặc ẩn List Item
         * @author: DUONGPV (08/09/2022)
         */
        onHandleChangeInputData() {
            this.$emit("setValue", "", this.propValue);
            if (this.textInput) {
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
                const text = item[this.dataText];
                // const value = item[this.dataField];
                this.textInput = text;
                this.isShowListData = false;
                this.$emit("setValue", item, this.propValue);
                if (this.propText) {
                    this.$emit("setValue", text, this.propText);
                }
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
                            this.isShowListData = false;
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
    components: { BaseTooltip, BaseLoading },
};
</script>
<style scoped></style>
