namespace CodingCardExercise.Models
{
    /// <summary>
    /// Helper Class
    /// </summary>
    public static class Helpers
    {
        public static TEnum ParseEnumByOneCharRep<TEnum>(char oneCharRep) where TEnum : Enum
        {
            foreach (var field in typeof(TEnum).GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(EnumOneCharRepAttribute)) is EnumOneCharRepAttribute attribute)
                {
                    if (attribute.OneCharRep == oneCharRep)
                    {
                        return (TEnum)field.GetValue(null);
                    }
                }
            }

            throw new ArgumentException($"No enum value with oneCharRep '{oneCharRep}' found.");
        }
    }
}
