<template>
    <div class="modal__row">
        <div class="d-flex pr-26 col-6">
            <BaseInput
                :lable="'Mã nhân viên'"
                :type="'text'"
                :dataField="'EmployeeCode'"
                :valueField="employee.EmployeeCode"
                :tabindex="'1'"
                :fieldName="'Mã nhân viên'"
                :maxlength="20"
                :autocomplete="'off'"
                :isRequired="true"
                @setValue="setValue"
            />
        </div>
    </div>
    <div class="modal__row">
        <div class="d-flex pr-26 col-6">
            <BaseInput
                :lable="'Tên nhân viên'"
                :type="'text'"
                :dataField="'EmployeeName'"
                :valueField="employee.EmployeeName"
                :tabindex="'2'"
                :fieldName="'Tên nhân viên'"
                :maxlength="100"
                :autocomplete="'off'"
                :isRequired="true"
                @setValue="setValue"
            />
        </div>
    </div>
</template>
<script>
import BaseInput from "@/components/bases/BaseInput/BaseInput.vue";
import { SUPPLIER_TEXT_CONFIG } from "@/views/Supplier/constants/resource"
export default {
    name: "SupplierForm",

    components: { BaseInput },

    data() {
        return {
            RESOURCE: SUPPLIER_TEXT_CONFIG,
            employee: {
                EmployeeCode: "",
                EmployeeName: "",
            },
            account_object: {
                account_object_id: "2ac46ee0-e193-4a63-9e44-5242ef47b49b",
                account_object_code: "NCC-877968",
                account_object_name: "Công ty Bùi Mỹ Thanh",
                address: "54 Heritage St. Prior Lake, MN 55372",
                website: "website2WW.com.vn",
                tax_code: "5163758074",
                phone_number: "0564681939",
                telephone_number: "0582527669",
                identity_number: "218413244092",
                identity_date: "2009-10-30T00:00:00",
                identity_place:
                    "Cục Cảnh sát quản lý hành chính về trật tự xã hội",
                employee_id: null,
                employee_name: null,
                supplier_type: 1,
                contact_name: "Bùi Thế Huy",
                vocative_contact: 3,
                vocative_supplier: 1,
                email: "jeJH22gGDYe8LVg@aws.com",
                representative_name: "Phạm Văn Giang",
                payment_term: 2,
                number_day_owed: 4,
                maximum_debt_amount: 40320952.6608,
                account_payable: "609482562113",
                department_name: null,
                created_date: "2022-09-09T23:57:59.907",
                created_by: "Vũ Văn Cường",
                modified_date: "2022-02-28T06:28:02.201",
                modified_by: "Bùi Văn Nhật",
            },
        };
    },
    methods: {
        setValue(dataField, valueField) {
            try {
                this.employee[dataField] = valueField;
            } catch (error) {
                console.log(error);
            }
        },
        handleClick(event) {
            try {
                console.log(event);
            } catch (error) {
                console.log(error);
            }
        },
    },
};
</script>
<style scoped></style>
