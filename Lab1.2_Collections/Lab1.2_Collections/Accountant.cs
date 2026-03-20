using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._2_Collections
{
    public class Accountant: Employee
    {
        // Accountant attributes 
        private double bonus;

        // Custom constructor - calls base class constructor 
        public Accountant(int id, string firstName, string lastName, double salary, double bonus)
            : base(id, firstName, lastName, salary)
        {
            this.bonus = bonus;
        }

        // Override the Salary property to include bonus 
        public override double Salary
        {
            get { return salary + bonus; }
        }

        // Override UpdateSalary to also update the bonus 
        public override void UpdateSalary(double incrementPercent)
        {
            base.UpdateSalary(incrementPercent);  // Update base salary 
            bonus += bonus * incrementPercent;    // Update bonus 
        }
    }
}
