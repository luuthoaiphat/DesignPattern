using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace Decorator
{
    /// <summary>Component クラス</summary>
    public abstract  class Display
    {
        public abstract string GetText();
        public void Show()
        {
            Console.WriteLine(GetText());
        }
    }

    /// <summary>ConcreteComponent クラス</summary>
    public class StringDisplay : Display
    {
        string Text;
        public StringDisplay(string txt)
        {
            this.Text = txt;
        }
        public override string GetText()
        {
            return Text;
        }
    }

    /// <summary>Decorator クラス</summary>
    public abstract class StringDecorator : Display
    {
        protected Display Display;
        public StringDecorator(Display display)
        {
            this.Display = display;
        }
    }

    /// <summary>ConcreteDecorator クラス</summary>
    public class RepeatStringDisplay : StringDecorator
    {
        int repreatNum;
        public RepeatStringDisplay(Display display, int num) : base(display)
        {
            repreatNum = num;
        }
        public override string GetText()
        {
            string txt = "";
            for (int i = 0; i < repreatNum; i++)
            {
                txt += Display.GetText();
            }
            return txt;
        }
    }

    /// <summary>ConcreteDecorator クラス</summary>
    public class BorderStringDisplay : StringDecorator
    {
        char border;
        public BorderStringDisplay(Display display, char c) : base (display)
        {
            this.border = c;
        }

        public override string GetText()
        {
            return border + Display.GetText() + border;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //txt
            var txt = new StringDisplay("ABC");
            txt.Show();
            //txt-> repeat
            var repeat = new RepeatStringDisplay(txt, 2);
            repeat.Show();
            //txt -> repeat -> border
            var border = new BorderStringDisplay(repeat, '|');
            border.Show();
            //txt -> border -> repeat -> border
            var a = new BorderStringDisplay(
                         new RepeatStringDisplay(
                             new BorderStringDisplay(
                                 new StringDisplay("ABC"), 
                             '='), 
                         3), 
                    '|');

            a.Show();
        }
    }
}
