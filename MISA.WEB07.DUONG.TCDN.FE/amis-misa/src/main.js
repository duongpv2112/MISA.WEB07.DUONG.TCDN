import { createApp } from "vue";
import App from "./App.vue";
import router from "./routers";
import VCalendar from "v-calendar";
import "v-calendar/dist/style.css";
import Toast from "vue-toastification";
import "vue-toastification/dist/index.css";

/* Sử dụng */
const app = createApp(App);
app.directive("clickoutside", {
    mounted: (el, binding) => {
        el.clickOutsideEvent = function (event) {
            if (
                !(
                    el === event.target ||
                    el.contains(event.target) ||
                    el.previousElementSibling.contains(event.target)
                )
            ) {
                binding.value(event, el);
            }
        };
        document.body.addEventListener("click", el.clickOutsideEvent);
        document.body.addEventListener("touchstart", el.clickOutsideEvent);
    },
    beforeUnmount: function (el) {
        document.body.removeEventListener("click", el.clickOutsideEvent);
        document.body.removeEventListener("touchstart", el.clickOutsideEvent);
    },
    stopProp(event) {
        event.stopPropagation();
    },
});

app.directive("keyboardoutside", {
    mounted: (el, binding) => {
        el.keyDownOutsideEvent = function (event) {
            if (!(el === event.target)) {
                binding.value(event, el);
            }
        };
        document.body.addEventListener("keydown", el.keyDownOutsideEvent);
        document.body.addEventListener("touchstart", el.keyDownOutsideEvent);
    },
    beforeUnmount: function (el) {
        document.body.removeEventListener("keydown", el.keyDownOutsideEvent);
        document.body.removeEventListener("touchstart", el.keyDownOutsideEvent);
    },
    stopProp(event) {
        event.stopPropagation();
    },
});

app.use(VCalendar, {
    componentPrefix: "vc",
});
const options = {
    timeout: 1500,
};

app.use(Toast, options);

app.use(router);
app.mount("#app");
