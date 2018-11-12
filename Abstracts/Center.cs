using Paw.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paw.Abstracts
{
   public abstract class Center : ICenter
    {
        private string name;
        private List<Animal> animals;

        public Center(string name)
        {
            this.Name = name;
            this.animals = new List<Animal>();
        }

        public string Name
        {
            get => name;
            private set
            {
                name = value;
            }
        }
        public List<Animal> Animals
        {
            get => animals;
            private set
            {
                animals = value;
            }
        }
        public void Register(Animal animal)
        {
            this.Animals.Add(animal);
        }
        public void RegisterAll(List<Animal>animals)
        {
            this.Animals.AddRange(animals);
        }
        public IReadOnlyList<Animal> GetAnimals()
        {
            return this.Animals;
        }
        public void RemoveAnimals(List<Animal>animals)
        {
            foreach (var animal in animals)
            {
                this.Animals.Remove(animal);
            }
        }
    }
}
