/*
 * Name: Luke O'Brien
 * Class: 3020:001
 * Due Date: 10/8/21 ->(moved to) 10/11/21
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 *  Postmortem
 *  
 *  1.) Full Transperency, This project took me FOREVER. About 9 hours in total to finish.
 *  part of that reason being that I had a really hard time understanding Events. So I spent
 *  atleast 2 of those hours just researching events and writing test programs to get better
 *  at them
 *  2.) Becuase I did a ton more resreach on events and even linQ, I have a really good understanding
 *  of their basic functionality now. Additionally, outside of these topics I didn't really run into
 *  any issues
 *  3.) I wasited about a full hour on a single bug... Null Reference Excpetion... My Mortal Enemy...
 *  To be fair, by this point I had gone without sleep for about 22-23 hours and had been programing for 4-5
 *  but the issue was with my first query in find and the temp var returing the exception. I just had to 
 *  add in the "where" section: "TempVar != null" and that fixed everything
 *  4.) Other than spending too much time on this project, next time, because I understand a bit better
 *  of what I am doing with events and linq, i would add functionallity to the form.
 */

namespace OBrienLA2
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
