<template>
    <div :class="className">
        <label :for="'Input_' + dataField" class="modal__label mb-6">
            {{ lable }}
        </label>
        <textarea
            :id="'Input_' + dataField"
            :ref="dataField"
            :name="dataField"
            :value="valueField"
            :tabindex="tabindex"
            :placeholder="fieldName"
            :autocomplete="autocomplete"
            :readonly="isReadonly"
            :maxlength="maxlength"
            :rows="numberRow"
            :class="{
                'bg-readonly': fieldReadonly && isReadonly,
                textarea__control: true,
            }"
            @change="handleChange(dataField, $event)"
        ></textarea>
    </div>
</template>
<script>
export default {
    name: "BaseTextArea",
    props: {
        lable: String,
        className: Array,
        dataField: String,
        valueField: String,
        isReadonly: Boolean,
        tabindex: String,
        fieldName: String,
        maxlength: Number,
        numberRow: Number,
        autocomplete: String,
    },
    emits: ["setValue"],

    data() {
        return {
            fieldReadonly: false,
        };
    },

    methods: {
        handleChange(dataField, event) {
            try {
                this.$emit("setValue", event.target.value, dataField);
            } catch (error) {
                console.log(error);
            }
        },
    },

    created() {
        this.fieldReadonly = this.isReadonly;
    },
};
</script>
<style scoped>
@import url("./textarea.css");
</style>
