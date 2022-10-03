<template>
    <BaseGrid :columns="columns" :data="data" :dataReady="dataReady" />
</template>
<script>
import BaseGrid from "@/components/bases/BaseGrid/BaseGrid.vue";

export default {
    name: "SupplierGrid",
    components: { BaseGrid },
    data() {
        return {
            columns: [
                {
                    fieldName: "Mã nhân viên",
                    dataField: "EmployeeID",
                    isHidden: true,
                },
                {
                    fieldName: "Tên nhân viên",
                    dataField: "EmployeeName",
                },
                {
                    fieldName: "Địa chỉ",
                    dataField: "Address",
                },
            ],
            data: [
                {
                    EmployeeID: "NV-0001",
                    EmployeeName: "Phạm Việt Dương",
                },
                {
                    EmployeeID: "NV-0002",
                    EmployeeName: "Phạm Việt Dương 1",
                },
                {
                    EmployeeID: "NV-0003",
                    EmployeeName: "Phạm Việt Dương 2",
                },
                {
                    EmployeeID: "NV-0004",
                    EmployeeName: "Phạm Việt Dương 3",
                },
                {
                    EmployeeID: "NV-0005",
                    EmployeeName: "Phạm Việt Dương 4",
                },
                {
                    EmployeeID: "NV-0006",
                    EmployeeName: "Phạm Việt Dương 5",
                },
                {
                    EmployeeID: "NV-0006",
                    EmployeeName: "Phạm Việt Dương 5",
                },
                {
                    EmployeeID: "NV-0006",
                    EmployeeName: "Phạm Việt Dương 5",
                },
                {
                    EmployeeID: "NV-0006",
                    EmployeeName: "Phạm Việt Dương 5",
                },
                {
                    EmployeeID: "NV-0006",
                    EmployeeName: "Phạm Việt Dương 5",
                },
                {
                    EmployeeID: "NV-0006",
                    EmployeeName: "Phạm Việt Dương 5",
                },
                {
                    EmployeeID: "NV-0006",
                    EmployeeName: "Phạm Việt Dương 5",
                },
                {
                    EmployeeID: "NV-0006",
                    EmployeeName: "Phạm Việt Dương 5",
                },
                {
                    EmployeeID: "NV-0006",
                    EmployeeName: "Phạm Việt Dương 5",
                },
            ],
            dataReady: true,
        };
    },
    methods: {
        setDataReady() {
            try {
                this.dataReady = false;
            } catch (error) {
                console.log(error);
            }
        },
    },
    created() {
        this.setDataReady();
    },
};
</script>
<style scoped>
@import url("../../../css/table.css");
</style>
