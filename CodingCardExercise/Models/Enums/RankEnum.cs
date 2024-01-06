using System.ComponentModel;

namespace CodingCardExercise.Models.Enums
{
    public enum Rank
    {
        [EnumOneCharRep('2')]
        Two = 2,
        [EnumOneCharRep('3')]
        Three = 3,
        [EnumOneCharRep('4')]
        Four = 4,
        [EnumOneCharRep('5')]
        Five = 5,
        [EnumOneCharRep('6')]
        Six = 6,
        [EnumOneCharRep('7')]
        Seven = 7,
        [EnumOneCharRep('8')]
        Eight = 8,
        [EnumOneCharRep('9')]
        Nine = 9,
        [EnumOneCharRep('T')]
        Ten = 10,
        [EnumOneCharRep('J')]
        Jack = 11,
        [EnumOneCharRep('Q')]
        Queen = 12,
        [EnumOneCharRep('K')]
        King = 13,
        [EnumOneCharRep('A')]
        Ace = 14,
    }
}
