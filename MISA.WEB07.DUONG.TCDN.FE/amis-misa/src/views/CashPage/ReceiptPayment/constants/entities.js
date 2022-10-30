import { API_RESOURCE } from "@/views/CashPage/ReceiptPayment/constants/api";
export const ListComboboxReceipt = [
    {
        type_voucher: 1,
        value_show: "1. Thu tiền khách hàng (không theo hóa đơn)",
    },
    {
        type_voucher: 2,
        value_show: "2. Thu hoàn ứng nhân viên",
    },
    {
        type_voucher: 3,
        value_show: "3. Rút tiền gửi về nhập quỹ",
    },
    {
        type_voucher: 4,
        value_show: "4. Thu khác",
    },
];

export const ListComboboxPayment = [
    {
        type_voucher: 1,
        value_show: "1. Trả tiền nhà cung cấp(Không theo hóa đơn)",
    },
    {
        type_voucher: 2,
        value_show: "2. Tạm ứng cho nhân viên",
    },
    {
        type_voucher: 3,
        value_show: "3. Chi mua ngoài có hóa đơn",
    },
    {
        type_voucher: 4,
        value_show: "4. Trả lương nhân viên",
    },
    {
        type_voucher: 5,
        value_show: "5. Chuyển tiền cho chi nhánh khác",
    },
    {
        type_voucher: 6,
        value_show: "6. Gửi tiền vào ngân hàng",
    },
    {
        type_voucher: 7,
        value_show: "7. Chi khác",
    },
];

export const ColumnsAccoutingReceipt = [
    {
        fieldName: "Diễn giải",
        dataField: "reason",
        styleObject: {
            "min-width": "252px !important",
        },
        isHidden: false,
        dataInput: {
            isInput: true,
            isInputNumber: false,
            dataField: "reason",
            autocomplete: "off",
        },
        dataCombobox: {
            isCombobox: false,
        },
    },
    {
        fieldName: "TK Nợ",
        dataField: "debt_account",
        styleObject: {
            "min-width": "127px !important",
        },
        isHidden: false,
        dataInput: {
            isInput: false,
            isInputNumber: false,
            dataField: "",
        },
        dataCombobox: {
            isCombobox: true,
            url: API_RESOURCE.PAGING_DATA_ACCOUNT,
            propValue: "debt_account",
            propText: "debt_account",
            dataField: "account_number",
            dataText: "account_number",
            placeholder: "Tài khoản nợ",
            classListData: [""],
            nameRows: [
                {
                    fieldName: "Số tài khoản",
                    dataField: "account_number",
                },
                {
                    fieldName: "Tên tài khoản",
                    dataField: "account_name",
                },
            ],
        },
    },
    {
        fieldName: "TK Có",
        dataField: "credit_account",
        styleObject: {
            "min-width": "137px !important",
        },
        isHidden: false,
        dataInput: {
            isInput: false,
            isInputNumber: false,
            dataField: "",
        },
        dataCombobox: {
            isCombobox: true,
            url: API_RESOURCE.PAGING_DATA_ACCOUNT,
            propValue: "credit_account",
            propText: "credit_account",
            dataField: "account_number",
            dataText: "account_number",
            placeholder: "Tài khoản có",
            classListData: [""],
            nameRows: [
                {
                    fieldName: "Số tài khoản",
                    dataField: "account_number",
                },
                {
                    fieldName: "Tên tài khoản",
                    dataField: "account_name",
                },
            ],
        },
    },
    {
        fieldName: "Số tiền",
        dataField: "amount_money",
        styleObject: {
            "min-width": "200px !important",
            "text-align": "right !important",
        },
        isHidden: false,
        dataInput: {
            isInput: true,
            isInputNumber: true,
            dataField: "amount_money",
            autocomplete: "off",
        },
        dataCombobox: {
            isCombobox: false,
        },
    },
    {
        fieldName: "Đối tượng",
        dataField: "account_object_code",
        styleObject: {
            "min-width": "150px !important",
        },
        isHidden: false,
        dataInput: {
            isInput: false,
            isInputNumber: false,
            dataField: "",
        },
        dataCombobox: {
            isCombobox: true,
            isComboboxFullWidth: true,
            url: API_RESOURCE.PAGING_DATA_ACCOUNT_OBJECT,
            propValue: "account_object_id",
            propText: "account_object_code",
            dataField: "account_object_id",
            dataText: "account_object_code",
            placeholder: "Đối tượng",
            classListData: ["h-large-combobox-table"],
            nameRows: [
                {
                    fieldName: "Đối tượng",
                    dataField: "account_object_code",
                    styleObject: {
                        "min-width": "120px",
                    },
                },
                {
                    fieldName: "Tên đối tượng",
                    dataField: "account_object_name",
                    styleObject: {
                        "min-width": "280px",
                    },
                },
                {
                    fieldName: "Mã số thuế",
                    dataField: "tax_code",
                    styleObject: {
                        "min-width": "140px",
                    },
                },
                {
                    fieldName: "Địa chỉ",
                    dataField: "address",
                    styleObject: {
                        "min-width": "250px",
                    },
                },
                {
                    fieldName: "Điện thoại",
                    dataField: "phone_number",
                    styleObject: {
                        "min-width": "100px",
                    },
                },
            ],
        },
    },
    {
        fieldName: "Tên đối tượng",
        dataField: "account_object_name",
        styleObject: {
            "min-width": "251px !important",
        },
        isHidden: false,
        dataInput: {
            isInput: false,
            isInputNumber: false,
            dataField: "",
        },
        dataCombobox: {
            isCombobox: false,
        },
    },
];

