using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reader_Text_DB;

namespace Reader_Text
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Main main = new Main();
            FileManager manager = new FileManager();

            Presentor presentor = new Presentor(main, manager);
            Application.Run(main);
        }
    }
}
