using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._1_OOP
{
    public class Accountant: Employee
    {
        private double bonus;

        public Accountant(int id, string firstName, string lastName, double salary, double bonus):base(id, firstName, lastName, salary)
        {
            this.bonus = bonus;
        }

        public override double Salary
        {
            get { return salary + bonus; }
        }

        public override void UpdateSalary(double incrementPercent)
        {
            base.UpdateSalary(incrementPercent);
            bonus += bonus * incrementPercent;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID}, Name: {FirstName} {LastName}, Bonus: {bonus}, Salary: {Salary:C}");
        }
    }
}
