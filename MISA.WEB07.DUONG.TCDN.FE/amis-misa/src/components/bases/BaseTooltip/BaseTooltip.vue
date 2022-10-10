<template>
    <span class="tooltip-text" :class="className">
        {{ content }}
    </span>
</template>
<script>
export default {
    name: "BaseTooltip",
    props: {
        content: String,
        className: Array,
    },
};
</script>
<style scoped>
@import url("./tooltip.css");
</style>
