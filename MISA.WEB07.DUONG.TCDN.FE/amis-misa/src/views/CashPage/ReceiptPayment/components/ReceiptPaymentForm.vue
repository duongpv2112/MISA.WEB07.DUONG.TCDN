<template>
    <div class="modal__body p-relative">
        <div class="modal__body-top">
            <div class="main-infomation">
                <div class="modal__row">
                    <div class="col-7 pr-12">
                        <div class="d-flex flex-wrap">
                            <div
                                class="modal__col"
                                :class="{
                                    'col-5': typeVoucher == ENUM.TYPE_PAYMENT,
                                    'col-4': typeVoucher == ENUM.TYPE_RECEIPT,
                                }"
                            >
                                <label class="modal__label mb-6">
                                    Mã đối tượng
                                </label>
                                <BaseComboboxTable
                                    :url="URL.PAGING_DATA_ACCOUNT_OBJECT"
                                    :propValue="'account_object_id'"
                                    :propText="'account_object_code'"
                                    :dataField="'account_object_id'"
                                    :dataText="'account_object_code'"
                                    :className="['modal__group', 'col-12']"
                                    :classListData="['min-w-1000', 'h-200']"
                                    :nameRow="[
                                        {
                                            fieldName: 'Đối tượng',
                                            dataField: 'account_object_code',
                                            styleObject: {
                                                'min-width': '120px',
                                            },
                                        },
                                        {
                                            fieldName: 'Tên đối tượng',
                                            dataField: 'account_object_name',
                                            styleObject: {
                                                'min-width': '280px',
                                            },
                                        },
                                        {
                                            fieldName: 'Mã số thuế',
                                            dataField: 'tax_code',
                                            styleObject: {
                                                'min-width': '140px',
                                            },
                                        },
                                        {
                                            fieldName: 'Địa chỉ',
                                            dataField: 'address',
                                            styleObject: {
                                                'min-width': '250px',
                                            },
                                        },
                                        {
                                            fieldName: 'Điện thoại',
                                            dataField: 'phone_number',
                                            styleObject: {
                                                'min-width': '100px',
                                            },
                                        },
                                    ]"
                                    :isBottom="true"
                                />
                            </div>
                            <BaseInput
                                :className="[
                                    'modal__group',
                                    'modal__col',
                                    typeVoucher == ENUM.TYPE_PAYMENT
                                        ? 'col-7'
                                        : '',
                                    typeVoucher == ENUM.TYPE_RECEIPT
                                        ? 'col-8'
                                        : '',
                                ]"
                                :lable="'Tên đối tượng'"
                                :valueField="receiptPayment.account_object_name"
                                :maxlength="20"
                            />
                            <BaseInput
                                :className="[
                                    'modal__group',
                                    'modal__col',
                                    typeVoucher == ENUM.TYPE_PAYMENT
                                        ? 'col-5'
                                        : '',
                                    typeVoucher == ENUM.TYPE_RECEIPT
                                        ? 'col-4'
                                        : '',
                                ]"
                                :lable="
                                    typeVoucher == ENUM.TYPE_PAYMENT
                                        ? 'Người nhận'
                                        : 'Người nộp'
                                "
                                :valueField="
                                    receiptPayment.account_object_contact_name
                                "
                                :maxlength="20"
                            />
                            <BaseInput
                                :className="[
                                    'modal__group',
                                    'modal__col',
                                    typeVoucher == ENUM.TYPE_PAYMENT
                                        ? 'col-7'
                                        : '',
                                    typeVoucher == ENUM.TYPE_RECEIPT
                                        ? 'col-8'
                                        : '',
                                ]"
                                :lable="'Địa chỉ'"
                                :valueField="receiptPayment.address"
                                :maxlength="20"
                            />
                            <BaseInput
                                v-if="typeVoucher == ENUM.TYPE_PAYMENT"
                                :className="[
                                    'modal__group',
                                    'modal__col',
                                    'col-12',
                                ]"
                                :lable="'Lý do chi'"
                                :valueField="receiptPayment.reason"
                                :maxlength="20"
                            />
                            <div class="d-flex col-12">
                                <div
                                    class="modal__col"
                                    :class="{
                                        'col-5':
                                            typeVoucher == ENUM.TYPE_PAYMENT,
                                        'col-4':
                                            typeVoucher == ENUM.TYPE_RECEIPT,
                                    }"
                                >
                                    <label class="modal__label mb-6">
                                        Nhân viên
                                    </label>
                                    <BaseComboboxTable
                                        :url="URL.PAGING_DATA_EMPLOYEE"
                                        :propValue="'account_object_id'"
                                        :propText="'account_object_code'"
                                        :dataField="'account_object_id'"
                                        :dataText="'account_object_name'"
                                        :className="['modal__group', 'col-12']"
                                        :classListData="['min-w-1000', 'h-200']"
                                        :nameRow="[
                                            {
                                                fieldName: 'Mã nhân viên',
                                                dataField:
                                                    'account_object_code',
                                                styleObject: {
                                                    'min-width': '120px',
                                                },
                                            },
                                            {
                                                fieldName: 'Tên nhân viên',
                                                dataField:
                                                    'account_object_name',
                                                styleObject: {
                                                    'min-width': '280px',
                                                },
                                            },
                                            {
                                                fieldName: 'Đơn vị',
                                                dataField: 'department_name',
                                                styleObject: {
                                                    'min-width': '140px',
                                                },
                                            },
                                            {
                                                fieldName: 'Điện thoại di động',
                                                dataField: 'phone_number',
                                                styleObject: {
                                                    'min-width': '250px',
                                                },
                                            },
                                            {
                                                fieldName: 'Điện thoại',
                                                dataField: 'phone_number',
                                                styleObject: {
                                                    'min-width': '100px',
                                                },
                                            },
                                        ]"
                                        :value="receiptPayment.employee_name"
                                        :isBottom="true"
                                        :isAbsoluteLayer="false"
                                    />
                                </div>

                                <BaseInput
                                    v-if="typeVoucher == ENUM.TYPE_RECEIPT"
                                    :className="[
                                        'modal__group',
                                        'modal__col',
                                        'col-4',
                                    ]"
                                    :lable="'Lý do nộp'"
                                    :valueField="receiptPayment.reason"
                                    :maxlength="20"
                                />

                                <BaseInput
                                    :className="[
                                        'modal__group',
                                        'modal__col',
                                        'col-2',
                                    ]"
                                    :lable="'Kèm theo'"
                                    :valueField="receiptPayment.adding_number"
                                    :isInputNumber="true"
                                    :maxlength="20"
                                />
                                <span class="root-invoice px-2"
                                    >chứng từ gốc</span
                                >
                            </div>
                            <div class="d-flex col-12 modal__col">
                                <div class="reference">
                                    <div class="reference-title-main">
                                        Tham chiếu
                                    </div>
                                    <div class="reference-icon">...</div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="col-12">
                            <label
                                for=""
                                class="modal__label left-separate-lable"
                            >
                                Ngày hạch toán
                            </label>
                            <vc-date-picker
                                v-model="receiptPaymentForm.accounting_date"
                                :popover="{
                                    visibility: 'focus',
                                }"
                                mode="date"
                                :attributes="datepicker"
                            >
                                <template v-slot="{ inputValue, inputEvents }">
                                    <label
                                        class="d-block p-relative"
                                        :class="[
                                            'modal__group',
                                            'modal__col',
                                            'mb-control-group',
                                            'col-12',
                                            'tooltip',
                                            'left-separate',
                                        ]"
                                    >
                                        <div
                                            class="square-32 cursor-pointer modal-icon__calendar"
                                        >
                                            <span
                                                class="square-32 icon icon-calendar"
                                            ></span>
                                        </div>
                                        <input
                                            class="modal__control modal__datepicker"
                                            v-on="inputEvents"
                                            ref="identity_date"
                                            :value="inputValue"
                                        />
                                    </label>
                                </template>
                            </vc-date-picker>
                        </div>
                        <div class="col-12">
                            <label
                                for=""
                                class="modal__label left-separate-lable"
                            >
                                Ngày phiếu chi
                            </label>
                            <vc-date-picker
                                v-model="
                                    receiptPaymentForm.receipt_payment_date
                                "
                                :popover="{
                                    visibility: 'focus',
                                }"
                                mode="date"
                                :attributes="datepicker"
                            >
                                <template v-slot="{ inputValue, inputEvents }">
                                    <label
                                        class="d-block p-relative"
                                        :class="[
                                            'modal__group',
                                            'modal__col',
                                            'mb-control-group',
                                            'col-12',
                                            'tooltip',
                                            'left-separate',
                                        ]"
                                    >
                                        <div
                                            class="square-32 cursor-pointer modal-icon__calendar"
                                        >
                                            <span
                                                class="square-32 icon icon-calendar"
                                            ></span>
                                        </div>
                                        <input
                                            class="modal__control modal__datepicker"
                                            v-on="inputEvents"
                                            ref="identity_date"
                                            :value="inputValue"
                                        />
                                    </label>
                                </template>
                            </vc-date-picker>
                        </div>
                        <div class="col-12">
                            <BaseInput
                                :className="[
                                    'modal__group',
                                    'modal__col',
                                    'col-12',
                                    'left-separate',
                                ]"
                                :lable="
                                    typeVoucher == ENUM.TYPE_PAYMENT
                                        ? 'Số phiếu chi'
                                        : 'Số phiếu thu'
                                "
                                :valueField="
                                    receiptPayment.receipt_payment_number
                                "
                                :maxlength="20"
                            />
                        </div>
                    </div>
                    <div class="col-3 modal__col">
                        <div class="summary-info">
                            <div class="summary-info-title">Tổng tiền</div>
                            <div class="summary-info-number">
                                {{ receiptPaymentForm.total_money }}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="grid-accounting">
                <div class="tab-detail">
                    <div class="tab-detail-title">Hạch toán</div>
                    <div class="tab-header-extend">
                        <div class="tab-header-option">
                            <div class="option-lable">Loại tiền</div>
                            <BaseComboboxDefault
                                :className="['tab-combobox']"
                                :isHideLable="true"
                                :isBottom="true"
                            />
                        </div>
                    </div>
                </div>

                <div class="grid-data">
                    <table class="table">
                        <thead class="table-head">
                            <tr>
                                <th scope="col" class="table-head__index">#</th>
                                <th
                                    scope="col"
                                    v-for="(column, index) in columns"
                                    :key="'col_grid_' + index"
                                    :style="column.styleObject"
                                >
                                    {{ column.fieldName }}
                                </th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody class="table-body">
                            <tr
                                class="table-row"
                                v-for="(item, index) in receiptPaymentDetail"
                                :key="item.id"
                            >
                                <td>
                                    {{ index + 1 }}
                                </td>
                                <td
                                    v-for="(column, index) in columns"
                                    :key="'col_' + (index + 1)"
                                >
                                    <BaseInput
                                        v-if="
                                            column.dataInput.isInput &&
                                            !column.dataCombobox.isCombobox
                                        "
                                        :className="[
                                            'modal__group',
                                            'modal__col',
                                            'mb-0',
                                            'col-12',
                                        ]"
                                        :valueField="item[column.dataField]"
                                        :isInputNumber="
                                            column.dataInput.isInputNumber
                                        "
                                        :isHideLable="true"
                                    />

                                    <BaseComboboxTable
                                        v-if="
                                            !column.dataInput.isInput &&
                                            column.dataCombobox.isCombobox
                                        "
                                        :url="column.dataCombobox.url"
                                        :propValue="'account_object_id'"
                                        :propText="'account_object_code'"
                                        :dataField="'account_object_id'"
                                        :dataText="'account_object_code'"
                                        :className="[
                                            'modal__group',
                                            'col-12',
                                            'mb-0',
                                        ]"
                                        :value="item[column.dataField]"
                                        :nameRow="column.dataCombobox.nameRows"
                                        :isHideIconPlus="true"
                                        :isAbsoluteLayer="false"
                                        :isAbsoluteFull="
                                            column.dataCombobox
                                                .isComboboxFullWidth
                                                ? true
                                                : false
                                        "
                                    />
                                    {{
                                        !column.dataInput.isInput &&
                                        !column.dataCombobox.isCombobox
                                            ? item[column.dataField]
                                            : ""
                                    }}
                                </td>
                                <td>
                                    <span
                                        @click="removeRow(typeVoucher, item)"
                                        class="square-16 icon icon-delete"
                                    ></span>
                                </td>
                            </tr>
                        </tbody>
                        <tfoot class="table-foot">
                            <tr>
                                <th scope="col"></th>
                                <th
                                    scope="col"
                                    v-for="column in columns"
                                    :key="'col_' + column.dataField"
                                    :style="column.styleObject"
                                >
                                    {{
                                        column.dataField ==
                                        dataFooter.columnShow
                                            ? dataFooter.data
                                            : ""
                                    }}
                                </th>
                                <th scope="col"></th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
            <div class="grid-control-accounting">
                <div class="grid-btn-control">
                    <button class="grid-btn mr-12" @click="addRow(typeVoucher)">
                        <span class="grid-btn-title">Thêm dòng</span>
                    </button>

                    <button class="grid-btn" @click="removeAllRow(typeVoucher)">
                        <span class="grid-btn-title">Xóa hết dòng</span>
                    </button>
                </div>

                <div class="grid-input-control">
                    <div class="grid-input-title">
                        <div class="attach-text">
                            <div class="icon grid-input-icon icon-attach"></div>
                            <div>Đính kèm</div>
                        </div>
                        <div class="max-size-upload">Dung lượng tối đa 5MB</div>
                    </div>
                    <div class="grid-input-upload">
                        <input type="file" />
                        <span>Kéo/thả tệp vào đây hoặc bấm vào đây</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal__footer">
        <div class="modal__footer--left">
            <BaseButton
                :title="RESOURCE.RECEIPT_PAYMENT_CANCEL_BTN"
                :className="[
                    'button-text-13',
                    'button-text-bold',
                    'button-border-modal',
                ]"
                :isButtonCancel="true"
            />
        </div>
        <div class="modal__footer--right d-flex">
            <BaseButton
                :title="RESOURCE.RECEIPT_PAYMENT_SAVE_BTN"
                :className="[
                    'button-text-13',
                    'button-text-bold',
                    'button-border-modal',
                    'tooltip',
                    'mr-12',
                ]"
                :contentTooltip="'Cất (Ctrl + S)'"
                :classNameTooltip="['tooltip-default']"
            />
            <div class="d-flex">
                <BaseButton
                    :title="RESOURCE.RECEIPT_PAYMENT_SAVE_AND_ADD_BTN"
                    :className="[
                        'button-text',
                        'button-primary',
                        'button-border-radius-right',
                    ]"
                />
                <div class="d-flex button-combobox">
                    <button
                        class="button button-primary button-border-radius-left"
                        @click="onHandleShowButtonCombobox"
                    >
                        <div class="d-flex flex-center button-icon">
                            <span
                                class="icon square-16 icon-arrow-up--white"
                            ></span>
                            <div class="button-line"></div>
                        </div>
                    </button>
                    <div
                        v-if="isShowButtonCombobox"
                        v-clickoutside="onHideButtonCombobox"
                        class="button-combobox__data"
                    >
                        <ul class="button-combobox__list">
                            <div class="tooltip">
                                <li class="button-combobox__item">
                                    <a href="#">Cất và Thêm</a>
                                </li>
                                <BaseTooltip
                                    :content="'Cất và thêm (Ctrl + Shift + S)'"
                                    :className="['tooltip-absolute-left']"
                                />
                            </div>
                            <div class="tooltip">
                                <li class="button-combobox__item">
                                    <a href="#">Cất và Đóng</a>
                                    <BaseTooltip
                                        :content="'Cất và đóng (Ctrl + Q)'"
                                        :className="['tooltip-absolute-left']"
                                    />
                                </li>
                            </div>
                            <div class="tooltip">
                                <li class="button-combobox__item tooltip">
                                    <a href="#">Cất và In</a>
                                    <BaseTooltip
                                        :content="'Cất và in (Ctrl + Alt + P)'"
                                        :className="['tooltip-absolute-left']"
                                    />
                                </li>
                            </div>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal__action d-flex">
        <div class="guide-tour d-flex flex-center">
            <span class="icon square-24 icon-tour"></span>
            <a href="#" class="guide-tour__link">Hướng dẫn</a>
        </div>
        <button class="modal__button modal__button--support tooltip">
            <i class="square-24 icon icon-setting__detail"></i>
            <BaseTooltip
                :content="'Tùy chỉnh giao diện'"
                :className="['tooltip-default']"
            />
        </button>
        <button class="modal__button modal__button--support tooltip">
            <i class="square-24 icon icon-support"></i>
            <BaseTooltip
                :content="'Giúp (F1)'"
                :className="['tooltip-default']"
            />
        </button>
        <button
            class="modal__button modal__button--close tooltip"
            @click="onClose"
        >
            <i class="square-24 icon icon-times"></i>
            <BaseTooltip
                :content="'Đóng (ESC)'"
                :className="['tooltip-default']"
            />
        </button>
    </div>
