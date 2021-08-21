using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MyButton
    {
        public string Name { get; set; }
        public delegate void Click(object sender);
        public Click OnClcik = null; 

        public void Clicked()
        {
            //先執行Console.Write or MessageBox.Show()
            if (OnClcik != null)
                OnClcik(this);
        }
    }
}
