using System;

namespace todoProject
{
    public class Card
    {
        public enum CardSize
        {
            XS=1,
            S,
            M,
            L,
            XL,
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string AssignedPerson { get; set; }
        public string Line { get; set; }
        public CardSize CardSizeType { get; set; }
        public Card(string title, string content, string assignedPerson, string line, CardSize cardSizeType)
        {
            Title = title;
            Content = content;
            AssignedPerson = assignedPerson;
            Line = line;
            CardSizeType = cardSizeType;
        }
        public Card(){}
    }
}