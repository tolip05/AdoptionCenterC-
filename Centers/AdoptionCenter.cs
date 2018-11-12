using Paw.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Paw.Contracts;

namespace Paw.Centers
{
    public class AdoptionCenter : Center
    {
        public AdoptionCenter(string name) 
            : base(name)
        {

        }
        public void SenForCleaning(CleansingCenter center)
        {
            List<Animal> animals = base.Animals
                .Where(a => a.IsCleaning == false).ToList();
            base.RemoveAnimals(animals);
            center.RegisterAll(animals);
            
        }
        public List<Animal> Adopt()
        {
            List<Animal> animals = base.Animals
                .Where(a => a.IsCleaning == true).ToList();
            base.RemoveAnimals(animals);
            return animals;
        }
    }
}
