<template>
    <div class="process">
        <div class="process-untility-area">
            <div class="process-area">
                <div class="process-area__title">Nghiệp vụ tiền mặt</div>
                <div class="process-area__cash">
                    <div class="cash-content">
                        <div class="icon-process-cash h-340"></div>
                        <div class="cash-button receipt">
                            <div class="cash-button__title">Thu tiền</div>
                        </div>
                        <div class="cash-button payment">
                            <div class="cash-button__title">Chi tiền</div>
                        </div>
                        <div class="cash-button audit">
                            <div class="cash-button__title">Kiểm kê quỹ</div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="dictionary-area d-flex">
                <div class="dictionary-item d-flex flex-center flex-grow">
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
                <div class="dictionary-item d-flex flex-center flex-grow">
                    <div class="dictionary-content">
                        <div class="icon square-24 icon-process-employee"></div>
                        <div class="dictionary-text">Nhân viên</div>
                    </div>
                </div>
                <div class="dictionary-item d-flex flex-center flex-grow">
                    <div class="dictionary-content">
                        <div class="icon square-24 icon-calculate"></div>
                        <div class="dictionary-text">Tính tỉ giá xuất quỹ</div>
                    </div>
                </div>
                <div class="dictionary-item d-flex flex-center flex-grow">
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
</template>
<script>
export default {
    name: "ProcessPage",
};
</script>
<style scoped>
@import url("./process.css");
</style>
