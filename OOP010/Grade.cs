using System;
using System.Collections.Generic;
using System.Text;

namespace OOP010
{
    public class Grade
    {
        protected int assignment;
        protected double grade;
        protected string moduleName;

        public Grade(string module, double studentGrade, int moduleAssignment)
        {
            this.assignment = moduleAssignment;
            this.grade = studentGrade;
            this.moduleName = module;
        }

        public int getAssignment
        {
            get { return this.assignment; }
        }

        public string getModule
        {
            get { return this.moduleName; }
        }

        public virtual double getGrade()
        {
            return grade;
        }
    }
}
