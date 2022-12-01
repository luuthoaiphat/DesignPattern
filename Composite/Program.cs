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

            // グループ全体の員数を出力
            rootCompany.PrintNumberOfStaff();
            subCompany1.PrintNumberOfStaff();
            subCompany2.PrintNumberOfStaff();
        }
    }

    /// <summary>Groupの拡張メソッド</summary>
    public static class GroupExt
    {
        //員数を出力
        public static void PrintNumberOfStaff(this Group grp) 
            => Console.WriteLine($"{grp.GetName()}の員数 = {grp.GetNumberOfStaff()}名");
    }

    /// <summary>Component クラス</summary>
    public abstract class Group
    {
        public abstract int GetNumberOfStaff();
        public abstract string GetName();
    }

    /// <summary>Composite クラス</summary>
    public class Company : Group
    {
        //会社名
        string Name;

        //会社の員数
        int NumberOfStaff;

        // 子会社または部署を保存
        List<Group> Grps = new List<Group>();

        public Company(string name)
        {
            Name = name;
        }

        // 子会社または部署を追加
        public void Add(Group grp)
        {
            Grps.Add(grp);
        }

        //会社の員数を取得
        public override int GetNumberOfStaff() => Grps.Select(grp => grp.GetNumberOfStaff()).Sum();
        
        //会社の員数を取得
        public override string GetName() => Name;
    }

    /// <summary>Leaf クラス</summary>
    public class Department : Group
    {
        //部署名
        string Name;

        //部署の員数
        int NumberOfStaff;

        public Department(string name, int numberOfStaff)
        {
            Name = name;
            NumberOfStaff = numberOfStaff;
        }

        //部署名を取得
        public override string GetName() => Name;

        //部署の員数を取得
        public override int GetNumberOfStaff() => NumberOfStaff;
    }
}
