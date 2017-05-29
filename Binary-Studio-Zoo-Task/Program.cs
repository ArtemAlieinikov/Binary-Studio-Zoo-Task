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
            #region helps
            //show_groups - получить животных, сгруппированных по виду, 
            //show_full - получить животных, с состоянием full,
            //show_tiger_ill - получить всех тигров, которые больны,
            //show_elephant_name_Robi - получить слона с кличкой Robi
            //show_hungry_names - получить список всех кличек животных, которые голодны,
            //show_healthiest - получить самых здоровых животных каждого вида,
            //show_numberOf_death - получить количество мертвых животных каждого вида,
            //show_wolfs_bears - получить всех волков и медведей, у которых здоровье выше 3,
            //show_maxMin_health - получить животных с макс.и мин. здоровьем,
            //show_avarage_health - получить среднее количество здоровья.
            #endregion

            #region start commands
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
            #endregion

            new Menu().Run(null);
        }
    }
}
