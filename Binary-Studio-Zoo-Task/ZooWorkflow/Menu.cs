using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Studio_Zoo_Task.Classes.Animals;
using Binary_Studio_Zoo_Task.Classes.AnimalSuppliers;
using Binary_Studio_Zoo_Task.Classes.LocalZooAviary;
using Binary_Studio_Zoo_Task.Classes.TemporaryChanges;
using Binary_Studio_Zoo_Task.Classes.ZooWorker;
using Binary_Studio_Zoo_Task.Enums;
using Binary_Studio_Zoo_Task.Interfaces;
using System.Threading;

namespace Binary_Studio_Zoo_Task.ZooWorkflow
{
    class Menu
    {

        private readonly IZooRepository zooAviary;
        private readonly IAnimalWorker animalWorker;
        private readonly TemporaryChanges temporaryCanges;

        public Menu()
        {
            zooAviary = new Aviary();
            animalWorker = new ZooWorker(zooAviary);
            temporaryCanges = new TemporaryChanges(zooAviary);

            SetupStartAnimalSet();
        }

        public void Run()
        {
            ShowGlobalMenu();
            new Task(ActivateTemporatyChanges).Start();

            while (true)
            {
                Console.Write("command: ");
                string command = Console.ReadLine();

                string[] commandArray = command.Split('_');

                if ((commandArray.Length < 2) || (commandArray.Length > 3))
                {
                    Console.WriteLine(command + " - wrong");
                }
                else if (commandArray.Length == 2)
                {
                    if ((commandArray[0].ToLower() == "clear") && (commandArray[1].ToLower() == "c"))
                    {
                        Console.Clear();
                        ShowGlobalMenu();
                    }
                    else if ((commandArray[0].ToLower() == "exit") && (commandArray[1].ToLower() == "c"))
                    {
                        return;
                    }
                    else if ((commandArray[0].ToLower() == "show") && (commandArray[1].ToLower() == "menu"))
                    {
                        ShowGlobalMenu();
                    }
                    else if ((commandArray[0].ToLower() == "show") && (commandArray[1].ToLower() == "all"))
                    {
                        Console.WriteLine();
                        foreach (var animal in zooAviary.GetAllAnimals())
                        {
                            Console.WriteLine(animal);
                        }
                    }
                    else if ((commandArray[0].ToLower() == "show") && (commandArray[1].ToLower() == "lion"))
                    {
                        Console.WriteLine();
                        foreach(var animal in zooAviary.GetAnimalsByType(AnimalType.lion))
                        {
                            Console.WriteLine(animal);
                        }
                    }
                    else if ((commandArray[0].ToLower() == "show") && (commandArray[1].ToLower() == "tiger"))
                    {
                        Console.WriteLine();
                        foreach (var animal in zooAviary.GetAnimalsByType(AnimalType.tiger))
                        {
                            Console.WriteLine(animal);
                        }
                    }
                    else if ((commandArray[0].ToLower() == "show") && (commandArray[1].ToLower() == "elephant"))
                    {
                        Console.WriteLine();
                        foreach (var animal in zooAviary.GetAnimalsByType(AnimalType.elephant))
                        {
                            Console.WriteLine(animal);
                        }
                    }
                    else if ((commandArray[0].ToLower() == "show") && (commandArray[1].ToLower() == "bear"))
                    {
                        Console.WriteLine();
                        foreach (var animal in zooAviary.GetAnimalsByType(AnimalType.bear))
                        {
                            Console.WriteLine(animal);
                        }
                    }
                    else if ((commandArray[0].ToLower() == "show") && (commandArray[1].ToLower() == "wolf"))
                    {
                        Console.WriteLine();
                        foreach (var animal in zooAviary.GetAnimalsByType(AnimalType.wolf))
                        {
                            Console.WriteLine(animal);
                        }
                    }
                    else if ((commandArray[0].ToLower() == "show") && (commandArray[1].ToLower() == "fox"))
                    {
                        Console.WriteLine();
                        foreach (var animal in zooAviary.GetAnimalsByType(AnimalType.fox))
                        {
                            Console.WriteLine(animal);
                        }
                    }
                    else if ((commandArray[0].ToLower() == "show") && (commandArray[1].ToLower() == "full"))
                    {
                        Console.WriteLine();
                        foreach (var animal in zooAviary.GetAnimalByState(AnimalState.full))
                        {
                            Console.WriteLine(animal);
                        }
                    }
                    else if ((commandArray[0].ToLower() == "show") && (commandArray[1].ToLower() == "hungry"))
                    {
                        Console.WriteLine();
                        foreach (var animal in zooAviary.GetAnimalByState(AnimalState.hungry))
                        {
                            Console.WriteLine(animal);
                        }
                    }
                    else if ((commandArray[0].ToLower() == "show") && (commandArray[1].ToLower() == "ill"))
                    {
                        Console.WriteLine();
                        foreach (var animal in zooAviary.GetAnimalByState(AnimalState.ill))
                        {
                            Console.WriteLine(animal);
                        }
                    }
                    else if ((commandArray[0].ToLower() == "show") && (commandArray[1].ToLower() == "dead"))
                    {
                        Console.WriteLine();
                        foreach (var animal in zooAviary.GetAnimalByState(AnimalState.dead))
                        {
                            Console.WriteLine(animal);
                        }
                    }
                    else if ((commandArray[0].ToLower() == "show") && (commandArray[1].Length > 0))
                    {
                        Animal animal = zooAviary.GetAnimalByName(commandArray[1]);
                        if (animal == null)
                        {
                            Console.WriteLine("There is no animal with this name");
                        }
                        else
                        {
                            Console.WriteLine(animal);
                        }
                    }
                    else if ((commandArray[0].ToLower() == "remove") && (commandArray[1].Length > 0))
                    {
                        bool resultOfDeleted = animalWorker.RemoveAnimal(commandArray[1]);
                        if (resultOfDeleted)
                        {
                            Console.WriteLine(String.Format("Animal with {0} name have been removed", commandArray[1]));
                        }
                        else
                        {
                            Console.WriteLine("There is no animal with this name");
                        }
                    }
                    else if ((commandArray[0].ToLower() == "heal") && (commandArray[1].Length > 0))
                    {
                        try
                        {
                            animalWorker.ToHealAnimal(commandArray[1]);
                            Console.WriteLine(String.Format("Animal {0}, have been healed", commandArray[1]));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if ((commandArray[0].ToLower() == "feed") && (commandArray[1].Length > 0))
                    {
                        try
                        {
                            animalWorker.ToFeedAnimal(commandArray[1]);
                            Console.WriteLine(String.Format("Animal {0}, have been feeded", commandArray[1]));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("wrong comand");
                    }
                }
                else if (commandArray.Length == 3)
                {
                    if ((commandArray[0].ToLower() == "create") && (commandArray[1].Length > 0) && (commandArray[2].Length > 0))
                    {
                        try
                        {
                            AnimalType animalType = GetAnimalType(commandArray[1]);

                            animalWorker.AddNewAnimal(animalType, commandArray[2], 7);
                            Console.WriteLine(String.Format("Animal {0}, have been created", commandArray[2]));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("wrong command");
                    }
                }
                else
                {
                    Console.WriteLine("wrong command");
                }
            }
        }

        private void ShowGlobalMenu()
        {
            Console.WriteLine("Welcome in our zoo, here you can work with animals");
            Console.WriteLine("Every 5 seconds some random animal will change its status");
            Console.WriteLine();
            Console.WriteLine("Avilable animal types - lion, tiger, elephant, bear, wolf, fox");
            Console.WriteLine("Avilable animal states - full, hungry, ill, dead");
            Console.WriteLine();
            Console.WriteLine("\t - create_animalType_animalName");
            Console.WriteLine("\t - feed_animalName");
            Console.WriteLine("\t - heal_animalName");
            Console.WriteLine("\t - remove_animalName");
            Console.WriteLine("\t - show_all");
            Console.WriteLine("\t - show_animalName");
            Console.WriteLine("\t - show_animalType");
            Console.WriteLine("\t - show_animalState");
            Console.WriteLine("\t - show_menu");
            Console.WriteLine();
            Console.WriteLine("\t - clear_с (it's about console)");
            Console.WriteLine("\t - exit_с");
            
        }

        private void ActivateTemporatyChanges()
        {
            while (true)
            {
                temporaryCanges.TimeCahges();
                Thread.Sleep(500);
                CheckAnimalCondition();
            }
        }

        private void SetupStartAnimalSet()
        {
            animalWorker.AddNewAnimal(AnimalType.bear, "Boris", 6);
            animalWorker.AddNewAnimal(AnimalType.elephant, "Robi", 7);
            animalWorker.AddNewAnimal(AnimalType.fox, "Foxy", 3);
            animalWorker.AddNewAnimal(AnimalType.lion, "Leopold", 5);
            animalWorker.AddNewAnimal(AnimalType.tiger, "Taras", 4);
            animalWorker.AddNewAnimal(AnimalType.wolf, "Volodia", 4);
        }

        private AnimalType GetAnimalType(string animalStringType)
        {
            if (animalStringType.ToLower() == AnimalType.wolf.ToString("g"))
            {
                return AnimalType.wolf;
            }
            else if (animalStringType.ToLower() == AnimalType.tiger.ToString("g"))
            {
                return AnimalType.tiger;
            }
            else if (animalStringType.ToLower() == AnimalType.lion.ToString("g"))
            {
                return AnimalType.lion;
            }
            else if (animalStringType.ToLower() == AnimalType.fox.ToString("g"))
            {
                return AnimalType.fox;
            }
            else if (animalStringType.ToLower() == AnimalType.elephant.ToString("g"))
            {
                return AnimalType.elephant;
            }
            else if (animalStringType.ToLower() == AnimalType.bear.ToString("g"))
            {
                return AnimalType.bear;
            }
            else
            {
                throw new ArgumentException("There are not animals with those type");
            }
        }

        private void CheckAnimalCondition()
        {
            int numberOfAllKindOfAnimals = zooAviary.GetAllAnimals().Count;
            int numberOfDeadAnimals = zooAviary.GetAllAnimals()
                .Where(x => x.AnimalState == AnimalState.dead).ToList().Count;

            if (numberOfAllKindOfAnimals == numberOfDeadAnimals)
            {
                Console.Clear();
                Console.WriteLine("All animals in ZOO are dead");
                Console.WriteLine();
                Environment.Exit(0);
            }
        }
    }
}
