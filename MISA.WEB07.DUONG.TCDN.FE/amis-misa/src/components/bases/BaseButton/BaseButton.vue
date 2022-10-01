<template>
    <button class="modal__button" :class="className" @click="functionz">
        {{ title }}
    </button>
</template>
<script>
export default {
    name: "BaseButton",
    props: {
        title: String,
        className: String,
        functionz: Function,
    },
};
</script>
<style scoped></style>
