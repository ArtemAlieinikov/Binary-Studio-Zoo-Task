using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Studio_Zoo_Task.Enums;

namespace Binary_Studio_Zoo_Task.Classes.Animals
{
    public class Bear : Animal
    {
        public Bear(string animalName, int currentHP) 
            : base(AnimalType.bear, animalName, AnimalState.full, 6, currentHP)
        { }
    }
}
