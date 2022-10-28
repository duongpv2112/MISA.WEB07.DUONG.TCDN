<template>
    <div v-keyboardoutside="eventHandleKey">
        <div class="modal__body p-relative">
            <div class="modal__body-top">
                <div class="main-infomation">
                    <div class="modal__row">
                        <div class="col-7 pr-12">
                            <div class="d-flex flex-wrap">
                                <div
                                    class="modal__col"
                                    :class="{
                                        'col-5':
                                            typeVoucher == ENUM.TYPE_PAYMENT,
                                        'col-4':
                                            typeVoucher == ENUM.TYPE_RECEIPT,
                                    }"
                                >
                                    <label class="modal__label mb-6">
                                        Mã đối tượng
                                    </label>
                                    <BaseComboboxTable
                                        :url="URL.PAGING_DATA_ACCOUNT_OBJECT"
                                        :propValue="'account_object_id'"
                                        :propText="'account_object_code'"
                                        :dataField="'account_object_id'"
                                        :dataText="'account_object_code'"
                                        :value="
                                            receiptPayment.account_object_code
                                        "
                                        :className="['modal__group', 'col-12']"
                                        :classListData="['min-w-1000', 'h-200']"
                                        :nameRow="[
                                            {
                                                fieldName: 'Đối tượng',
                                                dataField:
                                                    'account_object_code',
                                                styleObject: {
                                                    'min-width': '120px',
                                                },
                                            },
                                            {
                                                fieldName: 'Tên đối tượng',
                                                dataField:
                                                    'account_object_name',
                                                styleObject: {
                                                    'min-width': '280px',
                                                },
                                            },
                                            {
                                                fieldName: 'Mã số thuế',
                                                dataField: 'tax_code',
                                                styleObject: {
                                                    'min-width': '140px',
                                                },
                                            },
                                            {
                                                fieldName: 'Địa chỉ',
                                                dataField: 'address',
                                                styleObject: {
                                                    'min-width': '250px',
                                                },
                                            },
                                            {
                                                fieldName: 'Điện thoại',
                                                dataField: 'phone_number',
                                                styleObject: {
                                                    'min-width': '100px',
                                                },
                                            },
                                        ]"
                                        :placeholder="
                                            RESOURCE.ACCOUNT_OBJECT_CODE_FIELD
                                        "
                                        :isReadOnly="isViewDetail"
                                        :isBottom="true"
                                        :isFieldErrorFocus="
                                            fieldFocus == 'account_object_id'
                                        "
                                        :tabindex="1"
                                        :firstFocus="true"
                                        @setValue="setDataAccountObject"
                                        @setValidateData="
                                            setValidateReceiptPayment
                                        "
                                    />
                                </div>
                                <BaseInput
                                    :className="[
                                        'modal__group',
                                        'modal__col',
                                        typeVoucher == ENUM.TYPE_PAYMENT
                                            ? 'col-7'
                                            : '',
                                        typeVoucher == ENUM.TYPE_RECEIPT
                                            ? 'col-8'
                                            : '',
                                    ]"
                                    :fieldName="
                                        RESOURCE.ACCOUNT_OBJECT_NAME_FIELD
                                    "
                                    :lable="'Tên đối tượng'"
                                    :valueField="
                                        receiptPayment.account_object_name
                                    "
                                    :dataField="'account_object_name'"
                                    :key="keyNameComponent"
                                    :isReadonly="isViewDetail"
                                    :autocomplete="'off'"
                                    :tabindex="2"
                                    @setValue="setDataAccountObjectName"
                                />
                                <BaseInput
                                    :className="[
                                        'modal__group',
                                        'modal__col',
                                        typeVoucher == ENUM.TYPE_PAYMENT
                                            ? 'col-5'
                                            : '',
                                        typeVoucher == ENUM.TYPE_RECEIPT
                                            ? 'col-4'
                                            : '',
                                    ]"
                                    :lable="
                                        typeVoucher == ENUM.TYPE_PAYMENT
                                            ? 'Người nhận'
                                            : 'Người nộp'
                                    "
                                    :valueField="
                                        receiptPayment.account_object_contact_name
                                    "
                                    :fieldName="
                                        RESOURCE.ACCOUNT_OBJECT_CONTACT_NAME_FIELD
                                    "
                                    :dataField="'account_object_contact_name'"
                                    :key="keyComponent"
                                    :isReadonly="isViewDetail"
                                    :autocomplete="'off'"
                                    :tabindex="4"
                                    @setValue="setValue"
                                />
                                <BaseInput
                                    :className="[
                                        'modal__group',
                                        'modal__col',
                                        typeVoucher == ENUM.TYPE_PAYMENT
                                            ? 'col-7'
                                            : '',
                                        typeVoucher == ENUM.TYPE_RECEIPT
                                            ? 'col-8'
                                            : '',
                                    ]"
                                    :lable="'Địa chỉ'"
                                    :valueField="receiptPayment.address"
                                    :dataField="'address'"
                                    :fieldName="RESOURCE.ADDRESS_FIELD"
                                    :key="keyComponent"
                                    :isReadonly="isViewDetail"
                                    :autocomplete="'off'"
                                    :tabindex="5"
                                    @setValue="setValue"
                                />
                                <BaseInput
                                    v-if="typeVoucher == ENUM.TYPE_PAYMENT"
                                    :className="[
                                        'modal__group',
                                        'modal__col',
                                        'col-12',
                                    ]"
                                    :lable="'Lý do chi'"
                                    :valueField="receiptPayment.reason"
                                    :dataField="'reason'"
                                    :fieldName="RESOURCE.PAYMENT_REASON_FIELD"
                                    :key="keyComponent"
                                    :isReadonly="isViewDetail"
                                    :autocomplete="'off'"
                                    :tabindex="7"
                                    @setValue="setDataReason"
                                />
                                <div class="d-flex col-12">
                                    <div
                                        class="modal__col"
                                        :class="{
                                            'col-5':
                                                typeVoucher ==
                                                ENUM.TYPE_PAYMENT,
                                            'col-4':
                                                typeVoucher ==
                                                ENUM.TYPE_RECEIPT,
                                        }"
                                    >
                                        <label class="modal__label mb-6">
                                            Nhân viên
                                        </label>
                                        <BaseComboboxTable
                                            :url="URL.PAGING_DATA_EMPLOYEE"
                                            :propValue="'employee_id'"
                                            :propText="'employee_name'"
                                            :dataField="'account_object_id'"
                                            :dataText="'account_object_name'"
                                            :className="[
                                                'modal__group',
                                                'col-12',
                                            ]"
                                            :classListData="[
                                                'min-w-1000',
                                                'h-200',
                                            ]"
                                            :nameRow="[
                                                {
                                                    fieldName: 'Mã nhân viên',
                                                    dataField:
                                                        'account_object_code',
                                                    styleObject: {
                                                        'min-width': '120px',
                                                    },
                                                },
                                                {
                                                    fieldName: 'Tên nhân viên',
                                                    dataField:
                                                        'account_object_name',
                                                    styleObject: {
                                                        'min-width': '280px',
                                                    },
                                                },
                                                {
                                                    fieldName: 'Đơn vị',
                                                    dataField:
                                                        'department_name',
                                                    styleObject: {
                                                        'min-width': '140px',
                                                    },
                                                },
                                                {
                                                    fieldName:
                                                        'Điện thoại di động',
                                                    dataField: 'phone_number',
                                                    styleObject: {
                                                        'min-width': '250px',
                                                    },
                                                },
                                                {
                                                    fieldName: 'Điện thoại',
                                                    dataField: 'phone_number',
                                                    styleObject: {
                                                        'min-width': '100px',
                                                    },
                                                },
                                            ]"
                                            :isReadOnly="isViewDetail"
                                            :placeholder="
                                                RESOURCE.EMPLOYEE_FIELD
                                            "
                                            :value="
                                                receiptPayment.employee_name
                                            "
                                            :tabindex="typeVoucher == 0 ? 7 : 9"
                                            :isBottom="true"
                                            :isAbsoluteLayer="false"
                                            @setValue="setValue"
                                            @setValidateData="
                                                setValidateReceiptPayment
                                            "
                                        />
                                    </div>

                                    <BaseInput
                                        v-if="typeVoucher == ENUM.TYPE_RECEIPT"
                                        :className="[
                                            'modal__group',
                                            'modal__col',
                                            'col-4',
                                        ]"
                                        :lable="'Lý do nộp'"
                                        :valueField="receiptPayment.reason"
                                        :dataField="'reason'"
                                        :fieldName="
                                            RESOURCE.RECEIPT_REASON_FIELD
                                        "
                                        :key="keyComponent"
                                        :isReadonly="isViewDetail"
                                        :autocomplete="'off'"
                                        :tabindex="8"
                                        @setValue="setDataReason"
                                    />

                                    <BaseInput
                                        :className="[
                                            'modal__group',
                                            'modal__col',
                                            'col-2',
                                        ]"
                                        :lable="'Kèm theo'"
                                        :valueField="
                                            receiptPayment.adding_number
                                        "
                                        :isInputNumber="true"
                                        :dataField="'adding_number'"
                                        :fieldName="RESOURCE.ADDING_FIELD"
                                        :isReadonly="isViewDetail"
                                        :autocomplete="'off'"
                                        :tabindex="typeVoucher == 0 ? 8 : 10"
                                        @setValue="setValue"
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
                                    v-model="accounting_date"
                                    :popover="{
                                        visibility: 'focus',
                                    }"
                                    mode="date"
                                    :attributes="datepicker"
                                    @dayclick="checkDate('accounting_date')"
                                >
                                    <template
                                        v-slot="{ inputValue, inputEvents }"
                                    >
                                        <div class="left-separate">
                                            <label
                                                class="d-block p-relative"
                                                :class="[
                                                    'modal__group',
                                                    'col-12',
                                                    'tooltip',
                                                    'mb-0',
                                                    isViewDetail
                                                        ? 'pointer-event-none'
                                                        : '',
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
                                                    ref="accounting_date"
                                                    :class="{
                                                        'border-red':
                                                            validateDateAD?.isInValid ||
                                                            fieldFocus ==
                                                                'accounting_date',
                                                    }"
                                                    :value="inputValue"
                                                    :placeholder="
                                                        RESOURCE.ACCOUNTING_DATE_FIELD
                                                    "
                                                    :readonly="isViewDetail"
                                                    :tabindex="3"
                                                />
                                                <BaseTooltip
                                                    v-if="
                                                        validateDateAD?.isInValid
                                                    "
                                                    :content="
                                                        validateDateAD?.errorMessage
                                                    "
                                                    :className="[
                                                        'tooltip-default',
                                                        'tooltip-input__validate',
                                                    ]"
                                                />
                                            </label>
                                        </div>
                                    </template>
                                </vc-date-picker>
                            </div>
                            <div class="col-12">
                                <label
                                    for=""
                                    class="modal__label left-separate-lable"
                                >
                                    {{
                                        typeVoucher == ENUM.TYPE_PAYMENT
                                            ? RESOURCE.PAYMENT_DATE_FIELD
                                            : RESOURCE.RECEIPT_DATE_FIELD
                                    }}
                                </label>
                                <vc-date-picker
                                    v-model="receipt_payment_date"
                                    :popover="{
                                        visibility: 'focus',
                                    }"
                                    mode="date"
                                    :attributes="datepicker"
                                    @dayclick="
                                        checkDate('receipt_payment_date')
                                    "
                                >
                                    <template
                                        v-slot="{ inputValue, inputEvents }"
                                    >
                                        <div class="left-separate">
                                            <label
                                                class="d-block p-relative"
                                                :class="[
                                                    'modal__group',
                                                    'col-12',
                                                    'tooltip',
                                                    'mb-0',
                                                    isViewDetail
                                                        ? 'pointer-event-none'
                                                        : '',
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
                                                    ref="receipt_payment_date"
                                                    :class="{
                                                        'border-red':
                                                            validateDateRP?.isInValid ||
                                                            fieldFocus ==
                                                                'receipt_payment_date',
                                                    }"
                                                    :value="inputValue"
                                                    :placeholder="
                                                        typeVoucher ==
                                                        ENUM.TYPE_PAYMENT
                                                            ? RESOURCE.PAYMENT_DATE_FIELD
                                                            : RESOURCE.RECEIPT_DATE_FIELD
                                                    "
                                                    :readonly="isViewDetail"
                                                    :tabindex="6"
                                                />
                                                <BaseTooltip
                                                    v-if="
                                                        validateDateRP?.isInValid
                                                    "
                                                    :content="
                                                        validateDateRP?.errorMessage
                                                    "
                                                    :className="[
                                                        'tooltip-default',
                                                        'tooltip-input__validate',
                                                    ]"
                                                />
                                            </label>
                                        </div>
                                    </template>
                                </vc-date-picker>
                            </div>
                            <div class="col-12">
                                <div class="left-separate">
                                    <BaseInput
                                        :className="['modal__group', 'col-12']"
                                        :lable="
                                            typeVoucher == ENUM.TYPE_PAYMENT
                                                ? 'Số phiếu chi'
                                                : 'Số phiếu thu'
                                        "
                                        :valueField="
                                            receiptPayment.receipt_payment_number
                                        "
                                        :fieldName="
                                            typeVoucher == ENUM.TYPE_PAYMENT
                                                ? RESOURCE.PAYMENT_NUMBER_FIELD
                                                : RESOURCE.RECEIPT_NUMBER_FIELD
                                        "
                                        :dataField="'receipt_payment_number'"
                                        :isRequired="true"
                                        :isReadonly="isViewDetail"
                                        :isFieldErrorFocus="
                                            fieldFocus ==
                                            'receipt_payment_number'
                                        "
                                        :autocomplete="'off'"
                                        :tabindex="typeVoucher == 0 ? 10 : 8"
                                        @setValue="setValue"
                                        @setValidateData="
                                            setValidateReceiptPayment
                                        "
                                    />
                                </div>
                            </div>
                        </div>
                        <div class="col-3 modal__col">
                            <div class="summary-info">
                                <div class="summary-info-title">Tổng tiền</div>
                                <div class="summary-info-number">
                                    {{
                                        common.formatDecimalCurrency(
                                            receiptPaymentForm.total_money
                                        )
                                    }}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="grid-accounting" :key="keyAccountingComponent">
                    <div class="tab-detail">
                        <div class="tab-detail-title">Hạch toán</div>
                        <div class="tab-header-extend">
                            <div class="tab-header-option">
                                <div class="option-lable">Loại tiền</div>
                                <BaseComboboxTable
                                    :className="['tab-combobox']"
                                    :propValue="'currency_id'"
                                    :propText="'currency_code'"
                                    :dataField="'currency_code'"
                                    :dataText="'currency_code'"
                                    :isHideLable="true"
                                    :classListData="['absolute-bottom-right']"
                                    :isAbsoluteBottomRight="true"
                                    :nameRow="[
                                        {
                                            fieldName: 'Mã loại tiền',
                                            dataField: 'currency_code',
                                            styleObject: {
                                                'min-width': '120px',
                                            },
                                        },
                                        {
                                            fieldName: 'Tên loại tiền',
                                            dataField: 'currency_name',
                                            styleObject: {
                                                'min-width': '150px',
                                                width: '150px !important',
                                            },
                                        },
                                    ]"
                                    :listData="[
                                        {
                                            currency_id: 0,
                                            currency_code: 'VND',
                                            currency_name: 'Việt Nam đồng',
                                        },
                                        {
                                            currency_id: 1,
                                            currency_code: 'USD',
                                            currency_name: 'Đô la Mỹ',
                                        },
                                    ]"
                                    :isHideIconPlus="true"
                                    :value="'VND'"
                                    :tabindex="11"
                                    :isReadOnly="isViewDetail"
                                />
                            </div>
                        </div>
                    </div>

                    <div class="grid-data">
                        <table class="table">
                            <thead class="table-head">
                                <tr>
                                    <th scope="col" class="table-head__index">
                                        #
                                    </th>
                                    <th
                                        scope="col"
                                        v-for="(column, index) in columns"
                                        :key="'col_grid_' + index"
                                        :style="column.styleObject"
                                    >
                                        {{ column.fieldName }}
                                    </th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody class="table-body">
                                <tr
                                    class="table-row"
                                    v-for="(
                                        item, indextr
                                    ) in receiptPaymentDetail"
                                    :key="item.id"
                                    :class="{
                                        'bg-selected': rowSelected == indextr,
                                    }"
                                    @click="setRowSelected(indextr)"
                                >
                                    <td>
                                        {{ indextr + 1 }}
                                    </td>
                                    <td
                                        v-for="(column, index) in columns"
                                        :key="'col_' + (index + 1)"
                                        :class="{
                                            'text-right':
                                                isViewDetail ||
                                                (column.dataField ==
                                                    'amount_money' &&
                                                    (rowSelected !== indextr ||
                                                        (!column.dataInput
                                                            .isInput &&
                                                            !column.dataCombobox
                                                                .isCombobox))),
                                        }"
                                    >
                                        <BaseInput
                                            v-if="
                                                column.dataInput.isInput &&
                                                !column.dataCombobox
                                                    .isCombobox &&
                                                rowSelected === indextr &&
                                                !isViewDetail
                                            "
                                            :className="[
                                                'modal__group',
                                                'modal__col',
                                                'mb-0',
                                                'col-12',
                                            ]"
                                            :valueField="item[column.dataField]"
                                            :isInputNumber="
                                                column.dataInput.isInputNumber
                                            "
                                            :type="'text'"
                                            :dataField="
                                                column.dataInput.dataField
                                            "
                                            :isHideLable="true"
                                            :autocomplete="
                                                column.dataInput.autocomplete
                                            "
                                            :tabindex="12"
                                            @setValue="updateRow"
                                        />

                                        <BaseComboboxTable
                                            v-if="
                                                !column.dataInput.isInput &&
                                                column.dataCombobox
                                                    .isCombobox &&
                                                rowSelected === indextr &&
                                                !isViewDetail
                                            "
                                            :url="column.dataCombobox.url"
                                            :propValue="
                                                column.dataCombobox.propValue
                                            "
                                            :propText="
                                                column.dataCombobox.propText
                                            "
                                            :dataField="
                                                column.dataCombobox.dataField
                                            "
                                            :dataText="
                                                column.dataCombobox.dataText
                                            "
                                            :className="[
                                                'modal__group',
                                                'col-12',
                                                'mb-0',
                                            ]"
                                            :value="item[column.dataField]"
                                            :nameRow="
                                                column.dataCombobox.nameRows
                                            "
                                            :isHideIconPlus="true"
                                            :isAbsoluteLayer="false"
                                            :isAbsoluteFull="
                                                column.dataCombobox
                                                    .isComboboxFullWidth
                                                    ? true
                                                    : false
                                            "
                                            :classListData="
                                                column.dataCombobox
                                                    .classListData
                                            "
                                            :placeholder="
                                                column.dataCombobox.placeholder
                                            "
                                            :isFieldErrorFocus="
                                                fieldDetailFocus?.rowIndex ==
                                                    indextr &&
                                                fieldDetailFocus?.fieldError ==
                                                    column.dataField
                                            "
                                            :paramFunction="indextr"
                                            :tabindex="12"
                                            @setValue="updateRow"
                                            @setValidateData="
                                                setValidateReceiptPaymentDetail
                                            "
                                        />
                                        {{
                                            rowSelected !== indextr ||
                                            isViewDetail ||
                                            (!column.dataInput.isInput &&
                                                !column.dataCombobox.isCombobox)
                                                ? column.dataInput.isInputNumber
                                                    ? common.formatCurrency(
                                                          item[column.dataField]
                                                      )
                                                    : item[column.dataField]
                                                : ""
                                        }}
                                    </td>
                                    <td>
                                        <span
                                            @click="removeRow(item, indextr)"
                                            class="square-16 icon icon-delete"
                                        ></span>
                                    </td>
                                </tr>
                            </tbody>
                            <tfoot class="table-foot">
                                <tr>
                                    <th scope="col"></th>
                                    <th
                                        scope="col"
                                        v-for="column in columns"
                                        :key="'col_' + column.dataField"
                                        :style="column.styleObject"
                                    >
                                        {{
                                            column.dataField ==
                                            dataFooter.columnShow
                                                ? common.formatDecimalCurrency(
                                                      dataFooter.data
                                                  )
                                                : ""
                                        }}
                                    </th>
                                    <th scope="col"></th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
                <div class="grid-control-accounting">
                    <div class="grid-btn-control">
                        <button class="grid-btn mr-12" @click="addRow">
                            <span class="grid-btn-title">Thêm dòng</span>
                        </button>

                        <button class="grid-btn" @click="actionRemoveAll">
                            <span class="grid-btn-title">Xóa hết dòng</span>
                        </button>
                    </div>

                    <div class="grid-input-control">
                        <div class="grid-input-title">
                            <div class="attach-text">
                                <div
                                    class="icon grid-input-icon icon-attach"
                                ></div>
                                <div>Đính kèm</div>
                            </div>
                            <div class="max-size-upload">
                                Dung lượng tối đa 5MB
                            </div>
                        </div>
                        <div
                            class="grid-input-upload"
                            :class="{
                                'bg-readonly': isViewDetail,
                            }"
                        >
                            <input type="file" :disabled="isViewDetail" />
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
                    :functionz="onClose"
                />
            </div>
            <div class="modal__footer--right d-flex">
                <BaseButton
                    v-if="isViewDetail"
                    :title="RESOURCE.RECEIPT_PAYMENT_EDIT_BTN"
                    :className="[
                        'button-text-13',
                        'button-text-bold',
                        'button-border-modal',
                        'tooltip',
                        'mr-12',
                    ]"
                    :contentTooltip="'Sửa (Ctrl + E)'"
                    :classNameTooltip="['tooltip-default']"
                    :functionz="onHandleActionEdit"
                />

                <BaseButton
                    v-if="!isViewDetail"
                    :title="RESOURCE.RECEIPT_PAYMENT_SAVE_BTN"
                    :className="[
                        'button-text-13',
                        'button-text-bold',
                        'button-border-modal',
                        'tooltip',
                        'mr-12',
                    ]"
                    :contentTooltip="'Cất (Ctrl + S)'"
                    :classNameTooltip="['tooltip-default-top']"
                    :functionz="onHandleActionSave"
                />

                <BaseButton
                    v-if="isViewDetail"
                    :title="RESOURCE.RECEIPT_PAYMENT_RECORD_BOOK_BTN"
                    :className="[
                        'button-text-13',
                        'button-text-bold',
                        'button-border-modal',
                        'tooltip',
                        'button-text',
                        'button-primary',
                    ]"
                    :contentTooltip="'Ghi sổ (Ctrl + G)'"
                    :classNameTooltip="['tooltip-default']"
                />
                <div class="d-flex" v-if="!isViewDetail">
                    <BaseButton
                        :title="nameActionSave?.nameButton"
                        :className="[
                            'button-text',
                            'button-primary',
                            'button-border-radius-right',
                        ]"
                        :contentTooltip="`${nameActionSave?.nameButton} (${nameActionSave?.nameTooltip})`"
                        :classNameTooltip="['tooltip-default-top']"
                        :functionz="onHandleActionSave"
                        :paramFunction="nameActionSave?.paramFunction"
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
                                    <li
                                        class="button-combobox__item"
                                        @click="
                                            setNameActionSave(
                                                'Cất và Thêm',
                                                'Ctrl + Shift + S',
                                                1
                                            )
                                        "
                                    >
                                        <a>Cất và Thêm</a>
                                    </li>
                                    <BaseTooltip
                                        :content="'Cất và thêm (Ctrl + Shift + S)'"
                                        :className="['tooltip-absolute-left']"
                                    />
                                </div>
                                <div class="tooltip">
                                    <li
                                        class="button-combobox__item"
                                        @click="
                                            setNameActionSave(
                                                'Cất và Đóng',
                                                'Ctrl + Q',
                                                null
                                            )
                                        "
                                    >
                                        <a>Cất và Đóng</a>
                                        <BaseTooltip
                                            :content="'Cất và đóng (Ctrl + Q)'"
                                            :className="[
                                                'tooltip-absolute-left',
                                            ]"
                                        />
                                    </li>
                                </div>
                                <div class="tooltip">
                                    <li class="button-combobox__item tooltip">
                                        <a>Cất và In</a>
                                        <BaseTooltip
                                            :content="'Cất và in (Ctrl + Alt + P)'"
                                            :className="[
                                                'tooltip-absolute-left',
                                            ]"
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
                @click="this.onClose(0)"
            >
                <i class="square-24 icon icon-times"></i>
                <BaseTooltip
                    :content="'Đóng (ESC)'"
                    :className="['tooltip-default']"
                />
            </button>
        </div>
    </div>
