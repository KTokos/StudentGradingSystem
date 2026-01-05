// Basic Console Based Student Grading System

using System;
using System.Collections.Generic;

class Program
{
    // Class to represent a Student
    class Student
    {
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string FullName { get; set;}
        public double NumberGrade {get; set;}
        public char LetterGrade {get; set;}

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = FirstName + " " + LastName;

            // 0 by default until updated
            NumberGrade = 0;

            // F by default until updated
            LetterGrade = 'F';

            /*
            // Determines letter grade
            switch (NumberGrade)
            {
                case >= 90:
                    LetterGrade = 'A';
                    break;
                case >= 80:
                    LetterGrade = 'B';
                    break;
                case >= 70:
                    LetterGrade = 'C';
                    break;
                case >= 60:
                    LetterGrade = 'D';
                    break;
                default:
                    LetterGrade = 'F';
                    break;
            }
            */
        }
    }

    // A list to store the students as the student class
    static List<Student> students = new List<Student>();

    static void Main(string[] args)
    {
        // LCV
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Student Grading System ---");
            Console.WriteLine("1. View Students");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Assign Grade");
            Console.WriteLine("4. Remove Students");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Select an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    ViewStudents();
                    break;
                case "2":
                    AddStudent();
                    break;
                case "3":
                    AssignGrade();
                    break;
                case "4":
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void ViewStudents()
    {
        Console.WriteLine("\nStudents:");

        if (students.Count == 0)
        {
            Console.WriteLine("No students in class.");
        }
        else
        {
            for (int i = 0; i < students.Count; i++)
            {
                // Display student name along with grade, starting at 1
                Console.WriteLine($"{i+1}. {students[i].FullName} : {students[i].NumberGrade} = {students[i].LetterGrade}");
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("\nEnter student's first name: ");
        string firstName = Console.ReadLine() ?? "";

        Console.Write("Enter student's last name: ");
        string lastName = Console.ReadLine() ?? "";

        students.Add(new Student(firstName, lastName));

        Console.Write("Student added, grade by default is F");
    }

    static void AssignGrade()
    {
        // Instantiate random number generator using system-supplied value as seed
        var rand = new Random();

        double grade = 0.0;

        Console.WriteLine("\nWould you like to:");
        Console.WriteLine("1. Enter grade manually");
        Console.WriteLine("2. Randomly generate grade");
        Console.Write("Enter choice: ");

        string choice = Console.ReadLine() ?? "";

        switch (choice)
        {
            case "1":
                Console.Write("\nEnter grade (decimal format): ");
                
                string input = Console.ReadLine() ?? "";

                // If-else trys to turn input into a double
                if (Double.TryParse(input, out grade))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again");
                }

                break;
            case "2":
                // Generates random floating point value between 0 and 100
                grade = rand.NextDouble() * 100;

                // Round to 2 decimal places
                grade = Math.Round(grade, 2);

                break;
            default:
                Console.WriteLine("Invalid choice. Try again");
                break;
        }

        Console.Write("\nWhich student is this grade being assigned to (list number): ");
        choice = Console.ReadLine() ?? "";
        
        if (int.TryParse(choice, out int index))
        {
            if (index <= students.Count && index > 0)
            {
                students[index-1].NumberGrade = grade;
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Try again");
        }
    }   
}