</template>
<script>
import { RECEIPT_PAYMENT_TEXT_CONFIG } from "@/views/CashPage/ReceiptPayment/constants/resources";
import { RECEIPT_PAYMENT_ENUM } from "@/views/CashPage/ReceiptPayment/constants/enums";
import { API_RESOURCE } from "@/views/CashPage/ReceiptPayment/constants/api";
import BaseTooltip from "@/components/bases/BaseTooltip/BaseTooltip.vue";
import BaseButton from "@/components/bases/BaseButton/BaseButton.vue";
import BaseInput from "@/components/bases/BaseInput/BaseInput.vue";
import BaseComboboxTable from "@/components/bases/BaseCombobox/BaseComboboxTable.vue";
import BaseComboboxDefault from "@/components/bases/BaseCombobox/BaseComboboxDefault.vue";
import { common } from "@/libs/common/common";

export default {
    name: "ReceiptPaymentForm",

    components: {
        BaseTooltip,
        BaseButton,
        BaseInput,
        BaseComboboxTable,
        BaseComboboxDefault,
    },

    props: {
        onClose: Function,
        typeVoucher: null,
        columns: Array,
        receiptPayment: null,
        receiptPaymentDetail: null,
        addRow: Function,
        removeRow: Function,
        removeAllRow: Function,
    },

    data() {
        return {
            URL: API_RESOURCE,

            RESOURCE: RECEIPT_PAYMENT_TEXT_CONFIG,

            ENUM: RECEIPT_PAYMENT_ENUM,

            isShowButtonCombobox: Boolean,

            datepicker: [
                {
                    key: "today",
                    highlight: "green",
                    dates: new Date(),
                },
            ],

            dataFooter: {
                data: 0,
                columnShow: "amount_money",
            },

            receiptPaymentForm: {
                accounting_date: null,
                receipt_payment_date: null,
                total_money: 0,
            },
        };
    },

    created() {
        this.isShowButtonCombobox = false;
        if (this.receiptPayment) {
            this.receiptPaymentForm.accounting_date =
                this.receiptPayment.accounting_date;
            this.receiptPaymentForm.receipt_payment_date =
                this.receiptPayment.receipt_payment_date;
            this.receiptPaymentForm.total_money = common.formatDecimalCurrency(
                this.receiptPayment.total_money
            );
        }
    },

    methods: {
        onHandleShowButtonCombobox() {
            this.isShowButtonCombobox = !this.isShowButtonCombobox;
        },

        onHideButtonCombobox() {
            this.isShowButtonCombobox = false;
        },
    },
};
</script>
<style scoped>
.modal__body-top {
}

.modal__body-top .main-infomation {
    background-color: #eceef1;
    padding: 8px 24px 20px;
}

.modal__body-top .grid-accounting {
    padding: 16px 24px 12px;
}

.modal__body-top .grid-control-accounting {
    display: flex;
    flex-direction: column;
    padding: 0 24px 26px;
}

.clear {
    height: 26px;
    width: 100%;
}
</style>
