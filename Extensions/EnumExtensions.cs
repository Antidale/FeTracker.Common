using System.ComponentModel;

namespace FeTracker.Common.Extensions
{
    internal static class EnumExtensions
    {
        internal static string GetDescription<TEnum>(this TEnum enumMember) where TEnum : Enum
        {
            if (enumMember == null) { return ""; }

            return enumMember.GetType()
                             .GetField(enumMember.ToString())?
                             .GetCustomAttributes(typeof(DescriptionAttribute), false)
                             .SingleOrDefault() is not DescriptionAttribute attribute
                                ? enumMember.ToString()
                                : attribute.Description;
        }
    }
}
