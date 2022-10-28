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

                    <div class="mr-12" v-if="false">
                        <BaseButton
                            :isIconText="true"
                            :title="RESOURCE.RECEIPT_PAYMENT_UTILITIES_BTN"
                            :className="[
                                'button-text',
                                'button-border',
                                'button-radius-all',
                                'button-icon-text-padding',
                            ]"
                            :classNameIcon="[
                                'square-16',
                                'icon-arrow-up--black',
                            ]"
                        />
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
                    <button class="toolbar-button tooltip" @click="exportData">
                        <span class="d-block square-24 icon icon-excel"></span>
                        <BaseTooltip
                            :content="'Xuất ra Excel'"
                            :className="['tooltip-default--header']"
                        />
                    </button>
                    <button
                        class="toolbar-button tooltip"
                        @click="onHandleShowSettingPage"
                    >
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
                    :columns="columns"
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
                :isViewDetail="isViewDetail"
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
                :isViewDetail="isViewDetail"
                :onHandleEdit="setIsViewDetail"
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

    <BasePopup
        v-if="popupData && isShowPopup"
        :typePopup="popupData.typePopup"
        :footerPopup="popupData.footerPopup"
        :noticeMessage="popupData.noticeMessage"
    />

    <BaseModalSetting
        v-if="isShowModalSetting"
        :propDatas="JSON.stringify(columns)"
        :propDatasDefault="JSON.stringify(columns_default)"
        :onClose="onHandleHideSettingPage"
        @onSaveTemplate="onSaveTemplate"
    />

    <BaseLoading v-if="isLoading" :className="['bg-fade']" />
</template>
<script>
import { useToast } from "vue-toastification";
import { RECEIPT_PAYMENT_TEXT_CONFIG } from "@/views/CashPage/ReceiptPayment/constants/resources";
import {
    RECEIPT_PAYMENT_ENUM,
    TYPE_CLOSE,
} from "@/views/CashPage/ReceiptPayment/constants/enums";
import { API_RESOURCE } from "@/views/CashPage/ReceiptPayment/constants/api";
import { common } from "@/libs/common/common";
import api from "@/services/api";
import template_default from "@/views/CashPage/ReceiptPayment/constants/template_default.json";
import BaseButton from "@/components/bases/BaseButton/BaseButton.vue";
import BaseTooltip from "@/components/bases/BaseTooltip/BaseTooltip.vue";
import ReceiptPaymentGrid from "./components/ReceiptPaymentGrid.vue";
import BaseModal from "@/components/bases/BaseModal/BaseModal.vue";
import ReceiptPaymentFormHeader from "./components/ReceiptPaymentFormHeader.vue";
import ReceiptPaymentForm from "./components/ReceiptPaymentForm.vue";
import BasePopup from "@/components/bases/BasePopup/BasePopup.vue";
import BaseModalSetting from "@/components/bases/BaseModalSetting/BaseModalSetting.vue";
import BaseLoading from "@/components/bases/BaseLoading/BaseLoading.vue";

