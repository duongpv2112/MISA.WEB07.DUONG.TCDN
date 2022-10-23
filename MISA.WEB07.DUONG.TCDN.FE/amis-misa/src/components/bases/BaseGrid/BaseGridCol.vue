<template>
    <td :class="{ 'text-center': isCenter, 'text-right': isRight }">
        {{ value }}
    </td>
</template>
<script>
export default {
    name: "BaseGridCol",
    props: {
        value: null,
        isCenter: Boolean,
        isRight: Boolean,
    },
};
</script>
<style scoped></style>
