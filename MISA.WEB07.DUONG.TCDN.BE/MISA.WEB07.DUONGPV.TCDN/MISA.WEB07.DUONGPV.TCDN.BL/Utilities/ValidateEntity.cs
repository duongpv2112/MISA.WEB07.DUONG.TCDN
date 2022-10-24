
using MISA.WEB07.DUONGPV.TCDN.Common.Attributes;
using MISA.WEB07.DUONGPV.TCDN.Common.Resources;
using System.Text.RegularExpressions;

namespace MISA.WEB07.DUONGPV.TCDN.BL.Utilities
{
    public static class ValidateEntity<T>
    {
        public static void Validate(T entity)
        {
            List<string> errors = new List<string>();
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyRequired = (IsNotNullOrEmptyAttribute?)Attribute.GetCustomAttribute(property, typeof(IsNotNullOrEmptyAttribute));
                var propertyEmail = property.GetCustomAttributes(typeof(MISAEmailAttribute), true);
                var propertyDateBigger = property.GetCustomAttributes(typeof(DateBiggerCurrentAttribute), true);
                var propertyPhone = (IsNotNullOrEmptyAttribute?)Attribute.GetCustomAttribute(property, typeof(IsNotNullOrEmptyAttribute));
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
                if (propertyDateBigger.Count() > 0)
                {
                    DateTime? propertyValue = (DateTime?)property.GetValue(entity);

                    if (!CheckNullOrEmpty(propertyValue.ToString()))
                    {
                        if (propertyValue >= DateTime.Now)
                        {
                            errors.Add(string.Format(Resource.ErrorDateBiggerCurrent, property.Name));
                        }
                    }
                }
                if (propertyRequired != null && string.IsNullOrEmpty(property.GetValue(entity)?.ToString()))
                {
                    errors.Add(propertyRequired.ErrorMessage);
                }
            }
            if (errors.Count > 0)
            {
                //throw new MISAException(errors);
            }
        }

        public static bool CheckNullOrEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            return false;
        }

        public static bool CheckPhone(string value)
        {
            foreach (char c in value)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }

            }
            return true;
        }

        public static bool IsDate(string tempDate)
        {
            DateTime fromDateValue;
            var formats = new[] { "dd/MM/yyyy", "yyyy-MM-dd" };
            if (DateTime.TryParseExact(tempDate, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue))
            {
                return true;
            }
            else
                return false;
        }
    }
}
