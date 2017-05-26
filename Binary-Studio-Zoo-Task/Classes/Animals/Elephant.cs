using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Studio_Zoo_Task.Enums;

namespace Binary_Studio_Zoo_Task.Classes.Animals
{
    public class Elephant : Animal
    {
        public Elephant(string animalName, int currentHP) 
            : base(AnimalType.elephant, animalName, AnimalState.full, 7, currentHP)
        { }
    }
}
