<template>
    <div class="modal__group modal__col" :class="className">
        <label :for="'Input_' + dataField" class="modal__label mb-6">
            {{ lable }}
            <span class="text-danger" v-if="isRequired"> * </span>
        </label>
        <input
            :id="'Input_' + dataField"
            :class="{ modal__control: true }"
            :type="type"
            :ref="dataField"
            :name="dataField"
            :value="valueField"
            :tabindex="tabindex"
            :placeholder="fieldName"
            :maxlength="maxlength"
            :autocomplete="autocomplete"
            @change="handleChange(dataField, $event)"
            @blur="handleBlur($event)"
        />
        <span v-if="checkData.isValid">{{ checkData.errorMessage }}</span>
    </div>
</template>
<script>
export default {
    name: "BaseInput",
    props: {
        lable: String,
        className: String,
        type: String,
        dataField: String,
        valueField: String,
        tabindex: String,
        fieldName: String,
        maxlength: Number,
        autocomplete: String,
        isRequired: Boolean,
        errorMessage: String,
    },
    emits: ["setValue"],
    data() {
        return {
            checkData: {
                isValid: true,
                errorMessage: "",
            },
        };
    },
    methods: {
        handleChange(dataField, event) {
            try {
                this.$emit("setValue", dataField, event.target.value);
            } catch (error) {
                console.log(error);
            }
        },
        handleBlur(event) {
            try {
                if (!event.target.value) {
                    this.checkData.isValid = true;
                    this.checkData.errorMessage =
                        "Trường này không được để trống!";
                } else {
                    this.checkData.isValid = false;
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
