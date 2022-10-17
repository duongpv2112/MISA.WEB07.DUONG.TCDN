<template>
    <div class="modal__body">
        <div class="modal__body-top">
            <div class="main-infomation">
                <div class="modal__row">
                    <div class="col-7 pr-12">
                        <div class="d-flex flex-wrap">
                            <div class="modal__col col-5">
                                <label class="modal__label mb-6">
                                    Mã đối tượng
                                </label>
                                <BaseComboboxTable
                                    :propValue="'employee_id'"
                                    :propText="'employee_name'"
                                    :dataField="'account_object_id'"
                                    :dataText="'account_object_name'"
                                    :className="['modal__group', 'col-12']"
                                    :isBottom="true"
                                />
                            </div>
                            <BaseInput
                                :className="[
                                    'modal__group',
                                    'modal__col',
                                    'col-7',
                                ]"
                                :lable="'Tên đối tượng'"
                                :maxlength="20"
                                :isNotTooltip="false"
                            />
                            <BaseInput
                                :className="[
                                    'modal__group',
                                    'modal__col',
                                    'col-5',
                                ]"
                                :lable="'Người nhận'"
                                :maxlength="20"
                                :isNotTooltip="false"
                            />
                            <BaseInput
                                :className="[
                                    'modal__group',
                                    'modal__col',
                                    'col-7',
                                ]"
                                :lable="'Địa chỉ'"
                                :maxlength="20"
                                :isNotTooltip="false"
                            />
                            <BaseInput
                                :className="[
                                    'modal__group',
                                    'modal__col',
                                    'col-12',
                                ]"
                                :lable="'Lý do chi'"
                                :maxlength="20"
                                :isNotTooltip="false"
                            />
                            <div class="d-flex col-12">
                                <div class="modal__col col-5">
                                    <label class="modal__label mb-6">
                                        Nhân viên
                                    </label>
                                    <BaseComboboxTable
                                        :propValue="'employee_id'"
                                        :propText="'employee_name'"
                                        :dataField="'account_object_id'"
                                        :dataText="'account_object_name'"
                                        :className="['modal__group', 'col-12']"
                                        :isBottom="true"
                                    />
                                </div>

                                <BaseInput
                                    :className="[
                                        'modal__group',
                                        'modal__col',
                                        'col-2',
                                    ]"
                                    :lable="'Kèm theo'"
                                    :maxlength="20"
                                />
                                <span class="root-invoice px-2"
                                    >chứng từ gốc</span
                                >
                            </div>
                            <div class="d-flex col-12 modal__col">
                                <div class="reference">
                                    <div class="reference-title-main">
                                        Tham chiếu
                                    </div>
                                    <div class="reference-icon">...</div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-2">
                        <div class="col-12">
                            <label
                                for=""
                                class="modal__label left-separate-lable"
                            >
                                Ngày hạch toán
                            </label>
                            <vc-date-picker
                                v-model="a"
                                :popover="{
                                    visibility: 'focus',
                                }"
                                mode="date"
                                :attributes="datepicker"
                            >
                                <template v-slot="{ inputValue, inputEvents }">
                                    <label
                                        class="d-block p-relative"
                                        :class="[
                                            'modal__group',
                                            'modal__col',
                                            'mb-control-group',
                                            'col-12',
                                            'left-separate',
                                        ]"
                                    >
                                        <div
                                            class="square-32 cursor-pointer modal-icon__calendar"
                                        >
                                            <span
                                                class="square-32 icon icon-calendar"
                                            ></span>
                                        </div>
                                        <input
                                            class="modal__control modal__datepicker"
                                            v-on="inputEvents"
                                            ref="identity_date"
                                            :value="inputValue"
                                        />
                                    </label>
                                </template>
                            </vc-date-picker>
                        </div>
                        <div class="col-12">
                            <label
                                for=""
                                class="modal__label left-separate-lable"
                            >
                                Ngày phiếu chi
                            </label>
                            <vc-date-picker
                                v-model="a"
                                :popover="{
                                    visibility: 'focus',
                                }"
                                mode="date"
                                :attributes="datepicker"
                            >
                                <template v-slot="{ inputValue, inputEvents }">
                                    <label
                                        class="d-block p-relative"
                                        :class="[
                                            'modal__group',
                                            'modal__col',
                                            'mb-control-group',
                                            'col-12',
                                            'left-separate',
                                        ]"
                                    >
                                        <div
                                            class="square-32 cursor-pointer modal-icon__calendar"
                                        >
                                            <span
                                                class="square-32 icon icon-calendar"
                                            ></span>
                                        </div>
                                        <input
                                            class="modal__control modal__datepicker"
                                            v-on="inputEvents"
                                            ref="identity_date"
                                            :value="inputValue"
                                        />
                                    </label>
                                </template>
                            </vc-date-picker>
                        </div>
                        <div class="col-12">
                            <BaseInput
                                :className="[
                                    'modal__group',
                                    'modal__col',
                                    'col-12',
                                    'left-separate',
                                ]"
                                :lable="'Mã đối tượng'"
                                :maxlength="20"
                            />
                        </div>
                    </div>
                    <div class="col-3 modal__col">
                        <div class="summary-info">
                            <div class="summary-info-title">Tổng tiền</div>
                            <div class="summary-info-number">10.000.000</div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="grid-accounting">
                <div class="tab-detail">
                    <div class="tab-detail-title">Hạch toán</div>
                    <div class="tab-header-extend">
                        <div class="tab-header-option">
                            <div class="option-lable">Loại tiền</div>
                            <BaseComboboxDefault
                                :className="['tab-combobox']"
                                :isHideLable="true"
                                :isBottom="true"
                            />
                        </div>
                    </div>
                </div>

                <div class="grid-data">
                    <table class="table">
                        <thead class="table-head">
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Diễn giải</th>
                                <th scope="col">TK Nợ</th>
                                <th scope="col">TK Có</th>
                                <th scope="col">Số tiền</th>
                                <th scope="col">Đối tượng</th>
                                <th scope="col">Tên đối tượng</th>
                                <th scope="col">TK ngân hàng</th>
                                <th scope="col">Khế ước vay</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody class="table-body">
                            <tr class="table-row">
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>Xóa</td>
                            </tr>
                        </tbody>
                        <tfoot class="table-head">
                            <tr class="table-row">
                                <th></th>
                                <th></th>
                                <th></th>
                                <th></th>
                                <th></th>
                                <th></th>
                                <th></th>
                                <th></th>
                                <th></th>
                                <th></th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
            <div class="grid-control-accounting">
                <div class="grid-btn-control">
                    <button class="grid-btn mr-12">
                        <span class="grid-btn-title">Thêm dòng</span>
                    </button>

                    <button class="grid-btn">
                        <span class="grid-btn-title">Xóa hết dòng</span>
                    </button>
                </div>

                <div class="grid-input-control">
                    <div class="grid-input-title">
                        <div class="attach-text">
                            <div class="icon grid-input-icon icon-attach"></div>
                            <div>Đính kèm</div>
                        </div>
                        <div class="max-size-upload">Dung lượng tối đa 5MB</div>
                    </div>
                    <div class="grid-input-upload">
                        <input type="file" />
                        <span>Kéo/thả tệp vào đây hoặc bấm vào đây</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal__footer">
        <div class="modal__footer--left">
            <BaseButton
                :title="RESOURCE.RECEIPT_PAYMENT_CANCEL_BTN"
                :className="[
                    'button-text-13',
                    'button-text-bold',
                    'button-border-modal',
                ]"
                :isButtonCancel="true"
            />
        </div>
        <div class="modal__footer--right d-flex">
            <BaseButton
                :title="RESOURCE.RECEIPT_PAYMENT_SAVE_BTN"
                :className="[
                    'button-text-13',
                    'button-text-bold',
                    'button-border-modal',
                    'mr-12',
                ]"
                :contentTooltip="'Cất (Ctrl + S)'"
                :classNameTooltip="['tooltip-default']"
            />
            <div class="d-flex">
                <BaseButton
                    :title="RESOURCE.RECEIPT_PAYMENT_SAVE_AND_ADD_BTN"
                    :className="[
                        'button-text',
                        'button-primary',
                        'button-border-radius-right',
                    ]"
                />
                <div class="d-flex button-combobox">
                    <button
                        class="button button-primary button-border-radius-left"
                        @click="onHandleShowButtonCombobox"
                    >
                        <div class="d-flex flex-center button-icon">
                            <span
                                class="icon square-16 icon-arrow-up--white"
                            ></span>
                            <div class="button-line"></div>
                        </div>
                    </button>
                    <div
                        v-if="isShowButtonCombobox"
                        v-clickoutside="onHideButtonCombobox"
                        class="button-combobox__data"
                    >
                        <ul class="button-combobox__list">
                            <div class="tooltip">
                                <li class="button-combobox__item">
                                    <a href="#">Cất và Thêm</a>
                                </li>
                                <BaseTooltip
                                    :content="'Cất và thêm (Ctrl + Shift + S)'"
                                    :className="['tooltip-absolute-left']"
                                />
                            </div>
                            <div class="tooltip">
                                <li class="button-combobox__item">
                                    <a href="#">Cất và Đóng</a>
                                    <BaseTooltip
                                        :content="'Cất và đóng (Ctrl + Q)'"
                                        :className="['tooltip-absolute-left']"
                                    />
                                </li>
                            </div>
                            <div class="tooltip">
                                <li class="button-combobox__item tooltip">
                                    <a href="#">Cất và In</a>
                                    <BaseTooltip
                                        :content="'Cất và in (Ctrl + Alt + P)'"
                                        :className="['tooltip-absolute-left']"
                                    />
                                </li>
                            </div>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal__action d-flex">
        <div class="guide-tour d-flex flex-center">
            <span class="icon square-24 icon-tour"></span>
            <a href="#" class="guide-tour__link">Hướng dẫn</a>
        </div>
        <button class="modal__button modal__button--support tooltip">
            <i class="square-24 icon icon-setting__detail"></i>
            <BaseTooltip
                :content="'Tùy chỉnh giao diện'"
                :className="['tooltip-default']"
            />
        </button>
        <button class="modal__button modal__button--support tooltip">
            <i class="square-24 icon icon-support"></i>
            <BaseTooltip
                :content="'Giúp (F1)'"
                :className="['tooltip-default']"
            />
        </button>
        <button
            class="modal__button modal__button--close tooltip"
            @click="onClose"
        >
            <i class="square-24 icon icon-times"></i>
            <BaseTooltip
                :content="'Đóng (ESC)'"
                :className="['tooltip-default']"
            />
        </button>
    </div>
