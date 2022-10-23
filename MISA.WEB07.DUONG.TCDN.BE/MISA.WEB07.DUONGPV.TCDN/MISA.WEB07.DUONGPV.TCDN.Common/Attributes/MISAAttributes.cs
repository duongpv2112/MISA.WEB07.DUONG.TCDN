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
    /// Attribute dùng để xác định 1 property không được trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IsNotNullOrEmptyAttribute : Attribute
    {
        #region Field

        /// <summary>
        /// Message lỗi trả về cho client
        /// </summary>
        public string ErrorMessage;
        #endregion

        #region Contructor

        public IsNotNullOrEmptyAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

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

}
