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
    </main>
    <router-view name="process"></router-view>
</template>
<script>
export default {
    name: "CashPage",
};
</script>
<style scoped>
.tabs {
    display: block;
}

.tabs .tab-list {
    list-style-type: none;
    display: flex;
    border-bottom: 2px solid #d4d7dc;
}
.tab-list .tab-item {
    cursor: pointer;
}

.tab-list .tab-item a {
    max-height: 50px !important;
    padding: 15px 20px;
    display: inline-block;
    text-decoration: none;
    color: #111;
}

.tab-list .tab-item a.router-link-active {
    border-bottom: 4px solid #2ca01c;
    font-weight: 700;
}
</style>
