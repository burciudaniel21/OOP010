using System;
using System.Collections.Generic;
using System.Text;

namespace OOP010
{
    public class WeightedGrade:Grade //creates the WeightedGrade class inherited from Grade
    {
        private double weight;

        public WeightedGrade(string module, double studentGrade, int moduleAssignment, double assignmentWeight) : base(module, studentGrade, moduleAssignment)
        {
            this.weight = assignmentWeight;
        }

        public override double GetInitialGrade()
        {
            return grade;
        }
        public override double GetGrade() //overrides the getGrade function inherited from Grade
        {
            return grade*weight; //calculates % of the grade
        }


    }
}
