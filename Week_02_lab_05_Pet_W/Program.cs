using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Week_02_lab_05_Pet_W
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create 4 objects
            Pet petA = new Pet("Huskar", 10, "Husky");
            Pet petB = new Pet("Dame", 11, "Dalmatian");
            Pet petC = new Pet("Choi", 3, "Chowchow");
            Pet petD = new Pet("GS", 81, "German Shepherd");

            //create List to store objects
            List<Pet> pets = new List<Pet>();  
            pets.Add(petA);
            pets.Add(petB);
            pets.Add(petC);
            pets.Add(petD);

            //Use methods to set owner and set IsHouseTrained to true
            petA.SetOwner("Janiel");
            petB.SetOwner("Mark");
            petC.Train();
            petD.SetOwner("Janiel");

            //text header for the output
            Console.WriteLine("List of all dogs on the list: ");

            //Using a suitable looping statement, display all the objects in the collection.
            //start of loop

            //used to retrigger user input if user wanted to find another name
            int choice = 1;
            while (choice != 0)
            {
                foreach (Pet pet in pets) {
                Console.WriteLine(pet.ToString());             
            }

            //Prompt the user for an owner’s name and then display only the pets belonging to a particular person.
            Console.WriteLine("\nPlease enter owner's name: ");
            string ownerName = Console.ReadLine();

            //this is for checking if the name inputted by the user matches something on the list. This is not case sensitive.
            bool ownerExists = false;
            
            Console.WriteLine($"List of dogs under {ownerName}");

            foreach (Pet pet in pets) 
            //this will return the owner's pet if name matches someone on the list. 
            
            {
                if (pet.Owner.Equals(ownerName, StringComparison.OrdinalIgnoreCase))  //to ignore case sensitivity
                { 
                    Console.WriteLine(pet.ToString());
                    ownerExists = true;
                }
            }

                if (!ownerExists) //this will return an error message if name does not match someone on the list
                {
                    Console.WriteLine($"{ownerName} does not have a pet belonging to him.");
                }

                //if user wants to input another name again
                Console.WriteLine("press any number to check another name and 0 to stop");
                choice = Convert.ToInt32(Console.ReadLine());


                //this is to clear the screen upon new search
                if (choice != 0)
                {
                    Console.Clear();
                }
            }
            Console.ReadKey();
        }
    }
}

    internal class Pet
{
    //Properties
    public string Name { get; } //setter is absent
    public string Owner { get; private set; } //setter is private
    public int Age { get; } //setter is absent
    public string Description { get; } //setter is absent
    public bool IsHouseTrained { get; private set; } //setter is private

    //constructor with 3 arguments
    //initializes the fields owner to “no one” and isHousedTrained to false
    public Pet(string name, int age, string description)
    {
        Name = name;
        Owner = "no one";
        Age = age;
        Description = description;
        IsHouseTrained = false;
    }

    //Methods
    public override string ToString()
    {
        return $"Name: {Name}, Owner: {Owner}, Age: {Age}, Description: {Description}, IsHouseTrained: {IsHouseTrained}";
    }

    public void SetOwner(string owner)
    {
        Owner = owner;
    }

    public void Train()
    {
        IsHouseTrained = true;
    }
}

