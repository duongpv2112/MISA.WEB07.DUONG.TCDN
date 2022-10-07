<template>
    <div :class="className">
        <label
            :for="'Input_' + dataField"
            class="modal__label mb-6"
        >
            {{ lable }}
        </label>
        <textarea
            :id="'Input_' + dataField"
            :class="{ textarea__control: true }"
            :ref="dataField"
            :name="dataField"
            :value="valueField"
            :tabindex="tabindex"
            :placeholder="fieldName"
            :autocomplete="autocomplete"
            :maxlength="maxlength"
            :rows="numberRow"
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
        tabindex: String,
        fieldName: String,
        maxlength: Number,
        numberRow: Number,
        autocomplete: String,
    },
    emits: ["setValue"],
    data() {
        return {};
    },
    methods: {
        handleChange(dataField, event) {
            try {
                this.$emit("setValue", dataField, event.target.value);
            } catch (error) {
                console.log(error);
            }
        },
    },
};
</script>
<style scoped>
@import url("./textarea.css");
</style>
