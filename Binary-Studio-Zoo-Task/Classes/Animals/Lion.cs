using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Studio_Zoo_Task.Enums;

namespace Binary_Studio_Zoo_Task.Classes.Animals
{
    class Lion : Animal
    {
        public Lion(string animalName, int currentHP) 
            : base(AnimalType.lion, animalName, AnimalState.full, 5, currentHP)
        { }
    }
}
