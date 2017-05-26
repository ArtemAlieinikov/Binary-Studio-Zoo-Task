using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Studio_Zoo_Task.Interfaces
{
    interface IAnimalManipulation
    {
        void ToFeedAnimal(string animalName);
        void ToHealAnimal(string animalName);
    }
}
