using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DZ7
{
    public class Serializer
    {
        public static string ObjectToString(object obj)
        {
            var fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var fieldStrings = new List<string>();
            foreach (var field in fields)
            {
                var customName = field.GetCustomAttribute<CustomNameAttribute>();
                var fieldName = customName != null ? customName.Name : field.Name;
                fieldStrings.Add($"{fieldName}:{field.GetValue(obj)}");
            }
            return string.Join("\n", fieldStrings);
        }

        public static void StringToObject(string data, object obj)
        {
            var fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var lines = data.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length != 2)
                    continue;

                var fieldName = parts[0];
                var fieldValue = parts[1];

                FieldInfo fieldInfo = null;
                foreach (var field in fields)
                {
                    var customName = field.GetCustomAttribute<CustomNameAttribute>();
                    if ((customName != null && customName.Name == fieldName) || field.Name == fieldName)
                    {
                        fieldInfo = field;
                        break;
                    }
                }

                if (fieldInfo == null)
                    continue;

                // Проверка типа поля и преобразование строки в это значение
                if (fieldInfo.FieldType == typeof(int))
                {
                    if (int.TryParse(fieldValue, out int intValue))
                    {
                        fieldInfo.SetValue(obj, intValue);
                    }
                    else
                    {
                        Console.WriteLine($"Некорректное значение для {fieldName}: {fieldValue}");
                    }
                }
                else if (fieldInfo.FieldType == typeof(string))
                {
                    fieldInfo.SetValue(obj, fieldValue);
                }                
            }
        
        }
    }
}
