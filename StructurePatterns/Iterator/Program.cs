using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace Iterator
{
    public interface Aggregate
    {
        public abstract Iterator iterator();
    }

    public interface Iterator
    {
        //次の要素を持つかどうかを確認するために使用する。
        public abstract bool hasNext();
        //次の要素があった際に次の要素を取得するために使用する。
        public abstract object next();
    }


    public class Employee
    {
        string name;
        int numberCode;

        public Employee(string name, int numberCode)
        {
            this.name = name;
            this.numberCode = numberCode;
        }

        public string GetName() => name;
        public int GetNumberCode() => numberCode;
    }

    /// <summary> ConcreateAggregate </summary>

    public class EmployeeList : Aggregate
    {
        protected List<Employee> Employees;
        public EmployeeList() 
        {
            this.Employees = new List<Employee>();
        }

        public void Add(Employee employee)
        {
            Employees.Add(employee);
        }

        public int GetLength() => Employees.Count;

        public Employee GetAt(int index) => Employees[index];

        public Iterator iterator() => new EmployeeListIterator(this);

    }

    /// <summary> ConcreateIterator </summary>
    public class EmployeeListIterator : Iterator
    {
        EmployeeList Employees;
        int index;
        public EmployeeListIterator(EmployeeList employees)
        {
            this.Employees = employees;
            this.index = 0;
        }

        public bool hasNext()
        {
            return index < Employees.GetLength();
        }

        public object next()
        {
            var employee = Employees.GetAt(index);
            index++;
            return employee;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var employees = new EmployeeList();
            employees.Add(new Employee("phat", 1));
            employees.Add(new Employee("tan", 2));
            employees.Add(new Employee("maeda", 3));
            employees.Add(new Employee("yamato", 4));
            var it = employees.iterator();
            while (it.hasNext())
            {
                var em = (Employee)it.next();
                Console.WriteLine(em.GetName() + "/" + em.GetNumberCode());
            }
        }
    }
}
