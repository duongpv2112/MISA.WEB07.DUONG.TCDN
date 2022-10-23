<template>
    <main class="container-page supplier">
        <div class="container-page__top">
            <div class="d-flex justify-space-between">
                <h2 class="container-page__title">
                    {{ RESOURCE.SUPPLIER_PAGE_HEADER }}
                </h2>
                <div class="d-flex">
                    <div class="guide-tour d-flex flex-center">
                        <span class="icon square-24 icon-tour"></span>
                        <a href="#" class="guide-tour__link">Hướng dẫn</a>
                    </div>
                    <div class="mr-12">
                        <BaseButton
                            :isIconText="true"
                            :title="RESOURCE.SUPPLIER_UTILITIES_BTN"
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
                    <div class="d-flex">
                        <BaseButton
                            :title="RESOURCE.SUPPLIER_ADD_BTN"
                            :className="[
                                'button-text',
                                'button-default',
                                'button-primary',
                                'button-radius-left',
                            ]"
                            :functionz="onHandleShowModal"
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

            <div class="d-flex">
                <div>
                    <router-link
                        :to="{ name: 'app' }"
                        class="text-decoration-none back-page"
                    >
                        <span
                            class="icon square-16 icon-chevron-left-primary"
                        ></span>
                        Quay lại
                    </router-link>
                </div>
            </div>
        </div>

        <div class="container-page__overview">
            <div class="d-flex">
                <div
                    class="overview-item overview-item__dued-debt bg-dued-debt"
                >
                    <div class="overview-item__content">
                        <div class="total-money">1.335.208.978</div>
                        <div class="lable-overview">Nợ quá hạn</div>
                    </div>
                    <div class="overview-line"></div>
                    <div class="icon funnel-icon tooltip">
                        <BaseTooltip
                            :content="'Bấm vào để lọc'"
                            :className="['tooltip-default--header']"
                        />
                    </div>
                </div>

                <div
                    class="overview-item overview-item__total-debt bg-total-debt"
                >
                    <div class="overview-item__content">
                        <div class="total-money">47.155.167.800</div>
                        <div class="lable-overview">Tổng nợ phải trả</div>
                    </div>
                    <div class="overview-line"></div>
                    <div class="icon funnel-icon tooltip">
                        <BaseTooltip
                            :content="'Bấm vào để lọc'"
                            :className="['tooltip-default--header']"
                        />
                    </div>
                </div>

                <div class="overview-item overview-item__payment bg-payment">
                    <div class="overview-item__content">
                        <div class="total-money">0</div>
                        <div class="lable-overview">
                            Đã thanh toán (30 ngày gần đây)
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="container-page__container">
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
                                    {{ RESOURCE.SUPPLIER_ACTION_ALL_BTN }}
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
                                    {{ RESOURCE.SUPPLIER_DELETE_BTN }}
                                </a>
                            </div>
                        </div>

                        <div class="container-page__toolbar-all">
                            <div
                                class="d-flex flex-center container-page__toolbar-content"
                            >
                                <span class="container-page__toolbar-all--text">
                                    {{ RESOURCE.SUPPLIER_FILTER_BTN }}
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
                                    {{ RESOURCE.SUPPLIER_DELETE_BTN }}
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container-page__toolbar-right">
                    <div class="toolbar-search mr-12">
                        <input
                            type="text"
                            name="txtSearch"
                            :placeholder="RESOURCE.SUPPLIER_SEARCH_PLACEHOLDER"
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
                <SupplierGrid
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
                />
            </div>
        </div>
    </main>
    <BaseModal
        v-if="isShowModal"
        :titleHeader="RESOURCE.SUPPLIER_MODAL_PAGE_HEADER"
    >
        <template v-slot:header>
            <SupplierFormHeader
                :isViewDetail="isViewDetail"
                :typeSupplier="typeSupplier"
                @setValue="onChangTypeSupplier"
            />
        </template>
        <template v-slot:body>
            <SupplierForm
                :accountObject="account_object"
                :supplierConstraints="supplier_constraints"
                :isViewDetail="isViewDetail"
                :typeSupplier="typeSupplier"
                :supplierValue="supplierData"
                :onClose="onHandleHideModal"
                :onSave="onSaveSupplier"
                :onEdit="onEdit"
                :validateData="validateData"
                :fieldFocus="fieldErrorFocus"
                :setValidateData="setValidateData"
                :setValue="setValue"
                :setValueList="setValueList"
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
        :onClose="onHandleHideSettingPage"
    />
