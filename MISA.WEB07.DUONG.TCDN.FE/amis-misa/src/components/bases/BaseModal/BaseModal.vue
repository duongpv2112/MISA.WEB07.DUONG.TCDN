<template>
    <div class="modal fade">
        <div class="modal drag">
            <div
                class="modal__dialog modal__lg"
                :class="className"
            >
                <div class="modal__header cursor-grab">
                    <div class="icon square-24 icon-recent-log"></div>
                    <div class="modal__tittle">{{ titleHeader }}</div>
                    <slot name="header"></slot>
                </div>
                <slot name="body"></slot>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    name: "BaseModal",
    props: {
        titleHeader: String,
        className: Array,
    },
};
</script>
<style scoped>
@import url("./modal.css");
@import url("../../../css/flexbox.css");
</style>
