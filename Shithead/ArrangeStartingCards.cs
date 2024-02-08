using CardGames.Core.Cards;
using Shithead.CardCollections;
using System;

namespace Shithead
{
    public class ArrangeStartingCards
    {
        readonly ThreeCards _faceDownCards;

        Card _firstFaceUp;
        Card _secondFaceUp;
        Card _thirdFaceUp;
        Card _firstInHand;
        Card _secondInHand;
        Card _thirdInHand;

        public ArrangeStartingCards(StartingCards cards)
        {
            _faceDownCards = cards.FaceDown;

            _firstFaceUp = cards.FaceUp.First;
            _secondFaceUp = cards.FaceUp.Second;
            _thirdFaceUp = cards.FaceUp.Third;
            _firstInHand = cards.InHand.First;
            _secondInHand = cards.InHand.Second;
            _thirdInHand = cards.InHand.Third;

            FirstFaceUp = new FaceUpCardActions(
                swapWithFirstInHand: () => (_firstFaceUp, _firstInHand) = (_firstInHand, _firstFaceUp),
                swapWithSecondInHand: () => (_firstFaceUp, _secondInHand) = (_secondInHand, _firstFaceUp),
                swapWithThirdInHand: () => (_firstFaceUp, _thirdInHand) = (_thirdInHand, _firstFaceUp));

            SecondFaceUp = new FaceUpCardActions(
                swapWithFirstInHand: () => (_secondFaceUp, _firstInHand) = (_firstInHand, _secondFaceUp),
                swapWithSecondInHand: () => (_secondFaceUp, _secondInHand) = (_secondInHand, _secondFaceUp),
                swapWithThirdInHand: () => (_secondFaceUp, _thirdInHand) = (_thirdInHand, _secondFaceUp));

            ThirdFaceUp = new FaceUpCardActions(
                swapWithFirstInHand: () => (_thirdFaceUp, _firstInHand) = (_firstInHand, _thirdFaceUp),
                swapWithSecondInHand: () => (_thirdFaceUp, _secondInHand) = (_secondInHand, _thirdFaceUp),
                swapWithThirdInHand: () => (_thirdFaceUp, _thirdInHand) = (_thirdInHand, _thirdFaceUp));
        }

        public FaceUpCardActions FirstFaceUp { get; }

        public FaceUpCardActions SecondFaceUp { get; }

        public FaceUpCardActions ThirdFaceUp { get; }

        public StartingCards Finish()
        {
            return new StartingCards(
                _faceDownCards,
                faceUp: new ThreeCards(_firstFaceUp, _secondFaceUp, _thirdFaceUp),
                inHand: new ThreeCards(_firstInHand, _secondInHand, _thirdInHand)
                );
        }

        public class FaceUpCardActions
        {
            readonly Action _swapWithFirstInHand;
            readonly Action _swapWithSecondInHand;
            readonly Action _swapWithThirdInHand;

            internal FaceUpCardActions(
                Action swapWithFirstInHand,
                Action swapWithSecondInHand,
                Action swapWithThirdInHand)
            {
                _swapWithFirstInHand = swapWithFirstInHand;
                _swapWithSecondInHand = swapWithSecondInHand;
                _swapWithThirdInHand = swapWithThirdInHand;
            }

            public void SwapWithFirstInHand() => _swapWithFirstInHand();

            public void SwapWithSecondInHand() => _swapWithSecondInHand();

            public void SwapWithThirdInHand() => _swapWithThirdInHand();
        }
    }
}
