<template>
    <main class="container-page receipt">
        <div class="container-page__top mb-0">
            <div class="d-flex justify-space-between">
                <h2 class="container-page__title pl-10">
                    {{ RESOURCE.RECEIPT_PAYMENT_PAGE_HEADER }}
                </h2>
                <div class="d-flex">
                    <div class="guide-tour d-flex flex-center">
                        <span class="icon square-24 icon-tour"></span>
                        <a href="#" class="guide-tour__link">Hướng dẫn</a>
                    </div>
                    <div
                        class="d-flex"
                        :class="{
                            'mr-12':
                                filterValue != ENUM.TYPE_RECEIPT ||
                                filterValue == null,
                        }"
                        v-if="
                            (filterValue == ENUM.TYPE_RECEIPT &&
                                filterValue != ENUM.TYPE_PAYMENT) ||
                            filterValue == null
                        "
                    >
                        <BaseButton
                            :title="RESOURCE.RECEIPT_PAYMENT_ADD_RECEIPT_BTN"
                            :className="[
                                'button-text',
                                'button-default',
                                'button-primary',
                                'button-radius-left',
                            ]"
                            :functionz="onHandleShowModal"
                            :paramFunction="ENUM.TYPE_RECEIPT"
                        />
                        <BaseButton
                            :isIcon="true"
                            :className="[
                                'button-icon-padding',
                                'button-primary',
                                'button-radius-right',
                            ]"
                            :classNameIcon="[
                                'square-16',
                                'icon-arrow-up--white',
                            ]"
                        />
                    </div>

                    <div
                        class="d-flex"
                        v-if="
                            (filterValue != ENUM.TYPE_RECEIPT &&
                                filterValue == ENUM.TYPE_PAYMENT) ||
                            filterValue == null
                        "
                    >
                        <BaseButton
                            :title="RESOURCE.RECEIPT_PAYMENT_ADD_PAYMENT_BTN"
                            :className="[
                                'button-text',
                                'button-default',
                                'button-primary',
                                'button-radius-left',
                            ]"
                            :functionz="onHandleShowModal"
                            :paramFunction="ENUM.TYPE_PAYMENT"
                        />
                        <BaseButton
                            :isIcon="true"
                            :className="[
                                'button-icon-padding',
                                'button-primary',
                                'button-radius-right',
                            ]"
                            :classNameIcon="[
                                'square-16',
                                'icon-arrow-up--white',
                            ]"
                        />
                    </div>
                </div>
            </div>
        </div>

        <div v-show="!isCollapseResponse" class="container-page__overview">
            <div class="d-flex">
                <div
                    class="overview-item overview-item__with-draw bg-with-draw"
                >
                    <div class="overview-item__content">
                        <div class="total-money">1.335.208.978</div>
                        <div class="lable-overview">
                            Tổng thu đầu năm đến hiện tại
                        </div>
                    </div>
                </div>

                <div class="overview-item overview-item__deposit bg-deposit">
                    <div class="overview-item__content">
                        <div class="total-money">47.155.167.800</div>
                        <div class="lable-overview">
                            Tổng chi đầu năm đến hiện tại
                        </div>
                    </div>
                </div>

                <div class="overview-item overview-item__remain bg-remain">
                    <div class="overview-item__content">
                        <div class="total-money">1.948.573.501</div>
                        <div class="lable-overview">Tồn quỹ hiện tại</div>
                    </div>
                </div>
            </div>
        </div>

        <div class="container-page__tabs-filter">
            <ul class="tabs-filter__list">
                <li
                    class="tabs-filter__item"
                    :class="{
                        'active-filter':
                            !filterValue && filterValue != ENUM.TYPE_RECEIPT,
                    }"
                >
                    <div
                        class="tabs-filter__item-content"
                        @click="onHandleFilter(ENUM.TYPE_RECEIPT_PAYMENT)"
                    >
                        Tất cả
                    </div>
                </li>
                <li
                    class="tabs-filter__item"
                    :class="{
                        'active-filter': filterValue == ENUM.TYPE_RECEIPT,
                    }"
                >
                    <div
                        class="tabs-filter__item-content"
                        @click="onHandleFilter(ENUM.TYPE_RECEIPT)"
                    >
                        Thu tiền
                    </div>
                </li>
                <li
                    class="tabs-filter__item"
                    :class="{
                        'active-filter': filterValue == ENUM.TYPE_PAYMENT,
                    }"
                >
                    <div
                        class="tabs-filter__item-content"
                        @click="onHandleFilter(ENUM.TYPE_PAYMENT)"
                    >
                        Chi tiền
                    </div>
                </li>
            </ul>
        </div>

        <div
            class="container-page__container p-relative"
            :class="{
                'hide-collapse': isCollapseResponse,
            }"
        >
            <div class="container-page__toolbar">
                <div class="container-page__toolbar-left">
                    <div class="d-flex">
                        <div class="arrow-check-all">
                            <span
                                class="icon square-24 icon-arrow-check-all"
                            ></span>
                        </div>
                        <div class="container-page__toolbar-all mr-12">
                            <div
                                class="d-flex flex-center container-page__toolbar-content"
                            >
                                <span class="container-page__toolbar-all--text">
                                    {{
                                        RESOURCE.RECEIPT_PAYMENT_ACTION_ALL_BTN
                                    }}
                                </span>
                                <span
                                    class="square-16 icon icon-arrow-down"
                                ></span>
                            </div>

                            <div
                                class="container-page__toolbar-option"
                                v-if="false"
                            >
                                <a class="toolbar-option__item">
                                    {{ RESOURCE.RECEIPT_PAYMENT_DELETE_BTN }}
                                </a>
                            </div>
                        </div>

                        <div class="container-page__toolbar-all">
                            <div
                                class="d-flex flex-center container-page__toolbar-content"
                            >
                                <span class="container-page__toolbar-all--text">
                                    {{ RESOURCE.RECEIPT_PAYMENT_FILTER_BTN }}
                                </span>
                                <span
                                    class="square-16 icon icon-arrow-down"
                                ></span>
                            </div>

                            <div
                                class="container-page__toolbar-option"
                                v-if="false"
                            ></div>
                        </div>
                    </div>
                </div>
                <div class="container-page__toolbar-right">
                    <div class="toolbar-search mr-12">
                        <input
                            type="text"
                            name="txtSearch"
                            :placeholder="
                                RESOURCE.RECEIPT_PAYMENT_SEARCH_PLACEHOLDER
                            "
                            class="toolbar-search__input"
                            ref="txtSearch"
                            autocomplete="off"
                            @keypress.enter.prevent="
                                onHandleSearch($event.target.value)
                            "
                        />
                        <label
                            for="txtSearch"
                            class="toolbar-search__icon icon icon-search"
                        ></label>
                    </div>
                    <button
                        class="toolbar-button tooltip"
                        @click="onHandleReload"
                    >
                        <span class="d-block square-24 icon icon-refresh">
                        </span>
                        <BaseTooltip
                            :content="'Lấy lại dữ liệu'"
                            :className="['tooltip-default--header']"
                        />
                    </button>
                    <button class="toolbar-button tooltip">
                        <span class="d-block square-24 icon icon-excel"></span>
                        <BaseTooltip
                            :content="'Xuất ra Excel'"
                            :className="['tooltip-default--header']"
                        />
                    </button>
                    <button class="toolbar-button tooltip">
                        <span
                            class="d-block square-24 icon icon-setting-list"
                        ></span>
                        <BaseTooltip
                            :content="'Tùy chỉnh giao diện'"
                            :className="['tooltip-default--header']"
                        />
                    </button>
                </div>
            </div>
            <div class="container-page__table">
                <ReceiptPaymentGrid
                    :dataReady="dataReady"
                    :data="data"
                    :totalCount="totalCount"
                    :currentPage="currentPage"
                    :currentRecord="currentRecord"
                    :onHandlePageChange="onHandlePageChange"
                    :onHandlePageSizeChange="onHandlePageSizeChange"
                    :onEdit="onEdit"
                    :onDelete="onDelete"
                    :onDetail="onDetail"
                    :onReplication="onReplication"
                    :dataFooter="dataFooter"
                />
            </div>
            <div
                class="container-page__response d-flex flex-center"
                @click="setCollapse"
            >
                <div
                    class="icon square-16 icon"
                    :class="{
                        'icon-chevron-down--primary': isCollapseResponse,
                        'icon-chevron-up--primary': !isCollapseResponse,
                    }"
                ></div>
            </div>
        </div>
    </main>
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
                :receiptPaymentDetail="receiptPaymentDetail"
                :addRow="addRowAccounting"
                :removeRow="removeRowAccounting"
                :removeAllRow="removeAllRowAccounting"
                :setValue="setValueRecieptPayment"
                :key="keyForm"
            />
        </template>
    </BaseModal>