export default {
    name: "ReceiptPaymentContainer",

    setup() {
        const toast = useToast();
        return { toast };
    },

    components: {
        BaseButton,
        BaseTooltip,
        ReceiptPaymentGrid,
        BaseModal,
        ReceiptPaymentFormHeader,
        ReceiptPaymentForm,
        BasePopup,
        BaseModalSetting,
        BaseLoading,
    },

    data() {
        return {
            columns: Array,

            columns_default: Array,

            dataReady: Boolean,

            totalCount: Number,

            totalPage: Number,

            currentPage: Number,

            currentRecord: Number,

            keyWord: null,

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

            receiptPaymentDetail: null,

            receiptPayment: null,

            popupData: null,

            isShowPopup: Boolean,

            fieldErrorReceiptPaymentFocus: null,
            fieldErrorReceiptPaymentDetailFocus: null,

            isShowModalSetting: Boolean,

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
                        created_date: common.formatDateWithType(
                            item.created_date,
                            "DD/MM/YYYY"
                        ),
                        created_by: item.created_by,
                        modified_date: common.formatDateWithType(
                            item.modified_date,
                            "DD/MM/YYYY"
                        ),
                        modified_by: item.modified_by,
                        account_object_code: item.account_object_code,
                        is_receipt: item.is_receipt,
                        is_payment: item.is_payment,
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
                this.isLoading = true;
                this.isViewDetail = false;
                if (value.is_receipt) {
                    let urlGetOne = `${API_RESOURCE.PAGING_DATA_RECEIPT_PAYMENT}/${value.receipt_payment_id}?typeRecord=0`;

                    await api.get(urlGetOne).then((data) => {
                        this.receiptPayment = data.receiptPayment;
                        this.receiptPaymentDetail = data.receiptPaymentDetails;
                    });
                    this.receiptPayment.is_edit = true;
                    this.receiptPayment.is_add = false;
                    await this.setValueModal(0);
                    this.typeVoucher = 0;
                } else if (value.is_payment) {
                    let urlGetOne = `${API_RESOURCE.PAGING_DATA_RECEIPT_PAYMENT}/${value.receipt_payment_id}?typeRecord=1`;

                    await api.get(urlGetOne).then((data) => {
                        this.receiptPayment = data.receiptPayment;
                        this.receiptPaymentDetail = data.receiptPaymentDetails;
                    });
                    this.receiptPayment.is_edit = true;
                    this.receiptPayment.is_add = false;
                    await this.setValueModal(1);
                    this.typeVoucher = 1;
                }
                this.isLoading = false;
                this.isShowModal = true;
            } catch (error) {
                console.log(error);
            }
        },

        onDelete(value) {
            try {
                this.popupData = {
                    typePopup: 2,
                    footerPopup: {
                        footerLeft: [
                            {
                                buttonName: "Đóng",
                                buttonAction: this.onHandleHidePopup,
                                classButton: "",
                                valueFunction: "",
                            },
                        ],
                        footerRight: [
                            {
                                buttonName: "Đồng ý",
                                buttonAction: this.onHandleDelete,
                                classButton: ["btn-confirm"],
                                valueFunction: value,
                            },
                        ],
                        enterKeyFunc: this.onHandleDelete,
                        valueEnterKeyFunc: value,
                        escKeyFunc: this.onHandleHidePopup,
                    },

                    noticeMessage: `Bạn có thực sự muốn xóa chứng từ <${value.receipt_payment_number}> không?`,
                };
                this.isShowPopup = true;
            } catch (error) {
                console.log(error);
            }
        },

        async onHandleDelete(value) {
            try {
                this.isShowPopup = false;
                this.dataReady = false;
                if (value.is_receipt) {
                    let url = `${API_RESOURCE.PAGING_DATA_RECEIPT_PAYMENT}/${value.receipt_payment_id}?typeRecord=0`;

                    await api.delete(url).then(async (data) => {
                        if (data) {
                            await this.onHandleReload();
                            this.toast.success("Xóa bản ghi thành công!");
                        }
                    });
                } else if (value.is_payment) {
                    let url = `${API_RESOURCE.PAGING_DATA_RECEIPT_PAYMENT}/${value.receipt_payment_id}?typeRecord=1`;

                    await api.delete(url).then(async (data) => {
                        if (data) {
                            await this.onHandleReload();
                            this.toast.success("Xóa bản ghi thành công!");
                        }
                    });
                }
            } catch (error) {
                console.log(error);
            }
        },

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

        async onDetail(value) {
            try {
                this.isLoading = true;
                if (value.is_receipt) {
                    let urlGetOne = `${API_RESOURCE.PAGING_DATA_RECEIPT_PAYMENT}/${value.receipt_payment_id}?typeRecord=0`;

                    await api.get(urlGetOne).then((data) => {
                        this.receiptPayment = data.receiptPayment;
                        this.receiptPaymentDetail = data.receiptPaymentDetails;
                    });
                    this.receiptPayment.is_edit = true;
                    this.receiptPayment.is_add = false;
                    await this.setValueModal(0);
                    this.isViewDetail = true;
                    this.typeVoucher = 0;
                } else if (value.is_payment) {
                    let urlGetOne = `${API_RESOURCE.PAGING_DATA_RECEIPT_PAYMENT}/${value.receipt_payment_id}?typeRecord=1`;

                    await api.get(urlGetOne).then((data) => {
                        this.receiptPayment = data.receiptPayment;
                        this.receiptPaymentDetail = data.receiptPaymentDetails;
                    });
                    this.receiptPayment.is_edit = true;
                    this.receiptPayment.is_add = false;
                    await this.setValueModal(1);
                    this.isViewDetail = true;
                    this.typeVoucher = 1;
                }
                this.isLoading = false;
                this.isShowModal = true;
            } catch (error) {
                console.log(error);
            }
        },

        async onReplication(value) {
            try {
                this.isViewDetail = false;
                this.isLoading = true;
                if (value.is_receipt) {
                    let urlGetOne = `${API_RESOURCE.PAGING_DATA_RECEIPT_PAYMENT}/${value.receipt_payment_id}?typeRecord=0`;

                    await api.get(urlGetOne).then((data) => {
                        this.receiptPayment = data.receiptPayment;
                        this.receiptPaymentDetail = data.receiptPaymentDetails;
                    });
                    this.receiptPayment.is_edit = false;
                    this.receiptPayment.is_add = true;
                    await this.setValueModal(0, true);
                    this.typeVoucher = 0;
                } else if (value.is_payment) {
                    let urlGetOne = `${API_RESOURCE.PAGING_DATA_RECEIPT_PAYMENT}/${value.receipt_payment_id}?typeRecord=1`;

                    await api.get(urlGetOne).then((data) => {
                        this.receiptPayment = data.receiptPayment;
                        this.receiptPaymentDetail = data.receiptPaymentDetails;
                    });
                    this.receiptPayment.is_edit = false;
                    this.receiptPayment.is_add = true;
                    await this.setValueModal(1, true);
                    this.typeVoucher = 1;
                }
                this.isLoading = false;
                this.isShowModal = true;
            } catch (error) {
                console.log(error);
            }
        },

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
                                    this.onHandleReload();
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
                                    this.onHandleReload();
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

        async onHandleShowModal(type) {
            try {
                this.isLoading = true;
                this.isViewDetail = false;
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

                if (typeClose == TYPE_CLOSE.TYPE_CLOSE_CHECK_CHANGE) {
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
                } else if (typeClose == TYPE_CLOSE.TYPE_CLOSE_DEFAULT) {
                    this.isShowModal = false;
                    this.isShowPopup = false;
                }
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
                } else if (dataField == "receipt_payment_date") {
                    if (
                        this.receiptPayment.accounting_date >=
                        this.receiptPayment.receipt_payment_date
                    ) {
                        this.setValidateReceiptPayment(
                            true,
                            "",
                            "accounting_date"
                        );
                    }
                    this.receiptPayment.receipt_payment_date = valueField;
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

        setValueRecieptPaymentDetail(value) {
            try {
                this.receiptPaymentDetail = value;
                this.renderAccountings();
            } catch (error) {
                console.log(error);
            }
        },

        async exportData() {
            try {
                var columnsExport = this.columns
                    .filter((item) => {
                        return item.isShow;
                    })
                    .map((item) => {
                        return {
                            caption: item.fieldName,
                            key: item.dataField,
                            width: item.width,
                        };
                    });
                columnsExport.unshift({
                    caption: "STT",
                    key: "stt",
                    width: 155,
                });
                var fileNameDownload = "";
                var reportTitle = "";
                if (
                    this.filterValue ==
                    RECEIPT_PAYMENT_ENUM.TYPE_RECEIPT_PAYMENT
                ) {
                    fileNameDownload = "Danh_sach_thu_chi_tien";
                    reportTitle = "DANH SÁCH THU CHI TIỀN";
                } else if (
                    this.filterValue == RECEIPT_PAYMENT_ENUM.TYPE_RECEIPT
                ) {
                    fileNameDownload = "Danh_sach_thu_tien";
                    reportTitle = "DANH SÁCH THU TIỀN";
                } else if (
                    this.filterValue == RECEIPT_PAYMENT_ENUM.TYPE_PAYMENT
                ) {
                    fileNameDownload = "Danh_sach_chi_tien";
                    reportTitle = "DANH SÁCH CHI TIỀN";
                }
                var bodyExport = {
                    columns: columnsExport,
                    reportTitle: reportTitle,
                    fileNameDownload: fileNameDownload,
                    keyword: this.keyWord,
                    filter: this.filterValue,
                    orderBy: "",
                };
                await api
                    .export(
                        API_RESOURCE.RECEIPT_PAYMENT_EXPORT_DATA,
                        bodyExport,
                        `${fileNameDownload}.xlsx`
                    )
                    .then((data) => {
                        if (data) {
                            console.log("a");
                        }
                    });
            } catch (error) {
                console.log(error);
            }
        },

        onHandleShowSettingPage() {
            this.isShowModalSetting = true;
        },

        onHandleHideSettingPage() {
            this.isShowModalSetting = false;
        },

        onLoadTemplate() {
            try {
                if (localStorage.getItem("receipt_payment_template") === null) {
                    this.columns = template_default;
                } else
                    this.columns = JSON.parse(
                        localStorage.getItem("receipt_payment_template")
                    );
            } catch (error) {
                console.log(error);
            }
        },

        onSaveTemplate(value) {
            try {
                this.columns = value;
                this.isShowModalSetting = false;
                localStorage.setItem(
                    "receipt_payment_template",
                    JSON.stringify(value)
                );
            } catch (error) {
                console.log(error);
            }
        },

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

        setIsViewDetail(value) {
            try {
                this.isViewDetail = value;
            } catch (error) {
                console.log(error);
            }
        },

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

        setFieldReceiptPaymentErrorFocus(fieldError) {
            try {
                this.fieldErrorReceiptPaymentFocus = fieldError;
            } catch (error) {
                console.log(error);
            }
        },

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

        setPopupData(popupData) {
            try {
                this.popupData = popupData;
                this.isShowPopup = true;
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
        this.isShowModalSetting = false;
        this.onLoadTemplate();
        this.columns_default = template_default;
        this.isViewDetail = false;
        this.getReceiptPayments(this.currentRecord, this.currentPage);
    },
};
</script>
<style scoped>
@import url("./receipt.css");
</style>
