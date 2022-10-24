<template>
    <tbody
        class="table-body"
        v-if="
            dataReady &&
            columns.filter((item) => {
                return item.isShow == true;
            }).length > 0
        "
    >
        <tr
            class="table-row"
            v-for="(item, index) in data"
            :key="'Row_' + (index + 1)"
            @dblclick="this.columnActions.actionPrimary.functionAction(item)"
        >
            <td>
                <input type="checkbox" :id="'Row_' + (index + 1)" />
                <label
                    class="table-checkbox"
                    :for="'Row_' + (index + 1)"
                    @dblclick.stop="null"
                >
                    <div class="table-checkbox__icon"></div>
                </label>
            </td>
            <BaseGridCol
                v-for="(column, index) in columns.filter((item) => {
                    return item.isShow == true;
                })"
                :key="'Col_' + (index + 1)"
                :value="item[column.dataField]"
                :isCenter="column.isCenter"
                :isRight="column.isRight"
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
                            this.columnActions.actionPrimary.functionAction(
                                item
                            )
                        "
                    >
                        <span>{{
                            columnActions.actionPrimary.nameAction
                        }}</span>
                    </button>
                    <button
                        class="table-content__menu--choose"
                        @click="
                            isShowListAction && isShowListAction == item
                                ? showListAction(null)
                                : showListAction(item)
                        "
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
    <tbody
        class="table-body"
        v-if="
            !dataReady &&
            columns.filter((item) => {
                return item.isShow == true;
            }).length > 0
        "
    >
        <tr v-for="index in 10" :key="index">
            <td class="table-cell-loader">
                <div class="loading-animation"></div>
            </td>
            <td
                class="table-cell-loader"
                v-for="index in columns.filter((item) => {
                    return item.isShow == true;
                }).length"
                :key="'col_load_' + index"
            >
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
