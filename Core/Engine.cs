using System;
using System.Collections.Generic;
using System.Text;

namespace Paw.Core
{
    class Engine
    {
        private AnimalCenterManager manager;

        public Engine()
        {
            this.manager = new AnimalCenterManager();
        }

        public void Run()
        {
            string input = Console.ReadLine();
                
            
            while (input != "Paw Paw Pawah")
            {
                string[] inputArgs = input
                    .Split(" | ");
                switch (inputArgs[0])
                {
                    case "RegisterCleansingCenter":
                        manager.RegisterCleansingCenter(inputArgs[1]);
                        break;
                    case "RegisterAdoptionCenter":
                        manager.RegisterAdoptingCenter(inputArgs[1]);
                        break;
                    case "RegisterDog":
                        manager.RegisterDog(inputArgs[1]
                            ,int.Parse(inputArgs[2])
                            ,int.Parse(inputArgs[3])
                            ,inputArgs[4]);
                        break;
                    case "RegisterCat":
                        manager.RegisterCat(inputArgs[1]
                            , int.Parse(inputArgs[2])
                            , int.Parse(inputArgs[3])
                            , inputArgs[4]);
                        break;
                    case "SendForCleansing":
                        manager.SendForCleansing(inputArgs[1],inputArgs[2]);
                        break;
                    case "Cleanse":
                        manager.Cleanse(inputArgs[1]);
                        break;
                    case "Adopt":
                        manager.Adopt(inputArgs[1]);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }
            manager.PrintStatistics();
        }
    }
}
