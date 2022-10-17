import { createRouter, createWebHistory } from "vue-router";

import TheContainer from "../components/layouts/TheContainer/TheContainer.vue";
import DashBoard from "../views/Dashboard/DashBoard.vue";
import CashPage from "../views/CashPage/CashPage.vue";
import ProcessPage from "../views/CashPage/Process/Process.vue";
import ReceiptPayment from "../views/CashPage/ReceiptPayment/ReceiptPaymentContainer.vue";
import SupplierPage from "../views/Supplier/SupplierContainer.vue";

/* Khai báo các router */
const routes = [
    {
        path: "/",
        redirect: {
            name: "dashboard",
        },
    },
    { path: "/dashboard", name: "dashboard", component: DashBoard },
    {
        path: "/app",
        name: "app",
        redirect: {
            name: "CAProcess",
        },
        component: TheContainer,
        children: [
            {
                path: "CA",
                name: "CA",
                component: CashPage,
                redirect: {
                    name: "CAProcess",
                },
                children: [
                    {
                        path: "CAProcess",
                        name: "CAProcess",
                        component: ProcessPage,
                    },
                    {
                        path: "CAReceiptPayment",
                        name: "CAReceiptPayment",
                        component: ReceiptPayment,
                    },
                ],
            },
            {
                path: "supplier",
                name: "supplier",
                component: SupplierPage,
            },
        ],
    },
];

/* Khởi tạo router */
const vueRouter = createRouter({
    history: createWebHistory(),
    routes: routes,
});

export default vueRouter;
