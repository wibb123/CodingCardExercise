namespace CodingCardExercise.Models
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class EnumOneCharRepAttribute : Attribute
    {
        public char OneCharRep { get; }

        public EnumOneCharRepAttribute(char oneCharRep)
        {
            OneCharRep = oneCharRep;
        }
    }
}
