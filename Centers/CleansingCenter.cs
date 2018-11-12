using Paw.Abstracts;
using Paw.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Paw.Centers
{
    public class CleansingCenter : Center
    {
        public CleansingCenter(string name) 
            : base(name)
        {
        }
        public List<Animal> Cleanse()
        {
            List<Animal> cleansed = new List<Animal>();
            foreach (var animal in base.Animals)
            {
                Animal cleanAnimal = animal;
                cleanAnimal.Cleanse();
                cleansed.Add(cleanAnimal);
            }
            base.RemoveAnimals(cleansed);
            return cleansed;
        }
    }
}
