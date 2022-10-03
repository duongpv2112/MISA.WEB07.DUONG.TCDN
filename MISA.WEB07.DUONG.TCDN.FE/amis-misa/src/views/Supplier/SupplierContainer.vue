<template>
    <main class="container-page">
        <div class="container-page__top">
            <div class="d-flex justify-space-between">
                <h2 class="container-page__title">Danh sách nhà cung cấp</h2>
                <button class="btn">Thêm</button>
            </div>

            <a href="#" class="text-decoration-none back-page">
                <span class="icon square-16 icon-chevron-left-primary"></span>
                Tất cả danh mục
            </a>
        </div>
        <div class="container-page__container">
            <div class="container-page__toolbar">
                <div class="container-page__toolbar-left">
                    <div class="container-page__toolbar-all">
                        <div
                            class="d-flex flex-center container-page__toolbar-content"
                        >
                            <span class="container-page__toolbar-all--text">
                                Thực hiện hàng loạt
                            </span>
                            <span class="square-16 icon icon-arrow-down"></span>
                        </div>

                        <div
                            class="container-page__toolbar-option"
                            v-if="false"
                        >
                            <a class="toolbar-option__item">Xóa</a>
                        </div>
                    </div>
                </div>
                <div class="container-page__toolbar-right">
                    <div class="toolbar-search mr-12">
                        <input
                            type="text"
                            name="txtSearch"
                            placeholder="Tìm theo mã, tên, sđt nhân viên"
                            class="toolbar-search__input"
                            ref="txtSearch"
                            autocomplete="off"
                        />
                        <label
                            for="txtSearch"
                            class="toolbar-search__icon icon icon-search"
                        ></label>
                    </div>
                    <button class="toolbar-button">
                        <span class="d-block square-24 icon icon-refresh">
                        </span>
                    </button>
                    <button class="toolbar-button">
                        <span class="d-block square-24 icon icon-excel"></span>
                    </button>
                </div>
            </div>
            <div class="container-page__table">
                <SupplierGrid />
            </div>
        </div>
    </main>
    <SupplierForm />
</template>
<script>
import SupplierGrid from "./components/SupplierGrid.vue";
import SupplierForm from "./components/SupplierForm.vue";
export default {
    name: "SupplierContainer",
    components: { SupplierGrid, SupplierForm },
};
</script>
<style scoped>
.back-page {
    display: flex;
    align-items: center;
    color: #0075c0;
}
</style>
