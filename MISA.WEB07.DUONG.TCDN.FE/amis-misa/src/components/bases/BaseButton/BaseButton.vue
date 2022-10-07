<template>
    <button
        v-if="!isIcon && !isIconText"
        class="button"
        :class="className"
        @click="functionz"
    >
        {{ title }}
    </button>
    <button v-if="isIcon" class="button" :class="className" @click="functionz">
        <div class="d-flex flex-center button-icon">
            <span class="icon" :class="classNameIcon"></span>
            <div class="button-line"></div>
        </div>
    </button>
    <button
        v-if="isIconText"
        class="button"
        :class="className"
        @click="functionz"
    >
        <div class="d-flex flex-center">
            <span class="pr-4">{{ title }}</span>
            <span class="icon" :class="classNameIcon"></span>
        </div>
    </button>
</template>
<script>
export default {
    name: "BaseButton",
    props: {
        title: String,
        className: Array,
        functionz: Function,
        isIcon: Boolean,
        isIconText: Boolean,
        classNameIcon: Object,
    },
};
</script>
<style scoped>
@import url("./button.css");
</style>
