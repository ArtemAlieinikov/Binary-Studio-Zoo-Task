using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Binary_Studio_Zoo_Task.Classes.Animals;
using Binary_Studio_Zoo_Task.Enums;

namespace Binary_Studio_Zoo_Task.Interfaces
{
    public interface IZooRepository
    {
        void AddAnimal(Animal newAnimal);
        bool DeleteAnimalByName(string animalName);
        double GetAvarageHealth();

        Animal GetRandomAnimal();
        Animal GetAnimal(string animalName);
        Animal GetAnimal(AnimalType animalType, string animalName);

        IEnumerable<IGrouping<AnimalType, Animal>> GetAnimalGroups();

        Dictionary<AnimalType, Animal> GetHealthiestAnimalOnGroup();
        Dictionary<AnimalType, int> GetNumberOfDethInGroup();

        List<string> GetNamesOfHangryAnimals();

        List<Animal> GetAllAnimals();
        List<Animal> GetAnimalsWithMaxAndMinHealth();
        List<Animal> GetAnimals(AnimalType animalType);
        List<Animal> GetAnimals(AnimalState animalState);
        List<Animal> GetWolfsAndBearsWithHealthAboveThree();
        List<Animal> GetAnimals(AnimalType animalType, AnimalState animalState);
    }
}
