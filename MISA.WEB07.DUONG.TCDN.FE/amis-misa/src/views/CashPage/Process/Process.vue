<template>
    <div class="process">
        <div class="process-untility-area">
            <div class="process-area">
                <div class="process-area__title">Nghiệp vụ tiền mặt</div>
                <div class="process-area__cash">
                    <div class="cash-content">
                        <div class="icon-process-cash h-340"></div>
                        <div
                            class="cash-button receipt"
                            @click="onHandleShowModal(ENUM.TYPE_RECEIPT)"
                        >
                            <div class="cash-button__title">Thu tiền</div>
                        </div>
                        <div
                            class="cash-button payment"
                            @click="onHandleShowModal(ENUM.TYPE_PAYMENT)"
                        >
                            <div class="cash-button__title">Chi tiền</div>
                        </div>
                        <div class="cash-button audit" @click="onClick">
                            <div class="cash-button__title">Kiểm kê quỹ</div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="dictionary-area d-flex">
                <div
                    class="dictionary-item d-flex flex-center flex-grow"
                    @click="onClick"
                >
                    <div class="dictionary-content">
                        <div class="icon square-24 icon-process-customer"></div>
                        <div class="dictionary-text">Khách hàng</div>
                    </div>
                </div>
                <div class="dictionary-item d-flex flex-center flex-grow">
                    <router-link :to="{ name: 'supplier' }">
                        <div class="dictionary-content">
                            <div
                                class="icon square-24 icon-process-provider"
                            ></div>
                            <div class="dictionary-text">Nhà cung cấp</div>
                        </div>
                    </router-link>
                </div>
                <div
                    class="dictionary-item d-flex flex-center flex-grow"
                    @click="onClick"
                >
                    <div class="dictionary-content">
                        <div class="icon square-24 icon-process-employee"></div>
                        <div class="dictionary-text">Nhân viên</div>
                    </div>
                </div>
                <div
                    class="dictionary-item d-flex flex-center flex-grow"
                    @click="onClick"
                >
                    <div class="dictionary-content">
                        <div class="icon square-24 icon-calculate"></div>
                        <div class="dictionary-text">Tính tỉ giá xuất quỹ</div>
                    </div>
                </div>
                <div
                    class="dictionary-item d-flex flex-center flex-grow"
                    @click="onClick"
                >
                    <div class="dictionary-content">
                        <div class="icon square-24 icon-setting"></div>
                        <div class="dictionary-text">Tùy chọn</div>
                    </div>
                </div>
            </div>
        </div>
        <div class="reports-area">
            <div class="reports-area__title">Báo cáo</div>
            <div class="reports-area__body">
                <ul>
                    <li>Bảng kê số dư tiền theo ngày</li>
                    <li>Dòng tiền</li>
                    <li>S03a1-DN: Sổ nhật ký thu tiền</li>
                    <li>Sổ kế toán chi tiết quỹ tiền mặt</li>
                    <li>S03a2-DN: Sổ nhật ký chi tiền</li>
                </ul>
            </div>
            <div class="reports-area__footer">Tất cả báo cáo</div>
        </div>
    </div>

    <BasePopup
        v-if="popupData && isShowPopup"
        :typePopup="popupData.typePopup"
        :footerPopup="popupData.footerPopup"
        :noticeMessage="popupData.noticeMessage"
    />

    <BaseModal
        v-if="isShowModal"
        :titleHeader="titleHeaderModal"
        :className="['modal__dialog--full']"
    >
        <template v-slot:header>
            <ReceiptPaymentFormHeader
                :isViewDetail="true"
                :listDataCombobox="listDataCombobox"
                :stringTypeVoucher="valueTypeVoucher"
            />
        </template>
        <template v-slot:body>
            <ReceiptPaymentForm
                :onClose="onHandleHideModal"
                :typeVoucher="typeVoucher"
                :columns="columnsAccouting"
                :receiptPayment="receiptPayment"
                :accountings="receiptPaymentDetail"
                :setValue="setValueRecieptPayment"
                :setListValue="setValueRecieptPaymentDetail"
                :onSave="onSave"
            />
        </template>
    </BaseModal>
