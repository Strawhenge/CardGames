namespace Shithead.CardCollections
{
    public class StartingCards
    {
        public StartingCards(ThreeCards faceDown, ThreeCards faceUp, ThreeCards inHand)
        {
            FaceDown = faceDown;
            FaceUp = faceUp;
            InHand = inHand;
        }

        public ThreeCards FaceDown { get; }

        public ThreeCards FaceUp { get; }

        public ThreeCards InHand { get; }
    }
}
