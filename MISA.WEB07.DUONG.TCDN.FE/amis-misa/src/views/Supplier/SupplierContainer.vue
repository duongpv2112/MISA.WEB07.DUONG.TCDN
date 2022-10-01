<template>
    <SupplierGrid />
    <SupplierForm />
</template>
<script>
import SupplierGrid from "./components/SupplierGrid.vue";
import SupplierForm from "./components/SupplierForm.vue";
export default {
    name: "SupplierContainer",
    components: { SupplierGrid, SupplierForm },
};
</script>
