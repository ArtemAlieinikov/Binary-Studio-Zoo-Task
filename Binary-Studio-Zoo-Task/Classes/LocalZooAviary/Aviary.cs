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

        public double GetAvarageHealth()
        {
            lock (lockObject)
            {
                return animals.Average(x => x.HealPoints);
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

        public Animal GetAnimal(string animalName)
        {
            lock (lockObject)
            {
                return animals.Where(x => x.AnimalName == animalName).FirstOrDefault();
            }
        }

        public Animal GetAnimal(AnimalType animalType, string animalName)
        {
            lock (lockObject)
            {
                return animals.Where(x => (x.AnimalType == animalType) && (x.AnimalName.ToLower() == animalName.ToLower()))
                    .FirstOrDefault();
            }
        }

        public IEnumerable<IGrouping<AnimalType, Animal>> GetAnimalGroups()
        {
            lock (lockObject)
            {
                return animals.GroupBy(x => x.AnimalType);
            }
        }

        public Dictionary<AnimalType, Animal> GetHealthiestAnimalOnGroup()
        {
            Dictionary<AnimalType, Animal> result = new Dictionary<AnimalType, Animal>();

            lock (lockObject)
            {
                var animalGroup = animals.GroupBy(x => x.AnimalType);

                foreach (var group in animalGroup)
                {
                    result.Add(group.Key, group.OrderByDescending(x => x.HealPoints).FirstOrDefault());
                }
            }

            return result;
        }

        public Dictionary<AnimalType, int> GetNumberOfDethInGroup()
        {
            Dictionary<AnimalType, int> result = new Dictionary<AnimalType, int>();

            lock (lockObject)
            {
                var animalGroup = animals.GroupBy(x => x.AnimalType);

                foreach (var group in animalGroup)
                {
                    result.Add(group.Key, group.Count(x => x.AnimalState == AnimalState.dead));
                }
            }

            return result;
        }

        public List<Animal> GetAnimalsWithMaxAndMinHealth()
        {
            lock (lockObject)
            {
                return animals.OrderByDescending(x => x.HealPoints).Take(1).Union(animals.OrderBy(x => x.HealPoints).Take(1))
                    .ToList();
            }
        }

        public List<string> GetNamesOfHangryAnimals()
        {
            lock (lockObject)
            {
                return animals.Where(x => x.AnimalState == AnimalState.hungry).Select(x => x.AnimalName).ToList();
            }
        }

        public List<Animal> GetWolfsAndBearsWithHealthAboveThree()
        {
            lock (lockObject)
            {
                return animals.Where(x => ((x.AnimalType == AnimalType.bear) || (x.AnimalType == AnimalType.wolf)) && x.HealPoints > 3)
                    .ToList();
            }
        }

        public List<Animal> GetAllAnimals()
        {
            lock (lockObject)
            {
                return animals;
            }
        }

        public List<Animal> GetAnimals(AnimalType animalType)
        {
            lock (lockObject)
            {
                return animals.Where(x => x.AnimalType == animalType).ToList();
            }
        }

        public List<Animal> GetAnimals(AnimalState animalState)
        {
            lock (lockObject)
            {
                return animals.Where(x => x.AnimalState == animalState).ToList();
            }
        }

        public List<Animal> GetAnimals(AnimalType animalType, AnimalState animalState)
        {
            lock (lockObject)
            {
                return animals.Where(x => (x.AnimalType == animalType) && (x.AnimalState == animalState)).ToList();
            }
        }
    }
}