</template>
<script>
import { API_RESOURCE } from "./constants/api";
import { SUPPLIER_TEXT_CONFIG } from "@/views/Supplier/constants/resource";
import { TYPE_CLOSE } from "@/views/Supplier/constants/type-close";
import { common } from "@/libs/common/common";
import api from "@/services/api";
import SupplierGrid from "./components/SupplierGrid.vue";
import SupplierForm from "./components/SupplierForm.vue";
import BaseButton from "@/components/bases/BaseButton/BaseButton.vue";
import BaseModal from "@/components/bases/BaseModal/BaseModal.vue";
import SupplierFormHeader from "./components/SupplierFormHeader.vue";
import BasePopup from "@/components/bases/BasePopup/BasePopup.vue";
import BaseTooltip from "@/components/bases/BaseTooltip/BaseTooltip.vue";
import BaseModalSetting from "@/components/bases/BaseModalSetting/BaseModalSetting.vue";

export default {
    name: "SupplierContainer",

    components: {
        SupplierGrid,
        SupplierForm,
        BaseButton,
        BaseModal,
        SupplierFormHeader,
        BasePopup,
        BaseTooltip,
        BaseModalSetting,
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

            RESOURCE: SUPPLIER_TEXT_CONFIG,

            isShowModal: Boolean,

            isShowPopup: Boolean,

            typeSupplier: Number,

            supplierData: {
                accountObject: null,
                supplierConstraints: null,
            },

            popupData: null,

            isViewDetail: false,

            account_object: {
                account_object_code: "",
                account_object_name: "",
                address: "",
                website: "",
                tax_code: "",
                phone_number: "",
                telephone_number: "",
                identity_number: "",
                identity_date: "",
                identity_place: "",
                employee_id: "",
                employee_name: "",
                supplier_type: "",
                contact_name: "",
                vocative_contact: null,
                vocative_supplier: null,
                email: "",
                representative_name: "",
                payment_term: null,
                number_day_owed: null,
                maximum_debt_amount: null,
                account_payable: "",
                department_name: "",
            },

            supplier_constraints: [],

            validateData: [
                {
                    isInValid: false,
                    fieldName: "account_object_code",
                    errorMessage: "",
                },
                {
                    isInValid: false,
                    fieldName: "account_object_name",
                    errorMessage: "",
                },
                {
                    isInValid: false,
                    fieldName: "tax_code",
                    errorMessage: "",
                },
                {
                    isInValid: false,
                    fieldName: "telephone_number",
                    errorMessage: "",
                },
                {
                    isInValid: false,
                    fieldName: "email",
                    errorMessage: "",
                },
                {
                    isInValid: false,
                    fieldName: "phone_number",
                    errorMessage: "",
                },
                {
                    isInValid: false,
                    fieldName: "account_payable",
                    errorMessage: "",
                },
            ],

            fieldErrorFocus: null,

            isShowModalSetting: Boolean,
        };
    },

    methods: {
        async getSuppliers(pageSize, pageNumber, keyword, orderBy) {
            try {
                let urlFilter = `${API_RESOURCE.PAGING_DATA_SUPPLIER}?pageSize=${pageSize}&pageNumber=${pageNumber}`;
                if (keyword) {
                    urlFilter += `&keyword=${keyword}`;
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
                        this.keyGrid += 1;
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
                await this.getSuppliers(
                    this.currentRecord,
                    pageNumber,
                    this.keyWord
                );
            } catch (error) {
                console.log(error);
            }
        },

        async onHandlePageSizeChange(pageSize) {
            try {
                this.dataReady = false;
                await this.getSuppliers(
                    pageSize,
                    this.currentPage,
                    this.keyWord
                );
            } catch (error) {
                console.log(error);
            }
        },

        async onHandleSearch(searchParams) {
            try {
                this.dataReady = false;
                await this.getSuppliers(
                    this.currentRecord,
                    1,
                    searchParams.trim()
                );
            } catch (error) {
                console.log(error);
            }
        },

        async onHandleReload() {
            try {
                this.dataReady = false;
                await this.getSuppliers(
                    this.currentRecord,
                    this.currentPage,
                    this.keyWord
                );
            } catch (error) {
                console.log(error);
            }
        },

        async onHandleShowModal() {
            try {
                common.refreshObject(this.account_object);
                this.account_object.account_object_id = "";
                this.supplierData = null;
                this.typeSupplier = 0;
                this.isViewDetail = false;
                let urlGetNewCode = `${API_RESOURCE.SUPPLIER_GET_NEW_CODE}`;
                await api.get(urlGetNewCode).then((data) => {
                    this.account_object.account_object_code = data;
                });
                this.account_object.isEdit = false;
                this.account_object.isAdd = true;
                this.isShowModal = true;
            } catch (error) {
                console.log(error);
            }
        },

        onHandleHideModal(typeClose) {
            try {
                let isChange = false;
                if (!this.account_object.account_object_id) {
                    let newObject = {
                        account_object_code:
                            this.account_object.account_object_code,
                        account_object_name: "",
                        address: "",
                        website: "",
                        tax_code: "",
                        phone_number: "",
                        telephone_number: "",
                        identity_number: "",
                        identity_date: "",
                        identity_place: "",
                        employee_id: "",
                        employee_name: "",
                        supplier_type: "",
                        contact_name: "",
                        vocative_contact: null,
                        vocative_supplier: null,
                        email: "",
                        representative_name: "",
                        payment_term: null,
                        number_day_owed: null,
                        maximum_debt_amount: null,
                        account_payable: "",
                        department_name: "",
                    };
                    isChange = common.objCompare(
                        this.account_object,
                        newObject
                    );
                } else {
                    isChange = common.objCompare(
                        this.account_object,
                        this.supplierData.accountObject
                    );
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
                                        buttonAction: this.onSaveSupplier,
                                        classButton: ["btn-confirm"],
                                        valueFunction: "",
                                    },
                                ],
                                enterKeyFunc: this.onSaveSupplier,
                                escKeyFunc: this.onHandleHidePopup
                            },

                            noticeMessage:
                                "Dữ liệu đã bị thay đổi. Bạn có muốn cất không?",
                        };
                        this.isShowPopup = true;
                        this.setFieldErrorFocus(null);
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

        onHandleHidePopup() {
            try {
                this.isShowPopup = false;
                var listValidate = this.validateData.filter((e) => {
                    return e.isInValid == true;
                });
                if (listValidate.length > 0) {
                    this.setFieldErrorFocus(listValidate[0].fieldName);
                }
            } catch (error) {
                console.log(error);
            }
        },

        onChangTypeSupplier(value) {
            try {
                this.typeSupplier = value;
            } catch (error) {
                console.log(error);
            }
        },

        async onEdit(value) {
            try {
                let urlGetOne = `${API_RESOURCE.PAGING_DATA_SUPPLIER}/${value.account_object_id}`;

                await api.get(urlGetOne).then((data) => {
                    this.supplierData = data;
                    this.account_object = data.accountObject;
                    this.supplier_constraints = data.supplierConstraints;
                    this.onChangTypeSupplier(data.accountObject.supplier_type);
                });
                this.account_object.isEdit = true;
                this.account_object.isAdd = false;
                this.isViewDetail = false;
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
                                valueFunction: value.account_object_id,
                            },
                        ],
                        enterKeyFunc: this.onHandleDelete,
                        valueEnterKeyFunc: value.account_object_id,
                        escKeyFunc: this.onHandleHidePopup
                    },

                    noticeMessage: `Bạn có thực sự muốn xóa nhân viên <${value.account_object_code}> không?`,
                };
                this.isShowPopup = true;
            } catch (error) {
                console.log(error);
            }
        },

        async onHandleDelete(id) {
            try {
                this.isShowPopup = false;
                this.dataReady = false;
                let urlFilter = `${API_RESOURCE.PAGING_DATA_SUPPLIER}/${id}`;
                await api.delete(urlFilter).then((data) => {
                    if (data) {
                        this.onHandleReload();
                    }
                });
            } catch (error) {
                console.log(error);
            }
        },

        async onDetail(value) {
            try {
                this.isViewDetail = true;
                let urlFilter = `${API_RESOURCE.PAGING_DATA_SUPPLIER}/${value.account_object_id}`;
                await api.get(urlFilter).then((data) => {
                    this.supplierData = data;
                    this.onChangTypeSupplier(data.accountObject.supplier_type);
                });
                this.isShowModal = true;
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

        async onSaveSupplier(type) {
            try {
                this.setFieldErrorFocus(null);
                if (this.checkValidateData()) {
                    this.isShowPopup = true;
                } else {
                    Object.keys(this.account_object).forEach((key) => {
                        if (this.account_object[key] != "0") {
                            if (
                                !this.account_object[key] ||
                                (typeof this.account_object[key] === "string" &&
                                    this.account_object[key] === "") ||
                                key == "created_date" ||
                                key == "created_by" ||
                                key == "modified_date" ||
                                key == "modified_by"
                            ) {
                                this.account_object[key] = null;
                            }
                        }
                    });
                    if (this.account_object.vocative_contact) {
                        this.account_object.vocative_contact = Number(
                            this.account_object.vocative_contact
                        );
                    }
                    if (this.account_object.vocative_supplier) {
                        this.account_object.vocative_supplier = Number(
                            this.account_object.vocative_supplier
                        );
                    }
                    this.account_object.supplier_type = Number(
                        this.typeSupplier
                    );
                    this.account_object.maximum_debt_amount = Number(
                        this.account_object.maximum_debt_amount
                    );
                    this.account_object.number_day_owed = Number(
                        this.account_object.number_day_owed
                    );
                    this.account_object.identity_date = this.account_object
                        .identity_date
                        ? common.formatDate(this.account_object.identity_date)
                        : null;
                    this.account_object.is_supplier = true;
                    this.account_object.is_employee = false;
                    var bodyData = {
                        accountObject: this.account_object,
                        supplierConstraints: this.supplier_constraints,
                    };
                    if (this.account_object.isEdit) {
                        let urlFilter = `${API_RESOURCE.PAGING_DATA_SUPPLIER}/${this.account_object.account_object_id}`;
                        await api.put(urlFilter, bodyData).then((response) => {
                            if (response) {
                                this.isShowModal = false;
                                this.isShowPopup = false;
                            }
                        });
                    } else if (this.account_object.isAdd) {
                        delete bodyData.accountObject["account_object_id"];
                        let urlFilter = `${API_RESOURCE.PAGING_DATA_SUPPLIER}`;
                        await api.post(urlFilter, bodyData).then((response) => {
                            if (response) {
                                this.isShowModal = false;
                                this.isShowPopup = false;
                            }
                        });
                    }
                    if (type && type == 1) {
                        this.onHandleShowModal();
                    }
                }
                this.onHandleReload();
            } catch (error) {
                console.log(error);
            }
        },

        setValidateData(isError, errorMessage, dataField) {
            try {
                var field = this.validateData.findIndex((e) => {
                    return e.fieldName == dataField;
                });
                if (field != -1) {
                    this.validateData[field].isInValid = isError;
                    this.validateData[field].errorMessage = errorMessage;
                } else {
                    this.validateData.push({
                        isInValid: isError,
                        fieldName: dataField,
                        errorMessage: errorMessage,
                    });
                }
            } catch (error) {
                console.log(error);
            }
        },

        setValue(valueField, dataField) {
            try {
                this.account_object[dataField] = valueField;
                if (
                    typeof valueField == "object" &&
                    (dataField == "employee_id" || dataField == "employee_name")
                ) {
                    this.account_object["employee_id"] =
                        valueField["account_object_id"];
                    this.account_object["employee_name"] =
                        valueField["account_object_name"];
                }
            } catch (error) {
                console.log(error);
            }
        },

        setValueList(value) {
            try {
                this.supplier_constraints = [];
                for (let i = 0; i < value.length; i++) {
                    this.supplier_constraints.push({
                        supplier_group_id: value[i].valueField,
                        created_date: null,
                        created_by: "Admin",
                        modified_date: null,
                        modified_by: "Admin",
                    });
                }
            } catch (error) {
                console.log(error);
            }
        },

        checkValidateData() {
            try {
                if (!this.account_object.account_object_code) {
                    this.setValidateData(
                        true,
                        "Mã nhà cung cấp không được để trống.",
                        "account_object_code"
                    );
                } else {
                    this.setValidateData(false, "", "account_object_code");
                }
                if (!this.account_object.account_object_name) {
                    this.setValidateData(
                        true,
                        "Tên nhà cung cấp không được để trống.",
                        "account_object_name"
                    );
                } else {
                    this.setValidateData(false, "", "account_object_name");
                }
                var listValidate = this.validateData.filter((e) => {
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

        setFieldErrorFocus(fieldError) {
            try {
                this.fieldErrorFocus = fieldError;
            } catch (error) {
                console.log(error);
            }
        },

        async exportData() {
            try {
                var bodyExport = {
                    columns: [
                        {
                            caption: "STT",
                            key: "stt",
                            width: 155,
                        },
                        {
                            caption: "Mã nhà cung cấp",
                            key: "account_object_code",
                            width: 155,
                        },
                        {
                            caption: "Tên nhà cung cấp",
                            key: "account_object_name",
                            width: 155,
                        },
                        {
                            caption: "Địa chỉ",
                            key: "address",
                            width: 155,
                        },
                        {
                            caption: "Ngày cấp",
                            key: "identity_date",
                            width: 155,
                        },
                        {
                            caption: "Số nợ tối đa",
                            key: "maximum_debt_amount",
                            width: 155,
                        },
                    ],
                    reportTitle: "DANH SÁCH NHÀ CUNG CẤP",
                    fileNameDownload: "Danh_sach_nha_cung_cap",
                    keyword: this.keyWord,
                    filter: 0,
                    orderBy: "",
                };
                await api
                    .export(
                        API_RESOURCE.SUPPLIER_EXPORT,
                        bodyExport,
                        "Danh_sach_nha_cung_cap.xlsx"
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
    },

    created() {
        this.typeSupplier = 0;
        this.isShowModal = false;
        this.isShowPopup = false;
        this.dataReady = false;
        this.currentRecord = 20;
        this.currentPage = 1;
        this.totalCount = 0;
        this.isShowModalSetting = false;
        this.getSuppliers(this.currentRecord, this.currentPage);
    },
};
</script>
<style scoped>
@import url("./supplier.css");
</style>
