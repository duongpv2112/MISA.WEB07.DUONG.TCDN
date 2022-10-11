<template>
    <div class="modal__body">
        <div class="line-bottom">
            <div class="modal__row">
                <div class="col-6 pr-26">
                    <div class="d-flex px-1">
                        <BaseInput
                            :className="[
                                'modal__group',
                                'modal__col',
                                'col-4',
                                typeSupplier == 1 ? 'order-1' : '',
                            ]"
                            :lable="RESOURCE.SUPPLIER_TAXCODE_FIELD_LBL"
                            :type="TYPE_INPUT.TYPE_TEXT"
                            :dataField="listField.tax_code"
                            :valueField="account_object.tax_code"
                            :fieldName="RESOURCE.SUPPLIER_TAXCODE_FIELD_LBL"
                            :maxlength="20"
                            :isReadonly="isViewDetail"
                            :firstFocus="true"
                            @setValue="setValue"
                        />

                        <BaseInput
                            :className="['modal__group', 'modal__col', 'col-8']"
                            :lable="RESOURCE.SUPPLIER_CODE_FIELD_LBL"
                            :type="TYPE_INPUT.TYPE_TEXT"
                            :dataField="listField.account_object_code"
                            :valueField="account_object.account_object_code"
                            :fieldName="RESOURCE.SUPPLIER_CODE_FIELD_LBL"
                            :maxlength="20"
                            :isRequired="true"
                            :isReadonly="isViewDetail"
                            @setValue="setValue"
                        />
                    </div>
                    <div class="d-flex flex-wrap px-1">
                        <BaseInput
                            v-if="typeSupplier != 1"
                            :className="[
                                'modal__group',
                                'modal__col',
                                'col-12',
                            ]"
                            :lable="RESOURCE.SUPPLIER_NAME_FIELD_LBL"
                            :type="TYPE_INPUT.TYPE_TEXT"
                            :dataField="listField.account_object_name"
                            :valueField="account_object.account_object_name"
                            :fieldName="RESOURCE.SUPPLIER_NAME_FIELD_LBL"
                            :isRequired="true"
                            :isReadonly="isViewDetail"
                            @setValue="setValue"
                        />

                        <div
                            v-if="typeSupplier == 1"
                            class="d-flex col-12"
                            :class="{ 'order-2': typeSupplier == 1 }"
                        >
                            <div class="modal__col col-12">
                                <label class="modal__label mb-6">
                                    {{ RESOURCE.SUPPLIER_NAME_FIELD_LBL }}
                                </label>
                                <div class="modal__row">
                                    <div class="modal__group modal__col col-4">
                                        <BaseComboboxDefault
                                            :className="[
                                                'col-12',
                                            ]"
                                            :dataField="
                                                listField.vocative_supplier
                                            "
                                            :value="
                                                VOCATIVE[
                                                    account_object
                                                        .vocative_supplier
                                                ]
                                            "
                                            :listData="listVocative"
                                            :placeholder="
                                                RESOURCE.SUPPLIER_VOCATIVE_FIELD_LBL
                                            "
                                            :isHideLable="true"
                                            :isBottom="true"
                                            :isReadOnly="isViewDetail"
                                            @setValue="setValue"
                                        />
                                    </div>

                                    <BaseInput
                                        :className="[
                                            'modal__group',
                                            'modal__col',
                                            'col-8',
                                        ]"
                                        :type="TYPE_INPUT.TYPE_TEXT"
                                        :dataField="
                                            listField.account_object_name
                                        "
                                        :valueField="
                                            account_object.account_object_name
                                        "
                                        :fieldName="
                                            RESOURCE.SUPPLIER_REPRESENTATIVE_NAME_FIELD_LBL
                                        "
                                        :isHideLable="true"
                                        :isReadonly="isViewDetail"
                                        @setValue="setValue"
                                    />
                                </div>
                            </div>
                        </div>

                        <BaseTextArea
                            :className="[
                                'modal__group',
                                'modal__col',
                                'col-12',
                                typeSupplier == 1 ? 'order-3' : '',
                            ]"
                            :lable="RESOURCE.SUPPLIER_ADDRESS_FIELD_LBL"
                            :dataField="listField.address"
                            :valueField="account_object.address"
                            :fieldName="RESOURCE.SUPPLIER_ADDRESS_FIELD_LBL"
                            :numberRow="2"
                            :isReadonly="isViewDetail"
                            @setValue="setValue"
                        />
                    </div>
                </div>

                <div class="col-6">
                    <div class="d-flex px-1">
                        <BaseInput
                            v-if="typeSupplier != 1"
                            :className="['modal__group', 'modal__col', 'col-4']"
                            :lable="RESOURCE.SUPPLIER_PHONE_FIELD_LBL"
                            :type="TYPE_INPUT.TYPE_TEXT"
                            :dataField="listField.telephone_number"
                            :valueField="account_object.telephone_number"
                            :fieldName="RESOURCE.SUPPLIER_PHONE_FIELD_LBL"
                            :isReadonly="isViewDetail"
                            @setValue="setValue"
                        />

                        <BaseInput
                            v-if="typeSupplier != 1"
                            :className="['modal__group', 'modal__col', 'col-8']"
                            :lable="RESOURCE.SUPPLIER_WEBSITE_FIELD_LBL"
                            :type="TYPE_INPUT.TYPE_TEXT"
                            :dataField="listField.website"
                            :valueField="account_object.website"
                            :fieldName="RESOURCE.SUPPLIER_WEBSITE_FIELD_LBL"
                            :isReadonly="isViewDetail"
                            @setValue="setValue"
                        />
                    </div>

                    <div class="d-flex flex-wrap px-1">
                        <div class="modal__group modal__col col-12">
                            <label class="modal__label mb-6">
                                {{ RESOURCE.SUPPLIER_GROUP_FIELD_LBL }}
                            </label>
                            <BaseComboboxTags
                                :url="API.PAGING_DATA_SUPPLIER_GROUP"
                                :propValue="'supplier_group_id'"
                                :className="[
                                    'col-12',
                                ]"
                                :dataField="'supplier_group_id'"
                                :propText="'supplier_group_code'"
                                :value="valueSupplierConstraints"
                                :isReadOnly="isViewDetail"
                                :isBottom="true"
                                :placeholder="RESOURCE.SUPPLIER_GROUP_FIELD_LBL"
                                :nameRow="[
                                    {
                                        fieldName: 'Mã nhóm KH, NCC',
                                        dataField: 'supplier_group_code',
                                        stypeColumn: {
                                            'min-width': '150px !important',
                                        },
                                    },
                                    {
                                        fieldName: 'Tên nhóm KH, NCC',
                                        dataField: 'supplier_group_name',
                                        stypeColumn: {},
                                    },
                                ]"
                                @setValueList="setValueList"
                            />
                        </div>

                        <div class="modal__group modal__col col-12">
                            <label class="modal__label mb-6">
                                {{ RESOURCE.SUPPLIER_EMPLOYEE_FIELD_LBL }}
                            </label>
                            <BaseComboboxTable
                                :url="API.PAGING_DATA_EMPLOYEE"
                                :propValue="'employee_id'"
                                :propText="'employee_name'"
                                :dataField="'account_object_id'"
                                :dataText="'account_object_name'"
                                :className="[
                                    'modal__group',
                                    'col-12',
                                ]"
                                :value="account_object.employee_name"
                                :isReadOnly="isViewDetail"
                                :isBottom="true"
                                :placeholder="
                                    RESOURCE.SUPPLIER_EMPLOYEE_FIELD_LBL
                                "
                                :nameRow="[
                                    {
                                        fieldName: 'Mã nhân viên',
                                        dataField: 'account_object_code',
                                    },
                                    {
                                        fieldName: 'Tên nhân viên',
                                        dataField: 'account_object_name',
                                    },
                                ]"
                                @setValue="setValue"
                            />
                        </div>
                    </div>
                </div>
            </div>

            <BaseTabs>
                <BaseTabItem name="Thông tin liên hệ">
                    <div v-if="typeSupplier != 1" class="modal__row">
                        <div class="d-flex pr-26 col-6">
                            <div class="modal__group modal__col col-12">
                                <label class="modal__label mb-6">
                                    {{
                                        RESOURCE.SUPPLIER_CONTACT_NAME_FIELD_LBL
                                    }}
                                </label>

                                <div class="modal__row">
                                    <div class="d-flex col-12">
                                        <div
                                            class="modal__group modal__col mb-control-group col-4"
                                        >
                                            <BaseComboboxDefault
                                                :className="[
                                                    'col-12',
                                                ]"
                                                :dataField="
                                                    listField.vocative_contact
                                                "
                                                :value="
                                                    VOCATIVE[
                                                        account_object
                                                            .vocative_contact
                                                    ]
                                                "
                                                :listData="listVocative"
                                                :placeholder="
                                                    RESOURCE.SUPPLIER_VOCATIVE_FIELD_LBL
                                                "
                                                :isHideLable="true"
                                                :isBottom="true"
                                                :isReadOnly="isViewDetail"
                                                @setValue="setValue"
                                            />
                                        </div>

                                        <BaseInput
                                            :className="[
                                                'modal__group',
                                                'modal__col',
                                                'mb-control-group',
                                                'col-8',
                                            ]"
                                            :type="TYPE_INPUT.TYPE_TEXT"
                                            :dataField="listField.contact_name"
                                            :valueField="
                                                account_object.contact_name
                                            "
                                            :fieldName="
                                                RESOURCE.SUPPLIER_CONTACT_NAME_PLACEHOLDER
                                            "
                                            :isHideLable="true"
                                            :isReadonly="isViewDetail"
                                            @setValue="setValue"
                                        />
                                    </div>
                                    <BaseInput
                                        :className="[
                                            'modal__group',
                                            'modal__col',
                                            'mb-control-group',
                                            'col-12',
                                        ]"
                                        :type="TYPE_INPUT.TYPE_TEXT"
                                        :dataField="listField.email"
                                        :valueField="account_object.email"
                                        :fieldName="
                                            RESOURCE.SUPPLIER_EMAIL_FIELD_LBL
                                        "
                                        :isHideLable="true"
                                        :isReadonly="isViewDetail"
                                        @setValue="setValue"
                                    />
                                    <BaseInput
                                        :className="[
                                            'modal__group',
                                            'modal__col',
                                            'mb-control-group',
                                            'col-6',
                                        ]"
                                        :type="TYPE_INPUT.TYPE_TEXT"
                                        :dataField="listField.phone_number"
                                        :valueField="
                                            account_object.phone_number
                                        "
                                        :fieldName="
                                            RESOURCE.SUPPLIER_PHONE_FIELD_LBL
                                        "
                                        :isHideLable="true"
                                        :isReadonly="isViewDetail"
                                        @setValue="setValue"
                                    />
                                </div>
                            </div>
                        </div>

                        <div class="d-flex col-6">
                            <BaseInput
                                :className="[
                                    'modal__group',
                                    'modal__col',
                                    'col-12',
                                ]"
                                :lable="
                                    RESOURCE.SUPPLIER_REPRESENTATIVE_FIELD_LBL
                                "
                                :type="TYPE_INPUT.TYPE_TEXT"
                                :dataField="listField.representative_name"
                                :valueField="account_object.representative_name"
                                :fieldName="
                                    RESOURCE.SUPPLIER_REPRESENTATIVE_FIELD_LBL
                                "
                                :isReadonly="isViewDetail"
                                @setValue="setValue"
                            />
                        </div>
                    </div>
                    <div v-if="typeSupplier == 1" class="modal__row">
                        <div class="d-flex flex-wrap pr-26 col-6">
                            <div class="modal__group modal__col mb-0 col-12">
                                <label class="modal__label mb-6">
                                    {{
                                        RESOURCE.SUPPLIER_CONTACT_NAME_FIELD_LBL_V2
                                    }}
                                </label>

                                <div class="modal__row">
                                    <BaseInput
                                        :className="[
                                            'modal__group',
                                            'modal__col',
                                            'mb-control-group',
                                            'col-12',
                                        ]"
                                        :type="TYPE_INPUT.TYPE_TEXT"
                                        :dataField="listField.email"
                                        :valueField="account_object.email"
                                        :fieldName="
                                            RESOURCE.SUPPLIER_EMAIL_FIELD_LBL
                                        "
                                        :isReadonly="isViewDetail"
                                        :isHideLable="true"
                                        @setValue="setValue"
                                    />

                                    <div class="d-block col-12">
                                        <BaseInput
                                            :className="[
                                                'modal__group',
                                                'modal__col',
                                                'mb-control-group',
                                                'col-6',
                                            ]"
                                            :type="TYPE_INPUT.TYPE_TEXT"
                                            :dataField="listField.phone_number"
                                            :valueField="
                                                account_object.phone_number
                                            "
                                            :fieldName="
                                                RESOURCE.SUPPLIER_MOBILEPHONE_FIELD_LBL
                                            "
                                            :isReadonly="isViewDetail"
                                            :isHideLable="true"
                                            @setValue="setValue"
                                        />
                                    </div>
                                    <div class="d-block col-12">
                                        <BaseInput
                                            :className="[
                                                'modal__group',
                                                'modal__col',
                                                'mb-control-group',
                                                'col-6',
                                            ]"
                                            :type="TYPE_INPUT.TYPE_TEXT"
                                            :dataField="
                                                listField.telephone_number
                                            "
                                            :valueField="
                                                account_object.telephone_number
                                            "
                                            :fieldName="
                                                RESOURCE.SUPPLIER_TELEPHONE_FIELD_LBL
                                            "
                                            :isReadonly="isViewDetail"
                                            :isHideLable="true"
                                            @setValue="setValue"
                                        />
                                    </div>
                                </div>
                            </div>

                            <div class="modal__group modal__col mb-0 col-12">
                                <div class="modal__row">
                                    <BaseInput
                                        :className="[
                                            'modal__group',
                                            'modal__col',
                                            'mb-control-group',
                                            'col-12',
                                        ]"
                                        :lable="
                                            RESOURCE.SUPPLIER_REPRESENTATIVE_FIELD_LBL
                                        "
                                        :type="TYPE_INPUT.TYPE_TEXT"
                                        :dataField="
                                            listField.representative_name
                                        "
                                        :valueField="
                                            account_object.representative_name
                                        "
                                        :fieldName="
                                            RESOURCE.SUPPLIER_REPRESENTATIVE_FIELD_LBL
                                        "
                                        :isReadonly="isViewDetail"
                                        @setValue="setValue"
                                    />
                                </div>
                            </div>
                        </div>

                        <div class="d-flex flex-wrap col-6">
                            <div class="modal__group modal__col mb-0 col-12">
                                <label class="modal__label mb-6">
                                    {{ RESOURCE.SUPPLIER_IDENTITY_FIELD_LBL }}
                                </label>

                                <div class="modal__row">
                                    <div class="d-block col-12">
                                        <BaseInput
                                            :className="[
                                                'modal__group',
                                                'modal__col',
                                                'mb-control-group',
                                                'col-6',
                                            ]"
                                            :type="TYPE_INPUT.TYPE_TEXT"
                                            :dataField="
                                                listField.identity_number
                                            "
                                            :valueField="
                                                account_object.identity_number
                                            "
                                            :fieldName="
                                                RESOURCE.SUPPLIER_IDENTITY_NUMBER_FIELD_LBL
                                            "
                                            :isHideLable="true"
                                            :isReadonly="isViewDetail"
                                            @setValue="setValue"
                                        />
                                    </div>
                                    <div class="d-block col-12">
                                        <vc-date-picker
                                            v-model="
                                                account_object.identity_date
                                            "
                                            :popover="{
                                                visibility: 'focus',
                                            }"
                                            :attributes="datepicker"
                                        >
                                            <template
                                                v-slot="{
                                                    inputValue,
                                                    inputEvents,
                                                }"
                                            >
                                                <label
                                                    :for="
                                                        listField.identity_date
                                                    "
                                                    class="d-block p-relative"
                                                    :class="[
                                                        'modal__group',
                                                        'modal__col',
                                                        'mb-control-group',
                                                        'col-6',
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
                                                        :value="inputValue"
                                                        :id="
                                                            listField.identity_date
                                                        "
                                                        :placeholder="
                                                            RESOURCE.SUPPLIER_IDENTITY_DATE_FIELD_LBL
                                                        "
                                                    />
                                                </label>
                                            </template>
                                        </vc-date-picker>
                                    </div>
                                    <BaseInput
                                        :className="[
                                            'modal__group',
                                            'modal__col',
                                            'mb-control-group',
                                            'col-12',
                                        ]"
                                        :type="TYPE_INPUT.TYPE_TEXT"
                                        :dataField="listField.identity_place"
                                        :valueField="
                                            account_object.identity_place
                                        "
                                        :fieldName="
                                            RESOURCE.SUPPLIER_IDENTITY_PLACE_FIELD_LBL
                                        "
                                        :isHideLable="true"
                                        :isReadonly="isViewDetail"
                                        @setValue="setValue"
                                    />
                                </div>
                            </div>
                        </div>
                    </div>
                </BaseTabItem>
                <BaseTabItem name="Điều khoản thanh toán">
                    <div class="modal__row">
                        <div class="d-flex col-12">
                            <div class="d-flex col-3">
                                <div class="modal__group modal__col col-12">
                                    <label class="modal__label mb-6">
                                        {{
                                            RESOURCE.SUPPLIER_PAYMENT_TERM_FIELD_LBL
                                        }}
                                    </label>
                                    <BaseComboboxDefault
                                        :className="[
                                            'col-12',
                                        ]"
                                        :dataField="listField.payment_term"
                                        :value="
                                            PAYMENT_TERM[
                                                account_object.payment_term
                                            ]
                                        "
                                        :listData="listPaymentTerm"
                                        :placeholder="
                                            RESOURCE.SUPPLIER_PAYMENT_TERM_FIELD_LBL
                                        "
                                        :isHideLable="true"
                                        :isBottom="true"
                                        :isReadOnly="isViewDetail"
                                        :onHandleEvent="setValue"
                                        @setValue="setValue"
                                    />
                                </div>
                            </div>

                            <BaseInput
                                :className="[
                                    'modal__group',
                                    'modal__col',
                                    'col-3',
                                ]"
                                :lable="
                                    RESOURCE.SUPPLIER_NUM_DAY_OWED_FIELD_LBL
                                "
                                :type="TYPE_INPUT.TYPE_TEXT"
                                :dataField="listField.number_day_owed"
                                :valueField="account_object.number_day_owed"
                                :fieldName="
                                    RESOURCE.SUPPLIER_NUM_DAY_OWED_FIELD_LBL
                                "
                                :maxlength="18"
                                :isInputNumber="true"
                                :isReadonly="isViewDetail"
                                @setValue="setValue"
                            />
                            <BaseInput
                                :className="[
                                    'modal__group',
                                    'modal__col',
                                    'col-3',
                                ]"
                                :lable="RESOURCE.SUPPLIER_MAX_DEBT_FIELD_LBL"
                                :type="TYPE_INPUT.TYPE_TEXT"
                                :dataField="listField.maximum_debt_amount"
                                :valueField="account_object.maximum_debt_amount"
                                :fieldName="
                                    RESOURCE.SUPPLIER_MAX_DEBT_FIELD_LBL
                                "
                                :maxlength="18"
                                :isReadonly="isViewDetail"
                                :isInputNumber="true"
                                @setValue="setValue"
                            />
                        </div>
                        <div class="d-flex col-12">
                            <BaseInput
                                :className="[
                                    'modal__group',
                                    'modal__col',
                                    'col-3',
                                ]"
                                :lable="
                                    RESOURCE.SUPPLIER_ACCOUNT_PAYABLE_FIELD_LBL
                                "
                                :type="TYPE_INPUT.TYPE_TEXT"
                                :dataField="listField.account_payable"
                                :valueField="account_object.account_payable"
                                :fieldName="
                                    RESOURCE.SUPPLIER_ACCOUNT_PAYABLE_FIELD_LBL
                                "
                                :isReadonly="isViewDetail"
                                @setValue="setValue"
                            />
                        </div>
                    </div>
                </BaseTabItem>
                <BaseTabItem name="Tài khoản ngân hàng">
                    <h4>Tính năng đang phát triển. Vui lòng thử lại sau.</h4>
                </BaseTabItem>
                <BaseTabItem name="Địa chỉ khác">
                    <h4>Tính năng đang phát triển. Vui lòng thử lại sau.</h4>
                </BaseTabItem>
                <BaseTabItem name="Ghi chú">
                    <h4>Tính năng đang phát triển. Vui lòng thử lại sau.</h4>
                </BaseTabItem>
            </BaseTabs>
        </div>
    </div>
    <div class="modal__footer">
        <div class="modal__footer--left">
            <BaseButton
                :title="RESOURCE.SUPPLIER_CANCEL_BTN"
                :className="[
                    'button-text-13',
                    'button-text-bold',
                    'button-border-modal',
                ]"
                :isButtonCancel="true"
                :functionz="onClose"
            />
        </div>
        <div class="modal__footer--right">
            <BaseButton
                :title="RESOURCE.SUPPLIER_SAVE_BTN"
                :className="[
                    'button-text-13',
                    'button-text-bold',
                    'button-border-modal',
                    'tooltip',
                    'mr-12',
                ]"
                :contentTooltip="'Cất (Ctrl + S)'"
                :classNameTooltip="['tooltip-default']"
            />
            <BaseButton
                :title="RESOURCE.SUPPLIER_SAVE_AND_ADD_BTN"
                :className="[
                    'button-text-13',
                    'button-primary',
                    'button-text-bold',
                    'tooltip',
                ]"
                :contentTooltip="'Cất và thêm (Ctrl + Shift + S)'"
                :classNameTooltip="['tooltip-default']"
                :functionz="onHandleSave"
            />
        </div>
    </div>
    <div class="modal__action">
        <button class="modal__button modal__button--support tooltip">
            <i class="square-24 icon icon-support"></i>
            <BaseTooltip
                :content="'Giúp (F1)'"
                :className="['tooltip-default']"
            />
        </button>
        <button
            class="modal__button modal__button--close tooltip"
            @click.stop="onClose(0)"
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
import BaseInput from "@/components/bases/BaseInput/BaseInput.vue";
import BaseComboboxTable from "@/components/bases/BaseCombobox/BaseComboboxTable.vue";
import { SUPPLIER_TEXT_CONFIG } from "@/views/Supplier/constants/resource";
import { TYPE_INPUT } from "@/libs/resources/type_input";
import { VOCATIVE } from "@/views/Supplier/constants/vocative";
import { PAYMENT_TERM } from "@/views/Supplier/constants/payment_term";
import { API_RESOURCE } from "@/views/Supplier/constants/api";
import BaseTextArea from "@/components/bases/BaseTextArea/BaseTextArea.vue";
import BaseTabs from "@/components/bases/BaseTabs/BaseTabs.vue";
import BaseTabItem from "@/components/bases/BaseTabs/BaseTabItem.vue";
import BaseComboboxDefault from "@/components/bases/BaseCombobox/BaseComboboxDefault.vue";
import BaseButton from "@/components/bases/BaseButton/BaseButton.vue";
import BaseComboboxTags from "../../../components/bases/BaseCombobox/BaseComboboxTags.vue";
import BaseTooltip from "../../../components/bases/BaseTooltip/BaseTooltip";

