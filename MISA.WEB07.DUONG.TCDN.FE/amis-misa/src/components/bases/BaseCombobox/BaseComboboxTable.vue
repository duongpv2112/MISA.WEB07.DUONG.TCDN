<template>
    <div class="combobox border-radius-2" :class="className">
        <div class="combobox-selected">
            <div class="combobox-selected--input">
                <input
                    v-model="textInput"
                    type="text"
                    :placeholder="placeholder"
                    :tabindex="tabindex"
                    :readonly="isReadOnly"
                />
            </div>
            <div class="combobox-selected--icon" @click="btnSelectDataOnClick">
                <i
                    class="icon icon-dropdown square-16"
                    :class="{
                        'rotate-0': !isShowListData,
                        'rotate-180': isShowListData,
                    }"
                ></i>
            </div>
        </div>
        <div
            v-if="isShowListData"
            class="combobox-data"
            v-clickoutside="hideListData"
            :class="{ 'absolute-bottom': isBottom }"
        >
            <table class="combobox-table">
                <thead>
                    <tr>
                        <th
                            scope="col"
                            v-for="(item, index) in nameRow"
                            :key="index"
                        >
                            {{ item }}
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>1</td>
                        <td>2</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>
<script>
export default {
    name: "BaseComboboxTable",

    props: {
        value: String,
        placeholder: String,
        tabindex: Number,
        isReadOnly: Boolean,
        isTop: Boolean,
        isBottom: Boolean,
        listData: Array,
        className: Array,
        nameRow: Array,
    },

    methods: {
        /**
         * Nhấn vào button thì hiển thị hoặc ẩn List Item
         * @author: DUONGPV (08/09/2022)
         */
        btnSelectDataOnClick() {
            this.dataFilter = this.data;
            this.isShowListData = !this.isShowListData;
        },

        /**
         * Nhấn vào button thì hiển thị hoặc ẩn List Item
         * @author: DUONGPV (08/09/2022)
         */
        hideListData() {
            this.isShowListData = false;
        },
    },
    created() {
        try {
            if (this.url) {
                fetch(this.url)
                    .then((res) => res.json())
                    .then((res) => {
                        this.dataCombobox = res;
                        this.dataFilter = res;
                    })
                    .catch((res) => {
                        console.log(res);
                    });
            } else {
                this.dataCombobox = this.listData;
            }
            if (this.value) {
                this.textInput = this.value;
            }
        } catch (error) {
            console.log(error);
        }
    },
    beforeUpdate() {
        if (this.value) {
            this.textInput = this.value;
        }
    },
    data() {
        return {
            dataCombobox: Array,
            textInput: null,
            isShowListData: false,
        };
    },
};
</script>
<style scoped></style>
