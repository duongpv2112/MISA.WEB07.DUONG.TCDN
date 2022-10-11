<template>
    <div class="combobox border-radius-2">
        <div
            class="combobox-selected"
            :class="[
                className,
                {
                    'combobox-loading-bg': isLoading,
                    'bg-readonly': isReadOnly && !isComboboxPaging,
                    'border-focus': borderFocus,
                },
            ]"
        >
            <div class="combobox-selected--input">
                <input
                    v-model="textInput"
                    type="text"
                    :class="{ combobox__control: !isComboboxPaging }"
                    :placeholder="placeholder"
                    :tabindex="tabindex"
                    :readonly="isReadOnly"
                    :ref="this.dataField"
                    @input="onHandleInputChange"
                    @keydown="selecItemUpDown"
                    @blur="this.borderFocus = false"
                    @focus="this.borderFocus = true"
                />
            </div>
            <div class="d-flex">
                <div
                    class="combobox-selected--icon"
                    @click="
                        isLoading || (isReadOnly && !isComboboxPaging)
                            ? null
                            : btnShowListData()
                    "
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
            v-show="isShowListData"
            class="combobox-data combobox-data__default"
            v-clickoutside="hideListData"
            :class="{
                'absolute-top': isTop,
                'absolute-bottom': isBottom,
                'no-data--combobox': dataFilter.length == 0,
            }"
        >
            <ul class="combobox-options">
                <li
                    v-for="(item, index) in dataFilter"
                    :key="index"
                    class="combobox-options__item"
                    :class="{
                        'combobox-options__item--active':
                            currentPageRecords == item[dataField],
                        'combobox__item--focus': index == indexItemFocus,
                        'combobox__item--selected':
                            index == indexItemSelected ||
                            item.value_show == textInput,
                    }"
                    :ref="'toFocus_' + index"
                    @click="onHandleSelected(item, dataField, index)"
                >
                    {{ item.value_show }}
                </li>
            </ul>
            {{ dataFilter.length == 0 ? "Không có dữ liệu hiển thị" : "" }}
        </div>
    </div>
</template>
<script>
import { common } from "@/libs/common/common";

const keyCode = {
    Enter: 13,
    ArrowUp: 38,
    ArrowDown: 40,
    ESC: 27,
};

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
        isComboboxPaging: Boolean,
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
            this.$refs[this.dataField].focus();
            this.dataFilter = this.listData;
            this.isShowListData = !this.isShowListData;
        },

        /**
         * Nhấn vào button thì hiển thị hoặc ẩn List Item
         * @author: DUONGPV (08/09/2022)
         */
        onHandleSelected(item, dataField, index) {
            try {
                this.isShowListData = false;
                this.indexItemSelected = index;
                this.textInput = item.value_show;
                this.$emit("setValue", item[dataField], dataField);
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
            this.borderFocus = false;
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

        onHandleInputChange() {
            try {
                this.$emit("setValue", "", this.dataField);
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

    data() {
        return {
            dataCombobox: Array,
            textInput: String,
            isShowListData: Boolean,
            dataFilter: Array,
            borderFocus: Boolean,
            indexItemFocus: null,
            indexItemSelected: null,
        };
    },

    mounted() {
        this.isShowListData = false;
        this.borderFocus = false;
        if (this.value) {
            this.textInput = this.value;
        }
    },

    beforeUnmount() {
        this.$el.removeEventListener("click", () => {
            this.btnShowListData();
        });
    },
};
</script>
<style scoped>
@import url("./combobox.css");
</style>
