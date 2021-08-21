using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            MyButton button = new MyButton();
            button.OnClcik = MyButton_Click;

            button.Clicked();

            Console.ReadLine();
        }

        static void MyButton_Click(object sender)
        {
            Console.WriteLine("In delegater");
        }
    }
}
