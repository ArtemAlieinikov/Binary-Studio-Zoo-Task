using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Studio_Zoo_Task.Interfaces;
using Binary_Studio_Zoo_Task.Classes.Animals;
using Binary_Studio_Zoo_Task.Enums;

namespace Binary_Studio_Zoo_Task.Classes.TemporaryChanges
{
    class TemporaryChanges
    {
        private readonly IZooRepository zooRepository;

        public TemporaryChanges(IZooRepository zooRepository)
        {
            this.zooRepository = zooRepository;
        }

        public void TimeCahges()
        {
            Animal animalToChange = zooRepository.GetRandomAnimal();

            if (animalToChange == null)
            {
                return;
            }

            zooRepository.DeleteAnimalByName(animalToChange.AnimalName);

            if ((animalToChange.AnimalState == AnimalState.ill) && animalToChange.HealPoints > 0)
            {
                MakeHealCheanges(animalToChange);
            }

            MakeStarvingChanges(animalToChange);

            zooRepository.AddAnimal(animalToChange);
        }

        private void MakeStarvingChanges(Animal animal)
        {
            if (animal.AnimalState == AnimalState.full)
            {
                animal.AnimalState = AnimalState.hungry;
            }
            else if (animal.AnimalState == AnimalState.hungry)
            {
                animal.AnimalState = AnimalState.ill;
            }
            else if ((animal.AnimalState == AnimalState.ill) && (animal.HealPoints == 0))
            {
                animal.AnimalState = AnimalState.dead;
            }
        }

        private void MakeHealCheanges(Animal animal)
        {
            animal.HealPoints--;
        }
    }
}
