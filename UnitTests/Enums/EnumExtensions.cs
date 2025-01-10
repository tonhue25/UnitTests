using System.ComponentModel;
using System.Reflection;

namespace UnitTests.Enums
{
    public class EnumExtensions
    {
        public static string GetDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static string GetCodeValue(ErrorCode code)
        {
            return (code == ErrorCode.Success ? "00" : ((int)code).ToString("D2"));
        }
    }
}
