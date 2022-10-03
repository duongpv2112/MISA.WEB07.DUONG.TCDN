<template>
    <main class="container-page">
        <div class="tabs">
            <ul class="tab-list">
                <li class="tab-item">
                    <router-link :to="{ name: 'CAProcess' }">
                        Quy trình
                    </router-link>
                </li>
                <li class="tab-item">
                    <router-link :to="{ name: 'CAReceiptPayment' }">
                        Thu, chi tiền
                    </router-link>
                </li>
                <li class="tab-item">
                    <router-link :to="{ name: 'dashboard' }">
                        Kiểm kê
                    </router-link>
                </li>
                <li class="tab-item">
                    <router-link :to="{ name: 'dashboard' }">
                        Dự báo dòng tiền
                    </router-link>
                </li>
                <li class="tab-item">
                    <router-link :to="{ name: 'dashboard' }">
                        Báo cáo
                    </router-link>
                </li>
            </ul>
        </div>
        <router-view></router-view>
    </main>
</template>
<script>
export default {
    name: "CashPage",
};
</script>
<style scoped>
@import url("./cash.css");
</style>
