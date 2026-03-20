using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._2_DatabaseFirst.Models
{
    public partial class Student
    {
        public string FullName => $"{FirstName} {LastName}";
    }
}
