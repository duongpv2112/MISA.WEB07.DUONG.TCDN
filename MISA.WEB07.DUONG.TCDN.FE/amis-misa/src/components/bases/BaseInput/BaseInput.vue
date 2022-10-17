<template>
    <div :class="className" class="tooltip">
        <label
            v-if="!isHideLable"
            :for="'Input_' + dataField"
            class="modal__label mb-6"
        >
            {{ lable }}
            <span class="text-danger" v-if="isRequired"> * </span>
        </label>
        <input
            :id="'Input_' + dataField"
            :class="{
                modal__control: true,
                'input-number': isInputNumber,
                'border-red': checkData.isInValid,
            }"
            :type="type"
            :ref="dataField"
            :name="dataField"
            :value="
                isInputNumber
                    ? common.formatCurrency(valueInput || '0')
                    : valueInput
            "
            :tabindex="tabindex"
            :placeholder="fieldName"
            :maxlength="maxlength"
            :autocomplete="autocomplete"
            :readonly="isReadonly"
            @input="onHandleInput(dataField, $event)"
            @blur="handleBlur($event)"
            @keypress="isInputNumberString ? onKeyPressInputData() : null"
        />
        <BaseTooltip
            v-if="checkData.isInValid"
            :content="checkData.errorMessage"
            :className="['tooltip-default', 'tooltip-input__validate']"
        />
    </div>
</template>
<script>
import { common } from "@/libs/common/common";
import { REGEX_TYPE } from "@/libs/resources/regex";
import BaseTooltip from "../BaseTooltip/BaseTooltip";
export default {
    name: "BaseInput",

    props: {
        isHideLable: Boolean,
        lable: String,
        className: Array,
        type: String,
        dataField: String,
        valueField: null,
        tabindex: String,
        fieldName: String,
        maxlength: Number,
        autocomplete: String,
        isRequired: Boolean,
        errorMessage: String,
        isInputNumber: Boolean,
        isInputNumberString: Boolean,
        isReadonly: Boolean,
        firstFocus: Boolean,
        isFieldErrorFocus: Boolean,
        patternValidate: String,
    },

    emits: ["setValue", "setValidateData"],

    data() {
        return {
            checkData: {
                isInValid: false,
                errorMessage: "",
            },
            valueInput: null,
            common: common,
        };
    },

    created() {
        try {
            this.valueInput = this.valueField;
        } catch (error) {
            console.log(error);
        }
    },

    mounted() {
        if (this.firstFocus) {
            this.$refs[this.dataField].focus();
        }
    },

    watch: {
        isFieldErrorFocus(newValue) {
            if (newValue) {
                this.$refs[this.dataField].focus();
            }
        },
        firstFocus(newValue) {
            if (newValue) {
                this.$refs[this.dataField].focus();
            }
        },
    },

    methods: {
        onHandleInput(dataField, event) {
            try {
                this.valueInput = event.target.value.trim();
                if (this.isInputNumber) {
                    this.valueInput = this.valueInput.replace(/\D+/g, "");
                }
                this.$emit("setValue", this.valueInput, dataField);
            } catch (error) {
                console.log(error);
            }
        },

        handleBlur(event) {
            try {
                if (!event.target.value.trim() && this.isRequired) {
                    this.checkData.isInValid = true;
                    this.checkData.errorMessage = `${this.fieldName} không được để trống.`;
                    this.$emit(
                        "setValidateData",
                        true,
                        this.checkData.errorMessage,
                        this.dataField
                    );
                } else {
                    if (
                        this.patternValidate &&
                        event.target.value.trim() &&
                        !this.checkValidatePattern(event.target.value)
                    ) {
                        this.checkData.isInValid = true;
                        this.checkData.errorMessage = `${this.fieldName} không đúng định dạng.`;
                        this.$emit(
                            "setValidateData",
                            true,
                            this.checkData.errorMessage,
                            this.dataField
                        );
                    } else {
                        this.checkData.isInValid = false;
                        this.checkData.errorMessage = "";
                        this.$emit(
                            "setValidateData",
                            false,
                            this.checkData.errorMessage,
                            this.dataField
                        );
                    }
                }
            } catch (error) {
                console.log(error);
            }
        },

        onKeyPressInputData() {
            try {
                common.keypresOnlyNumber(event);
            } catch (error) {
                console.log(error);
            }
        },

        checkValidatePattern(value) {
            var regex = REGEX_TYPE[this.patternValidate];
            return regex.test(value);
        },
    },

    components: { BaseTooltip },
};
</script>
<style scoped>
@import url("./input.css");
</style>