</template>
<script>
import { RECEIPT_PAYMENT_TEXT_CONFIG } from "@/views/CashPage/ReceiptPayment/constants/resources";
import { RECEIPT_PAYMENT_ENUM } from "@/views/CashPage/ReceiptPayment/constants/enums";
import { API_RESOURCE } from "@/views/CashPage/ReceiptPayment/constants/api";
import { common } from "@/libs/common/common";
import BaseTooltip from "@/components/bases/BaseTooltip/BaseTooltip.vue";
import BaseButton from "@/components/bases/BaseButton/BaseButton.vue";
import BaseInput from "@/components/bases/BaseInput/BaseInput.vue";
import BaseComboboxTable from "@/components/bases/BaseCombobox/BaseComboboxTable.vue";

export default {
    name: "ReceiptPaymentForm",

    components: {
        BaseTooltip,
        BaseButton,
        BaseInput,
        BaseComboboxTable,
    },

    props: {
        onClose: Function,
        typeVoucher: null,
        columns: Array,
        receiptPayment: null,
        accountings: null,
        setValue: Function,
        setListValue: Function,
        isViewDetail: Boolean,
        onSave: Function,
        onHandleEdit: Function,
        setValidateReceiptPayment: Function,
        setValidateReceiptPaymentDetail: Function,
        fieldFocus: null,
        fieldDetailFocus: null,
        setPopupData: Function,
        onHandleHidePopup: Function,
    },

    data() {
        return {
            URL: API_RESOURCE,

            RESOURCE: RECEIPT_PAYMENT_TEXT_CONFIG,

            ENUM: RECEIPT_PAYMENT_ENUM,

            common: common,

            isShowButtonCombobox: Boolean,

            receiptPaymentDetail: null,

            datepicker: [
                {
                    key: "today",
                    highlight: "green",
                    dates: new Date(),
                },
            ],

            dataFooter: {
                data: 0,
                columnShow: "amount_money",
            },

            receiptPaymentForm: {
                account_object_id: null,
                total_money: 0,
            },

            accounting_date: new Date(),
            receipt_payment_date: new Date(),

            validateDateAD: null,
            validateDateRP: null,

            keyComponent: 0,
            keyNameComponent: 0,
            keyAccountingComponent: 0,

            rowSelected: null,

            nameActionSave: null,

            rowErrorSelected: null,
        };
    },

    created() {
        this.isShowButtonCombobox = false;
        if (this.receiptPayment) {
            this.receiptPaymentForm = this.receiptPayment;
            this.receiptPaymentForm.total_money =
                this.receiptPayment.total_money;
            this.accounting_date = this.receiptPayment.accounting_date;
            this.receipt_payment_date =
                this.receiptPayment.receipt_payment_date;
        }

        if (this.accountings) {
            this.receiptPaymentDetail = this.accountings;
        }
        this.sumTotalMoney();
        this.getNameActionSave();
    },

    beforeUpdate() {
        this.sumTotalMoney();
    },

    watch: {
        fieldFocus(newValue) {
            if (
                newValue &&
                (newValue == "accounting_date" ||
                    newValue == "receipt_payment_date")
            ) {
                this.$refs[newValue].focus();
            }
        },

        fieldDetailFocus(newValue) {
            if (newValue) {
                this.setRowSelected(newValue.rowIndex);
            }
        },

        accountings(newValue) {
            this.receiptPaymentDetail = newValue;
        },

        accounting_date(newValue) {
            if (!newValue) {
                this.validateDateAD = {
                    isInValid: true,
                    errorMessage: "Ngày hạch toán không được để trống",
                };
                this.setValidateReceiptPayment(
                    true,
                    this.validateDateAD.errorMessage,
                    "accounting_date"
                );
            } else {
                this.validateDateAD = {
                    isInValid: false,
                    errorMessage: "",
                };
                this.setValidateReceiptPayment(false, "", "accounting_date");
            }
        },

        receipt_payment_date(newValue) {
            if (!newValue) {
                this.validateDateRP = {
                    isInValid: true,
                    errorMessage:
                        this.typeVoucher == 0
                            ? "Ngày phiếu thu không được để trống"
                            : "Ngày phiếu chi không được để trống",
                };
                this.setValidateReceiptPayment(
                    true,
                    this.validateDateRP.errorMessage,
                    "receipt_payment_date"
                );
            } else {
                this.validateDateRP = {
                    isInValid: false,
                    errorMessage: "",
                };
                this.setValidateReceiptPayment(
                    false,
                    "",
                    "receipt_payment_date"
                );
            }
        },
    },

    methods: {
        /**
         * Kiểm tra dữ liệu typeof date
         * @param {*} nameDate: Tên trường có type là date
         * @author: DUONGPV (04/10/2022)
         */
        checkDate(nameDate) {
            try {
                if (nameDate == "accounting_date") {
                    this.setValue(
                        common.formatDate(this.accounting_date),
                        "accounting_date"
                    );
                } else if (nameDate == "receipt_payment_date") {
                    this.setValue(
                        common.formatDate(this.receipt_payment_date),
                        "receipt_payment_date"
                    );
                }
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện đóng/mở combobox loại tiền tệ
         * @author: DUONGPV (04/10/2022)
         */
        onHandleShowButtonCombobox() {
            this.isShowButtonCombobox = !this.isShowButtonCombobox;
        },

        /**
         * Thực hiện đóng combobox loại tiền tệ
         * @author: DUONGPV (04/10/2022)
         */
        onHideButtonCombobox() {
            this.isShowButtonCombobox = false;
        },

        /**
         * Cập nhật giá trị rowSelected
         * @param {*} index: Vị trí dòng đang selected
         * @author: DUONGPV (04/10/2022)
         */
        setRowSelected(index) {
            try {
                this.rowSelected = index;
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện tính tổng tiền
         * @author: DUONGPV (04/10/2022)
         */
        sumTotalMoney() {
            try {
                var sum = 0;
                this.receiptPaymentDetail.map((item) => {
                    var money = 0;
                    if (typeof item.amount_money == "string") {
                        money = item.amount_money.replace(/\D+/g, "");
                    } else {
                        money = Math.ceil(item.amount_money);
                    }
                    return (sum += Number(money));
                });
                this.receiptPaymentForm.total_money = sum;
                this.dataFooter.data = sum;
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện cập nhật giá trị theo từng row
         * @param {*} value: Giá trị của trường cần cập nhật
         * @param {*} dataField: Tên trường cần cập nhật
         * @author: DUONGPV (04/10/2022)
         */
        updateRow(value, dataField) {
            try {
                if (
                    typeof value == "object" &&
                    value &&
                    (dataField == "debt_account" ||
                        dataField == "credit_account")
                ) {
                    this.receiptPaymentDetail[this.rowSelected][dataField] =
                        value.account_number;
                } else if (
                    typeof value == "object" &&
                    value &&
                    (dataField == "account_object_id" ||
                        dataField == "account_object_code")
                ) {
                    this.receiptPaymentDetail[this.rowSelected][dataField] =
                        value[dataField];
                    this.receiptPaymentDetail[this.rowSelected][
                        "account_object_name"
                    ] = value["account_object_name"];
                } else if (dataField == "amount_money") {
                    this.receiptPaymentDetail[this.rowSelected][dataField] =
                        Number(value);
                } else {
                    this.receiptPaymentDetail[this.rowSelected][dataField] =
                        value;
                }
                this.setListValue(this.receiptPaymentDetail);
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện thêm dòng trong bảng Hạch toán
         * @author: DUONGPV (04/10/2022)
         */
        addRow() {
            try {
                if (!this.isViewDetail) {
                    if (this.receiptPaymentDetail.length == 0) {
                        this.receiptPaymentDetail.push({
                            id: common.createUUID(),
                            reason:
                                this.typeVoucher == 0
                                    ? "Thu tiền của "
                                    : "Chi tiền cho",
                            debt_account: "",
                            credit_account: "",
                            amount_money: 0,
                            account_object_id: "",
                            account_object_code: "",
                            account_object_name: "",
                        });
                    } else {
                        this.receiptPaymentDetail.push({
                            id: common.createUUID(),
                            reason: this.receiptPaymentDetail[
                                this.receiptPaymentDetail.length - 1
                            ].reason,
                            debt_account:
                                this.receiptPaymentDetail[
                                    this.receiptPaymentDetail.length - 1
                                ].debt_account,
                            credit_account:
                                this.receiptPaymentDetail[
                                    this.receiptPaymentDetail.length - 1
                                ].credit_account,
                            amount_money: 0,
                            account_object_id:
                                this.receiptPaymentDetail[
                                    this.receiptPaymentDetail.length - 1
                                ].account_object_id,
                            account_object_code:
                                this.receiptPaymentDetail[
                                    this.receiptPaymentDetail.length - 1
                                ].account_object_code,
                            account_object_name:
                                this.receiptPaymentDetail[
                                    this.receiptPaymentDetail.length - 1
                                ].account_object_name,
                        });
                    }
                    this.setRowSelected(this.receiptPaymentDetail.length - 1);
                    this.setListValue(this.receiptPaymentDetail);
                }
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện xóa dòng trong bảng Hạch toán
         * @param {*} valueRow: Giá trị dòng cần xóa
         * @author: DUONGPV (04/10/2022)
         */
        removeRow(valueRow) {
            try {
                if (!this.isViewDetail) {
                    let listData = this.receiptPaymentDetail.map((item) => {
                        return item;
                    });
                    this.receiptPaymentDetail = listData.filter((item) => {
                        return item != valueRow;
                    });
                    this.setListValue(this.receiptPaymentDetail);
                    this.keyAccountingComponent += 1;
                }
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Hiện popup cảnh báo xóa tất cả
         * @author: DUONGPV (04/10/2022)
         */
        actionRemoveAll() {
            try {
                this.setPopupData({
                    typePopup: 2,
                    footerPopup: {
                        footerLeft: [
                            {
                                buttonName: "Không",
                                buttonAction: this.onHandleHidePopup,
                                classButton: "",
                                valueFunction: "",
                            },
                        ],
                        footerRight: [
                            {
                                buttonName: "Có",
                                buttonAction: this.removeAllRow,
                                classButton: ["btn-confirm"],
                                valueFunction: "",
                            },
                        ],
                        enterKeyFunc: this.removeAllRow,
                        valueEnterKeyFunc: "",
                        escKeyFunc: this.onHandleHidePopup,
                    },

                    noticeMessage: `Bạn có thực sự muốn xóa tất cả các dòng đã nhập không?`,
                });
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện xóa tất cả cá dòng
         * @author: DUONGPV (04/10/2022)
         */
        removeAllRow() {
            try {
                if (!this.isViewDetail) {
                    this.receiptPaymentDetail = [
                        {
                            id: common.createUUID(),
                            reason:
                                this.typeVoucher == 0
                                    ? "Thu tiền của"
                                    : "Chi tiền cho",
                            amount_money: 0,
                        },
                    ];
                    this.setRowSelected(0);
                    this.setListValue(this.receiptPaymentDetail);
                    this.onHandleHidePopup();
                }
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Cập nhật giá trị của trường account_object_id
         * @param {*} value: Giá trị của trường account_object_id cần cập nhật
         * @param {*} dataField: Tên trường cần cập nhật
         * @author: DUONGPV (04/10/2022)
         */
        async setDataAccountObject(value, dataField) {
            try {
                await this.setValue(value, dataField);
                this.keyComponent += 1;
                this.keyAccountingComponent += 1;
                this.keyNameComponent += 1;
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Cập nhật giá trị của trường account_object_name
         * @param {*} value: Giá trị của trường account_object_name cần cập nhật
         * @param {*} dataField: Tên trường cần cập nhật
         * @author: DUONGPV (04/10/2022)
         */
        async setDataAccountObjectName(value, dataField) {
            try {
                await this.setValue(value, dataField);
                this.keyComponent += 1;
                this.keyAccountingComponent += 1;
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Cập nhật giá trị của trường reason
         * @param {*} value: Giá trị của trường reason cần cập nhật
         * @param {*} dataField: Tên trường cần cập nhật
         * @author: DUONGPV (04/10/2022)
         */
        async setDataReason(value, dataField) {
            try {
                await this.setValue(value, dataField);
                this.keyAccountingComponent += 1;
                this.keyNameComponent += 1;
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện enable các ô readonly
         * @author: DUONGPV (04/10/2022)
         */
        onHandleActionEdit() {
            try {
                this.onHandleEdit(false);
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện lưu thông tin chứng từ
         * @param {*} type: Loại lưu(0: Lưu xong đóng, 1: Lưu xong refresh object và không đóng form)
         * @author: DUONGPV (04/10/2022)
         */
        onHandleActionSave(type) {
            try {
                if (type == 1) {
                    this.onSave(this.typeVoucher, type);
                } else this.onSave(this.typeVoucher);
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Lấy thông tin ô button Cất và thêm, Cất và đóng, ...
         * @author: DUONGPV (04/10/2022)
         */
        getNameActionSave() {
            try {
                if (localStorage.getItem("name_action_save") === null) {
                    this.nameActionSave = {
                        nameButton:
                            RECEIPT_PAYMENT_TEXT_CONFIG.RECEIPT_PAYMENT_SAVE_AND_ADD_BTN,
                        nameTooltip: "Ctrl + Shift + S",
                        paramFunction: 1,
                    };
                } else
                    this.nameActionSave = JSON.parse(
                        localStorage.getItem("name_action_save")
                    );
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Thực hiện cập nhật
         * @param {*} nameButton: Giá trị tên button
         * @param {*} nameTooltip: Giá trị tên ToolTip
         * @param {*} paramFunction: Giá trị biến truyền trong function
         * @param {*} isKeyCode: True hoặc False
         * @author: DUONGPV (04/10/2022)
         */
        setNameActionSave(nameButton, nameTooltip, paramFunction, isKeyCode) {
            try {
                this.nameActionSave = {
                    nameButton: nameButton,
                    nameTooltip: nameTooltip,
                    paramFunction: paramFunction,
                };
                localStorage.setItem(
                    "name_action_save",
                    JSON.stringify(this.nameActionSave)
                );
                if (!isKeyCode) {
                    this.onHandleActionSave(paramFunction);
                }
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Function kiểm tra người dùng nhấn các key để thao tác với modal
         * @param {*} $event: Giá trị thẻ đang được chọn
         * @author: DUONGPV (08/09/2022)
         */
        eventHandleKey($event) {
            if ($event.ctrlKey) {
                if ($event.keyCode == 83) {
                    if ($event.shiftKey) {
                        this.onSave(this.typeVoucher, 1);
                        this.setNameActionSave(
                            "Cất và Thêm",
                            "Ctrl + Shift + S",
                            1,
                            true
                        );
                    } else {
                        $event.preventDefault();
                        this.onSave(this.typeVoucher);
                    }
                } else if ($event.keyCode == 81) {
                    this.onSave(this.typeVoucher);
                    this.setNameActionSave("Cất và Đóng", "Ctrl + Q", 1, true);
                }
            }
            if ($event.keyCode == 27) {
                event.stopPropagation();
                this.onClose(0);
            }
        },
    },
};
</script>
<style scoped>
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
