using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryConsole2
{
    class Program
    {
        static void Main(string[] args)
        {
            MySecButton button = new MySecButton() { Name = "btn1" };
            //使用匿名函式
            button.OnClick += (object sender, EventArgs e) =>
            {
                var btn = sender as MySecButton;
                Console.WriteLine(btn.Name);
            };
            button.Clicked();
            Console.ReadLine();
        }
        //事件
        //private static void Button_OnClick(object sender, EventArgs e)
        //{
        //    var btn = sender as MySecButton;
        //    Console.WriteLine(btn);
        //}
    }
}
