<template>
    <span class="tooltip-text" :class="className" :style="styleObject">
        {{ content }}
    </span>
</template>
<script>
export default {
    name: "BaseTooltip",
    props: {
        content: String,
        className: Array,
        styleObject: null
    },
};
</script>
<style scoped>
@import url("./tooltip.css");
</style>
