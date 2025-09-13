using System;
namespace Assignment2_StudentMarksAnalyzer
{
    // StudentData is a class which contains marks of students and Some methods In order to calculate result  
    public class StudentData
    {
        int[] marks =new int[6];//It contains marks for each student of each subject 
       
        
        public int getPracticalMarks()//It is use to get practical marks played by the students
        {
            
            Console.WriteLine("----------GUESS THE NUMBER----------\n\n");
            int chance = 2;//number of chances
            Random random = new Random();//using Random() in order to get random numbers b/w 1-100
            int PracticalMarks = 0;//if student fails the practical then he/she will get zero
            int WinningNumber=random.Next(1,101);
            while (chance != 0) {//those 2 chances
                Console.WriteLine("The number was " + WinningNumber);
                Console.Write("Guess to Win (´◡`) :");
               
                var userInput=Console.ReadLine();//taking guess from user
                
                    int guessedNumber;
                if (int.TryParse(userInput, out guessedNumber))//checking is the input is Ineger or not
                {
                    

                        if (WinningNumber == guessedNumber)//if the guessed input is correct then he got marks accordingly
                        {
                            PracticalMarks = chance == 2 ? 100 : 50; chance = 0;
                        }
                        else
                        {

                            chance--;//else chance will be reduce
                            Console.WriteLine($"{chance} left");
                        }
                    
                   
                }
                else
                {
                    Console.WriteLine("You gived wrong input Try again");//if user trying to give string as input
                }       
            }
            return PracticalMarks;//return the marks
        }
       public void getMarks(string name, int[] maxMarks, string[] subject) {//this method() is use to initialize the marks of student and we take input from user 
            
            Console.WriteLine($"\n\n--------------Enter the Marks For {name}--------------");

            int Total = 0;//for Aggregate of marks
            for(int i = 0; i < subject.Length-2; i++)//this will itterate to get all subject marks
            {
                Console.Write($"\nEnter Marks of {subject[i]} :");
                var score= Console.ReadLine();//Taking marks from user
                int SubjectMarks;
                if (int.TryParse(score,out SubjectMarks)){//if the inuput is  integer then the marks will initialise for that subject
                     

                    maxMarks[i] = SubjectMarks > maxMarks[i] ? SubjectMarks : maxMarks[i];//as we have many students so we are checking what is the highest marks of any student


                   
                    if (SubjectMarks < 0 || SubjectMarks > 100)//if the marks are greater than 100 or less than 0 it will take input again from the user
                    {
                        Console.WriteLine("-----Invalid Marks-----\nEnter again ");
                        i--;//decreasing by 1 bkz to get that subject again

                    }
                    else
                    {
                        marks[i] = SubjectMarks;//geting that input from user
                        Total += SubjectMarks;//Aggregate for each subject
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input try Again");//string as input
                    i--;//decreasing by 1 bkz to get that subject again
                }
                
            }
            int PracticalMarks = getPracticalMarks();//to get the practical marks
            marks[4]= PracticalMarks;//storing practical marks
            maxMarks[4] = PracticalMarks> maxMarks[4]? PracticalMarks: maxMarks[4];//storing the highest practical marks
            Total= Total + PracticalMarks;//Aggregate of practical and total
            marks[5]= Total;//storing the highest Aggregate marks
            maxMarks[5]= Total > maxMarks[5] ? Total : maxMarks[5];//storing the highest Total marks


        }

        public void FindMaxMarksInSubject(int SubjectId,int NumberOfStrudent,StudentData[] student, int[] maxMarks,int toggel, string[] studentName, string[] subject)
            //This Method() is use for finding whom got maximum marks in each subject
        {
            string[] highestScorer=new string[5];
            int  k = -1;
            for (int i=0;i< NumberOfStrudent; i++)
            {
                if (maxMarks[SubjectId]== student[i].marks[SubjectId] && maxMarks[SubjectId]!=0)
                {
                    k++;
                    highestScorer[k] = studentName[i];
                    
                }
            }
            if  (k==-1) {
                Console.WriteLine($"All Failed the {subject[SubjectId]}");
            }
            if (toggel == 0)
            {
                foreach (string name in highestScorer)
                {
                    if (name == null) break;
                    Console.WriteLine($"In {subject[SubjectId]} , The Scorrer is {name}");
                }
            }
            else
            {
                if (SubjectId == 5)
                {
                    foreach (string name in highestScorer)
                    {
                        Console.WriteLine();
                        if (name == null) break;
                        Console.WriteLine($" {subject[SubjectId],-7} {name,7} {maxMarks[5],9}");
                    }
                }

            }
           

        }

        public void ShowStudentMarks()
        {
            foreach(var mar in marks)
                Console.Write($"{mar,10}");
        }

    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] maxMarks = new int[6];
            string[] subject = { "Hindi", "English", "Science", "Computer", "Practical", "Total" };
            string[]  studentName = { "Vikas", "Viney", "Kishan", "Jagriti", "Simran" };
            

            StudentData[] student = new StudentData[studentName.Length];

            for (int i = 0; i < studentName.Length; i++)
            {
                student[i] = new StudentData();
                
                student[i].getMarks(studentName[i], maxMarks,subject);
                
            }

            Console.Clear();
            Console.WriteLine("\n------------------Over All Topper------------------\n");
            Console.WriteLine($"StudentName      {subject[0],7}   {subject[1],-2}   {subject[2],7}  {subject[3],7}  {subject[4],7}  {subject[5],7}");

            for (int i = 0; i < studentName.Length; i++)
            {
                Console.Write($"{studentName[i],-6}");
                student[i].ShowStudentMarks();
                Console.WriteLine();
            }
            StudentData HighestMarks = new StudentData();

            Console.WriteLine("\n------------------Over All Topper------------------\n");

            HighestMarks.FindMaxMarksInSubject(5, studentName.Length, student, maxMarks, 1, studentName, subject);

            Console.WriteLine("\n------------------Subject-wise Toppers------------------\n");

            for (int i = 0; i < subject.Length; i++)
            {

                HighestMarks.FindMaxMarksInSubject(i, studentName.Length, student, maxMarks, 0, studentName, subject);

            }

            Console.ReadLine();
        }
    }
}
