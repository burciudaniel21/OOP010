using System;
using System.Collections.Generic;
using System.Text;

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

        private Student student = new Student("John");
        private Student student1 = new Student("");
        public List<Student> students = new List<Student>();



        private bool inMenu = true;
        public void InMenu()
        {
            student.AddGrade(new WeightedGrade("OOP", 70, 1, 0.3));
            student.AddGrade(new WeightedGrade("OOP", 60, 2, 0.7));
            student.AddGrade(new WeightedGrade("IWD", 50, 1, 0.7));
            student.AddGrade(new WeightedGrade("IWD", 70, 2, 0.3)); //add grades for the pre-set student*/

            while (inMenu)
            {
                Console.WriteLine("Select option:\n");
                Console.WriteLine("Press 1 to display pre-set student grades and average.");
                Console.WriteLine("Press 2 to add a new student."); 
                Console.WriteLine("Press 3 to display a student.");
                Console.WriteLine("Press 4 to display all the students and their list number.\n");
                Console.Write($"Press "); RedText("ESC", false); Console.WriteLine(" to exit.");
                //Console.WriteLine($"Press {RedText("ESC", false)} to exit.");

                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                if (keyPressed.Key == ConsoleKey.Escape)
                {
                    inMenu = false;
                }

                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1:

                        PrintDefaultStudent();
                        Console.Beep();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        studentNumber = CountStudents();
                        Console.WriteLine("Input student name:");
                        studentName = Console.ReadLine();
                        Student newStudent = new Student(studentName);
                        AddStudent(newStudent);
                       
                        Console.WriteLine("How many grades would you like to input?:");
                        Int32.TryParse(Console.ReadLine(), out numberOfGrades);
                        while (numberOfGrades > 0)
                        {
                            Console.WriteLine("Input module name:");
                            moduleName = Console.ReadLine();
                            Console.WriteLine("Input module grade:");
                            Double.TryParse(Console.ReadLine(), out grade);
                            Console.WriteLine("Which assignment is this grade for?");
                            Int32.TryParse(Console.ReadLine(), out assignment);
                            Console.WriteLine("What is the weight percentage of this assignment?");
                            Double.TryParse(Console.ReadLine(), out weight);
                            weight /= 100;
                            students[studentNumber].AddGrade(new WeightedGrade(moduleName, grade, assignment, weight));
                            numberOfGrades--;
                        }


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
                        Console.WriteLine("Which student?");
                        Console.WriteLine($"You currently have {CountStudents()} students in your list. Select a number between 1 and {CountStudents()}");
                        Int32.TryParse(Console.ReadLine(), out studentNumber);
                        
                        if(studentNumber <= CountStudents()) 
                        {
                            studentNumber -= 1;
                            //students[studentNumber].GetGrades();
                            PrintStudent(students[studentNumber]);
                        }

                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        DisplayStudentsList();
                        break;
                }
            }
        }

        public void PrintStudent(Student s)
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
            Console.WriteLine($"Student: {s.Name}");
            Console.Write($"Student grades are: \n");
            foreach (Grade grade in s.GetGrades()) //returns the grade linked to the student object
            {

                Console.WriteLine($" Module: {grade.getModule}, assignment: {grade.getAssignment}, grade: {grade.getGrade()}");

            }
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
        /*{
            Console.WriteLine($"{s.Name}");
            Console.Write($"Student grades are: \n");
            foreach (Grade grade in s.GetGrades()) //returns the grade linked to the student object
            {
                Console.WriteLine($" Module: {grade.getModule}, assignment: {grade.getAssignment}, grade: {grade.getGrade()}");

            }
        }*/

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
                
                Console.WriteLine($" Module: {grade.getModule}, assignment: {grade.getAssignment}, grade: {grade.getGrade()}");

            }
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
    }
}
