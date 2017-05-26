using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Studio_Zoo_Task.Enums;

namespace Binary_Studio_Zoo_Task.Interfaces
{
    interface IAnimalDefinition
    {
        void AddNewAnimal(AnimalType animalType, string animalName, int currentHP);
        bool RemoveAnimal(string animalName);
    }
}
