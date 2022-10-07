<template>
    <div class="modal__row">
        <div class="d-flex pr-26 col-6">
            <BaseInput
                :className="['modal__group', 'modal__col', 'col-4']"
                :lable="RESOURCE.SUPPLIER_TAXCODE_FIELD_LBL"
                :type="TYPE_INPUT.TYPE_TEXT"
                :dataField="listField.tax_code"
                :valueField="account_object.tax_code"
                :fieldName="RESOURCE.SUPPLIER_TAXCODE_FIELD_LBL"
                :maxlength="20"
                :autocomplete="'off'"
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
                :autocomplete="'off'"
                :isRequired="true"
                @setValue="setValue"
            />
        </div>

        <div class="d-flex col-6">
            <BaseInput
                :className="['modal__group', 'modal__col', 'col-4']"
                :lable="RESOURCE.SUPPLIER_PHONE_FIELD_LBL"
                :type="TYPE_INPUT.TYPE_TEXT"
                :dataField="listField.phone_number"
                :valueField="account_object.phone_number"
                :fieldName="RESOURCE.SUPPLIER_PHONE_FIELD_LBL"
                :autocomplete="'off'"
                @setValue="setValue"
            />
            <BaseInput
                :className="['modal__group', 'modal__col', 'col-8']"
                :lable="RESOURCE.SUPPLIER_WEBSITE_FIELD_LBL"
                :type="TYPE_INPUT.TYPE_TEXT"
                :dataField="listField.website"
                :valueField="account_object.website"
                :fieldName="RESOURCE.SUPPLIER_WEBSITE_FIELD_LBL"
                :autocomplete="'off'"
                @setValue="setValue"
            />
        </div>
    </div>

    <div class="modal__row">
        <div class="d-flex pr-26 col-6">
            <BaseInput
                :className="['modal__group', 'modal__col', 'col-12']"
                :lable="RESOURCE.SUPPLIER_NAME_FIELD_LBL"
                :type="TYPE_INPUT.TYPE_TEXT"
                :dataField="listField.account_object_name"
                :valueField="account_object.account_object_name"
                :fieldName="RESOURCE.SUPPLIER_NAME_FIELD_LBL"
                :autocomplete="'off'"
                :isRequired="true"
                @setValue="setValue"
            />
        </div>

        <div class="d-flex col-6">
            <div class="modal__group modal__col col-12">
                <label class="modal__label mb-6">
                    {{ RESOURCE.SUPPLIER_GROUP_FIELD_LBL }}
                </label>
                <BaseComboboxTable
                    :className="['modal__col', 'modal__control', 'col-12']"
                    :value="null"
                    :isReadOnly="false"
                    :isBottom="true"
                    :placeholder="RESOURCE.SUPPLIER_GROUP_FIELD_LBL"
                    :nameRow="['Mã nhóm KH, NCC', 'Tên nhóm KH, NCC']"
                />
            </div>
        </div>
    </div>

    <div class="modal__row">
        <div class="d-flex pr-26 col-6">
            <BaseTextArea
                :className="['modal__group', 'modal__col', 'col-12']"
                :lable="RESOURCE.SUPPLIER_ADDRESS_FIELD_LBL"
                :dataField="listField.address"
                :valueField="account_object.address"
                :fieldName="RESOURCE.SUPPLIER_ADDRESS_FIELD_LBL"
                :autocomplete="'off'"
                :numberRow="2"
                @setValue="setValue"
            />
        </div>

        <div class="d-flex col-6">
            <div class="modal__group modal__col col-12">
                <label class="modal__label mb-6">
                    {{ RESOURCE.SUPPLIER_EMPLOYEE_FIELD_LBL }}
                </label>
                <BaseComboboxTable
                    :className="[
                        'modal__group',
                        'modal__col',
                        'modal__control',
                        'col-12',
                    ]"
                    :value="null"
                    :isReadOnly="false"
                    :isBottom="true"
                    :placeholder="RESOURCE.SUPPLIER_EMPLOYEE_FIELD_LBL"
                    :nameRow="['Mã nhân viên', 'Tên nhân viên']"
                />
            </div>
        </div>
    </div>

    <BaseTabs>
        <BaseTabItem name="Thông tin liên hệ">
            <div class="modal__row">
                <div class="d-flex pr-26 col-6">
                    <div class="modal__group modal__col col-12">
                        <label class="modal__label mb-6">
                            {{ RESOURCE.SUPPLIER_CONTACT_NAME_FIELD_LBL }}
                        </label>

                        <div class="modal__row">
                            <div class="d-flex col-12">
                                <div
                                    class="modal__group modal__col mb-control-group col-4"
                                >
                                    <BaseComboboxDefault
                                        :className="[
                                            'modal__control',
                                            'col-12',
                                        ]"
                                        :dataField="listField.vocative_contact"
                                        :value="
                                            VOCATIVE[
                                                account_object.vocative_contact
                                            ]
                                        "
                                        :listData="listVocative"
                                        :placeholder="
                                            RESOURCE.SUPPLIER_VOCATIVE_FIELD_LBL
                                        "
                                        :autocomplete="'off'"
                                        :isHideLable="true"
                                        :isBottom="true"
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
                                    :dataField="listField.representative_name"
                                    :valueField="
                                        account_object.representative_name
                                    "
                                    :fieldName="
                                        RESOURCE.SUPPLIER_REPRESENTATIVE_NAME_FIELD_LBL
                                    "
                                    :autocomplete="'off'"
                                    :isHideLable="true"
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
                                :fieldName="RESOURCE.SUPPLIER_EMAIL_FIELD_LBL"
                                :autocomplete="'off'"
                                :isHideLable="true"
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
                                :valueField="account_object.phone_number"
                                :fieldName="RESOURCE.SUPPLIER_PHONE_FIELD_LBL"
                                :autocomplete="'off'"
                                :isHideLable="true"
                                @setValue="setValue"
                            />
                        </div>
                    </div>
                </div>

                <div class="d-flex col-6">
                    <BaseInput
                        :className="['modal__group', 'modal__col', 'col-12']"
                        :lable="RESOURCE.SUPPLIER_REPRESENTATIVE_FIELD_LBL"
                        :type="TYPE_INPUT.TYPE_TEXT"
                        :dataField="listField.representative_name"
                        :valueField="account_object.representative_name"
                        :fieldName="RESOURCE.SUPPLIER_REPRESENTATIVE_FIELD_LBL"
                        :autocomplete="'off'"
                        @setValue="setValue"
                    />
                </div>
            </div>
        </BaseTabItem>
        <BaseTabItem name="Điều khoản thanh toán">
            <div class="modal__row">
                <div class="d-flex col-12">
                    <div class="d-flex col-3">
                        <div class="modal__group modal__col col-12">
                            <label class="modal__label mb-6">
                                {{ RESOURCE.SUPPLIER_PAYMENT_TERM_FIELD_LBL }}
                            </label>
                            <BaseComboboxDefault
                                :className="['modal__control', 'col-12']"
                                :dataField="listField.payment_term"
                                :value="
                                    PAYMENT_TERM[account_object.payment_term]
                                "
                                :listData="listPaymentTerm"
                                :placeholder="
                                    RESOURCE.SUPPLIER_PAYMENT_TERM_FIELD_LBL
                                "
                                :autocomplete="'off'"
                                :isHideLable="true"
                                :isBottom="true"
                                :onHandleEvent="setValue"
                                @setValue="setValue"
                            />
                        </div>
                    </div>

                    <BaseInput
                        :className="['modal__group', 'modal__col', 'col-3']"
                        :lable="RESOURCE.SUPPLIER_NUM_DAY_OWED_FIELD_LBL"
                        :type="TYPE_INPUT.TYPE_TEXT"
                        :dataField="listField.number_day_owed"
                        :valueField="account_object.number_day_owed"
                        :fieldName="RESOURCE.SUPPLIER_NUM_DAY_OWED_FIELD_LBL"
                        :autocomplete="'off'"
                        :isRequired="true"
                        @setValue="setValue"
                    />
                    <BaseInput
                        :className="['modal__group', 'modal__col', 'col-3']"
                        :lable="RESOURCE.SUPPLIER_MAX_DEBT_FIELD_LBL"
                        :type="TYPE_INPUT.TYPE_TEXT"
                        :dataField="listField.maximum_debt_amount"
                        :valueField="account_object.maximum_debt_amount"
                        :fieldName="RESOURCE.SUPPLIER_MAX_DEBT_FIELD_LBL"
                        :autocomplete="'off'"
                        @setValue="setValue"
                    />
                </div>
                <div class="d-flex col-12">
                    <BaseInput
                        :className="['modal__group', 'modal__col', 'col-3']"
                        :lable="RESOURCE.SUPPLIER_ACCOUNT_PAYABLE_FIELD_LBL"
                        :type="TYPE_INPUT.TYPE_TEXT"
                        :dataField="listField.account_payable"
                        :valueField="account_object.account_payable"
                        :fieldName="RESOURCE.SUPPLIER_ACCOUNT_PAYABLE_FIELD_LBL"
                        :autocomplete="'off'"
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
</template>
<script>
import BaseInput from "@/components/bases/BaseInput/BaseInput.vue";
import BaseComboboxTable from "@/components/bases/BaseCombobox/BaseComboboxTable.vue";
import { SUPPLIER_TEXT_CONFIG } from "@/views/Supplier/constants/resource";
import { TYPE_INPUT } from "@/libs/resources/type_input";
import { VOCATIVE } from "@/views/Supplier/constants/vocative";
import { PAYMENT_TERM } from "@/views/Supplier/constants/payment_term";
import BaseTextArea from "@/components/bases/BaseTextArea/BaseTextArea.vue";
import BaseTabs from "@/components/bases/BaseTabs/BaseTabs.vue";
import BaseTabItem from "@/components/bases/BaseTabs/BaseTabItem.vue";
import BaseComboboxDefault from "@/components/bases/BaseCombobox/BaseComboboxDefault.vue";
export default {
    name: "SupplierForm",

    components: {
        BaseInput,
        BaseComboboxTable,
        BaseTextArea,
        BaseTabs,
        BaseTabItem,
        BaseComboboxDefault,
    },

    data() {
        return {
            RESOURCE: SUPPLIER_TEXT_CONFIG,
            
            TYPE_INPUT: TYPE_INPUT,

            VOCATIVE: VOCATIVE,

            PAYMENT_TERM: PAYMENT_TERM,

            account_object: {
                account_object_id: "",
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
                vocative_contact: "",
                vocative_supplier: "",
                email: "",
                representative_name: "",
                payment_term: "",
                number_day_owed: "",
                maximum_debt_amount: "",
                account_payable: "",
                department_name: "",
                created_date: "",
                created_by: "",
                modified_date: "",
                modified_by: "",
            },

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
        handleClick(event) {
            try {
                console.log(event);
            } catch (error) {
                console.log(error);
            }
        },
    },
};
</script>
<style scoped></style>
