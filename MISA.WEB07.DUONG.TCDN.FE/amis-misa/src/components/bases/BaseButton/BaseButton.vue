<template>
    <button
        v-if="!isIcon && !isIconText"
        class="button"
        :class="className"
        :tabindex="tabindex"
        @click="
            isButtonCancel
                ? this.functionz(1)
                : this.functionz
                ? this.functionz(paramFunction)
                : null
        "
    >
        {{ title }}
        <BaseTooltip
            v-if="contentTooltip"
            :content="contentTooltip"
            :className="classNameTooltip"
        />
    </button>
    <button
        v-if="isIcon"
        class="button"
        :class="className"
        :tabindex="tabindex"
        @click="this.functionz ? this.functionz(paramFunction) : null"
    >
        <div class="d-flex flex-center button-icon">
            <span class="icon" :class="classNameIcon"></span>
            <div class="button-line"></div>
        </div>
        <BaseTooltip
            v-if="contentTooltip"
            :content="contentTooltip"
            :className="classNameTooltip"
        />
    </button>
    <button
        v-if="isIconText"
        class="button"
        :class="className"
        :tabindex="tabindex"
        @click="this.functionz()"
    >
        <div class="d-flex flex-center">
            <span class="pr-4">{{ title }}</span>
            <span class="icon" :class="classNameIcon"></span>
        </div>
        <BaseTooltip
            v-if="contentTooltip"
            :content="contentTooltip"
            :className="classNameTooltip"
        />
    </button>
</template>
<script>
import BaseTooltip from "../BaseTooltip/BaseTooltip";
export default {
    name: "BaseButton",
    props: {
        title: String,
        className: Array,
        functionz: Function,
        isIcon: Boolean,
        isIconText: Boolean,
        classNameIcon: Object,
        classNameTooltip: Array,
        contentTooltip: String,
        isButtonCancel: Boolean,
        paramFunction: null,
        tabindex: Number,
    },

    data() {
        return {};
    },

    components: { BaseTooltip },

    methods: {},
};
</script>
<style scoped>
@import url("./button.css");
</style>
