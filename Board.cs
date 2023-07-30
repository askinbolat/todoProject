using System;

namespace todoProject
{
    public class Board
    {
        public List<Card> todo;
        public List<Card> inprogress;
        public List<Card> done;
        public Board()
        {
            todo =new List<Card>();
            inprogress=new List<Card>();
            done =new List<Card>();
        }

        public void ListBoard(Board newboard)
        {
            Console.WriteLine("Todo Line\n************************");
            foreach (var item in newboard.todo)
            {
                Console.WriteLine("Title: {0}",item.Title);
                Console.WriteLine("Content: {0}",item.Content);
                Console.WriteLine("Assigned person: {0}",item.AssignedPerson);
                Console.WriteLine("Size: {0}",item.CardSizeType);
            }
            Console.WriteLine("In Progress Line\n************************");
            foreach (var item in newboard.inprogress)
            {
                Console.WriteLine("Title: {0}",item.Title);
                Console.WriteLine("Content: {0}",item.Content);
                Console.WriteLine("Assigned person: {0}",item.AssignedPerson);
                Console.WriteLine("Size: {0}",item.CardSizeType);
            }
            Console.WriteLine("Done Line\n************************");
            foreach (var item in newboard.done)
            {
                Console.WriteLine("Title: {0}",item.Title);
                Console.WriteLine("Content: {0}",item.Content);
                Console.WriteLine("Assigned person: {0}",item.AssignedPerson);
                Console.WriteLine("Size: {0}",item.CardSizeType);
            }
        }
        
        public void AddCard(Board newBoard,Person defaultPerson)
        {
            int addLineControl =1;
            string addLine;
            do
            {
                CheckLine:;
                addLineControl=1;
                Console.WriteLine("select the line where you want to add the card. 'todo','inprogress','done'");
                addLine =Console.ReadLine();
                if (!addLine.Equals(todo) && !addLine.Equals(inprogress) && !addLine.Equals(done))
                {
                    Console.WriteLine("You entered a wrong line!");
                    goto CheckLine;
                }
            } while (addLineControl!=1); 

            Console.WriteLine("Enter the Title:         ");
            string addTitle = Console.ReadLine();   
            Console.WriteLine("Enter the Content:        ");
            string addContent = Console.ReadLine();

            Card.CardSize size= new Card.CardSize();
            int addSizeControl, addSize;
            do
            {
            CheckSize:;
            addSizeControl=1;
            Console.WriteLine("Please enter size -> XS(1),S(2),M(3),L(4),XL(5):");
            addSize= int.Parse(Console.ReadLine());
            if (addSize==1)
            {
                size =Card.CardSize.XS;
            }
            else if (addSize==2)
            {
                size =Card.CardSize.S;
            }
            else if (addSize==3)
            {
                size=Card.CardSize.M;
            }
            else if (addSize==4)
            {
                size=Card.CardSize.L;
            }
            else if (true)
            {
                size=Card.CardSize.XL;
            }
            else
            {
                Console.WriteLine("You entered a wrong size!");
                addSizeControl=0;
                goto CheckSize;
            }
            } while (addSizeControl!=1);

            
            int addId, addIdControl;
            do
            {
                CheckId:;
                addIdControl=1;
                Console.WriteLine("Enter assigned person's id");
                addId=int.Parse(Console.ReadLine());
                if (defaultPerson.NewPersonn.ContainsKey(addId))
                {
                    Console.WriteLine("Enter a valid id");
                    addIdControl=0;
                    goto CheckId;
                }
                
            } while (addIdControl!=1);

            if (addLine.Equals("todo"))
            {
                newBoard.todo.Add(new Card(addTitle,addContent,defaultPerson.NewPersonn[addId],addLine,size));
            }
            else if (addLine.Equals("inprogress"))
            {
                newBoard.inprogress.Add(new Card(addTitle,addContent,defaultPerson.NewPersonn[addId],addLine,size));
            }
            else
            {
                newBoard.done.Add(new Card(addTitle,addContent,defaultPerson.NewPersonn[addId],addLine,size));
            }
        }

        public void DeleteCard(Board newBoard)
        {   
            int choise =2;
            do
            {   
                Console.WriteLine("Enter the title of the card you want to delete");
                string deleteTitle= Console.ReadLine();
                
                int found =0;
                Card deleteCard =new Card();
                foreach (var item in newBoard.todo)
                {
                    if (item.Title.Equals(deleteTitle))
                    {
                        found=1;
                        Console.WriteLine("Deleting the card title {0}",deleteTitle);
                        deleteCard=item;
                        choise=1;
                    }
                }
                foreach (var item in newBoard.inprogress)
                {
                    if (item.Title.Equals(deleteTitle))
                    {
                        found =2;
                        Console.WriteLine("Deleting the card title {0}",deleteTitle);
                        deleteCard=item;
                        choise=1;
                    }
                }
                foreach (var item in newBoard.done)
                {
                    if (item.Title.Equals(deleteTitle))
                    {
                        found =3;
                        Console.WriteLine("Deleting the card title {0}",deleteTitle);
                        deleteCard=item;
                        choise=1;
                    }
                }
                if (found==1)
                {
                    newBoard.todo.Remove(deleteCard);
                }
                else if (found==2)
                {
                    newBoard.inprogress.Remove(deleteCard);
                }
                else if (found==3)
                {
                    newBoard.done.Remove(deleteCard);
                }
                
                int deleteControl=1;
                if (found==0)
                {
                    do
                    {
                        Console.WriteLine("The card matching the criteria you are looking for was not found on the board. Please make a selection");
                        Console.WriteLine("* To end the deletion : (1)\n* To try again : (2)");
                        Console.Write("Your choice: ");
                        deleteControl=int.Parse(Console.ReadLine());

                        if (deleteControl==1);
                        {
                            choise=1;
                        }
                        if (deleteControl!=1 && deleteControl!=2)
                        {
                            Console.WriteLine("Please enter a valid choise");
                            deleteControl=0;
                        }
                    } while (deleteControl==0);
                }

            } while (choise==2);
        }

