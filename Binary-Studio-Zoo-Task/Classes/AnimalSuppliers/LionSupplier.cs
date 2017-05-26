using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Studio_Zoo_Task.Classes.Animals;
using Binary_Studio_Zoo_Task.Enums;

namespace Binary_Studio_Zoo_Task.Classes.AnimalSuppliers
{
    class LionSupplier : AnimalSupplier
    {
        public override Animal ProvideAnAnimal(string animalName, int currentHP)
        {
            return new Lion(animalName, currentHP);
        }
    }
}
