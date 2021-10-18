using System;
using System.Collections.Generic;
using System.Text;

namespace OOP010
{
    public class WeightedGrade:Grade
    {
        private double weight;

        public WeightedGrade(string module, double studentGrade, int moduleAssignment, double assignmentWeight) : base(module, studentGrade, moduleAssignment)
        {
            this.weight = assignmentWeight;
        }
        public override double getGrade()
        {
            return grade*weight; //calculates % of the grade
        }


    }
}
