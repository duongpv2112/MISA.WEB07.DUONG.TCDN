<template>
    <div class="modal-setting fade">
        <div class="modal-setting__container">
            <div class="modal-setting__header">
                <div class="modal-setting__header-title">
                    Tùy chỉnh giao diện
                </div>
                <div class="modal-setting__header-action">
                    <div class="d-flex">
                        <div class="tooltip square-24 icon icon-support mr-6">
                            <BaseTooltip
                                :content="'Giúp (F1)'"
                                :className="['tooltip-default']"
                            />
                        </div>
                    </div>

                    <div
                        class="tooltip square-24 icon icon-times"
                        @click="this.onClose"
                    >
                        <BaseTooltip
                            :content="'Đóng (ESC)'"
                            :className="['tooltip-default']"
                        />
                    </div>
                </div>
            </div>
            <div class="modal-setting__toolbar">
                <div class="modal-setting__toolbar-search">
                    <input
                        type="text"
                        name="txtSearch"
                        :placeholder="'Nhập từ khóa tìm kiếm'"
                        class="modal-setting__input-search"
                        ref="txtSearch"
                        autocomplete="off"
                    />
                    <label
                        for="txtSearch"
                        class="modal-setting__icon-search icon icon-search"
                    ></label>
                </div>
                <div class="modal-setting__toolbar-action">
                    <div class="show-layout-info" @click="showEditColumn">
                        Sửa tên cột hiển thị và độ rộng
                    </div>
                </div>
            </div>
            <div class="modal-setting__body">
                <table class="modal-setting__table">
                    <thead class="table-setting__header">
                        <tr>
                            <th style="width: 44px"></th>
                            <th scope="col" style="width: 38px">
                                <input
                                    type="checkbox"
                                    id="checkAllSetting"
                                    v-model="isCheckAll"
                                    @click="checkAllColumn"
                                />
                                <label
                                    class="table-setting__checkbox"
                                    for="checkAllSetting"
                                >
                                    <div
                                        class="table-setting__icon-checkbox"
                                    ></div>
                                </label>
                            </th>
                            <th
                                scope="col"
                                v-for="column in columns"
                                :key="column.fieldName"
                                :style="column.styleObject"
                                :class="{
                                    'd-none': !column.isEditColumn,
                                }"
                            >
                                <div class="d-flex">
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
                        </tr>
                    </thead>
                    <tbody class="table-setting__body">
                        <tr
                            v-for="(data, index) in dataColumns"
                            :key="'row_' + index"
                            @click="setRowIndexSelected(index)"
                            :class="{
                                'bg-selected': rowIndexSelected == index,
                            }"
                        >
                            <td>
                                <div
                                    class="square-16 icon icon-drag-grid"
                                ></div>
                            </td>
                            <td>
                                <input
                                    type="checkbox"
                                    v-model="data.isShow"
                                    :id="data.dataField + '_show'"
                                />
                                <label
                                    class="table-setting__checkbox"
                                    :for="data.dataField + '_show'"
                                >
                                    <div
                                        class="table-setting__icon-checkbox"
                                    ></div>
                                </label>
                            </td>
                            <td
                                scope="col"
                                v-for="column in columns"
                                :key="'row_' + column.fieldName"
                                :style="column.styleObject"
                                :class="{
                                    'd-none': !column.isEditColumn,
                                }"
                            >
                                <div
                                    class="d-flex"
                                    v-if="
                                        column.dataField != 'isFix' &&
                                        (column.dataField == 'name_column' ||
                                            !isShowInput ||
                                            rowIndexSelected != index)
                                    "
                                >
                                    {{
                                        column.dataField != "isFix" &&
                                        (column.dataField == "name_column" ||
                                            !isShowInput ||
                                            rowIndexSelected != index)
                                            ? data[column.dataField]
                                            : ""
                                    }}
                                </div>

                                <BaseInput
                                    v-if="
                                        column.dataField != 'isFix' &&
                                        column.dataField != 'name_column' &&
                                        isShowInput &&
                                        rowIndexSelected == index
                                    "
                                    :type="'text'"
                                    :className="[
                                        'modal__group',
                                        'modal__col',
                                        'col-12',
                                        'mb-0',
                                    ]"
                                    :valueField="data[column.dataField]"
                                    :dataField="column.dataField"
                                    @setValue="updateDataColumn"
                                />

                                <div v-if="column.dataField == 'isFix'">
                                    <input
                                        type="checkbox"
                                        v-model="data.isFix"
                                        :id="data.dataField + '_fix'"
                                    />
                                    <label
                                        class="table-setting__checkbox"
                                        :for="data.dataField + '_fix'"
                                    >
                                        <div
                                            class="table-setting__icon-checkbox"
                                        ></div>
                                    </label>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="modal-setting__line"></div>
            <div class="modal-setting__footer">
                <div class="modal-setting__footer--left">
                    <BaseButton
                        :title="'Hủy'"
                        :className="[
                            'button-text-13',
                            'button-text-bold',
                            'button-border-modal',
                        ]"
                        :isButtonCancel="true"
                        :functionz="onClose"
                    />
                </div>
                <div class="modal-setting__footer--right">
                    <BaseButton
                        :title="'Lấy mẫu ngầm định'"
                        :className="[
                            'button-text-13',
                            'button-border-modal',
                            'button-text-bold',
                            'tooltip',
                            'mr-12',
                        ]"
                        :functionz="defaultSampling"
                    />
                    <BaseButton
                        :title="'Cất'"
                        :className="[
                            'button-text-13',
                            'button-primary',
                            'button-text-bold',
                            'tooltip',
                        ]"
                        :functionz="onSave"
                    />
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import BaseTooltip from "../BaseTooltip/BaseTooltip.vue";
import BaseInput from "../BaseInput/BaseInput.vue";
import BaseButton from "../BaseButton/BaseButton.vue";
export default {
    name: "BaseModalSetting",
    components: { BaseTooltip, BaseInput, BaseButton },

    props: {
        propDatas: null,
        propDatasDefault: null,
        onClose: Function,
    },

    emits: ["onSaveTemplate"],

    data() {
        return {
            isCheckAll: false,

            isEditColumn: false,

            rowIndexSelected: null,

            isShowInput: false,

            columns: [
                {
                    fieldName: "Tên cột dữ liệu",
                    dataField: "name_column",
                    styleObject: {
                        "min-width": "266px !important",
                    },
                    isEditColumn: true,
                },
                {
                    fieldName: "Tên cột trên giao diện",
                    dataField: "fieldName",
                    styleObject: {
                        "min-width": "200px !important",
                    },
                    isEditColumn: false,
                },
                {
                    fieldName: "Độ rộng",
                    dataField: "width",
                    styleObject: {
                        "min-width": "100px !important",
                    },
                    isEditColumn: false,
                },
                {
                    fieldName: "Cố định cột",
                    dataField: "isFix",
                    styleObject: {
                        "min-width": "120px !important",
                    },
                    isEditColumn: false,
                },
            ],

            dataColumns: null,
        };
    },

    created() {
        this.dataColumns = JSON.parse(this.propDatas);
        this.checkIsCheckAll();
    },

    methods: {
        checkIsCheckAll() {
            try {
                this.dataColumns.forEach((item) => {
                    if (item.isShow == false) {
                        this.isCheckAll = false;
                    }else {
                        this.isCheckAll = true;
                    }
                });
            } catch (error) {
                console.log(error);
            }
        },

        checkAllColumn() {
            try {
                if (!this.isCheckAll) {
                    this.dataColumns.forEach((item) => {
                        item.isShow = true;
                    });
                } else {
                    this.dataColumns.forEach((item) => {
                        item.isShow = false;
                    });
                }
            } catch (error) {
                console.log(error);
            }
        },

        showEditColumn() {
            this.columns.forEach((item) => {
                if (item.dataField != "name_column") {
                    item.isEditColumn = !item.isEditColumn;
                }
            });
        },

        setRowIndexSelected(value) {
            try {
                this.rowIndexSelected = value;
                this.isShowInput = true;
            } catch (error) {
                console.log(error);
            }
        },

        updateDataColumn(value, dataField) {
            try {
                this.dataColumns[this.rowIndexSelected][dataField] = value;
            } catch (error) {
                console.log(error);
            }
        },

        defaultSampling() {
            this.dataColumns = JSON.parse(this.propDatasDefault);
        },

        onSave() {
            try {
                this.$emit("onSaveTemplate", this.dataColumns);
            } catch (error) {
                console.log(error);
            }
        },
    },
};
</script>
<style scoped>
@import url("./modal-setting.css");
</style>
