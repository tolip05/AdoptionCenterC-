using Paw.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paw.Animals
{
    public class Cat : Animal
    {
        private int intelligence;

        public Cat(string name, int age, string adoptionCenter,int inteligence) 
            : base(name, age, adoptionCenter)
        {
            this.Intelligence = intelligence;
        }

        public int Intelligence
        {
            get => intelligence;
            private set
            {
                intelligence = value;
            }
        }
    }
}
