using sni;

namespace FeTracker.Sni.Extensions;

public static class FieldsResponseExtensions
{
    extension(FieldsResponse fr)
    {
        public bool TryGetValue(Field fieldName, out string fieldValue)
        {
            fieldValue = string.Empty;
            var index = fr.Fields.IndexOf(fieldName);

            if (index < 0)
                return false;

            fieldValue = fr.Values[index];
            return true;
        }
    }
}