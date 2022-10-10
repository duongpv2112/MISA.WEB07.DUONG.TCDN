<template>
    <tbody class="table-body" v-if="dataReady">
        <tr
            class="table-row"
            v-for="(item, index) in data"
            :key="'Row_' + (index + 1)"
        >
            <td>
                <input type="checkbox" :id="'Row_' + (index + 1)" />
                <label class="table-checkbox" :for="'Row_' + (index + 1)">
                    <div class="table-checkbox__icon"></div>
                </label>
            </td>
            <BaseGridCol
                v-for="(column, index) in columns"
                :key="'Col_' + (index + 1)"
                :value="item[column.dataField]"
            />
            <td
                :key="'col_action_' + (index + 1)"
                :class="{
                    'z-index1': isShowListAction && isShowListAction == item,
                }"
            >
                <div class="table-content__menu d-flex flex-center">
                    <button
                        class="table-content__menu--action"
                        @click="
                            this.columnActions.actionPrimary.functionAction(item)
                        "
                    >
                        <span>{{
                            columnActions.actionPrimary.nameAction
                        }}</span>
                    </button>
                    <button
                        class="table-content__menu--choose"
                        @click="showListAction(item)"
                    >
                        <span class="square-16 icon icon-downcaret-down"></span>
                    </button>
                </div>
                <div
                    v-if="isShowListAction && isShowListAction == item"
                    v-clickoutside="hideListAction"
                    class="table-content__sub-menu flex-center"
                >
                    <ul class="sub-menu__list">
                        <li
                            class="sub-menu__item"
                            v-for="(action, index) in columnActions.actionChild"
                            :key="'action_child_' + index"
                            @click="action.functionAction(item)"
                        >
                            {{ action.nameAction }}
                        </li>
                    </ul>
                </div>
            </td>
        </tr>
    </tbody>
    <tbody class="table-body" v-if="!dataReady">
        <tr v-for="(item, index) of 10" :key="index">
            <td class="table-cell-loader">
                <div class="loading-animation"></div>
            </td>
            <td class="table-cell-loader">
                <div class="loading-animation"></div>
            </td>
            <td class="table-cell-loader">
                <div class="loading-animation"></div>
            </td>
            <td class="table-cell-loader">
                <div class="loading-animation"></div>
            </td>
            <td class="table-cell-loader">
                <div class="loading-animation"></div>
            </td>
            <td class="table-cell-loader">
                <div class="loading-animation"></div>
            </td>
            <td class="table-cell-loader">
                <div class="loading-animation"></div>
            </td>
            <td class="table-cell-loader">
                <div class="loading-animation"></div>
            </td>
            <td class="table-cell-loader">
                <div class="loading-animation"></div>
            </td>
            <td class="table-cell-loader">
                <div class="loading-animation"></div>
            </td>
            <td class="table-cell-loader">
                <div class="loading-animation"></div>
            </td>
            <td class="table-cell-loader" style="min-width: 120px">
                <div class="loading-animation"></div>
            </td>
        </tr>
    </tbody>
</template>
<script>
import BaseGridCol from "./BaseGridCol.vue";
export default {
    name: "BaseGridRow",
    props: {
        data: Array,
        columns: Array,
        columnActions: Object,
        dataReady: Boolean,
    },
    components: { BaseGridCol },
    data() {
        return {
            isShowListAction: null,
        };
    },

    methods: {
        showListAction(item) {
            this.isShowListAction = item;
        },

        hideListAction() {
            this.isShowListAction = null;
        },
    },
};
</script>
<style scoped></style>
