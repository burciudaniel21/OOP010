using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OOP010
{
    class GradeProfile
    {
        private List<Grade> grades = new List<Grade>(); //creates a list of grades from the Grade class

        public void AddGrade(Grade grade)
        {
            grades.Add(grade); //adds a grade to the list
        }

        public void CleanGrades()
        {
            grades.Clear(); //clears the list
        }

        public List<Grade> GetGrades( )
        {
            return grades;
        }

        public double GetAverage()
        {
            Dictionary<string, double> moduleGrades = new Dictionary<string, double>(); 
            foreach (Grade grade in grades)
            {
                if (!moduleGrades.ContainsKey(grade.getModule)) //verifies if the Key exists
                {
                    moduleGrades[grade.getModule] = grade.GetGrade(); //gets grades for the specified module
                }
                else
                {
                    moduleGrades[grade.getModule] += grade.GetGrade(); //if a grade already exists, adds the value to the grade
                }

            }

            double sum = 0;

            foreach (var item in moduleGrades) //calculates sum of all grades
            {
                sum += item.Value;
            }

            if (moduleGrades.Count != 0) //if there are more than 0 elements, divide the total sum to the number of elements to get the average
            {
                return sum / moduleGrades.Count;
            }
            else
            {
                return 0;
            }
        }

        public void RemoveGrade(string module, int assignment)
        {
            Grade toRemove = null; // initialize empty reference
            foreach (Grade grade in grades)
            {
                if (grade.getModule == module && grade.getAssignment == assignment)
                {
                    toRemove = grade;
                    break;
                }
            }

            if (toRemove != null) //if the element is found, remove
            {
                grades.Remove(toRemove);
            }
        }

    }
}
