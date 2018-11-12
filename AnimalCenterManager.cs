using Paw.Abstracts;
using Paw.Animals;
using Paw.Centers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Paw
{
   public class AnimalCenterManager
    {
        private Dictionary<string, CleansingCenter> cleansingCenter;
        private Dictionary<string, AdoptionCenter> adoptionCenter;
        private List<Animal> cleansingAnimal;
        private List<Animal> adoptionAnimal;

        public AnimalCenterManager()
        {
            this.cleansingCenter = new Dictionary<string, CleansingCenter>();
            this.adoptionCenter = new Dictionary<string, AdoptionCenter>();
            this.cleansingAnimal = new List<Animal>();
            this.adoptionAnimal = new List<Animal>();
        }
        public void RegisterCleansingCenter(string name)
        {
            CleansingCenter cleansingCenter = new CleansingCenter(name);
            if (!this.cleansingCenter.ContainsKey(name))
            {
                this.cleansingCenter.Add(name, cleansingCenter);
            }
            
        }
        public void RegisterAdoptingCenter(string name)
        {
            AdoptionCenter adoption = new AdoptionCenter(name);
            if (!this.adoptionCenter.ContainsKey(name))
            {
                this.adoptionCenter.Add(name,adoption);
            }
        }
        public void RegisterDog(string name,int age,int command,string centerName)
        {
            Animal dog = new Dog(name,age,centerName,command);
            this.adoptionCenter[centerName].Register(dog);
        }
        public void RegisterCat(string name,int age,int inteligence,string centerName)
        {
            Cat cat = new Cat(name, age,centerName,inteligence);
            this.adoptionCenter[centerName].Register(cat);
        }
        public void SendForCleansing(string adoptionCenterName,string cleansingCenterName)
        {

            AdoptionCenter adoptionCenter = 
                this.adoptionCenter[adoptionCenterName];
            CleansingCenter cleansingCenter = 
                this.cleansingCenter[cleansingCenterName];
            if (adoptionCenter == null || cleansingCenter == null)
            {
                throw new ArgumentException("No such Center!");
            }
            adoptionCenter.SenForCleaning(cleansingCenter);
        //    this.adoptionCenter[adoptionCenterName]
        //        .SenForCleaning(this.cleansingCenter[cleansingCenterName]);
        }
        public void Cleanse(string cleansingdCenterName)
        {
            List<Animal> cleansed =
                this.cleansingCenter[cleansingdCenterName].Cleanse();
            foreach ( var animal in cleansed)
            {
                this.adoptionCenter[animal.AdoptionCenter].Register(animal);
            }
            this.cleansingAnimal.AddRange(cleansed);
        }
        public void Adopt(string adoptionCenterName)
        {
            List<Animal> adoptedAnimal =
                this.adoptionCenter[adoptionCenterName].Adopt();
            this.adoptionAnimal.AddRange(adoptedAnimal);
        }
        public void PrintStatistics()
        {
            Console.WriteLine("Paw Incorporative Regular Statistics");
            Console.WriteLine($"Adoption Centers: {this.adoptionCenter.Count}");
            Console.WriteLine($"Cleansing Centers: {this.cleansingCenter.Count}");
            Console.WriteLine($"Adopted Animals: {GetSortedAnimals(this.adoptionAnimal)}");
            Console.WriteLine($"Cleansed Animals: {GetSortedAnimals(this.cleansingAnimal)}");
            Console.WriteLine($"Animals Awaiting Adoption: {GetAwaitingAdoptionCount()}");
            Console.WriteLine($"Animals Awaiting Cleansing: {GetAwaitingCleansedCount()}");
        }

        private int GetAwaitingCleansedCount()
        {
            int result = 0;
            foreach (var kvp in this.cleansingCenter)
            {
                
                foreach (var animal in kvp.Value.Animals)
                {
                    if (animal.IsCleaning == false)
                    {
                        result++;
                    }
                }
            }



            return result;
        }

        private object GetAwaitingAdoptionCount()
        {
            int count = 0;
           
            foreach (var center in this.adoptionCenter)
            {
                var valu = center.Value;
                foreach (var animal in valu.Animals)
                {
                    if (animal.IsCleaning)
                    {
                        count++;
                    }
                }
            }
            return count;

        }

        private object GetSortedAnimals(List<Animal> adoptionAnimal)
        {
            if (adoptionAnimal.Count == 0)
            {
                return "None";
            }
            List<Animal> animals =
                adoptionAnimal.OrderBy(a => a.Name).ToList();
            return string.Join(", ",animals);
        }
    }
}