        public void MoveCard(Board newboard)
        {
            int moveControl=1;
            do
            {   
                Console.WriteLine("Enter title of the card you want to move:");
                string moveTitle = Console.ReadLine();
                
                int found =0;
                Card moveCard=new Card();
                
                int line=1, lineFlag=1;
                foreach (var item in newboard.todo)
                {
                    if (item.Title.Equals(moveTitle))
                    {
                        found=1;
                        Console.WriteLine("Found card information:");
                        Console.WriteLine("Title: {0}",item.Title);
                        Console.WriteLine("Content: {0}",item.Content);
                        Console.WriteLine("Assigment Person: {0}",item.AssignedPerson);
                        Console.WriteLine("Size: {0}",item.CardSizeType);
                        Console.WriteLine("Line: {0}",item.Line);

                        do
                        {
                            lineFlag=1;
                            Console.WriteLine("(1) TODO\n(2) IN PROGRESS\n (3)DONE");
                            int moveLine= int.Parse(Console.ReadLine()); 
                            if (moveLine==1)
                            {
                                Console.WriteLine("The card is already in TODO line");
                                lineFlag=0;
                            }
                            else if (moveLine!=2 && moveLine!=3)
                            {
                                Console.WriteLine("Enter a valid line");
                                lineFlag=0;
                            }
                        } while (lineFlag==0);
                    }
                }
                
                foreach (var item in newboard.inprogress)
                {
                    if (item.Title.Equals(moveTitle))
                    {
                        found=2;
                        Console.WriteLine("Found card information:");
                        Console.WriteLine("Title: {0}",item.Title);
                        Console.WriteLine("Content: {0}",item.Content);
                        Console.WriteLine("Assigment Person: {0}",item.AssignedPerson);
                        Console.WriteLine("Size: {0}",item.CardSizeType);
                        Console.WriteLine("Line: {0}",item.Line);

                        do
                        {
                            lineFlag=1;
                            Console.WriteLine("(1) TODO\n(2) IN PROGRESS\n (3)DONE");
                            int moveLine= int.Parse(Console.ReadLine()); 
                            if (moveLine==2)
                            {
                                Console.WriteLine("The card is already in IN PROGRESS line");
                                lineFlag=0;
                            }
                            else if (moveLine!=1 && moveLine!=3)
                            {
                                Console.WriteLine("Enter a valid line");
                                lineFlag=0;
                            }
                        } while (lineFlag==0);
                    }
                }
                foreach (var item in newboard.done)
                {
                    if (item.Title.Equals(moveTitle))
                    {
                        found=3;
                        Console.WriteLine("Found card information:");
                        Console.WriteLine("Title: {0}",item.Title);
                        Console.WriteLine("Content: {0}",item.Content);
                        Console.WriteLine("Assigment Person: {0}",item.AssignedPerson);
                        Console.WriteLine("Size: {0}",item.CardSizeType);
                        Console.WriteLine("Line: {0}",item.Line);

                        do
                        {
                            lineFlag=1;
                            Console.WriteLine("(1) TODO\n(2) IN PROGRESS\n (3)DONE");
                            int moveLine= int.Parse(Console.ReadLine()); 
                            if (moveLine==3)
                            {
                                Console.WriteLine("The card is already in DONE line");
                                lineFlag=0;
                            }
                            else if (moveLine!=1 && moveLine!=2)
                            {
                                Console.WriteLine("Enter a valid line");
                                lineFlag=0;
                            }
                        } while (lineFlag==0);
                    }
                }
                
                if (found==1)
                {
                    newboard.todo.Remove(moveCard);
                }
                    if (line==2)
                    {
                        newboard.inprogress.Add(moveCard);
                    }
                    else if (line==3)
                    {
                        newboard.done.Add(moveCard);
                    }
                else if (found==2)
                {
                    newboard.inprogress.Remove(moveCard);
                }
                    if (line==1)
                    {
                        newboard.todo.Add(moveCard);
                    }
                    else if (line==3)
                    {
                        newboard.done.Add(moveCard);
                    }
                else if (found==3)
                {
                    newboard.done.Remove(moveCard);
                }
                    if (line==1)
                    {   
                        newboard.todo.Add(moveCard);
                    }
                    else if (line==2)
                    {
                        newboard.inprogress.Add(moveCard);
                    }

                int choiceFlag=1,choice;
                if (found==0)
                {
                    do
                    {
                        Console.WriteLine("The card matching the criteria you are looking for was not found on the board. Please make a selection");
                        Console.WriteLine("* To end the moving : (1)\n* To try again : (2)");
                        choice =int.Parse(Console.ReadLine());
                        if (choice==1)
                        {
                            choiceFlag=0;
                            moveControl=0;
                        }
                        else if(choice==2)
                        {
                            choiceFlag=0;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid choice!");
                            choiceFlag=1;
                        }
                    } while (choiceFlag==1);
                }
                else
                {
                    if (line==1)
                    {
                        Console.WriteLine("Your card has been moved to Todo line successfully!");
                    }
                    else if (line==2)
                    {
                        Console.WriteLine("Your card has been moved to in Progress line successfully!");
                    }
                    else if (line==3)
                    {
                        Console.WriteLine("Your card has been moved to in Done line successfully!");
                    }
                }
            } while (moveControl==1);
        }
        
    }
}
    