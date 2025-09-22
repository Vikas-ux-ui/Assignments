namespace Assignment06Inheritance
{
    internal class Program
    {
        


        static void Main(string[] args)
        {
            List<Mentor> Mentorlist = new List<Mentor>() {
             new Mentor(1,"Ayush",25,"sql",21,50000,"SystemDesign","Indian"),
             new Mentor(2,"Abhishek",25,"C#",22,50000,"backend","Indian"),
             new Mentor(3,"Ishika",25,"sql",23,50000,"Fullstack","Indian"),
            };
          void UniversalFunction(string choice)
            {
                Console.Write("Enter the adhar id");
                if (int.TryParse(Console.ReadLine(), out int adharId))
                {
                    
                    Mentor dummy = GetAdharId(adharId);
                    if (dummy != null)
                    {
                        switch (choice)
                        {
                            case "1":
                                dummy.BasicInfo();
                                break;
                            case "2":
                                dummy.MentorDetail();
                                break;
                            case "3":
                                dummy.ShowEmployeeDetail();
                                break;
                            
                        }
                    }
                    else
                    {
                        return;
                    }

                }
            }

            while (true)
            {
                Console.WriteLine("\nEnter 1 to see bacic Information");
                Console.WriteLine("Enter 2 to see As mentor Information ");
                Console.WriteLine("Enter 3 to see As Employee Information \n");
                Console.Write("Enter your choice ");
                string choice=Console.ReadLine();
                switch (choice)
                {
                    case"1":
                       
                    case "2":
                        
                    case "3":
                        UniversalFunction(choice);
                         break;
                     case "4":
                        Console.WriteLine("Exit");
                        return;
                      default:
                        Console.WriteLine("Invalid input");
                        break;
                }
               

            }


             Mentor GetAdharId(int adharId)
            {
                foreach(var mentor in Mentorlist)
                {
                    if(mentor.AdharId == adharId)
                    {
                        return mentor;
                    }
                }
                Console.WriteLine("Adhar not found");
                return null;
             }
        }
    }
}