export const ColumnsAccoutingPayment = [
    {
        fieldName: "Diễn giải",
        dataField: "reason",
        styleObject: {
            "min-width": "252px !important",
        },
        isHidden: false,
        dataInput: {
            isInput: true,
            isInputNumber: false,
            dataField: "reason",
            autocomplete: "off",
        },
        dataCombobox: {
            isCombobox: false,
        },
    },
    {
        fieldName: "TK Nợ",
        dataField: "debt_account",
        styleObject: {
            "min-width": "127px !important",
        },
        isHidden: false,
        dataInput: {
            isInput: false,
            isInputNumber: false,
            dataField: "",
        },
        dataCombobox: {
            isCombobox: true,
            url: API_RESOURCE.PAGING_DATA_ACCOUNT,
            placeholder: "Tài khoản nợ",
            propValue: "debt_account",
            propText: "debt_account",
            dataField: "account_number",
            dataText: "account_number",
            classListData: [""],
            nameRows: [
                {
                    fieldName: "Số tài khoản",
                    dataField: "account_number",
                },
                {
                    fieldName: "Tên tài khoản",
                    dataField: "account_name",
                },
            ],
        },
    },
    {
        fieldName: "TK Có",
        dataField: "credit_account",
        styleObject: {
            "min-width": "137px !important",
        },
        isHidden: false,
        dataInput: {
            isInput: false,
            isInputNumber: false,
            dataField: "",
        },
        dataCombobox: {
            isCombobox: true,
            url: API_RESOURCE.PAGING_DATA_ACCOUNT,
            placeholder: "Tài khoản có",
            propValue: "credit_account",
            propText: "credit_account",
            dataField: "account_number",
            dataText: "account_number",
            classListData: [""],
            nameRows: [
                {
                    fieldName: "Số tài khoản",
                    dataField: "account_number",
                },
                {
                    fieldName: "Tên tài khoản",
                    dataField: "account_name",
                },
            ],
        },
    },
    {
        fieldName: "Số tiền",
        dataField: "amount_money",
        styleObject: {
            "min-width": "200px !important",
            "text-align": "right !important",
        },
        isHidden: false,
        dataInput: {
            isInput: true,
            isInputNumber: true,
            dataField: "amount_money",
            autocomplete: "off",
        },
        dataCombobox: {
            isCombobox: false,
        },
    },
    {
        fieldName: "Đối tượng",
        dataField: "account_object_code",
        styleObject: {
            "min-width": "150px !important",
        },
        isHidden: false,
        dataInput: {
            isInput: false,
            isInputNumber: false,
            dataField: "",
        },
        dataCombobox: {
            isCombobox: true,
            isComboboxFullWidth: true,
            url: API_RESOURCE.PAGING_DATA_ACCOUNT_OBJECT,
            placeholder: "Đối tượng",
            propValue: "account_object_id",
            propText: "account_object_code",
            dataField: "account_object_id",
            dataText: "account_object_code",
            classListData: ["h-large-combobox-table"],
            nameRows: [
                {
                    fieldName: "Đối tượng",
                    dataField: "account_object_code",
                    styleObject: {
                        "min-width": "120px",
                    },
                },
                {
                    fieldName: "Tên đối tượng",
                    dataField: "account_object_name",
                    styleObject: {
                        "min-width": "280px",
                    },
                },
                {
                    fieldName: "Mã số thuế",
                    dataField: "tax_code",
                    styleObject: {
                        "min-width": "140px",
                    },
                },
                {
                    fieldName: "Địa chỉ",
                    dataField: "address",
                    styleObject: {
                        "min-width": "250px",
                    },
                },
                {
                    fieldName: "Điện thoại",
                    dataField: "phone_number",
                    styleObject: {
                        "min-width": "100px",
                    },
                },
            ],
        },
    },
    {
        fieldName: "Tên đối tượng",
        dataField: "account_object_name",
        styleObject: {
            "min-width": "251px !important",
        },
        isHidden: false,
        dataInput: {
            isInput: false,
            isInputNumber: false,
            dataField: "",
        },
        dataCombobox: {
            isCombobox: false,
        },
    },
];
