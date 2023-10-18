using Core.Processing.Data;

namespace Core.Processing.Helpers
{
    public static class GlobalHelper
    {
        public static string ConvertByteArrayToBase64(byte[] byteArray)
        {
            return $"data:image/png;base64,{Convert.ToBase64String(byteArray)}";
        }
        public static byte[] FromBase64String(string base64)
        {
            try
            {
                return Convert.FromBase64String(base64);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Input is not a valid Base64 string.", nameof(base64));
            }
        }
        public static string GetHtmlInputType(Type propertyType)
        {
            if (propertyType == typeof(int) || propertyType == typeof(decimal) || propertyType == typeof(double))
            {
                return "number";
            }
            else if (propertyType == typeof(bool))
            {
                return "checkbox";
            }
            else if (propertyType == typeof(DateTime))
            {
                return "datetime-local";
            }
            else
            {
                return "text";
            }
        }

    }

    public static class Enums
    {
        public enum ModalTypeEnum
        {
            NewOperattion,
            NewDevice
        }
    }
    public class FormFieldConverter<T>
    {
        public T Convert(List<FormField> formFields)
        {
            var instance = Activator.CreateInstance<T>();

            foreach (var formField in formFields)
            {
                SetPropertyValue(instance, formField.Label, formField.Value);
            }

            return instance;
        }

        private void SetPropertyValue(object instance, string propertyName, string propertyValue)
        {
            var targetType = typeof(T);
            var propertyInfo = targetType.GetProperty(propertyName);

            if (propertyInfo != null)
            {
                object value = ConvertValue(propertyValue, propertyInfo.PropertyType);
                propertyInfo.SetValue(instance, value);
            }
        }

        private object ConvertValue(string stringValue, Type targetType)
        {
            if (targetType == typeof(int))
            {
                if (int.TryParse(stringValue, out int intValue))
                {
                    return intValue;
                }
            }
            else if (targetType == typeof(string))
            {
                return stringValue;
            }
            else if (targetType == typeof(byte[]))
            {
                return new byte[0];
            }
            else if (targetType == typeof(Device))
            {
                return ProcessingService.GetSampleDevices().Result.Find(x => x.DeviceID == int.Parse(stringValue));
            }
            else if (targetType == typeof(Operation))
            {
                return ProcessingService.GetSampleOperations().Result.Find(x => x.OperationID == int.Parse(stringValue));
            }
            return null;
        }
    }
}
