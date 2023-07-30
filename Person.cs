using System;

namespace todoProject
{
    public class Person
    {
        private Dictionary<int, string> newPersonn;

        public Dictionary<int, string> NewPersonn { get => newPersonn; set => newPersonn = value; }

        public Person()
        {
            newPersonn =new Dictionary<int, string>();
        }
    }
}