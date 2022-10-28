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
                :onSave="onSave"
                :setValue="setValueRecieptPayment"
                :setListValue="setValueRecieptPaymentDetail"
                :setValidateReceiptPayment="setValidateReceiptPayment"
                :setValidateReceiptPaymentDetail="
                    setValidateReceiptPaymentDetail
                "
                :fieldFocus="fieldErrorReceiptPaymentFocus"
                :fieldDetailFocus="fieldErrorReceiptPaymentDetailFocus"
                :setPopupData="setPopupData"
                :onHandleHidePopup="onHandleHidePopup"
                :key="keyFormComponent"
            />
        </template>
    </BaseModal>

    <BaseLoading v-if="isLoading" :className="['bg-fade']" />
</template>

<script>
import { useToast } from "vue-toastification";
import { RECEIPT_PAYMENT_ENUM } from "@/views/CashPage/ReceiptPayment/constants/enums";
import { API_RESOURCE } from "@/views/CashPage/ReceiptPayment/constants/api";
import { common } from "@/libs/common/common";
import api from "@/services/api";
import BasePopup from "@/components/bases/BasePopup/BasePopup.vue";
import BaseModal from "@/components/bases/BaseModal/BaseModal.vue";
import ReceiptPaymentFormHeader from "@/views/CashPage/ReceiptPayment/components/ReceiptPaymentFormHeader.vue";
import ReceiptPaymentForm from "@/views/CashPage/ReceiptPayment/components/ReceiptPaymentForm.vue";
import BaseLoading from "@/components/bases/BaseLoading/BaseLoading.vue";

