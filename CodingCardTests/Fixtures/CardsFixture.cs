using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingCardTests.Fixtures
{
    public static class CardsFixture
    {
        public static IEnumerable<object[]> ValidCardLists()
        {
            yield return new object[] { new List<Card> {
            new Card
            {
                TwoLetterRep = "JK",
                IsJoker = true,
            },
            new Card
            {
                TwoLetterRep = "JD",
                IsJoker = false,
                Rank = Rank.Jack,
                Suit = Suit.Diamond
            },
            new Card
            {
                TwoLetterRep = "2C",
                IsJoker = false,
                Rank = Rank.Two,
                Suit = Suit.Club
            },
            new Card
            {
                TwoLetterRep = "TS",
                IsJoker = false,
                Rank = Rank.Ten,
                Suit = Suit.Spade
            }
            }
        };
        }

        public static IEnumerable<object[]> InvalidCardLists()
        {
            yield return new object[] { new List<Card> {
            new Card
            {
                TwoLetterRep = "JK",
                IsJoker = true,
            },
            new Card
            {
                TwoLetterRep = "JD",
                IsJoker = false,
                Rank = Rank.Jack,
                Suit = Suit.Diamond
            },
            new Card
            {
                TwoLetterRep = "JD",
                IsJoker = false,
                Rank = Rank.Two,
                Suit = Suit.Club
            },
            new Card
            {
                TwoLetterRep = "TS",
                IsJoker = false,
                Rank = Rank.Ten,
                Suit = Suit.Spade
            }
            } };
            yield return new object[] { new List<Card> {
            new Card
            {
                TwoLetterRep = "JK",
                IsJoker = true,
            },
            new Card
            {
                TwoLetterRep = "JK",
                IsJoker = true,
            },
            new Card
            {
                TwoLetterRep = "JK",
                IsJoker = true,
            },
            new Card
            {
                TwoLetterRep = "TS",
                IsJoker = false,
                Rank = Rank.Ten,
                Suit = Suit.Spade
            }
            }
        };
        }

        public static IEnumerable<object[]> ValidCardStrings()
        {
            yield return new object[] { "JK" };
            yield return new object[] { "2C" };
            yield return new object[] { "2D" };
            yield return new object[] { "2H" };
            yield return new object[] { "2S" };
            yield return new object[] { "TC" };
            yield return new object[] { "JC" };
            yield return new object[] { "QC" };
            yield return new object[] { "KC" };
            yield return new object[] { "AC" };
            yield return new object[] { "2C" };
        }

        public static IEnumerable<object[]> InvalidCardStrings()
        {
            yield return new object[] { "1S" };
            yield return new object[] { "2B" };
            yield return new object[] { "43" };
            yield return new object[] { "SS" };
            yield return new object[] { "8Y" };
            yield return new object[] { "JL" };
        }

        public static IEnumerable<object[]> ValidCardListStrings()
        {
            yield return new object[] { "JK" };
            yield return new object[] { "2C" };
            yield return new object[] { "2D" };
            yield return new object[] { "2H" };
            yield return new object[] { "2S" };
            yield return new object[] { "TC" };
            yield return new object[] { "JK" };
            yield return new object[] { "JK,JK" };
            yield return new object[] { "2C,JK" };
            yield return new object[] { "JK,2C,JK" };
            yield return new object[] { "TC,  TD ,  JK, TH,  TS,   JK" };
            yield return new object[] { "" };
        }

        public static IEnumerable<object[]> InvalidCardListStrings()
        {
            yield return new object[] { "1S" };
            yield return new object[] { "2B" };
            yield return new object[] { "2S,1S" };
            yield return new object[] { "2S|3D" };
            yield return new object[] { "TC,TD,,JK,TH,TS" };
            yield return new object[] { ",2C" };
            yield return new object[] { "," };
            yield return new object[] { ",2C," };
            yield return new object[] { "2C," };
        }

        public static IEnumerable<object[]> ValidCardsWithScores()
        {
            yield return new object[] {
            new Card
            {
                TwoLetterRep = "JK",
                IsJoker = true,
            }, 0 };
            yield return new object[] {
            new Card
            {
                TwoLetterRep = "JD",
                IsJoker = false,
                Rank = Rank.Jack,
                Suit = Suit.Diamond
            }, 22 };
            yield return new object[] {
            new Card
            {
                TwoLetterRep = "2C",
                IsJoker = false,
                Rank = Rank.Two,
                Suit = Suit.Club
            }, 2 };
            yield return new object[] {
            new Card
            {
                TwoLetterRep = "TS",
                IsJoker = false,
                Rank = Rank.Ten,
                Suit = Suit.Spade
            }, 40 };
        }
    }
}

