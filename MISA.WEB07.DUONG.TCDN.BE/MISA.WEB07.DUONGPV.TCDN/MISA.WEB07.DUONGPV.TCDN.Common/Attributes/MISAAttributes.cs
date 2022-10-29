namespace MISA.WEB07.DUONGPV.TCDN.Common.Attributes
{
    /// <summary>
    /// Attribute dùng để xác định 1 property là khóa chính
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute : Attribute
    {
        public string PrimaryKeyName;

        public PrimaryKeyAttribute(string primaryKeyName)
        {
            PrimaryKeyName = primaryKeyName;
        }

        public string Name { get { return PrimaryKeyName; } }
    }

    /// <summary>
    /// Attribute dùng để xác định 1 property là unique
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class UniqueKeyAttribute : Attribute
    {
        public string UniqueKeyName;

        public UniqueKeyAttribute(string uniqueKeyName)
        {
            UniqueKeyName = uniqueKeyName;
        }

        public string Name { get { return UniqueKeyName; } }
    }

    /// <summary>
    /// Attribute dùng để xác định 1 property không được trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IsNotNullOrEmptyAttribute : Attribute
    {
        #region Field

        /// <summary>
        /// Message lỗi trả về cho client
        /// </summary>
        public string Message;
        #endregion

        #region Contructor

        public IsNotNullOrEmptyAttribute(string errorMessage)
        {
            Message = errorMessage;
        }

        public string ErrorMessage { get { return Message; } }

        #endregion
    }

    /// <summary>
    /// Attribute dùng để xác định 1 property là khóa ngoại
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKeyAttribute : Attribute
    {
        public string ForeignKeyName;

        public ForeignKeyAttribute(string foreignKeyName)
        {
            ForeignKeyName = foreignKeyName;
        }

        public string Name { get { return ForeignKeyName; } }
    }

    /// <summary>
    /// Attribute dùng để xác định ngày nhập không lớn hơn ngày hiện tại
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DateBiggerCurrentAttribute : Attribute
    {
        public string PropertyName;

        public DateBiggerCurrentAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }

        public string Name { get { return PropertyName; } }
    }

    /// <summary>
    /// Attribute dùng để xác định email đúng định dạng
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MISAEmailAttribute : Attribute
    {
        public string PropertyName;

        public MISAEmailAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }

        public string Name { get { return PropertyName; } }
    }

    /// <summary>
    /// Attribute dùng để xác định số điện thoại có đúng định dạng
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MISAPhoneAttribute : Attribute
    {
        public string Message;

        public MISAPhoneAttribute(string errorMessage)
        {
            Message = errorMessage;
        }

        public string ErrorMessage { get { return Message; } }
    }

    /// <summary>
    /// Attribute dùng để xác định tên table
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class MISATableAttribute : Attribute
    {
        public string NameTable;

        public string NameTableConstraint;

        public MISATableAttribute(string name)
        {
            NameTable = name;
        }

        public MISATableAttribute(string name, string nameConstraint)
        {
            NameTable = name;
            NameTableConstraint = nameConstraint;
        }

        public string Name { get { return NameTable; } }

        public string NameConstraint { get { return NameTableConstraint; } }
    }

    /// <summary>
    /// Attribute dùng để xác định số có phải là số dương không
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PositiveNumberAttribute : Attribute
    {
        public string Message;

        public PositiveNumberAttribute(string errorMessage)
        {
            Message = errorMessage;
        }

        public string ErrorMessage { get { return Message; } }
    }
}
