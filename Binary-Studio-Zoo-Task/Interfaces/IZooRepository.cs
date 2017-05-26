using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Studio_Zoo_Task.Classes.Animals;
using Binary_Studio_Zoo_Task.Enums;

namespace Binary_Studio_Zoo_Task.Interfaces
{
    public interface IZooRepository
    {
        void AddAnimal(Animal newAnimal);
        Animal GetRandomAnimal();
        Animal GetAnimalByName(string animalName);
        bool DeleteAnimalByName(string animalName);

        List<Animal> GetAllAnimals();
        List<Animal> GetAnimalsByType(AnimalType animalType);
        List<Animal> GetAnimalByState(AnimalState animalState);
    }
}
