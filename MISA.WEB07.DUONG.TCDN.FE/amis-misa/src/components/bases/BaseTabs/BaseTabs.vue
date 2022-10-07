<template>
    <div class="tabs">
        <div class="tabs-navbar">
            <ul class="tabs-navbar__list">
                <li
                    v-for="(tab, index) in tabNames"
                    class="tabs-navbar__item"
                    :class="{
                        'tabs-navbar__item--active': tab == selectedName,
                    }"
                    :key="'tab_' + index"
                    @click="selectedName = tab"
                >
                    <div class="tabs-navbar__content">
                        {{ tab }}
                    </div>
                </li>
            </ul>
        </div>

        <div class="tabs-content">
            <slot></slot>
        </div>
    </div>
</template>
<script>
import { ref, provide } from "vue";
export default {
    name: "BaseTabs",
    setup(props, { slots }) {
        const tabNames = ref(slots.default().map((tab) => tab.props.name));
        const selectedName = ref(tabNames.value[0]);

        provide("selectedName", selectedName);
        return {
            selectedName,
            tabNames,
        };
    },
};
</script>
<style scoped>
@import url("./tabs.css");
</style>
