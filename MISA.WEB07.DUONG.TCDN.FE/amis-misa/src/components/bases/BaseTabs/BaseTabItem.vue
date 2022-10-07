<template>
    <div class="tabs-content__data" v-show="name == selectedName">
        <slot></slot>
    </div>
</template>
<script>
import { inject } from "vue";

export default {
    name: "BaseTabItem",
    props: ["name"],
    setup() {
        const selectedName = inject("selectedName");

        return {
            selectedName,
        };
    },
};
</script>
