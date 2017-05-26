using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Studio_Zoo_Task.Enums;
using Binary_Studio_Zoo_Task.Classes.Animals;

namespace Binary_Studio_Zoo_Task.Classes.AnimalSuppliers
{
    class TigerSupplier : AnimalSupplier
    {
        public override Animals.Animal ProvideAnAnimal(string animalName, int currentHP)
        {
            return new Tiger(animalName, currentHP);
        }
    }
}
