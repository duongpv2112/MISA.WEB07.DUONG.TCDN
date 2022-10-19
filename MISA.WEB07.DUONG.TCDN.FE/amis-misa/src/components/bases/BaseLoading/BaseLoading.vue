<template>
    <div class="d-flex flex-center loading">
        <span class="loading-icon"></span>
    </div>
</template>
<script>
export default {
    name: "BaseLoading",
};
</script>
<style scoped>
.loading {
    position: absolute;
    top: 32px;
    left: 0;
    right: 0;
    bottom: 0;
}

.loading .loading-icon {
    background-image: url("../../../assets/img/loading-favorite-report.8d2517bd.svg");
    background-repeat: no-repeat;
    width: 36px;
    height: 36px;
    background-position: 2px 2px;
    animation: round-infinite infinite linear 0.8s;
}

@keyframes round-infinite {
    0% {
        transform: rotate(0deg);
    }
    100% {
        transform: rotate(360deg);
    }
}
</style>
