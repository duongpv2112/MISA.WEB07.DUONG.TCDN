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
            step="1"
            @input="onHandleInput(dataField, $event)"
            @blur="handleBlur($event)"
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
        isReadonly: Boolean,
        firstFocus: Boolean,
    },

    emits: ["setValue"],

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

    methods: {
        onHandleInput(dataField, event) {
            try {
                this.valueInput = event.target.value;
                if (this.isInputNumber) {
                    console.log("a");
                    this.valueInput = this.valueInput.replace(/\D+/g, "");
                }
                this.$emit("setValue", this.valueInput, dataField);
            } catch (error) {
                console.log(error);
            }
        },
        handleBlur(event) {
            try {
                if (!event.target.value && this.isRequired) {
                    this.checkData.isInValid = true;
                    this.checkData.errorMessage = `${this.fieldName} không được để trống.`;
                } else {
                    this.checkData.isInValid = false;
                    this.checkData.errorMessage = "";
                }
            } catch (error) {
                console.log(error);
            }
        },
    },

    components: { BaseTooltip },
};
</script>
<style scoped>
@import url("./input.css");
</style>
