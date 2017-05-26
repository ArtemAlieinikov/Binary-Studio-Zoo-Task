using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Studio_Zoo_Task.Enums;

namespace Binary_Studio_Zoo_Task.Classes.Animals
{
    class Fox : Animal
    {
        public Fox(string animalName, int currentHP) 
            : base(AnimalType.fox, animalName, AnimalState.full, 3, currentHP)
        { }
    }
}
