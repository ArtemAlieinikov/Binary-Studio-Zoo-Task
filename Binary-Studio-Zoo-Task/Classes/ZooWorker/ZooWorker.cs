using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Studio_Zoo_Task.Interfaces;
using Binary_Studio_Zoo_Task.Enums;
using Binary_Studio_Zoo_Task.Classes.Animals;
using Binary_Studio_Zoo_Task.Classes.AnimalSuppliers;

namespace Binary_Studio_Zoo_Task.Classes.ZooWorker
{
    class ZooWorker : IAnimalWorker
    {
        private readonly IZooRepository zooRepository;

        public ZooWorker(IZooRepository zooRepozitory) 
        {
            this.zooRepository = zooRepozitory;
        }

        public void AddNewAnimal(AnimalType animalType, string animalName, int currentHP)
        {
            bool isAnimalWithSameNameExist = zooRepository.GetAllAnimals().Where(x => x.AnimalName == animalName).FirstOrDefault() != null;

            if (isAnimalWithSameNameExist)
            {
                throw new ArgumentException("You cannot add animals with the same names");
            }

            AnimalSupplier animalSupplier;

            if (animalType == AnimalType.bear)
            {
                animalSupplier = new BearSupplier();
            }
            else if (animalType == AnimalType.elephant)
            {
                animalSupplier = new ElephantSupplier();
            }
            else if (animalType == AnimalType.fox)
            {
                animalSupplier = new FoxSupplier();
            }
            else if (animalType == AnimalType.lion)
            {
                animalSupplier = new LionSupplier();
            }
            else if (animalType == AnimalType.tiger)
            {
                animalSupplier = new TigerSupplier();
            }
            else
            {
                animalSupplier = new WolfSupplier();
            }

            zooRepository.AddAnimal(animalSupplier.ProvideAnAnimal(animalName, currentHP));
        }

        public bool RemoveAnimal(string animalName)
        {
            return zooRepository.DeleteAnimalByName(animalName);
        }

        public void ToFeedAnimal(string animalName)
        {
            Animal animalToFeed = zooRepository.GetAnimalByName(animalName);

            if (animalToFeed == null)
            {
                throw new ArgumentException("There are no animals with this name");
            }
            else if (animalToFeed.AnimalState == AnimalState.dead)
            {
                throw new ArgumentException("This animal is dead");
            }

            zooRepository.DeleteAnimalByName(animalToFeed.AnimalName);
            GrowAnimalStarvingLevel(animalToFeed);
            zooRepository.AddAnimal(animalToFeed);
        }

        public void ToHealAnimal(string animalName)
        {
            Animal animalToHeal = zooRepository.GetAnimalByName(animalName);

            if (animalToHeal == null)
            {
                throw new ArgumentException("There are no animals with this name");
            }
            else if (animalToHeal.AnimalState == AnimalState.dead)
            {
                throw new ArgumentException("This animal is dead");
            }

            zooRepository.DeleteAnimalByName(animalToHeal.AnimalName);
            HealAnimal(animalToHeal);
            zooRepository.AddAnimal(animalToHeal);
        }

        private void GrowAnimalStarvingLevel(Animal animal)
        {
            if (animal.AnimalState == AnimalState.hungry)
            {
                animal.AnimalState = AnimalState.full;
            }
        }

        private void HealAnimal(Animal animal)
        {
            animal.HealPoints++;

            if (animal.AnimalState == AnimalState.ill)
            {
                animal.AnimalState = AnimalState.hungry;
            }
        }
    }
}
