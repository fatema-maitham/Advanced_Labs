namespace Lab1._1_OOP
{
    public class Program
    {
        static void Main(string[] args)
        {
            Employee[] staff = new Employee[4];

            staff[0] = new Employee(1, "Ali", "Mohsen", 1000);
            staff[1] = new Employee(2, "Mohsen", "Mohammed", 1200);

            staff[2] = new Accountant(3, "Ruqaya", "Hussain", 1500, 200);
            staff[3] = new Manager(3, "Sayed", "Hassan", 1500, "IT");

            Console.WriteLine("Inital Salaries:");
            foreach (Employee emp in staff)
            {
                emp.DisplayInfo();
            }
            Console.WriteLine();
            Console.WriteLine("After 5% Increment:");

            foreach (Employee emp in staff)
            {
                emp.UpdateSalary(0.05);
                emp.DisplayInfo();
            }
            Console.ReadLine();
        }
    }
}