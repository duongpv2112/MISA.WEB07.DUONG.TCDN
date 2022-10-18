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
                :receiptPaymentDetail="receiptDetail"
                :addRow="addRowAccounting"
                :removeRow="removeRowAccounting"
                :removeAllRow="removeAllRowAccounting"
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

                    this.receiptDetail = [
                        {
                            id: common.createUUID(),
                            reason: "Thu tiền của Công ty Hoàng Đức Cường",
                            debt_account: "610221272652",
                            credit_account: "291231754285",
                            amount_money: 41730800.9187,
                            account_object_id:
                                "03ff3c09-79b2-4343-ad03-fb0202cbb2d7",
                            account_object_code: "",
                            account_object_name: "Công ty Phạm Đức Sang",
                            bank_account: "636016688056",
                            loan_contract: "2126784201",
                            receipt_id: "01ea9d77-6c31-47e6-af16-94c391bac238",
                            created_date: "2022-08-03T16:58:54.468Z",
                            created_by: "Hoàng Đức Quang",
                            modified_date: "2022-04-02T16:41:29.015Z",
                            modified_by: "Hoàng Đức Quốc",
                        },
                        {
                            id: common.createUUID(),
                            reason: "Thu tiền của Công ty Kiều Khắc Cường",
                            debt_account: "813553811419",
                            credit_account: "687958343100",
                            amount_money: 242754544.851,
                            account_object_id:
                                "1086d028-e690-4441-94a6-f640f474f26f",
                            account_object_code: "",
                            account_object_name: "Công ty Phạm Minh Dũng",
                            bank_account: "563177028567",
                            loan_contract: "0558613124",
                            receipt_id: "01ea9d77-6c31-47e6-af16-94c391bac238",
                            created_date: "2022-08-25T03:43:31.527Z",
                            created_by: "Phan Đức Tài",
                            modified_date: "2022-05-23T02:52:54.227Z",
                            modified_by: "Phan Khắc Vinh",
                        },
                        {
                            id: common.createUUID(),
                            reason: "Thu tiền của Công ty Lê Đức Tài",
                            debt_account: "833651827636",
                            credit_account: "283884627346",
                            amount_money: 139765760.606,
                            account_object_id:
                                "1c3c1ccd-7ddc-4023-9e3a-ce04b4975b34",
                            account_object_code: "",
                            account_object_name: "Công ty Bùi Đức Cường",
                            bank_account: "210502827726",
                            loan_contract: "5893270883",
                            receipt_id: "01ea9d77-6c31-47e6-af16-94c391bac238",
                            created_date: "2022-03-16T11:48:31.742Z",
                            created_by: "Nguyễn Khắc Hải",
                            modified_date: "2022-03-19T20:43:38.343Z",
                            modified_by: "Kiều Mỹ Giang",
                        },
                        {
                            id: common.createUUID(),
                            reason: "Thu tiền của Công ty Tống Khắc Cường",
                            debt_account: "561051281281",
                            credit_account: "321333521092",
                            amount_money: 160043568.8128,
                            account_object_id:
                                "26850076-ad2c-4b48-ad99-0fc9728f54e2",
                            account_object_code: "",
                            account_object_name: "Công ty Phạm Đức Công",
                            bank_account: "284620281861",
                            loan_contract: "6342883275",
                            receipt_id: "01ea9d77-6c31-47e6-af16-94c391bac238",
                            created_date: "2022-09-03T23:07:44.044Z",
                            created_by: "Lê Khắc Tân",
                            modified_date: "2021-09-23T21:46:49.902Z",
                            modified_by: "Ngô Đức Vinh",
                        },
                    ];

                    this.receiptPayment = {
                        account_object_code: null,
                        account_object_contact_name: "Kiều Thị Nhật",
                        account_object_id:
                            "1d04944c-93e9-4ccd-9942-12b63dc5d248",
                        account_object_name: "Công ty Hồ Minh Huy",
                        accounting_date: "2021-02-02T00:00:00",
                        adding_number: 1,
                        address: "1 Military Dr. Lansdale, PA 19446",
                        created_by: "Nguyễn Việt Cường",
                        created_date: "2022-09-09T23:59:37.757",
                        employee_id: null,
                        employee_name: "Phạm Việt Dương",
                        modified_by: "Hoàng Trường Sang",
                        modified_date: "2022-07-30T20:29:07.934",
                        reason: "Thu tiền của Công ty Dương Khắc Hậu",
                        receipt_payment_date: "2021-12-27T00:00:00",
                        receipt_payment_id:
                            "008ce717-c600-4d6f-a45a-3bbacd6c0d4f",
                        receipt_payment_number: "PT-340040",
                        total_money: 230626608.8958,
                    };
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

                    this.receiptPayment = {
                        account_object_code: null,
                        account_object_contact_name: "Kiều Thị Nhật",
                        account_object_id:
                            "1d04944c-93e9-4ccd-9942-12b63dc5d248",
                        account_object_name: "Công ty Hồ Minh Huy",
                        accounting_date: "2021-02-02T00:00:00",
                        adding_number: 1,
                        address: "1 Military Dr. Lansdale, PA 19446",
                        created_by: "Nguyễn Việt Cường",
                        created_date: "2022-09-09T23:59:37.757",
                        employee_id: null,
                        modified_by: "Hoàng Trường Sang",
                        modified_date: "2022-07-30T20:29:07.934",
                        reason: "Thu tiền của Công ty Dương Khắc Hậu",
                        receipt_payment_date: "2021-12-27T00:00:00",
                        receipt_payment_id:
                            "008ce717-c600-4d6f-a45a-3bbacd6c0d4f",
                        receipt_payment_number: "PT-340040",
                        total_money: 230626608.8958,
                    };
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
                    this.receiptDetail.push({
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
                    this.receiptDetail = [
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
                    this.receiptDetail = this.receiptDetail.filter((item) => {
                        return item != valueRow;
                    });
                } else if (type == this.ENUM.TYPE_PAYMENT) {
                    this.receiptDetail = [
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
                    this.receiptDetail = [];
                } else if (type == this.ENUM.TYPE_PAYMENT) {
                    this.receiptDetail = [
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
