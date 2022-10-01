import { createApp } from "vue";
import App from "./App.vue";
import router from "./routers";

/* Sử dụng */
const app = createApp(App);
app.directive("clickoutside", {
    mounted: (el, binding, vnode) => {
        console.log(vnode);
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
app.use(router);
app.mount("#app");