export default {
    name: "SupplierForm",

    components: {
        BaseInput,
        BaseComboboxTable,
        BaseTextArea,
        BaseTabs,
        BaseTabItem,
        BaseComboboxDefault,
        BaseButton,
        BaseComboboxTags,
        BaseTooltip,
    },

    props: {
        typeSupplier: null,
        supplierValue: null,
        onClose: Function,
        onSave: Function,
        isViewDetail: Boolean,
    },

    data() {
        return {
            RESOURCE: SUPPLIER_TEXT_CONFIG,

            TYPE_INPUT: TYPE_INPUT,

            VOCATIVE: VOCATIVE,

            PAYMENT_TERM: PAYMENT_TERM,

            API: API_RESOURCE,

            datepicker: [
                {
                    key: "today",
                    highlight: "red",
                    dates: new Date(),
                },
            ],

            account_object: {
                account_object_code: "",
                account_object_name: "",
                address: "",
                website: "",
                tax_code: "",
                phone_number: "",
                telephone_number: "",
                identity_number: "",
                identity_date: "",
                identity_place: "",
                employee_id: "",
                employee_name: "",
                supplier_type: "",
                contact_name: "",
                vocative_contact: null,
                vocative_supplier: null,
                email: "",
                representative_name: "",
                payment_term: null,
                number_day_owed: null,
                maximum_debt_amount: null,
                account_payable: "",
                department_name: "",
            },

            supplier_constraints: [],

            listField: {
                account_object_id: "account_object_id",
                account_object_code: "account_object_code",
                account_object_name: "account_object_name",
                address: "address",
                website: "website",
                tax_code: "tax_code",
                phone_number: "phone_number",
                telephone_number: "telephone_number",
                identity_number: "identity_number",
                identity_date: "identity_date",
                identity_place: "identity_place",
                employee_id: "employee_id",
                employee_name: "employee_name",
                supplier_type: "supplier_type",
                contact_name: "contact_name",
                vocative_contact: "vocative_contact",
                vocative_supplier: "vocative_supplier",
                email: "email",
                representative_name: "representative_name",
                payment_term: "payment_term",
                number_day_owed: "number_day_owed",
                maximum_debt_amount: "maximum_debt_amount",
                account_payable: "account_payable",
                department_name: "department_name",
                created_date: "created_date",
                created_by: "created_by",
                modified_date: "modified_date",
                modified_by: "modified_by",
            },

            listVocative: [
                {
                    vocative_contact: 0,
                    vocative_supplier: 0,
                    value_show: "Ông",
                },
                {
                    vocative_contact: 1,
                    vocative_supplier: 1,
                    value_show: "Bà",
                },
                {
                    vocative_contact: 2,
                    vocative_supplier: 2,
                    value_show: "Anh",
                },
                {
                    vocative_contact: 3,
                    vocative_supplier: 3,
                    value_show: "Chị",
                },
            ],

            listPaymentTerm: [
                {
                    payment_term: 0,
                    value_show: "Điều khoản 1",
                },
                {
                    payment_term: 1,
                    value_show: "Điều khoản 2",
                },
                {
                    payment_term: 2,
                    value_show: "Điều khoản 3",
                },
                {
                    payment_term: 3,
                    value_show: "Điều khoản 4",
                },
            ],

            valueSupplierConstraints: [],
        };
    },
    methods: {
        setValue(valueField, dataField) {
            try {
                this.account_object[dataField] = valueField;
            } catch (error) {
                console.log(error);
            }
        },

        setValueList(value) {
            try {
                this.supplier_constraints = [];
                for (let i = 0; i < value.length; i++) {
                    this.supplier_constraints.push({
                        supplier_group_id: value[i].valueField,
                        created_date: null,
                        created_by: "Admin",
                        modified_date: null,
                        modified_by: "Admin",
                    });
                }
            } catch (error) {
                console.log(error);
            }
        },

        handleClick(event) {
            try {
                console.log(event);
            } catch (error) {
                console.log(error);
            }
        },

        onHandleSave() {
            try {
                Object.keys(this.account_object).forEach((key) => {
                    if (
                        !this.account_object[key] ||
                        key == "created_date" ||
                        key == "created_by" ||
                        key == "modified_date" ||
                        key == "modified_by"
                    ) {
                        delete this.account_object[key];
                    }
                });
                this.onSave(this.account_object, this.supplier_constraints);
            } catch (error) {
                console.log(error);
            }
        },
    },

    created() {
        if (this.supplierValue) {
            this.account_object = this.supplierValue.accountObject;
            this.supplier_constraints = this.supplierValue.supplierConstraints;
            if (this.supplierValue) {
                this.valueSupplierConstraints =
                    this.supplierValue.supplierConstraints.map((e) => {
                        return {
                            valueField: e.supplier_group_id,
                            valueShow: e.supplier_group_code,
                        };
                    });
            }
        }
    },
};
</script>
<style scoped></style>
