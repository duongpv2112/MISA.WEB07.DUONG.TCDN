<template>
    <div class="line-bottom">
        <div class="modal__row">
            <div class="d-flex pr-26 col-6">
                <BaseInput
                    :lable="'Mã nhân viên'"
                    :className="''"
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
                    :className="''"
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
    </div>
    <BaseButton :title="'Cất'" :className="''" :functionz="handleClick" />
</template>
<script>
import BaseInput from "@/components/bases/BaseInput/BaseInput.vue";
import BaseButton from "@/components/bases/BaseButton/BaseButton.vue";
export default {
    name: "SupplierForm",
    components: { BaseInput, BaseButton },
    data() {
        return {
            employee: {
                EmployeeCode: "",
                EmployeeName: "",
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
