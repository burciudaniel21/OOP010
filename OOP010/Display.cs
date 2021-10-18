using System;
using System.Collections.Generic;
using System.Text;

namespace OOP010
{
    class Display
    {
        private string studentName = "";
        private double grade = 0;
        private double assignment = 0;
        private double weight = 0;

        private Student student = new Student("John");

        private bool inMenu = true;
        public void InMenu()
        {
            student.AddGrade(new WeightedGrade("OOP", 70, 1, 0.3));
            student.AddGrade(new WeightedGrade("OOP", 60, 2, 0.7));
            student.AddGrade(new WeightedGrade("IIE", 50, 1, 0.7));
            student.AddGrade(new WeightedGrade("IIE", 70, 2, 0.3)); //add grades for the pre-set student

            while (inMenu)
            {
                Console.WriteLine("Select option:\n");
                Console.WriteLine("Press 1 to display pre-set student grades and average.");

                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                if (keyPressed.Key == ConsoleKey.Escape)
                {
                    inMenu = false;
                }

                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1:

                        PrintStudent(student);
                        break;
                }
            }
        }

        public void PrintStudent(Student s)
        {
            Console.Write($"Student grades are: \n");
            foreach (Grade grade in student.GetGrades())
            {
                Console.WriteLine($" Module: {grade.getModule}, assignment: {grade.getAssignment}, grade: {grade.getGrade()}");

            }
        }
    }
}
