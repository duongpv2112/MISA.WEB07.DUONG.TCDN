<template>
    <main class="container-page">
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
                :isViewDetail="isViewDetail"
                :typeSupplier="typeSupplier"
                :supplierValue="supplierData"
                :onClose="onHandleHideModal"
                :onSave="onSaveSupplier"
            />
        </template>
    </BaseModal>
    <BasePopup
        v-if="popupData && isShowPopup"
        :typePopup="popupData.typePopup"
        :footerPopup="popupData.footerPopup"
        :noticeMessage="popupData.noticeMessage"
    />
</template>
<script>
import SupplierGrid from "./components/SupplierGrid.vue";
import SupplierForm from "./components/SupplierForm.vue";
import BaseButton from "@/components/bases/BaseButton/BaseButton.vue";
import BaseModal from "@/components/bases/BaseModal/BaseModal.vue";
import SupplierFormHeader from "./components/SupplierFormHeader.vue";
import api from "@/services/api";
import { API_RESOURCE } from "./constants/api";
import { SUPPLIER_TEXT_CONFIG } from "@/views/Supplier/constants/resource";
import { TYPE_CLOSE } from "@/views/Supplier/constants/type-close";
import BasePopup from "@/components/bases/BasePopup/BasePopup.vue";
import BaseTooltip from "@/components/bases/BaseTooltip/BaseTooltip.vue";

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
            supplierData: null,
            popupData: null,
            isViewDetail: false,
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

        onHandleShowModal() {
            try {
                this.isShowModal = true;
                this.supplierData = null;
                this.typeSupplier = 0;
                this.isViewDetail = false;
            } catch (error) {
                console.log(error);
            }
        },

        onHandleHideModal(typeClose) {
            try {
                if (typeClose == TYPE_CLOSE.TYPE_CLOSE_CHECK_CHANGE) {
                    this.isShowPopup = true;
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
                                    buttonAction: "",
                                    classButton: ["btn-confirm"],
                                    valueFunction: "",
                                },
                            ],
                        },

                        noticeMessage:
                            "Dữ liệu đã bị thay đổi. Bạn có muốn cất không?",
                    };
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
                let urlFilter = `${API_RESOURCE.PAGING_DATA_SUPPLIER}/${value.account_object_id}`;
                await api.get(urlFilter).then((data) => {
                    this.supplierData = data;
                    this.onChangTypeSupplier(data.accountObject.supplier_type);
                });
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
                    },

                    noticeMessage: `Bạn có thực sự muốn xóa nhân viên <${value.account_object_code}> không?`,
                };
                this.isShowPopup = true;
            } catch (error) {
                console.log(error);
            }
        },

        onHandleDelete(id) {
            try {
                console.log(id);
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

        async onSaveSupplier(supplier, supplierConstraints) {
            try {
                // Object.keys(supplier).forEach((key) => {
                //     if (
                //         !supplier[key] ||
                //         (typeof supplier[key] === "string" &&
                //             supplier[key] === "")
                //     ) {
                //         supplier[key] = null;
                //     }
                // });
                if (supplier.vocative_contact) {
                    supplier.vocative_contact = Number(
                        supplier.vocative_contact
                    );
                }
                if (supplier.vocative_supplier) {
                    supplier.vocative_supplier = Number(
                        supplier.vocative_supplier
                    );
                }
                supplier.supplier_type = Number(this.typeSupplier);
                supplier.maximum_debt_amount = Number(
                    supplier.maximum_debt_amount
                );
                supplier.number_day_owed = Number(supplier.number_day_owed);
                supplier.is_supplier = true;
                supplier.is_employee = false;
                var bodyData = {
                    accountObject: supplier,
                    supplierConstraints: supplierConstraints,
                };
                if (supplier.account_object_id) {
                    let urlFilter = `${API_RESOURCE.PAGING_DATA_SUPPLIER}/${supplier.account_object_id}`;
                    await api.put(urlFilter, bodyData).then((response) => {
                        if (response) {
                            this.isShowModal = false;
                        }
                    });
                } else {
                    let urlFilter = `${API_RESOURCE.PAGING_DATA_SUPPLIER}`;
                    await api.post(urlFilter, bodyData).then((response) => {
                        if (response) {
                            this.isShowModal = false;
                        }
                    });
                }
                this.onHandleReload();
            } catch (error) {
                console.log(error);
            }
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
        this.getSuppliers(this.currentRecord, this.currentPage);
    },
};
</script>
<style scoped>
@import url("./supplier.css");
</style>