</template>
<script>
import { RECEIPT_PAYMENT_TEXT_CONFIG } from "@/views/CashPage/ReceiptPayment/constants/resources";
import BaseTooltip from "@/components/bases/BaseTooltip/BaseTooltip.vue";
import BaseButton from "@/components/bases/BaseButton/BaseButton.vue";
import BaseInput from "@/components/bases/BaseInput/BaseInput.vue";
import BaseComboboxTable from "@/components/bases/BaseCombobox/BaseComboboxTable.vue";
import BaseComboboxDefault from "@/components/bases/BaseCombobox/BaseComboboxDefault.vue";

export default {
    name: "ReceiptPaymentForm",

    components: {
        BaseTooltip,
        BaseButton,
        BaseInput,
        BaseComboboxTable,
        BaseComboboxDefault,
    },

    props: {
        onClose: Function,
    },

    data() {
        return {
            RESOURCE: RECEIPT_PAYMENT_TEXT_CONFIG,

            isShowButtonCombobox: Boolean,

            datepicker: [
                {
                    key: "today",
                    highlight: "green",
                    dates: new Date(),
                },
            ],
            a: null,
        };
    },

    created() {
        this.isShowButtonCombobox = false;
    },

    methods: {
        onHandleShowButtonCombobox() {
            this.isShowButtonCombobox = !this.isShowButtonCombobox;
        },

        onHideButtonCombobox() {
            this.isShowButtonCombobox = false;
        },
    },
};
</script>
<style scoped>
.modal__body-top {
}

.modal__body-top .main-infomation {
    background-color: #eceef1;
    padding: 8px 24px 20px;
}

.modal__body-top .grid-accounting {
    padding: 16px 24px 12px;
}

.modal__body-top .grid-control-accounting {
    display: flex;
    flex-direction: column;
    padding: 0 24px 26px;
}

.clear {
    height: 26px;
    width: 100%;
}
</style>
