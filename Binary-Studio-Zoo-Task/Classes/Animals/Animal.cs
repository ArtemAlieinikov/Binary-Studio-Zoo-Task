using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Studio_Zoo_Task.Enums;

namespace Binary_Studio_Zoo_Task.Classes.Animals
{
    public abstract class Animal
    {
        protected int topHealPointsLevel;
        protected int healPoints;

        public int HealPoints
        {
            get
            {
                return healPoints;
            }
            set
            {
                if (value > topHealPointsLevel)
                {
                    healPoints = topHealPointsLevel;
                }
                else if (value < 0)
                {
                    healPoints = 0;
                }
                else
                {
                    healPoints = value;
                }
            }
        }
        public AnimalState AnimalState { get; set; }
        public string AnimalName { get; private set; }
        public AnimalType AnimalType { get; private set; }

        public Animal(AnimalType animalType, string animalName, AnimalState animalState, int topHP, int currentHP)
        {
            AnimalType = animalType;
            AnimalName = animalName;
            AnimalState = animalState;
            topHealPointsLevel = topHP;
            HealPoints = currentHP;
        }

        public override string ToString()
        {
            return String.Format("Name - {0}, Type - {1}, State - {2}, HP - {3}",
                AnimalName, AnimalType.ToString("g"), AnimalState.ToString("g"), HealPoints);
        }
    }
}
