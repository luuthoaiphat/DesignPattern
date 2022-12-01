using System;
using System.Collections.Generic;
using System.Linq;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            // 親会社の作成
            var rootCompany = new Company("図研株式会社");

            // 子会社の作成
            var subCompany1 = new Company("図研アルファテック株式会社");
            var subCompany2 = new Company("図研テック株式会社");

            // 親会社に子会社を登録
            rootCompany.Add(subCompany1);
            rootCompany.Add(subCompany2);

            // 親会社の部署を作成
            rootCompany.Add(new Department("開発部", 150));
            rootCompany.Add(new Department("営業部", 100));
            // 子会社の部署を作成
            subCompany1.Add(new Department("開発部", 15));
            subCompany1.Add(new Department("営業部", 20));            
            subCompany2.Add(new Department("開発部", 80));
            subCompany2.Add(new Department("営業部", 100));

            // グループ全体の員数を取得
            rootCompany.PrintNumberOfStaff();
            subCompany1.PrintNumberOfStaff();
            subCompany2.PrintNumberOfStaff();
        }
    }

    public abstract class Object
    {
        public abstract string Name { get;}
        public abstract int NumberOfStaff { get; }

        public void PrintNumberOfStaff() => Console.WriteLine($"{Name}の員数 = {NumberOfStaff}名");
    }

    public class Company : Object
    {
        //会社名
        public override string Name { get; }
        //会社の員数
        public override int NumberOfStaff => Objs.Select(obj => obj.NumberOfStaff).Sum();

        // 子会社または部署を保存
        List<Object> Objs = new List<Object>();

        public Company(string name)
        {
            Name = name;
        }

        // 子会社または部署を追加
        public void Add(Object obj)
        {
            Objs.Add(obj);
        }
    }

    public class Department : Object
    {
        //部署名
        public override string Name { get; }
        //部署の員数
        public override int NumberOfStaff { get;}
        public Department(string name, int numberOfStaff)
        {
            Name = name;
            NumberOfStaff = numberOfStaff;
        }
    }
}