</template>
<script>
import { RECEIPT_PAYMENT_TEXT_CONFIG } from "@/views/CashPage/ReceiptPayment/constants/resources";
import { RECEIPT_PAYMENT_ENUM } from "@/views/CashPage/ReceiptPayment/constants/enums";
import { API_RESOURCE } from "@/views/CashPage/ReceiptPayment/constants/api";
import { common } from "@/libs/common/common";
import api from "@/services/api";
import BaseButton from "@/components/bases/BaseButton/BaseButton.vue";
import BaseTooltip from "@/components/bases/BaseTooltip/BaseTooltip.vue";
import ReceiptPaymentGrid from "./components/ReceiptPaymentGrid.vue";
import BaseModal from "@/components/bases/BaseModal/BaseModal.vue";
import ReceiptPaymentFormHeader from "./components/ReceiptPaymentFormHeader.vue";
import ReceiptPaymentForm from "./components/ReceiptPaymentForm.vue";

export default {
    name: "ReceiptPaymentContainer",

    components: {
        BaseButton,
        BaseTooltip,
        ReceiptPaymentGrid,
        BaseModal,
        ReceiptPaymentFormHeader,
        ReceiptPaymentForm,
    },

    data() {
        return {
            dataReady: Boolean,

            totalCount: Number,

            totalPage: Number,

            currentPage: Number,

            currentRecord: Number,

            keyWord: String,

            data: [],

            keyGrid: 0,

            RESOURCE: RECEIPT_PAYMENT_TEXT_CONFIG,

            ENUM: RECEIPT_PAYMENT_ENUM,

            isCollapseResponse: Boolean,

            filterValue: null,

            dataFooter: {
                isShow: true,
                data: null,
                firstColumn: {
                    nameColumn: "accounting_date",
                    valueColumn: "Tổng",
                },
                columnShow: "total_money",
            },

            listDataCombobox: Array,

            isShowModal: Boolean,

            isViewDetail: Boolean,

            titleHeaderModal: String,

            valueTypeVoucher: String,

            typeVoucher: null,

            columnsAccouting: Array,

            receiptDetail: null,

            receiptPayment: null,

            keyForm: 0,
        };
    },

    methods: {
        async getReceiptPayments(
            pageSize,
            pageNumber,
            keyword,
            filter,
            orderBy
        ) {
            try {
                let urlFilter = `${API_RESOURCE.PAGING_DATA_RECEIPT_PAYMENT}?pageSize=${pageSize}&pageNumber=${pageNumber}`;
                if (keyword) {
                    urlFilter += `&keyword=${keyword}`;
                }
                if (filter || filter == 0) {
                    urlFilter += `&filter=${filter}`;
                }
                if (orderBy) {
                    urlFilter += `&orderBy=${orderBy}`;
                }
                await api
                    .get(urlFilter)
                    .then((data) => {
                        this.data = data.data;
                        this.totalCount = data.totalCount;
                        this.currentRecord = data.currentRecord;
                        this.currentPage = data.currentPage;
                        this.totalPage = data.totalPage;
                        this.keyWord = data.keyWord;
                        this.filterValue = data.filter;
                        this.dataFooter.data = common.formatDecimalCurrency(
                            data.summaryData.totalMoney
                        );
                        this.keyGrid += 1;
                        this.renderTable();
                    })
                    .finally(() => {
                        this.dataReady = true;
                    });
            } catch (error) {
                console.log(error);
            }
        },

        async onHandlePageChange(pageNumber) {
            try {
                this.dataReady = false;
                await this.getReceiptPayments(
                    this.currentRecord,
                    pageNumber,
                    this.keyWord,
                    this.filterValue
                );
            } catch (error) {
                console.log(error);
            }
        },

        async onHandlePageSizeChange(pageSize) {
            try {
                this.dataReady = false;
                await this.getReceiptPayments(
                    pageSize,
                    this.currentPage,
                    this.keyWord,
                    this.filterValue
                );
            } catch (error) {
                console.log(error);
            }
        },

        async onHandleSearch(searchParams) {
            try {
                this.dataReady = false;
                await this.getReceiptPayments(
                    this.currentRecord,
                    1,
                    searchParams.trim(),
                    this.filterValue
                );
            } catch (error) {
                console.log(error);
            }
        },

        async onHandleReload() {
            try {
                this.dataReady = false;
                await this.getReceiptPayments(
                    this.currentRecord,
                    this.currentPage,
                    this.keyWord,
                    this.filterValue
                );
            } catch (error) {
                console.log(error);
            }
        },

        async onHandleFilter(filter) {
            try {
                this.filterValue = filter;
                this.dataReady = false;
                await this.getReceiptPayments(
                    this.currentRecord,
                    1,
                    this.keyWord,
                    filter
                );
            } catch (error) {
                console.log(error);
            }
        },

        async renderTable() {
            try {
                this.data = this.data.map((item) => {
                    return {
                        receipt_payment_id: item.receipt_payment_id,
                        accounting_date: common.formatDateWithType(
                            item.accounting_date,
                            "DD/MM/YYYY"
                        ),
                        receipt_payment_date: common.formatDateWithType(
                            item.receipt_payment_date,
                            "DD/MM/YYYY"
                        ),
                        receipt_payment_number: item.receipt_payment_number,
                        account_object_id: item.account_object_id,
                        account_object_name: item.account_object_name,
                        account_object_contact_name:
                            item.account_object_contact_name,
                        address: item.address,
                        employee_id: item.employee_id,
                        reason: item.reason,
                        adding_number: item.adding_number,
                        total_money: common.formatDecimalCurrency(
                            item.total_money
                        ),
                        created_date: item.created_date,
                        created_by: item.created_by,
                        modified_date: item.modified_date,
                        modified_by: item.modified_by,
                        account_object_code: item.account_object_code,
                    };
                });
            } catch (error) {
                console.log(error);
            }
        },

        setCollapse() {
            try {
                this.isCollapseResponse = !this.isCollapseResponse;
            } catch (error) {
                console.log(error);
            }
        },

        async onEdit(value) {
            try {
                console.log(value);
            } catch (error) {
                console.log(error);
            }
        },

        onDelete(value) {
            try {
                console.log(value);
            } catch (error) {
                console.log(error);
            }
        },

        async onHandleDelete(id) {
            try {
                console.log(id);
            } catch (error) {
                console.log(error);
            }
        },

        async onDetail(value) {
            try {
                console.log(value);
            } catch (error) {
                console.log(error);
            }
        },

        onReplication(value) {
            try {
                console.log(value);
            } catch (error) {
                console.log(error);
            }
        },

        async onSave(type) {
            try {
                console.log(type);
            } catch (error) {
                console.log(error);
            }
        },

        onHandleShowModal(type) {
            try {
                if (type == this.ENUM.TYPE_RECEIPT) {
                    this.titleHeaderModal = "Phiếu thu PT-312312";

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
                            },
                            dataCombobox: {
                                isCombobox: true,
                                url: API_RESOURCE.PAGING_DATA_ACCOUNT,
                                propValue: "account_number",
                                propText: "account_number",
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
                            },
                            dataCombobox: {
                                isCombobox: true,
                                url: API_RESOURCE.PAGING_DATA_ACCOUNT,
                                propValue: "account_number",
                                propText: "account_number",
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
                            },
                            dataCombobox: {
                                isCombobox: false,
                            },
                        },
                    ];

                    this.receiptPayment = {
                        account_object_code: "",
                        account_object_contact_name: "",
                        account_object_id: "",
                        account_object_name: "",
                        accounting_date: new Date(),
                        adding_number: 0,
                        address: "",
                        created_by: "",
                        created_date: "",
                        employee_id: "",
                        employee_name: "",
                        modified_by: "",
                        modified_date: "",
                        reason: "Thu tiền của ",
                        receipt_payment_date: new Date(),
                        receipt_payment_id: "",
                        receipt_payment_number: "",
                        total_money: 0,
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
                    this.titleHeaderModal = "Phiếu chi PC-312312";

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
                            },
                            dataCombobox: {
                                isCombobox: true,
                                url: API_RESOURCE.PAGING_DATA_ACCOUNT,
                                propValue: "account_number",
                                propText: "account_number",
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
                            },
                            dataCombobox: {
                                isCombobox: true,
                                url: API_RESOURCE.PAGING_DATA_ACCOUNT,
                                propValue: "account_number",
                                propText: "account_number",
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
                            },
                            dataCombobox: {
                                isCombobox: false,
                            },
                        },
                    ];

                    this.receiptPayment = {
                        account_object_code: "",
                        account_object_contact_name: "",
                        account_object_id: "",
                        account_object_name: "",
                        accounting_date: new Date(),
                        adding_number: 0,
                        address: "",
                        created_by: "",
                        created_date: "",
                        employee_id: "",
                        employee_name: "",
                        modified_by: "",
                        modified_date: "",
                        reason: "Chi tiền cho ",
                        receipt_payment_date: new Date(),
                        receipt_payment_id: "",
                        receipt_payment_number: "",
                        total_money: 0,
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
                this.typeVoucher = type;
                this.isShowModal = true;
            } catch (error) {
                console.log(error);
            }
        },

        onHandleHideModal() {
            try {
                this.isShowModal = false;
            } catch (error) {
                console.log(error);
            }
        },

        addRowAccounting(type) {
            try {
                if (type == this.ENUM.TYPE_RECEIPT) {
                    this.receiptPaymentDetail.push({
                        id: common.createUUID(),
                        reason: "",
                        debt_account: "",
                        credit_account: "",
                        amount_money: "",
                        account_object_id: "",
                        account_object_code: "",
                        account_object_name: "",
                    });
                } else if (type == this.ENUM.TYPE_PAYMENT) {
                    this.receiptPaymentDetail = [
                        {
                            reason: "",
                            debt_account: "",
                            credit_account: "",
                            amount_money: "",
                            account_object_id: "",
                            account_object_code: "",
                            account_object_name: "",
                        },
                    ];
                }
                this.typeVoucher = type;
                this.isShowModal = true;
            } catch (error) {
                console.log(error);
            }
        },

        removeRowAccounting(type, valueRow) {
            try {
                if (type == this.ENUM.TYPE_RECEIPT) {
                    this.receiptPaymentDetail =
                        this.receiptPaymentDetail.filter((item) => {
                            return item != valueRow;
                        });
                } else if (type == this.ENUM.TYPE_PAYMENT) {
                    this.receiptPaymentDetail = [
                        {
                            reason: "",
                            debt_account: "",
                            credit_account: "",
                            amount_money: "",
                            account_object_id: "",
                            account_object_code: "",
                            account_object_name: "",
                        },
                    ];
                }
                this.typeVoucher = type;
                this.isShowModal = true;
            } catch (error) {
                console.log(error);
            }
        },

        removeAllRowAccounting(type) {
            try {
                if (type == this.ENUM.TYPE_RECEIPT) {
                    this.receiptPaymentDetail = [];
                } else if (type == this.ENUM.TYPE_PAYMENT) {
                    this.receiptPaymentDetail = [
                        {
                            reason: "",
                            debt_account: "",
                            credit_account: "",
                            amount_money: "",
                            account_object_id: "",
                            account_object_code: "",
                            account_object_name: "",
                        },
                    ];
                }
                this.typeVoucher = type;
                this.isShowModal = true;
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
                }
                // this.keyForm += 1;
                this.$forceUpdate();
            } catch (error) {
                console.log(error);
            }
        },
    },

    created() {
        this.isCollapseResponse = false;
        this.dataReady = false;
        this.currentRecord = 20;
        this.currentPage = 1;
        this.totalCount = 0;
        this.isShowModal = false;
        this.getReceiptPayments(this.currentRecord, this.currentPage);
    },
};
</script>
<style scoped>
@import url("./receipt.css");
</style>
