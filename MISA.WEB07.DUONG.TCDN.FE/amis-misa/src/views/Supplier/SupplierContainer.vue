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
                            :functionz="onHandleShowHideModal"
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

            <a href="#" class="text-decoration-none back-page">
                <span class="icon square-16 icon-chevron-left-primary"></span>
                Tất cả danh mục
            </a>
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
                    <div class="icon funnel-icon"></div>
                </div>

                <div
                    class="overview-item overview-item__total-debt bg-total-debt"
                >
                    <div class="overview-item__content">
                        <div class="total-money">47.155.167.800</div>
                        <div class="lable-overview">Tổng nợ phải trả</div>
                    </div>
                    <div class="overview-line"></div>
                    <div class="icon funnel-icon"></div>
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
                    <button class="toolbar-button" @click="onHandleReload">
                        <span class="d-block square-24 icon icon-refresh">
                        </span>
                    </button>
                    <button class="toolbar-button">
                        <span class="d-block square-24 icon icon-excel"></span>
                    </button>
                    <button class="toolbar-button">
                        <span
                            class="d-block square-24 icon icon-setting-list"
                        ></span>
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
                />
            </div>
        </div>
    </main>
    <BaseModal
        v-if="isShowModal"
        :titleHeader="RESOURCE.SUPPLIER_MODAL_PAGE_HEADER"
        :onClose="onHandleShowHideModal"
    >
        <template v-slot:header>
            <SupplierFormHeader />
        </template>
        <template v-slot:body>
            <SupplierForm />
        </template>
    </BaseModal>
</template>
<script>
import SupplierGrid from "./components/SupplierGrid.vue";
import SupplierForm from "./components/SupplierForm.vue";
import BaseButton from "@/components/bases/BaseButton/BaseButton.vue";
import BaseModal from "@/components/bases/BaseModal/BaseModal.vue";
import SupplierFormHeader from "./components/SupplierFormHeader.vue";
import api from "@/services/api";
import { API } from "./constants/api";
import { SUPPLIER_TEXT_CONFIG } from "@/views/Supplier/constants/resource";
export default {
    name: "SupplierContainer",
    components: {
        SupplierGrid,
        SupplierForm,
        BaseButton,
        BaseModal,
        SupplierFormHeader,
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
        };
    },
    methods: {
        async getSuppliers(pageSize, pageNumber, keyword, orderBy) {
            try {
                let urlFilter = `${API.PAGING_DATA_SUPPLIER}?pageSize=${pageSize}&pageNumber=${pageNumber}`;
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

        onHandleSearch(searchParams) {
            try {
                this.dataReady = false;
                this.getSuppliers(this.currentRecord, 1, searchParams.trim());
            } catch (error) {
                console.log(error);
            }
        },

        onHandleReload() {
            try {
                this.dataReady = false;
                this.getSuppliers(
                    this.currentRecord,
                    this.currentPage,
                    this.keyWord
                );
            } catch (error) {
                console.log(error);
            }
        },

        onHandleShowHideModal() {
            try {
                this.isShowModal = !this.isShowModal;
            } catch (error) {
                console.log(error);
            }
        },
    },
    created() {
        this.isShowModal = false;
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
