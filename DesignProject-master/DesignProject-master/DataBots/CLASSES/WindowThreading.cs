using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DataBots.CLASSES
{
    internal class WindowThreading
    {
        public void CloseWindow(Window close,Window Open)
        {
            close.Close();
            Open.Show();
          
        }
    }
}
