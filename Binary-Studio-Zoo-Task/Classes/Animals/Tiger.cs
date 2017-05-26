using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Studio_Zoo_Task.Enums;

namespace Binary_Studio_Zoo_Task.Classes.Animals
{
    public class Tiger : Animal
    {
        public Tiger(string animalName, int currentHP) 
            : base(AnimalType.tiger, animalName, AnimalState.full, 4, currentHP)
        { }
    }
}
