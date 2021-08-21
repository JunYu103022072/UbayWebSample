using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MySecButton
    {
        public string Name { get; set; }

        public event EventHandler OnClick;

        public void Clicked()
        {
            if (OnClick != null)
                OnClick(this, new EventArgs());
        }
    }
}
