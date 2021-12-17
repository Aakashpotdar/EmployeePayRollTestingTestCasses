using System;
using System.Data;

namespace EmployeeManagment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcom to Employee pay roll");
            EmployeeRepo employee = new EmployeeRepo();
            EmployeeModel data = new EmployeeModel();

            data.Address="solapur";
            data.BasicPay = 200;
            data.City = "solapur";
            data.Country = "india";
            data.Deductions = 64;
            data.Department = "HR";
            data.EmployeeID = 007;
            data.EmployeeName = "aakash";
            data.PhoneNumber = "826487287";
            data.Gender = 'M';
            data.TaxablePay = 383;
            data.Tax = 276;
            data.NetPay = 2974;
            data.StartDate = DateTime.Now;

            // employee.AddEmployee(data);
            employee.GetAllEmpoyee();

        }
    }
}