</template>
<script>
import { RECEIPT_PAYMENT_ENUM } from "@/views/CashPage/ReceiptPayment/constants/enums";
import { API_RESOURCE } from "@/views/CashPage/ReceiptPayment/constants/api";
import { common } from "@/libs/common/common";
import api from "@/services/api";
import BasePopup from "@/components/bases/BasePopup/BasePopup.vue";
import BaseModal from "@/components/bases/BaseModal/BaseModal.vue";
import ReceiptPaymentFormHeader from "@/views/CashPage/ReceiptPayment/components/ReceiptPaymentFormHeader.vue";
import ReceiptPaymentForm from "@/views/CashPage/ReceiptPayment/components/ReceiptPaymentForm.vue";
export default {
    name: "ProcessPage",

    components: {
        BasePopup,
        ReceiptPaymentFormHeader,
        ReceiptPaymentForm,
        BaseModal,
    },

    data() {
        return {
            data: [],

            ENUM: RECEIPT_PAYMENT_ENUM,

            listDataCombobox: Array,

            isShowModal: Boolean,

            isViewDetail: Boolean,

            titleHeaderModal: String,

            valueTypeVoucher: String,

            typeVoucher: null,

            columnsAccouting: Array,

            receiptPayment: null,

            popupData: null,

            isShowPopup: Boolean,
        };
    },

    created() {
        this.isShowModal = false;
    },

    methods: {
        onClick() {
            try {
                this.popupData = {
                    typePopup: 2,
                    footerPopup: {
                        footerLeft: [
                            {
                                buttonName: "Đồng ý",
                                buttonAction: this.onHandleHidePopup,
                                classButton: ["btn-confirm"],
                                valueFunction: "",
                            },
                        ],
                        footerRight: [],
                        enterKeyFunc: this.onHandleHidePopup,
                    },
                    noticeMessage:
                        "Tính năng đang phát triển. Vui lòng thử lại sau.",
                };
                this.isShowPopup = true;
            } catch (error) {
                console.log(error);
            }
        },

        onHandleHidePopup() {
            try {
                this.isShowPopup = false;
            } catch (error) {
                console.log(error);
            }
        },

        async onSave(type) {
            try {
                var bodyData = {
                    receiptPayment: this.receiptPayment,
                    receiptPaymentDetails: this.receiptPaymentDetail,
                };
                if (this.receiptPayment.is_add) {
                    delete bodyData.receiptPayment.receipt_payment_id;
                    api.post(
                        `${API_RESOURCE.PAGING_DATA_RECEIPT_PAYMENT}?typeRecord=` +
                            type,
                        bodyData
                    ).then((data) => {
                        if (data) {
                            this.isShowModal = false;
                            this.onHandleReload();
                        }
                    });
                } else if (this.receiptPayment.is_edit) {
                    api.put(
                        `${API_RESOURCE.PAGING_DATA_RECEIPT_PAYMENT}/${this.receiptPayment.receipt_payment_id}?typeRecord=` +
                            type,
                        bodyData
                    ).then((data) => {
                        if (data) {
                            this.isShowModal = false;
                            this.onHandleReload();
                        }
                    });
                }
            } catch (error) {
                console.log(error);
            }
        },

        async onHandleShowModal(type) {
            try {
                if (type == this.ENUM.TYPE_RECEIPT) {
                    this.receiptPayment = {
                        account_object_code: "",
                        account_object_contact_name: "",
                        account_object_id: "",
                        account_object_name: "",
                        accounting_date: common.formatDate(new Date()),
                        adding_number: 0,
                        address: "",
                        created_by: "",
                        created_date: "",
                        employee_id: "",
                        employee_name: "",
                        modified_by: "",
                        modified_date: "",
                        reason: "Thu tiền của ",
                        receipt_payment_date: common.formatDate(new Date()),
                        receipt_payment_id: "",
                        receipt_payment_number: "",
                        total_money: 0,
                        is_add: true,
                        is_edit: false,
                    };

                    this.receiptPaymentDetail = [
                        {
                            id: common.createUUID(),
                            reason: this.receiptPayment.reason,
                            debt_account: "",
                            credit_account: "",
                            amount_money: 0,
                            account_object_id:
                                this.receiptPayment.account_object_id,
                            account_object_code:
                                this.receiptPayment.account_object_code,
                            account_object_name:
                                this.receiptPayment.account_object_name,
                        },
                    ];
                } else if (type == this.ENUM.TYPE_PAYMENT) {
                    this.receiptPayment = {
                        account_object_code: "",
                        account_object_contact_name: "",
                        account_object_id: "",
                        account_object_name: "",
                        accounting_date: common.formatDate(new Date()),
                        adding_number: 0,
                        address: "",
                        created_by: "",
                        created_date: "",
                        employee_id: "",
                        employee_name: "",
                        modified_by: "",
                        modified_date: "",
                        reason: "Chi tiền cho ",
                        receipt_payment_date: common.formatDate(new Date()),
                        receipt_payment_id: "",
                        receipt_payment_number: "",
                        total_money: 0,
                        is_add: true,
                        is_edit: false,
                    };

                    this.receiptPaymentDetail = [
                        {
                            id: common.createUUID(),
                            reason: this.receiptPayment.reason,
                            debt_account: "",
                            credit_account: "",
                            amount_money: 0,
                            account_object_id:
                                this.receiptPayment.account_object_id,
                            account_object_code:
                                this.receiptPayment.account_object_code,
                            account_object_name:
                                this.receiptPayment.account_object_name,
                        },
                    ];
                }

                await this.setValueModal(type, true);
                this.typeVoucher = type;
                this.isShowModal = true;
            } catch (error) {
                console.log(error);
            }
        },

        async setValueModal(type, isNewCode) {
            if (type == this.ENUM.TYPE_RECEIPT) {
                this.listDataCombobox = [
                    {
                        type_voucher: 1,
                        value_show:
                            "1. Thu tiền khách hàng (không theo hóa đơn)",
                    },
                    {
                        type_voucher: 2,
                        value_show: "2. Thu hoàn ứng nhân viên",
                    },
                    {
                        type_voucher: 3,
                        value_show: "3. Rút tiền gửi về nhập quỹ",
                    },
                    {
                        type_voucher: 4,
                        value_show: "4. Thu khác",
                    },
                ];

                this.valueTypeVoucher = "4. Thu khác";

                this.columnsAccouting = [
                    {
                        fieldName: "Diễn giải",
                        dataField: "reason",
                        styleObject: {
                            "min-width": "252px !important",
                        },
                        isHidden: false,
                        dataInput: {
                            isInput: true,
                            isInputNumber: false,
                            dataField: "reason",
                        },
                        dataCombobox: {
                            isCombobox: false,
                        },
                    },
                    {
                        fieldName: "TK Nợ",
                        dataField: "debt_account",
                        styleObject: {
                            "min-width": "127px !important",
                        },
                        isHidden: false,
                        dataInput: {
                            isInput: false,
                            isInputNumber: false,
                            dataField: "",
                        },
                        dataCombobox: {
                            isCombobox: true,
                            url: API_RESOURCE.PAGING_DATA_ACCOUNT,
                            propValue: "debt_account",
                            propText: "debt_account",
                            dataField: "account_number",
                            dataText: "account_number",
                            classListData: [""],
                            nameRows: [
                                {
                                    fieldName: "Số tài khoản",
                                    dataField: "account_number",
                                },
                                {
                                    fieldName: "Tên tài khoản",
                                    dataField: "account_name",
                                },
                            ],
                        },
                    },
                    {
                        fieldName: "TK Có",
                        dataField: "credit_account",
                        styleObject: {
                            "min-width": "137px !important",
                        },
                        isHidden: false,
                        dataInput: {
                            isInput: false,
                            isInputNumber: false,
                            dataField: "",
                        },
                        dataCombobox: {
                            isCombobox: true,
                            url: API_RESOURCE.PAGING_DATA_ACCOUNT,
                            propValue: "credit_account",
                            propText: "credit_account",
                            dataField: "account_number",
                            dataText: "account_number",
                            classListData: [""],
                            nameRows: [
                                {
                                    fieldName: "Số tài khoản",
                                    dataField: "account_number",
                                },
                                {
                                    fieldName: "Tên tài khoản",
                                    dataField: "account_name",
                                },
                            ],
                        },
                    },
                    {
                        fieldName: "Số tiền",
                        dataField: "amount_money",
                        styleObject: {
                            "min-width": "200px !important",
                            "text-align": "right !important",
                        },
                        isHidden: false,
                        dataInput: {
                            isInput: true,
                            isInputNumber: true,
                            dataField: "amount_money",
                        },
                        dataCombobox: {
                            isCombobox: false,
                        },
                    },
                    {
                        fieldName: "Đối tượng",
                        dataField: "account_object_code",
                        styleObject: {
                            "min-width": "150px !important",
                        },
                        isHidden: false,
                        dataInput: {
                            isInput: false,
                            isInputNumber: false,
                            dataField: "",
                        },
                        dataCombobox: {
                            isCombobox: true,
                            isComboboxFullWidth: true,
                            url: API_RESOURCE.PAGING_DATA_ACCOUNT_OBJECT,
                            propValue: "account_object_id",
                            propText: "account_object_code",
                            dataField: "account_object_id",
                            dataText: "account_object_code",
                            classListData: ["h-large-combobox-table"],
                            nameRows: [
                                {
                                    fieldName: "Đối tượng",
                                    dataField: "account_object_code",
                                    styleObject: {
                                        "min-width": "120px",
                                    },
                                },
                                {
                                    fieldName: "Tên đối tượng",
                                    dataField: "account_object_name",
                                    styleObject: {
                                        "min-width": "280px",
                                    },
                                },
                                {
                                    fieldName: "Mã số thuế",
                                    dataField: "tax_code",
                                    styleObject: {
                                        "min-width": "140px",
                                    },
                                },
                                {
                                    fieldName: "Địa chỉ",
                                    dataField: "address",
                                    styleObject: {
                                        "min-width": "250px",
                                    },
                                },
                                {
                                    fieldName: "Điện thoại",
                                    dataField: "phone_number",
                                    styleObject: {
                                        "min-width": "100px",
                                    },
                                },
                            ],
                        },
                    },
                    {
                        fieldName: "Tên đối tượng",
                        dataField: "account_object_name",
                        styleObject: {
                            "min-width": "251px !important",
                        },
                        isHidden: false,
                        dataInput: {
                            isInput: false,
                            isInputNumber: false,
                            dataField: "",
                        },
                        dataCombobox: {
                            isCombobox: false,
                        },
                    },
                ];

                if (isNewCode) {
                    await api
                        .get(
                            `${API_RESOURCE.RECEIPT_PAYMENT_GET_NEW_CODE}?typeRecord=` +
                                this.ENUM.TYPE_RECEIPT
                        )
                        .then((data) => {
                            this.receiptPayment.receipt_payment_number = data;
                        });
                }

                this.titleHeaderModal = `Phiếu thu ${this.receiptPayment.receipt_payment_number}`;
            } else if (type == this.ENUM.TYPE_PAYMENT) {
                this.listDataCombobox = [
                    {
                        type_voucher: 1,
                        value_show:
                            "1. Trả tiền nhà cung cấp(Không theo hóa đơn)",
                    },
                    {
                        type_voucher: 2,
                        value_show: "2. Tạm ứng cho nhân viên",
                    },
                    {
                        type_voucher: 3,
                        value_show: "3. Chi mua ngoài có hóa đơn",
                    },
                    {
                        type_voucher: 4,
                        value_show: "4. Trả lương nhân viên",
                    },
                    {
                        type_voucher: 5,
                        value_show: "5. Chuyển tiền cho chi nhánh khác",
                    },
                    {
                        type_voucher: 6,
                        value_show: "6. Gửi tiền vào ngân hàng",
                    },
                    {
                        type_voucher: 7,
                        value_show: "7. Chi khác",
                    },
                ];

                this.valueTypeVoucher = "7. Chi khác";

                this.columnsAccouting = [
                    {
                        fieldName: "Diễn giải",
                        dataField: "reason",
                        styleObject: {
                            "min-width": "252px !important",
                        },
                        isHidden: false,
                        dataInput: {
                            isInput: true,
                            isInputNumber: false,
                            dataField: "reason",
                        },
                        dataCombobox: {
                            isCombobox: false,
                        },
                    },
                    {
                        fieldName: "TK Nợ",
                        dataField: "debt_account",
                        styleObject: {
                            "min-width": "127px !important",
                        },
                        isHidden: false,
                        dataInput: {
                            isInput: false,
                            isInputNumber: false,
                            dataField: "",
                        },
                        dataCombobox: {
                            isCombobox: true,
                            url: API_RESOURCE.PAGING_DATA_ACCOUNT,
                            propValue: "debt_account",
                            propText: "debt_account",
                            dataField: "account_number",
                            dataText: "account_number",
                            classListData: [""],
                            nameRows: [
                                {
                                    fieldName: "Số tài khoản",
                                    dataField: "account_number",
                                },
                                {
                                    fieldName: "Tên tài khoản",
                                    dataField: "account_name",
                                },
                            ],
                        },
                    },
                    {
                        fieldName: "TK Có",
                        dataField: "credit_account",
                        styleObject: {
                            "min-width": "137px !important",
                        },
                        isHidden: false,
                        dataInput: {
                            isInput: false,
                            isInputNumber: false,
                            dataField: "",
                        },
                        dataCombobox: {
                            isCombobox: true,
                            url: API_RESOURCE.PAGING_DATA_ACCOUNT,
                            propValue: "credit_account",
                            propText: "credit_account",
                            dataField: "account_number",
                            dataText: "account_number",
                            classListData: [""],
                            nameRows: [
                                {
                                    fieldName: "Số tài khoản",
                                    dataField: "account_number",
                                },
                                {
                                    fieldName: "Tên tài khoản",
                                    dataField: "account_name",
                                },
                            ],
                        },
                    },
                    {
                        fieldName: "Số tiền",
                        dataField: "amount_money",
                        styleObject: {
                            "min-width": "200px !important",
                            "text-align": "right !important",
                        },
                        isHidden: false,
                        dataInput: {
                            isInput: true,
                            isInputNumber: true,
                            dataField: "amount_money",
                        },
                        dataCombobox: {
                            isCombobox: false,
                        },
                    },
                    {
                        fieldName: "Đối tượng",
                        dataField: "account_object_code",
                        styleObject: {
                            "min-width": "150px !important",
                        },
                        isHidden: false,
                        dataInput: {
                            isInput: false,
                            isInputNumber: false,
                            dataField: "",
                        },
                        dataCombobox: {
                            isCombobox: true,
                            isComboboxFullWidth: true,
                            url: API_RESOURCE.PAGING_DATA_ACCOUNT_OBJECT,
                            propValue: "account_object_id",
                            propText: "account_object_code",
                            dataField: "account_object_id",
                            dataText: "account_object_code",
                            classListData: ["h-large-combobox-table"],
                            nameRows: [
                                {
                                    fieldName: "Đối tượng",
                                    dataField: "account_object_code",
                                    styleObject: {
                                        "min-width": "120px",
                                    },
                                },
                                {
                                    fieldName: "Tên đối tượng",
                                    dataField: "account_object_name",
                                    styleObject: {
                                        "min-width": "280px",
                                    },
                                },
                                {
                                    fieldName: "Mã số thuế",
                                    dataField: "tax_code",
                                    styleObject: {
                                        "min-width": "140px",
                                    },
                                },
                                {
                                    fieldName: "Địa chỉ",
                                    dataField: "address",
                                    styleObject: {
                                        "min-width": "250px",
                                    },
                                },
                                {
                                    fieldName: "Điện thoại",
                                    dataField: "phone_number",
                                    styleObject: {
                                        "min-width": "100px",
                                    },
                                },
                            ],
                        },
                    },
                    {
                        fieldName: "Tên đối tượng",
                        dataField: "account_object_name",
                        styleObject: {
                            "min-width": "251px !important",
                        },
                        isHidden: false,
                        dataInput: {
                            isInput: false,
                            isInputNumber: false,
                            dataField: "",
                        },
                        dataCombobox: {
                            isCombobox: false,
                        },
                    },
                ];

                if (isNewCode) {
                    await api
                        .get(
                            `${API_RESOURCE.RECEIPT_PAYMENT_GET_NEW_CODE}?typeRecord=` +
                                this.ENUM.TYPE_PAYMENT
                        )
                        .then((data) => {
                            this.receiptPayment.receipt_payment_number = data;
                        });
                }
                this.titleHeaderModal = `Phiếu chi ${this.receiptPayment.receipt_payment_number}`;
            }
        },

        onHandleHideModal() {
            try {
                this.isShowModal = false;
            } catch (error) {
                console.log(error);
            }
        },

        setValueRecieptPayment(valueField, dataField) {
            try {
                if (valueField && dataField == "account_object_id") {
                    this.receiptPayment.account_object_id =
                        valueField.account_object_id;
                    this.receiptPayment.account_object_code =
                        valueField.account_object_code;
                    this.receiptPayment.account_object_name =
                        valueField.account_object_name;
                    if (valueField.supplier_type == 1) {
                        this.receiptPayment.account_object_contact_name =
                            valueField.account_object_name;
                    } else if (valueField.supplier_type == 0) {
                        this.receiptPayment.account_object_contact_name =
                            valueField.representative_name;
                    }
                    this.receiptPayment.address = valueField.address;
                    if (this.typeVoucher == this.ENUM.TYPE_PAYMENT) {
                        this.receiptPayment.reason = `Chi tiền cho ${valueField.account_object_name}`;
                    } else if (this.typeVoucher == this.ENUM.TYPE_RECEIPT) {
                        this.receiptPayment.reason = `Thu tiền của ${valueField.account_object_name}`;
                    }

                    for (let i = 0; i < this.receiptPaymentDetail.length; i++) {
                        this.receiptPaymentDetail[i].account_object_id =
                            valueField.account_object_id;
                        this.receiptPaymentDetail[i].account_object_code =
                            valueField.account_object_code;
                        this.receiptPaymentDetail[i].account_object_name =
                            valueField.account_object_name;
                        this.receiptPaymentDetail[i].reason =
                            this.receiptPayment.reason;
                    }
                } else if (
                    typeof valueField == "object" &&
                    valueField &&
                    dataField == "employee_id"
                ) {
                    this.receiptPayment.employee_id =
                        valueField["account_object_id"];
                    this.receiptPayment.employee_name =
                        valueField["account_object_name"];
                } else if (typeof valueField != "object") {
                    this.receiptPayment[dataField] = valueField;
                }
            } catch (error) {
                console.log(error);
            }
        },

        setValueRecieptPaymentDetail(value) {
            try {
                this.receiptPaymentDetail = value;
            } catch (error) {
                console.log(error);
            }
        },
    },
};
</script>
<style scoped>
@import url("./process.css");
</style>
