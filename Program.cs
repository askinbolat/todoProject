using System;

namespace todoProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person defaultPerson= new Person();
            defaultPerson.NewPersonn.Add(142,"Duman");
            defaultPerson.NewPersonn.Add(454,"Paşa");
            defaultPerson.NewPersonn.Add(994,"Puruşa");
            

            Board newBoard =new Board();
            newBoard.todo.Add(new Card("Engineer","Problem",defaultPerson.NewPersonn[142],"todo",Card.CardSize.L));
            newBoard.inprogress.Add(new Card("Doctor","Healt",defaultPerson.NewPersonn[454],"inprogress",Card.CardSize.XS));
            newBoard.done.Add(new Card("Art","Painting",defaultPerson.NewPersonn[994],"done",Card.CardSize.XL));

            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) \n*******************************************");
            Console.WriteLine("(1) Board Listelemek\n(2) Board'a Kart Eklemek\n(3) Board'dan Kart Silmek\n(4) Kart Taşımak");
            int choose = int.Parse(Console.ReadLine());

            switch (choose)
            {
                case 1:
                    Board instance1 =new Board();
                    instance1.ListBoard(newBoard);
                    break;
                case 2:
                    Board instance2 =new Board();
                    instance2.AddCard(newBoard,defaultPerson);
                    break;
                case 3:
                    Board instance3=new Board();
                    instance3.DeleteCard(newBoard);
                    break;
                case 4:
                    Board instance4 =new Board();
                    instance4.MoveCard(newBoard);
                    break;

            }
        }
    }
}