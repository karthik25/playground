/*
 *
 * */
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestConsoleApp
{
    public class FunWithGenerics1
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Ex 1: With duplicates added by using the same instance twice");
            var e1 = new Employee { EmployeeId = "1", EmployeeName = "test 1" };
            var e2 = new Employee { EmployeeId = "2", EmployeeName = "test 2" };
            var list5 = new List<Employee> { e1, e2, e1 };
            list5.ForEach(l => Console.WriteLine(l.EmployeeId + " : " + l.EmployeeName));
            Console.WriteLine("------------");

            Console.WriteLine("Ex 1: With duplicates added by using the same instance twice, using default comparer");
            list5.Distinct().ToList().ForEach(l => Console.WriteLine(l.EmployeeId + " : " + l.EmployeeName));
            Console.WriteLine("------------");

            Console.WriteLine("Ex 1: With duplicates identified by a property, with type specific comparer");
            var list = GetEmployees();
            var list2 = list.Distinct(new EmployeeEqualityComparer()).ToList();
            list2.ForEach(l => Console.WriteLine(l.EmployeeId + " : " + l.EmployeeName));

            Console.WriteLine("-----------");

            Console.WriteLine("Ex 1: With duplicates identified by a property, with type generic comparer");
            var list3 = GetEmployees();
            var list4 = list3.Distinct(new GenericEqualityComparer<Employee>()).ToList();
            list4.ForEach(l => Console.WriteLine(l.EmployeeId + " : " + l.EmployeeName));

        }

        private static IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>
                       {
                           new Employee{ EmployeeId = "1", EmployeeName = "name 1"},
                           new Employee{EmployeeId = "2", EmployeeName = "name 2"},
                           new Employee{ EmployeeId = "1", EmployeeName = "name 1"}
                       };
        }
    }

    public class EmployeeEqualityComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.EmployeeId == y.EmployeeId;
        }

        public int GetHashCode(Employee obj)
        {
            return obj.EmployeeId.GetHashCode();
        }
    }

    public interface IComparable
    {
        string PrimaryId { get; set; }
    }

    public class GenericEqualityComparer<T> : IEqualityComparer<T>
        where T : IComparable
    {
        public bool Equals(T x, T y)
        {
            return x.PrimaryId == y.PrimaryId;
        }

        public int GetHashCode(T obj)
        {
            return obj.PrimaryId.GetHashCode();
        }
    }

    public class Employee : IComparable
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        // Or you could just remove EmployeeId and just have PrimaryId !
        public string PrimaryId
        {
            get { return EmployeeId; }
            set { EmployeeId = value; }
        }
    }
}
