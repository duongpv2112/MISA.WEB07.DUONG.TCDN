
using MISA.WEB07.DUONGPV.TCDN.Common.Attributes;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.Common.Exceptions;
using MISA.WEB07.DUONGPV.TCDN.Common.Resources;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MISA.WEB07.DUONGPV.TCDN.BL.Utilities
{
    /// <summary>
    /// Kiểm tra dữ liệu trước khi được gọi vào DataBase
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class ValidateEntity<T>
    {
        /// <summary>
        /// Kiểm tra dữ liệu đầu vào
        /// </summary>
        /// <param name="entity">Giá trị cần kiểm tra</param>
        /// <exception cref="MISAException"></exception>
        public static void Validate(T entity)
        {
            List<string> errors = new List<string>();
            var properties = entity?.GetType().GetProperties();
            foreach (var property in properties)
            {
                // Tìm những property có attribute IsNotNullOrEmptyAttribute
                var propertyRequired = (IsNotNullOrEmptyAttribute?)Attribute.GetCustomAttribute(property, typeof(IsNotNullOrEmptyAttribute));

                // Tìm những property có attribute MISAEmailAttribute
                var propertyEmail = property.GetCustomAttributes(typeof(MISAEmailAttribute), true);

                // Tìm property có attribute DateBiggerCurrentAttribute
                var propertyDateBigger = typeof(T).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(DateBiggerCurrentAttribute), true).Count() > 0);

                // Tìm những property có attribute MISAPhoneAttribute
                var propertyPhone = property.GetCustomAttributes(typeof(MISAPhoneAttribute), true);

                // Tìm những property có attribute PositiveNumberAttribute
                var propertyPositiveNumber = property.GetCustomAttributes(typeof(PositiveNumberAttribute), true);

                // Kiểm tra các property. Sau mỗi lần kiểm tra nếu bị lỗi sẽ được thêm vào errors
                if (propertyRequired != null && string.IsNullOrEmpty(property.GetValue(entity)?.ToString()))
                {
                    errors.Add(propertyRequired.ErrorMessage);
                }
                if (propertyEmail.Count() > 0)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        string? propertyValue = (string?)property.GetValue(entity);
                        if (propertyValue != null && propertyValue != "")
                        {
                            string regexEmail = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                            Regex email = new Regex(regexEmail);
                            if (propertyValue != null && !email.IsMatch(propertyValue))
                                errors.Add(Resource.ErrorEmail);

                        }
                    }
                }
                if (propertyDateBigger?.CustomAttributes.Count() > 0)
                {
                    if (!CheckNullOrEmpty((string)propertyDateBigger.GetValue(entity)))
                    {
                        DateTime? propertyValue = DateTime.Parse((string)propertyDateBigger.GetValue(entity));

                        if (propertyValue >= DateTime.Now)
                        {
                            var attributeDate = propertyDateBigger.GetCustomAttribute(typeof(DateBiggerCurrentAttribute), true);
                            errors.Add(string.Format(Common.Resources.Resource.ErrorDateBiggerCurrent, attributeDate.GetType().Name));
                        }
                    }
                }
                if (propertyPhone.Count() > 0)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        string? propertyValue = (string?)property.GetValue(entity);
                        if (propertyValue != null && propertyValue != "")
                        {
                            string regexPhone = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
                            Regex phone = new Regex(regexPhone);
                            if (propertyValue != null && !phone.IsMatch(propertyValue))
                                errors.Add(string.Format(Resource.ErrorPhoneNumber, property.Name));

                        }
                    }
                }
                if (propertyPositiveNumber.Count() > 0)
                {
                    if (property.PropertyType == typeof(int))
                    {
                        int propertyValue = (int)property.GetValue(entity);
                        if (propertyValue != null)
                        {
                            if (propertyValue < 0)
                            {
                                var attributeDate = (PositiveNumberAttribute?)Attribute.GetCustomAttribute(property, typeof(PositiveNumberAttribute));
                                errors.Add(attributeDate.ErrorMessage);
                            }
                        }
                    }
                    else if (property.PropertyType == typeof(decimal))
                    {
                        decimal propertyValue = (decimal)property.GetValue(entity);
                        if (propertyValue != null)
                        {
                            if (propertyValue < 0)
                            {
                                var attributeDate = (PositiveNumberAttribute?)Attribute.GetCustomAttribute(property, typeof(PositiveNumberAttribute));
                                errors.Add(attributeDate.ErrorMessage);
                            }
                        }
                    }
                    

                }
            }

            // Kiểm tra errors, nếu lớn hơn 0 thì trả về Custom Exception
            if (errors.Count > 0)
            {
                throw new MISAException(errors);
            }
        }

        /// <summary>
        /// Hàm kiểm tra giá trị Null hoặc rỗng
        /// </summary>
        /// <param name="value">Giá trị cần kiểm tra</param>
        /// <returns>True hoặc False</returns>
        public static bool CheckNullOrEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            return false;
        }
    }
}
