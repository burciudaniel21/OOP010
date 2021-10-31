using System;
using System.Collections.Generic;
using System.Text;

namespace OOP010
{
    public class Grade
    {
        protected int assignment; //protected variable which can only be accessed by code in the same class or a class derived from it
        protected double grade;
        protected string moduleName;

        public Grade(string module, double studentGrade, int moduleAssignment) //constructor for Grade
        {
            this.assignment = moduleAssignment;
            this.grade = studentGrade;
            this.moduleName = module;
        }
        public virtual double GetInitialGrade()
        {
            return grade;
        }
        public int getAssignment
        {
            get { return this.assignment; }
        }

        public string getModule
        {
            get { return this.moduleName; }
        }

        public virtual double GetGrade()
        {
            return grade;
        }


    }
}