export default {
    name: "ProcessPage",

    setup() {
        const toast = useToast();
        return { toast };
    },

    components: {
        BasePopup,
        ReceiptPaymentFormHeader,
        ReceiptPaymentForm,
        BaseModal,
        BaseLoading,
    },

    data() {
        return {
            columns: Array,

            ENUM: RECEIPT_PAYMENT_ENUM,

            listDataCombobox: Array,

            isShowModal: Boolean,

            titleHeaderModal: String,

            valueTypeVoucher: String,

            typeVoucher: null,

            columnsAccouting: Array,

            receiptPaymentDetail: null,

            receiptPayment: null,

            popupData: null,

            isShowPopup: Boolean,

            fieldErrorReceiptPaymentFocus: null,
            fieldErrorReceiptPaymentDetailFocus: null,

            keyFormComponent: 0,

            isLoading: false,

            validateReceiptPayment: [],

            validateReceiptPaymentDetail: [],

            newObject: {
                accounting_date: common.formatDate(new Date()),
                receipt_payment_date: common.formatDate(new Date()),
                receipt_payment_number: "",
                account_object_id: "",
                account_object_name: "",
                account_object_contact_name: "",
                address: "",
                employee_id: "",
                employee_name: "",
                reason: "",
                adding_number: 0,
                total_money: 0,
                created_date: "",
                created_by: "",
                modified_date: "",
                modified_by: "",
                account_object_code: "",
                is_add: true,
                is_edit: false,
            },
        };
    },

    created() {
        this.isShowModal = false;
    },

    methods: {
        /**
         * Thực hiện hiển thị popup thông báo cho các icon chưa có chức năng
         * @author: DUONGPV (04/10/2022)
         */
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
                        escKeyFunc: this.onHandleHidePopup
                    },
                    noticeMessage:
                        "Tính năng đang phát triển. Vui lòng thử lại sau.",
                };
                this.isShowPopup = true;
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện đóng popup thông báo
         * @author: DUONGPV (04/10/2022)
         */
        onHandleHidePopup() {
            try {
                this.isShowPopup = false;

                var listValidateReceiptPayment =
                    this.validateReceiptPayment.filter((e) => {
                        return e.isInValid == true;
                    });
                var listValidateReceiptPaymentDetail =
                    this.validateReceiptPaymentDetail.filter((e) => {
                        return e.isInValid == true;
                    });
                if (listValidateReceiptPayment.length > 0) {
                    this.setFieldReceiptPaymentErrorFocus(
                        listValidateReceiptPayment[0].fieldName
                    );
                }

                if (listValidateReceiptPaymentDetail.length > 0) {
                    this.setFieldReceiptPaymentDetailErrorFocus(
                        listValidateReceiptPaymentDetail[0].fieldName,
                        listValidateReceiptPaymentDetail[0].rowIndex
                    );
                }
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện lưu thông tin chứng từ
         * @param {*} type: Loại chứng từ cần lưu(0: Phiếu thu, 1: Phiếu chi)
         * @param {*} typeSave: Kiểu lưu(0: Lưu xong đóng, 1: Lưu xong refresh object và giữ nguyên form)
         * @author: DUONGPV (04/10/2022)
         */
        async onSave(type, typeSave) {
            try {
                this.setFieldReceiptPaymentErrorFocus(null);
                this.setFieldReceiptPaymentDetailErrorFocus(null, null);
                if (await this.checkValidateReceiptPayment()) {
                    this.isShowPopup = true;
                } else if (await this.checkValidateReceiptPaymentDetail()) {
                    this.isShowPopup = true;
                } else {
                    this.receiptPaymentDetail.map((item) => {
                        if (typeof item.amount_money == "string") {
                            item.amount_money = Number(
                                item.amount_money.replace(/\D+/g, "")
                            );
                        }
                        return item;
                    });
                    var bodyData = {
                        receiptPayment: this.receiptPayment,
                        receiptPaymentDetails: this.receiptPaymentDetail,
                    };
                    if (this.receiptPayment.is_add) {
                        delete bodyData.receiptPayment.receipt_payment_id;
                        await api
                            .post(
                                `${API_RESOURCE.PAGING_DATA_RECEIPT_PAYMENT}?typeRecord=` +
                                    type,
                                bodyData
                            )
                            .then(async (data) => {
                                if (data) {
                                    this.toast.success(
                                        "Thêm bản ghi thành công!"
                                    );
                                    if (typeSave && typeSave == 1) {
                                        await this.onHandleShowModal(
                                            this.typeVoucher
                                        );
                                        this.keyFormComponent += 1;
                                    } else {
                                        this.isShowModal = false;
                                    }
                                    this.isShowPopup = false;
                                }
                            });
                    } else if (this.receiptPayment.is_edit) {
                        if (bodyData.receiptPayment.account_object_id == null) {
                            delete bodyData.receiptPayment.account_object_id;
                        }
                        if (bodyData.receiptPayment.employee_id == null) {
                            delete bodyData.receiptPayment.employee_id;
                        }
                        bodyData.receiptPaymentDetails.forEach((item) => {
                            if (
                                item.account_object_id == null ||
                                item.account_object_id == ""
                            ) {
                                delete item.account_object_id;
                            }
                        });
                        await api
                            .put(
                                `${API_RESOURCE.PAGING_DATA_RECEIPT_PAYMENT}/${this.receiptPayment.receipt_payment_id}?typeRecord=` +
                                    type,
                                bodyData
                            )
                            .then(async (data) => {
                                if (data) {
                                    this.toast.success(
                                        "Sửa bản ghi thành công!"
                                    );
                                    if (typeSave && typeSave == 1) {
                                        await this.onHandleShowModal(
                                            this.typeVoucher
                                        );
                                        this.keyFormComponent += 1;
                                    } else {
                                        this.isShowModal = false;
                                    }
                                    this.isShowPopup = false;
                                }
                            });
                    }
                }
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện mở popup modal
         * @param {*} type: Loại chứng từ cần hiển thị(0: Phiếu thu, 1: Phiếu chi)
         * @author: DUONGPV (04/10/2022)
         */
        async onHandleShowModal(type) {
            try {
                this.isLoading = true;
                if (type == this.ENUM.TYPE_RECEIPT) {
                    this.receiptPayment = {
                        account_object_code: "",
                        account_object_contact_name: "",
                        account_object_name: "",
                        accounting_date: common.formatDate(new Date()),
                        adding_number: 0,
                        address: "",
                        created_by: "",
                        created_date: "",
                        employee_name: "",
                        modified_by: "",
                        modified_date: "",
                        reason: "Thu tiền của ",
                        receipt_payment_date: common.formatDate(new Date()),
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
                        account_object_name: "",
                        accounting_date: common.formatDate(new Date()),
                        adding_number: 0,
                        address: "",
                        created_by: "",
                        created_date: "",
                        employee_name: "",
                        modified_by: "",
                        modified_date: "",
                        reason: "Chi tiền cho ",
                        receipt_payment_date: common.formatDate(new Date()),
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
                            account_object_code:
                                this.receiptPayment.account_object_code,
                            account_object_name:
                                this.receiptPayment.account_object_name,
                        },
                    ];
                }
                await this.setValueModal(type, true);
                this.typeVoucher = type;
                this.isLoading = false;
                this.isShowModal = true;
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện lấy các giá trị cần hiển thị theo loại chứng từ
         * @param {*} type: Loại chứng từ cần hiển thị(0: Phiếu thu, 1: Phiếu chi)
         * @param {*} isNewCode: Cho phép lấy mã mới(True hoặc False)
         * @author: DUONGPV (04/10/2022)
         */
        async setValueModal(type, isNewCode) {
            try {
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
                                autocomplete: "off",
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
                                placeholder: "Tài khoản nợ",
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
                                placeholder: "Tài khoản có",
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
                                autocomplete: "off",
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
                                placeholder: "Đối tượng",
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
                                this.receiptPayment.receipt_payment_number =
                                    data;
                                this.newObject.receipt_payment_number = data;
                                this.newObject.reason = "Thu tiền của ";
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
                                autocomplete: "off",
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
                                placeholder: "Tài khoản nợ",
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
                                placeholder: "Tài khoản có",
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
                                autocomplete: "off",
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
                                placeholder: "Đối tượng",
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
                                this.receiptPayment.receipt_payment_number =
                                    data;
                                this.newObject.receipt_payment_number = data;
                                this.newObject.reason = "Chi tiền cho ";
                            });
                    }
                    this.titleHeaderModal = `Phiếu chi ${this.receiptPayment.receipt_payment_number}`;
                }
                this.renderAccountings();
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện đóng popup modal
         * @param {*} typeClose: Kiểu đóng(0: Đóng luôn, 1: Kiểm tra thay đổi và chờ xác nhận đóng)
         * @author: DUONGPV (04/10/2022)
         */
        onHandleHideModal(typeClose) {
            try {
                let isChange = false;
                if (!this.receiptPayment.receipt_payment_id) {
                    isChange = common.objCompare(
                        this.receiptPayment,
                        this.newObject
                    );
                } else {
                    isChange = true;
                }

                if (typeClose == 0) {
                    if (!isChange) {
                        this.popupData = {
                            typePopup: 0,
                            footerPopup: {
                                footerLeft: [
                                    {
                                        buttonName: "Hủy",
                                        buttonAction: this.onHandleHidePopup,
                                        classButton: "",
                                        valueFunction: "",
                                    },
                                ],
                                footerRight: [
                                    {
                                        buttonName: "Không",
                                        buttonAction: this.onHandleHideModal,
                                        classButton: "",
                                        valueFunction: 1,
                                    },
                                    {
                                        buttonName: "Có",
                                        buttonAction: this.onSave,
                                        classButton: ["btn-confirm"],
                                        valueFunction: "",
                                    },
                                ],
                                enterKeyFunc: this.onSave,
                                escKeyFunc: this.onHandleHidePopup,
                            },

                            noticeMessage:
                                "Dữ liệu đã bị thay đổi. Bạn có muốn cất không?",
                        };
                        this.isShowPopup = true;
                    } else {
                        this.isShowModal = false;
                        this.isShowPopup = false;
                    }
                } else if (typeClose == 1) {
                    this.isShowModal = false;
                    this.isShowPopup = false;
                }
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện cập nhật giá trị đối tượng ReceiptPayment
         * @param {*} valueField: Giá trị cần cập nhật
         * @param {*} dataField: Trường thông tin cần cập nhật
         * @author: DUONGPV (04/10/2022)
         */
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
                } else if (dataField == "account_object_name") {
                    var nameReason = this.receiptPayment.reason.slice(13);
                    if (
                        this.typeVoucher == 0 &&
                        (this.receiptPayment.reason == "Thu tiền của " ||
                            nameReason ==
                                this.receiptPayment.account_object_name)
                    ) {
                        this.receiptPayment.account_object_name = valueField;
                        this.setValueRecieptPayment(
                            `Thu tiền của ${valueField}`,
                            "reason"
                        );
                    } else if (
                        this.typeVoucher == 1 &&
                        (this.receiptPayment.reason == "Chi tiền cho " ||
                            nameReason ==
                                this.receiptPayment.account_object_name)
                    ) {
                        this.setValueRecieptPayment(
                            `Chi tiền cho ${valueField}`,
                            "reason"
                        );
                    }
                    this.receiptPayment.account_object_name = valueField;
                } else if (
                    typeof valueField == "object" &&
                    valueField &&
                    dataField == "employee_id"
                ) {
                    this.receiptPayment.employee_id =
                        valueField["account_object_id"];
                    this.receiptPayment.employee_name =
                        valueField["account_object_name"];
                } else if (dataField == "accounting_date") {
                    if (
                        this.receiptPayment.accounting_date ==
                        this.receiptPayment.receipt_payment_date
                    ) {
                        this.receiptPayment.accounting_date = valueField;
                        this.receiptPayment.receipt_payment_date = valueField;
                    } else {
                        this.receiptPayment.accounting_date = valueField;
                    }
                    this.keyFormComponent += 1;
                } else if (dataField == "reason") {
                    for (let i = 0; i < this.receiptPaymentDetail.length; i++) {
                        if (
                            this.receiptPaymentDetail[i].reason ==
                            this.receiptPayment.reason
                        ) {
                            this.receiptPaymentDetail[i].reason = valueField;
                        }
                    }
                    this.receiptPayment.reason = valueField;
                } else if (typeof valueField != "object") {
                    this.receiptPayment[dataField] = valueField;
                }
                this.renderAccountings();
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện cập nhật giá trị đối tượng ReceiptPaymentDetail
         * @param {*} value: Giá trị cần cập nhật
         * @author: DUONGPV (04/10/2022)
         */
        setValueRecieptPaymentDetail(value) {
            try {
                this.receiptPaymentDetail = value;
                this.renderAccountings();
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện render dữ liệu bảng Hạch toán
         * @author: DUONGPV (04/10/2022)
         */
        renderAccountings() {
            try {
                this.receiptPaymentDetail = this.receiptPaymentDetail.map(
                    (item) => {
                        if (typeof item.amount_money == "string") {
                            item.amount_money = Number(
                                item.amount_money.replace(/\D+/g, "")
                            );
                        }
                        return {
                            reason: item.reason,
                            debt_account: item.debt_account,
                            credit_account: item.credit_account,
                            amount_money: common.formatDecimalCurrency(
                                item.amount_money
                            ),
                            account_object_id: item.account_object_id,
                            account_object_code: item.account_object_code,
                            account_object_name: item.account_object_name,
                            receipt_payment_id: item.receipt_payment_id,
                            created_date: item.created_date,
                            created_by: item.created_by,
                            modified_date: item.modified_date,
                            modified_by: item.modified_by,
                        };
                    }
                );
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện lưu thông tin lỗi khi người dùng đang thao tác trên form đối tượng ReceiptPayment
         * @param {*} isError: True hoặc False
         * @param {*} errorMessage: Message thông báo lỗi
         * @param {*} dataField: Trường bị lỗi
         * @author: DUONGPV (04/10/2022)
         */
        setValidateReceiptPayment(isError, errorMessage, dataField) {
            try {
                if (
                    this.validateReceiptPayment != null &&
                    this.validateReceiptPayment.length > 0
                ) {
                    var field = this.validateReceiptPayment.findIndex((e) => {
                        return e.fieldName == dataField;
                    });
                    if (field != -1) {
                        this.validateReceiptPayment[field].isInValid = isError;
                        this.validateReceiptPayment[field].errorMessage =
                            errorMessage;
                    } else {
                        this.validateReceiptPayment.push({
                            isInValid: isError,
                            fieldName: dataField,
                            errorMessage: errorMessage,
                        });
                    }
                } else {
                    this.validateReceiptPayment.push({
                        isInValid: isError,
                        fieldName: dataField,
                        errorMessage: errorMessage,
                    });
                }
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện lưu thông tin lỗi khi người dùng đang thao tác trên form đối tượng ReceiptPaymentDetail
         * @param {*} isError: True hoặc False
         * @param {*} errorMessage: Message thông báo lỗi
         * @param {*} dataField: Trường bị lỗi
         * @param {*} rowIndex: Dòng có trường bị lỗi
         * @author: DUONGPV (04/10/2022)
         */
        setValidateReceiptPaymentDetail(
            isError,
            errorMessage,
            dataField,
            rowIndex
        ) {
            try {
                if (
                    this.validateReceiptPaymentDetail != null &&
                    this.validateReceiptPaymentDetail.length > 0
                ) {
                    var field = this.validateReceiptPaymentDetail.findIndex(
                        (e) => {
                            return (
                                e.fieldName == dataField &&
                                e.rowIndex == rowIndex
                            );
                        }
                    );
                    if (field != -1) {
                        this.validateReceiptPaymentDetail[field].isInValid =
                            isError;
                        this.validateReceiptPaymentDetail[field].errorMessage =
                            errorMessage;
                        this.validateReceiptPaymentDetail[field].rowIndex =
                            rowIndex;
                    } else {
                        this.validateReceiptPaymentDetail.push({
                            isInValid: isError,
                            fieldName: dataField,
                            errorMessage: errorMessage,
                            rowIndex: rowIndex,
                        });
                    }
                } else {
                    this.validateReceiptPaymentDetail.push({
                        isInValid: isError,
                        fieldName: dataField,
                        errorMessage: errorMessage,
                        rowIndex: rowIndex,
                    });
                }
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện kiểm tra dữ liệu ReceiptPayment sau khi ấn lưu
         * @author: DUONGPV (04/10/2022)
         */
        async checkEmptyReceiptPayment() {
            try {
                if (
                    this.receiptPayment.accounting_date <
                    this.receiptPayment.receipt_payment_date
                ) {
                    await this.setValidateReceiptPayment(
                        true,
                        `Ngày hạch toán phải lớn hơn hoặc bằng Ngày chứng từ
                        <${common.formatDateWithType(
                            this.receiptPayment.receipt_payment_date,
                            "DD/MM/YYYY"
                        )}>. Xin vui lòng kiểm tra lại.`,
                        "accounting_date"
                    );
                }
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện kiểm tra dữ liệu ReceiptPayment sau khi ấn lưu
         * @author: DUONGPV (04/10/2022)
         */
        async checkValidateReceiptPayment() {
            try {
                await this.checkEmptyReceiptPayment();
                var listValidate = this.validateReceiptPayment.filter((e) => {
                    return e.isInValid == true;
                });
                if (listValidate.length > 0) {
                    var noticeMessage = listValidate[0].errorMessage;
                    this.popupData = {
                        typePopup: 1,
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
                            escKeyFunc: this.onHandleHidePopup,
                        },
                        noticeMessage: noticeMessage,
                    };
                    return true;
                }
                return false;
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện kiểm tra dữ liệu ReceiptPaymentDetail sau khi ấn lưu
         * @author: DUONGPV (04/10/2022)
         */
        async checkValidateReceiptPaymentDetail() {
            try {
                if (this.receiptPaymentDetail.length == 0) {
                    await this.setValidateReceiptPaymentDetail(
                        true,
                        "Bạn phải nhập chứng từ chi tiết",
                        "debt_account",
                        0
                    );
                } else {
                    this.receiptPaymentDetail.forEach(async (item, index) => {
                        if (item.debt_account == "") {
                            await this.setValidateReceiptPaymentDetail(
                                true,
                                "Tài khoản nợ không được để trống!",
                                "debt_account",
                                index
                            );
                        }

                        if (item.credit_account == "") {
                            await this.setValidateReceiptPaymentDetail(
                                true,
                                "Tài khoản có không được để trống!",
                                "credit_account",
                                index
                            );
                        }
                    });
                }

                var listValidate = this.validateReceiptPaymentDetail.filter(
                    (e) => {
                        return e.isInValid == true;
                    }
                );
                if (listValidate.length > 0) {
                    var noticeMessage = listValidate[0].errorMessage;
                    this.popupData = {
                        typePopup: 1,
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
                            escKeyFunc: this.onHandleHidePopup,
                        },
                        noticeMessage: noticeMessage,
                    };
                    return true;
                }
                return false;
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện cập nhật giá trị trường lỗi đầu tiên cần focus của đối tượng ReceiptPayment
         * @param {*} fieldError: Trường bị lỗi đầu tiền
         * @author: DUONGPV (04/10/2022)
         */
        setFieldReceiptPaymentErrorFocus(fieldError) {
            try {
                this.fieldErrorReceiptPaymentFocus = fieldError;
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện cập nhật giá trị trường lỗi đầu tiên cần focus của đối tượng ReceiptPaymentDetail
         * @param {*} fieldError: Trường bị lỗi đầu tiền
         * @param {*} rowIndex: Dòng có trường bị lỗi
         * @author: DUONGPV (04/10/2022)
         */
        setFieldReceiptPaymentDetailErrorFocus(fieldError, rowIndex) {
            try {
                this.fieldErrorReceiptPaymentDetailFocus = {
                    fieldError: fieldError,
                    rowIndex: rowIndex,
                };
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện cập nhật giá trị popup để hiển thị thông báo
         * @param {*} popupData: Dữ liệu của popup thông báo cần hiển thị
         * @author: DUONGPV (04/10/2022)
         */
        setPopupData(popupData) {
            try {
                this.popupData = popupData;
                this.isShowPopup = true;
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
