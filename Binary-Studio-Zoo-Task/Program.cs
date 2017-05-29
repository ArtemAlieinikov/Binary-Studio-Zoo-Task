using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Studio_Zoo_Task.ZooWorkflow;

namespace Binary_Studio_Zoo_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] startCommands =
            //{
            //    "show_groups",
            //    "show_full",
            //    "show_tiger_ill",
            //    "show_elephant_name_Robi",
            //    "show_hungry_names",
            //    "show_healthiest",
            //    "show_numberOf_death",
            //    "show_wolfs_bears",
            //    "show_maxMin_health",
            //    "show_avarage_health",
            //};

            new Menu().Run(null);
        }
    }
}
