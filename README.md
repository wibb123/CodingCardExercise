# CodingCardExercise

## Overview
This program takes an input of cards as a comma-separated list and returns a score based on the following criteria:
- Number cards are worth their face value; e.g. 4 equals 4 points.
- A Jack is worth 11 points, a Queen 12 points, a King 13 points and an Ace 14 points.
- The suit of the card determines what to multiply the card’s value by:
  - Club: Multiply by 1
  - Diamond: Multiply by 2
  - Heart: Multiply by 3
  - Spade: Multiply by 4

For example, the Ace of Spades point value would be 56 (14 x 4).

The point values for each card are added up to give a final score. If a Joker appears anywhere in the
list of cards, the score for that hand is doubled.

Each card can only appear once in the list, however a Joker may appear twice (as a deck contains
two Jokers), however a Joker cannot appear three or more times.

## Technical Detail

The code is built in ASP.NET core and has a very simple user interface with a small amount of JavaScript.
