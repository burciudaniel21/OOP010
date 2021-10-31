using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OOP010
{
    class Class
    {
        private int studentNumber = 0;
        private string studentName = "";
        private double grade = 0;
        private int assignment = 0;
        private double weight = 0;
        private string moduleName;
        private int numberOfGrades;
        private double checkWeight;
        private double weightPercentage;

        private Student student = new Student("John");
        private Student student1 = new Student("");
        public List<Student> students = new List<Student>();


        private bool inMenu = true;
        public void InMenu()
        {
            student.AddGrade(new WeightedGrade("OOP", 70, 1, 0.3));
            student.AddGrade(new WeightedGrade("OOP", 60, 2, 0.3));
            student.AddGrade(new WeightedGrade("OOP", 50, 3, 0.4));

            {

            }
            while (inMenu)
            {
                Console.WriteLine("Select option:\n");
                Console.WriteLine("Press 1 to display pre-set student grades and average.");
                Console.WriteLine("Press 2 to add a new student."); 
                Console.WriteLine("Press 3 to display a student.");
                Console.WriteLine("Press 4 to remove a student.");
                Console.WriteLine("Press 5 to remove a student's grades.");
                Console.WriteLine("Press 6 to add grades to a registered student.\n");

                Console.WriteLine("Press 9 to display all the students and their list number.");
                Console.Write($"Press "); RedText("ESC", false); Console.WriteLine(" to exit.");

                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                if (keyPressed.Key == ConsoleKey.Escape)
                {
                    inMenu = false;
                }

                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1:

                        PrintDefaultStudent();

                        break;
                    case ConsoleKey.D2:
                        CreateStudent();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        if(CountStudents() == 1)
                        {
                            PrintStudent(students[0]);
                            break;
                        }

                        else if(CountStudents() == 0)
                        {
                            break;
                        }
                        Console.WriteLine($"You currently have {CountStudents()} students in your list. Select a number between 1 and {CountStudents()}");
                        Console.WriteLine("Input student number.");
                        Int32.TryParse(Console.ReadLine(), out studentNumber);
                        
                        if(studentNumber <= CountStudents()) 
                        {
                            studentNumber -= 1;
                            PrintStudent(students[studentNumber]);
                        }

                        break;
                    case ConsoleKey.D9:
                        Console.Clear();
                        DisplayStudentsList();
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("Input student number to remove.");
                        Int32.TryParse(Console.ReadLine(), out studentNumber);
                        if (studentNumber > 0 && studentNumber <= CountStudents())
                        {
                            studentNumber -= 1;
                            RemoveStudent(students[studentNumber]);
                        }
                        else
                        {
                            RedText("Invalid selection.", true);
                        }
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.WriteLine("Input student number to remove grades.");
                        Int32.TryParse(Console.ReadLine(), out studentNumber);
                        if (studentNumber > 0 && studentNumber <= CountStudents())
                        {
                            studentNumber -= 1;
                            students[studentNumber].CleanGrades();
                        }
                        else
                        {
                           RedText("Invalid selection.", true);
                        } 
                        break;
                    case ConsoleKey.D6:
                        Console.Clear();
                        Console.WriteLine("Input student number to add grades.");
                        Int32.TryParse(Console.ReadLine(), out studentNumber);
                        
                        if (studentNumber <= CountStudents() && studentNumber > 0)
                        {
                            studentNumber -= 1;
                            students[studentNumber].CleanGrades();
                            Console.WriteLine("Input module name:");
                            moduleName = Console.ReadLine();
                            Console.WriteLine("How many assignments would you like to input?:");
                            Int32.TryParse(Console.ReadLine(), out numberOfGrades);
                            assignment = 1;
                            int initialNumberOfGrades = numberOfGrades;
                            while (numberOfGrades > 0)
                            {

                                Console.WriteLine($"Input module grade for assigmnet {assignment}:");
                                Double.TryParse(Console.ReadLine(), out grade);
                                weightPercentage = (1 - checkWeight) * 100;

                                if (initialNumberOfGrades > 1)
                                {
                                    Console.Write($"What is the weight percentage of this assignment? You can add "); RedText(Math.Round(weightPercentage).ToString(), false); Console.Write("% grade weight divideded between "); RedText(numberOfGrades.ToString(), false);
                                    if (numberOfGrades > 1)
                                    {
                                        Console.WriteLine(" assignments.");
                                    }
                                    else if (numberOfGrades == 1)
                                    {
                                        Console.WriteLine(" assignment.");

                                    }

                                    Double.TryParse(Console.ReadLine(), out weight);
                                }
                                if (initialNumberOfGrades == 1)
                                {
                                    weight = 100;
                                }
                                weight /= 100;
                                checkWeight += weight;
                                students[studentNumber].AddGrade(new WeightedGrade(moduleName, grade, assignment, weight));
                                if (checkWeight > 1)
                                {
                                    RedText($"Total weight for the assingment should be 100. The grade for this student can't be calculated corectly with the current input. \n Please try again.", true);
                                    Thread.Sleep(2500);
                                    students[studentNumber].CleanGrades();
                                    numberOfGrades = 1;
                                }
                                numberOfGrades--;
                                assignment++;
                                Console.Clear();
                            }
                            checkWeight = 0;
                        }
                        else
                        {

                            RedText("Invalid selection.", true);
                        }
                        break;
                }
            }
        }

        public void PrintStudent(Student student)
        {
            Console.Clear();
            int i = 0;
            while (i < Console.WindowWidth)
            {
                Console.Write("-");
                i++;
                if (i == Console.WindowWidth)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"Student: {student.Name}");
            Console.Write($"Student grades are: \n");
            foreach (Grade grade in student.GetGrades()) //returns the grade linked to the student object
            {

                Console.WriteLine($" Module: {grade.getModule}, assignment: {grade.getAssignment}, grade: {grade.GetInitialGrade()}");

            }

            Console.WriteLine($"Average grade for {student.Name} is {student.GetAverage()}.");

            i = 0;
            while (i < Console.WindowWidth)
            {
                Console.Write("-");
                i++;
                if (i == Console.WindowWidth)
                {
                    Console.WriteLine();
                }
            }
        }


        public int CountStudents()
        {
            return students.Count;
        }
        public void AddStudent(Student Name)
        {
            students.Add(Name);
        }

        public void PrintDefaultStudent()
        {
            Console.Clear();
            int i = 0;
            while (i < Console.WindowWidth)
            {
                Console.Write("-");
                i++;
                if(i == Console.WindowWidth)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"Student: {student.Name}");
            Console.Write($"Student grades are: \n");
            foreach (Grade grade in student.GetGrades()) //returns the grade linked to the student object
            {
                
                Console.WriteLine($" Module: {grade.getModule}, assignment: {grade.getAssignment}, grade: {grade.GetInitialGrade()}");

            }
            Console.WriteLine($"Average grade for {student.Name} is {student.GetAverage()}.");
            i = 0;
            while (i < Console.WindowWidth)
            {
                Console.Write("-");
                i++;
                if (i == Console.WindowWidth)
                {
                    Console.WriteLine();
                }
            }
        }

        public void DisplayStudentsList()
        {
            int i = 0;
            foreach (Student student in students)
            {
                
                i++;
                Console.WriteLine($"{i} = {student.Name}\n");
                

            }
        }

        public string RedText(string text, bool newLine)
        {
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
            if(newLine == true)
            {
                Console.WriteLine();
            }
            if (newLine == false)
{

            }

                return text;

        }

        public void RemoveStudent(Student Name)
        {
            students.Remove(Name);
        }

        public void CreateStudent()
        {
            Console.Clear();
            studentNumber = CountStudents();
            Console.WriteLine("Input student name:");
            studentName = Console.ReadLine();
            Student newStudent = new Student(studentName);
            AddStudent(newStudent);
            Console.WriteLine("Input module name:");
            moduleName = Console.ReadLine();

            Console.WriteLine("How many assignments would you like to input?:");
            Int32.TryParse(Console.ReadLine(), out numberOfGrades);
            assignment = 1;
            int initialNumberOfGrades = numberOfGrades;
            while (numberOfGrades > 0)
            {

                Console.WriteLine($"Input module grade for assigmnet {assignment}:");
                Double.TryParse(Console.ReadLine(), out grade);
                weightPercentage = (1 - checkWeight) * 100;

                if(initialNumberOfGrades > 1)
                {
                    Console.Write($"What is the weight percentage of this assignment? You can add "); RedText(Math.Round(weightPercentage).ToString(), false); Console.Write("% grade weight divideded between "); RedText(numberOfGrades.ToString(), false);
                    if (numberOfGrades > 1)
                    {
                        Console.WriteLine(" assignments.");
                    }
                    else if (numberOfGrades == 1)
                    {
                        Console.WriteLine(" assignment.");

                    }

                    Double.TryParse(Console.ReadLine(), out weight);
                }
                if (initialNumberOfGrades == 1)
                {
                    weight = 100;
                }
                    weight /= 100;
                checkWeight += weight;
                students[studentNumber].AddGrade(new WeightedGrade(moduleName, grade, assignment, weight));
                if (checkWeight > 1)
                {
                    RedText($"Total weight for the assingment should be 100. The grade for this student can't be calculated corectly with the current input and the student will be deleted.\n Please try again.", true);
                    Thread.Sleep(2500);
                    RemoveStudent(newStudent);
                    numberOfGrades = 1;
                }
                numberOfGrades--;
                assignment++;
                Console.Clear();
            }
            checkWeight = 0;
        }
    }
}
