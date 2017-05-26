using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Studio_Zoo_Task.Classes.Animals;
using Binary_Studio_Zoo_Task.Interfaces;
using Binary_Studio_Zoo_Task.Classes.AnimalSuppliers;
using Binary_Studio_Zoo_Task.Enums;

namespace Binary_Studio_Zoo_Task.Classes.LocalZooAviary
{
    public class Aviary : IZooRepository
    {
        private List<Animal> animals;
        private object lockObject = new object();

        public Aviary()
        {
            animals = new List<Animal>();
        }

        public void AddAnimal(Animal newAnimal)
        {
            lock (lockObject)
            {
                animals.Add(newAnimal);
            }
        }

        public Animal GetRandomAnimal()
        {
            int numberOfAnimals = animals.Count;

            if (numberOfAnimals < 1)
            {
                return null;
            }
            else if (numberOfAnimals == 1)
            {
                return animals.First();
            }

            Random rnd = new Random();
            int animalIndex = rnd.Next(0, numberOfAnimals);

            lock (lockObject)
            {
                return animals.ElementAt(animalIndex);
            }
        }

        public Animal GetAnimalByName(string animalName)
        {
            lock (lockObject)
            {
                return animals.Where(x => x.AnimalName == animalName).FirstOrDefault();
            }
        }

        public bool DeleteAnimalByName(string animalName)
        {
            lock (lockObject)
            {
                Animal removedAnimal = animals.Where(x => x.AnimalName == animalName).FirstOrDefault();
                if (removedAnimal != null)
                {
                    animals.Remove(removedAnimal);
                    return true;
                }
            }
            return false;
        }

        public List<Animal> GetAllAnimals()
        {
            lock (lockObject)
            {
                return animals;
            }
        }

        public List<Animal> GetAnimalsByType(AnimalType animalType)
        {
            lock (lockObject)
            {
                return animals.Where(x => x.AnimalType == animalType).ToList();
            }
        }

        public List<Animal> GetAnimalByState(AnimalState animalState)
        {
            lock (lockObject)
            {
                return animals.Where(x => x.AnimalState == animalState).ToList();
            }
        }
    }
}
