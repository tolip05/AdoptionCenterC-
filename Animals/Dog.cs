using Paw.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paw.Animals
{
    public class Dog : Animal
    {
        private int commands;

        public Dog(string name, int age, string adoptionCenter,int commands) 
            : base(name, age, adoptionCenter)
        {
            this.Commands = commands;
        }

        public int Commands
        {
            get => commands;
            private set
            {
                commands = value;
            }
        }
        
    }
}
