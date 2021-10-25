using System;
using System.Collections.Generic;
using System.Text;

namespace OOP010
{
    class Student
    {
        private string name, address;
        private int age;
        private GradeProfile gradeProfile = new GradeProfile();
        public Student(string studentName) //constructor of Student
        {
            name = studentName;
        }

        public string SetName()
        {
            Console.WriteLine("Input student name:");
            name = Console.ReadLine();
            return name;
        }



        public List<Grade> GetGrades() //reutrns the grades from the Grade list
        {
            return gradeProfile.GetGrades();
        }

        public void AddGrade(Grade grade)
        {
            gradeProfile.AddGrade(grade); //adds an element to the list from GradeProfile.
        }

        public void RemoveGrade(string module, int assignment)
        {
            gradeProfile.RemoveGrade(module, assignment);  //removes an element from the list from GradeProfile.
        }

        public void CleanGrades()
        {
            gradeProfile.CleanGrades(); //clears all elements from the list from GradeProfile.
        }

        public double GetAverage()
        {
            return gradeProfile.GetAverage(); //calculates the average of the grades from GradeProfile.
        }

        

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Address
        {
            get { return this.address; }
            set { this.address = value;}
        }

        /*public void PrintStudent(Student student)
        {

            int studentNr;
            Console.WriteLine("Input student number:");
            Int32.TryParse(Console.ReadLine(), out studentNr);
            if (studentNr <= CountStudents())
            {
                Console.Write($"Student grades are: \n");
                foreach (Grade grade in students[studentNr].GetGrades()) //returns the grade linked to the student object
                {
                    Console.WriteLine($" Module: {grade.getModule}, assignment: {grade.getAssignment}, grade: {grade.getGrade()}");

                }
            }
            
        }*/



    }
}
