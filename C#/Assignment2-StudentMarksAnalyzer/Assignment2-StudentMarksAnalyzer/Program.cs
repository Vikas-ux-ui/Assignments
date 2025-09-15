using System;
using System.Linq;

namespace Assignment2_StudentMarksAnalyzer
{
    public class StudentData
    {
        int PracticalPoint, Aggregate, Total;
        int[] marks= new int[4 + 2];

        public int getPracticalMarks(string name)
        {
            Console.WriteLine("\n----------GUESS THE NUMBER----------\n");
            Console.WriteLine($"Hey {name}, You Have 2 chances to guess a number between 1 and 100.");
            Console.WriteLine("First chance correct: 100 points, Second chance correct: 50 points. Else: 0 points.\n");

            int chance = 2;
            int PracticalMarks = 0;
            Random random = new Random();

            int WinningNumber = random.Next(1, 101);

            while (chance != 0)
            {
                Console.WriteLine("The number was: " + WinningNumber);
                Console.Write("Guess to Win: ");

                var userInput = Console.ReadLine();
                int guessedNumber;

                if (int.TryParse(userInput, out guessedNumber))
                {
                    if (WinningNumber == guessedNumber)
                    {
                        PracticalMarks = (chance == 2) ? 100 : 50;
                        Console.WriteLine($"Congratulations You got {PracticalMarks} points.");
                        break;
                    }
                    else
                    {
                        chance--;
                        Console.WriteLine($"{chance} chance left.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

            if (PracticalMarks == 0)
            {
                Console.WriteLine("You failed the practical.");
            }


            return PracticalMarks;
        }

        public void getMarks(string name, int[] maxMarks, string[] subject, int numberOfSubject)
        {
              // extra for practical and total
            int PracticalMarks = getPracticalMarks(name);

            Console.WriteLine($"\nEnter marks for {name}:");

            int Sum = 0;

            for (int i = 0; i < numberOfSubject; i++)
            {
                Console.Write($"\nEnter Marks of {subject[i]}: ");
                var score = Console.ReadLine();
                int SubjectMarks;

                if (int.TryParse(score, out SubjectMarks))
                {
                    if (SubjectMarks < 0 || SubjectMarks > 100)
                    {
                        Console.WriteLine("Invalid marks. Enter again.");
                        i--;
                        continue;
                    }

                    marks[i] = SubjectMarks;
                    Sum += SubjectMarks;
                    if (SubjectMarks > maxMarks[i])
                        maxMarks[i] = SubjectMarks;
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a number.");
                    i--;
                }
            }

            PracticalPoint = PracticalMarks;
            marks[numberOfSubject] = PracticalMarks; // store practical
            marks[numberOfSubject + 1] = Sum + PracticalMarks; // store total
            Aggregate = Sum;
            Total = Sum + PracticalMarks;

            if (PracticalMarks > maxMarks[numberOfSubject])
                maxMarks[numberOfSubject] = PracticalMarks;

            if (Total > maxMarks[numberOfSubject + 1])
                maxMarks[numberOfSubject + 1] = Total;
        }

        public void FindMaxMarksInSubject(int SubjectId, int NumberOfStudents, StudentData[] students, int[] maxMarks, int toggle, string[] studentNames, string[] subjects)
        {
            string[] highestScorer = new string[NumberOfStudents];
            int k = 0;

            for (int i = 0; i < NumberOfStudents; i++)
            {
                if (students[i].marks[SubjectId] == maxMarks[SubjectId])
                {
                    highestScorer[k++] = studentNames[i];
                }
            }

            if (toggle == 0)
            {
                for (int i = 0; i < k; i++)
                {
                    Console.WriteLine($"In {subjects[SubjectId]}, the top scorer is {highestScorer[i]} with {maxMarks[SubjectId]} marks.");
                }
            }
            else
            {
                Console.WriteLine($"\nOverall Topper with {maxMarks[SubjectId]} marks:");
                for (int i = 0; i < k; i++)
                {
                    Console.WriteLine($"{subjects[SubjectId],-10} {highestScorer[i],-10} {maxMarks[SubjectId],5}");
                }
            }
        }

        public void ShowStudentMarks()
        {
            foreach (var mark in marks)
            {
                Console.Write($"{mark,10}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] subject = { "English", "Hindi", "Maths", "Science", "Practical" };
            int numberOfSubjects = subject.Length - 1; // 4  subjects

            Console.Write("Enter the number of students: ");
            if (!int.TryParse(Console.ReadLine(), out int numberOfStudents))
            {
                Console.WriteLine("Invalid number of students.");
                return;
            }

            string[] studentNames = new string[numberOfStudents];
            StudentData[] students = new StudentData[numberOfStudents];
            int[] MaximumMarksInSubjects = new int[subject.Length+1];

            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.Write($"\nEnter name of student {i + 1}: ");
                studentNames[i] = Console.ReadLine();
            }

            for (int i = 0; i < numberOfStudents; i++)
            {
                students[i] = new StudentData();
                students[i].getMarks(studentNames[i], MaximumMarksInSubjects, subject, numberOfSubjects);
            }

            Console.Clear();
            Console.WriteLine("\n------------------ Results ------------------\n");

            Console.WriteLine($"{"StudentName",-15} {subject[0],10} {subject[1],10} {subject[2],10} {subject[3],10} {subject[4],10} {"Total",6}");

            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.Write($"{studentNames[i],-15}");
                students[i].ShowStudentMarks();
                Console.WriteLine();
            }

            StudentData High = new StudentData();

            Console.WriteLine("\n------------------ Overall Topper ------------------");
            High.FindMaxMarksInSubject(5, numberOfStudents, students, MaximumMarksInSubjects, 1, studentNames, subject);

            Console.WriteLine("\n------------------ Subject-wise Toppers ------------------");
            for (int i = 0; i < subject.Length - 2; i++)
            {
                High.FindMaxMarksInSubject(i, numberOfStudents, students, MaximumMarksInSubjects, 0, studentNames, subject);
            }

            Console.ReadLine();
        }
    }
}