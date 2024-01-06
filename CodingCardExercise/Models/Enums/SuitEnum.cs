using System.ComponentModel;

namespace CodingCardExercise.Models.Enums
{
    public enum Suit
    {
        [EnumOneCharRep('C')]
        Club = 1,
        [EnumOneCharRep('D')]
        Diamond = 2,
        [EnumOneCharRep('H')]
        Heart = 3,
        [EnumOneCharRep('S')]
        Spade = 4
    }
}
