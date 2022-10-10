<template>
    <div :class="className">
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
            :class="{ modal__control: true, 'input-number': isInputNumber }"
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
            step="1"
            @input="onHandleInput(dataField, $event)"
            @blur="handleBlur($event)"
        />
        <span v-if="checkData.isInValid">{{ checkData.errorMessage }}</span>
    </div>
</template>
<script>
import { common } from "@/libs/common/common";
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
                if (!event.target.value) {
                    this.checkData.isInValid = true;
                    this.checkData.errorMessage =
                        "Trường này không được để trống!";
                } else {
                    this.checkData.isInValid = false;
                    this.checkData.errorMessage = "";
                }
            } catch (error) {
                console.log(error);
            }
        },
    },
};
</script>
<style scoped>
@import url("./input.css");
</style>
