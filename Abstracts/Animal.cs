using Paw.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paw.Abstracts
{
   public abstract class Animal : IAnimal
    {
        private string name;
        private int age;
        
        private string adoptionCenter;
        public bool IsCleaning { get; set; }
        

        public Animal(string name, int age, string adoptionCenter)
            
        {
            this.Name = name;
            this.Age = age;
            this.IsCleaning = false;
            this.AdoptionCenter = adoptionCenter;
        }

        public string Name
        {
            get => name;
            private set
            {
                name = value;
            }
        }
        public int Age
        {
            get => age;
            private set
            {
                age = value;
            }
        }

        public string AdoptionCenter
        {
            get => adoptionCenter;
            private set
            {
                adoptionCenter = value;
            }
        }
        public bool Cleanse()
        {
            return this.IsCleaning = true;
        }

        public string GetCenterName()
        {
            return this.AdoptionCenter;
        }
        public override string ToString()
        {
            return $"{this.Name}";
        }
    }


}


