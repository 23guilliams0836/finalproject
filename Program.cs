
using System.Diagnostics;
using System.Linq.Expressions;


/*
 * Program Name: Petmania
 * Programmer: Cooper Guilliams
 * Date: 12/19/2022
 *
 * Description: This program simulates the life of a pet owner.
 * Features include: adopting pets from a semi random selection,
 * feeding your pets, and the ability for a pet to recieve "monster status"
 */

Random random = new Random();

string[] possibleNames = new string[]
{
    "Alice","Bob","Colin","Dean","Egg","Jojo","Flower","Spots","Trunks","Meat head"
};
string[] possibleSpecies = new string[]
{
    "dog","cat","fish","fox","lion","wolf","bug","human","kangaroo","cow"
};

List<Animal> pets = new List<Animal>();

Adopt();

Home();


void Home() {
    Console.Clear();
    Console.WriteLine("--------ACTIONS--------");
    Console.WriteLine(" 1. Adopt\n 2. Care\n 3. Pet list");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Adopt();
            break;
        case "2":
            Care();
            break;
        case "3":
            Console.Clear();
            Console.WriteLine("--------PETS--------");
            ListPets();
            Console.ReadLine();
            break;
        default:
            ErrorInvalidInput();
            break;
    }
    Home();

    void ErrorInvalidInput()
    {
        Console.Clear();
        Console.WriteLine("--------ACTIONS--------");
        Console.WriteLine("Invalid Input!");
        Console.ReadLine();
    }
}

void Adopt()
{
    Console.Clear();
    Console.WriteLine("--------ADOPT--------");
    Animal[] animalsForAdoption = new Animal[5];
    for(int i = 0; i < 5; i++)
    {
        animalsForAdoption[i] = generateAnimal();
        Console.WriteLine("{0}: {1}", i+1, animalsForAdoption[i].name);
        Console.WriteLine("  Species: " + animalsForAdoption[i].species);
        Console.WriteLine("  Size: " + animalsForAdoption[i].size);
    }
    Console.WriteLine("Which one will you adopt?");
    string choice = Console.ReadLine();
    if(Int32.TryParse(choice, out int c) && c <= 5 && c > 0)
    {
        pets.Add(animalsForAdoption[c - 1]);
        Console.Clear();
        Console.WriteLine("--------ADOPT--------");
        Console.WriteLine("{0} the {1} has been adopted!", animalsForAdoption[c - 1].name, animalsForAdoption[c - 1].species);
        Console.ReadLine();
    } else
    {
        Console.Clear();
        Console.WriteLine("--------ADOPT--------");
        Console.WriteLine("Invalid Input! Returning home");
        Console.ReadLine();
    }
    Home();
}

void Care()
{
    bool exit = false;
    Animal petToFeed = pets[0];
    Animal petToBeFood = pets[0];
    List<Animal> ediblePets = new List<Animal>(pets);
    GetPetToFeed();
    if (exit == true)
    {
        return;
    }
    GetPetToBeFood();
    if (exit == true)
    {
        return;
    }
    Console.Clear();
    Console.WriteLine("--------CARE--------");
    if (petToFeed.size > petToBeFood.size)
    {
        petToFeed.Eat(petToBeFood);
        pets.Remove(petToBeFood);
        Console.ReadLine();
    } else
    {
        Console.WriteLine("{0} the {1} is too big for {2} the {3} to eat! {0} will live another day.", petToBeFood.name, petToBeFood.species, petToFeed.name, petToFeed.species);
        Console.ReadLine();
    }




    void GetPetToFeed()
    {
        Console.Clear();
        Console.WriteLine("--------CARE--------");
        Console.WriteLine("Your pets are starving! Who will you feed?");
        ListPets();
        string choice = Console.ReadLine();
        if (Int32.TryParse(choice, out int c) && c <= pets.Count && c > 0)
        {
            petToFeed = pets[c - 1];
            ediblePets.Remove(ediblePets[c - 1]);
        }
        else
        {
            InvalidInput();
            exit = true;
        }
    }

    void GetPetToBeFood()
    {
        Console.Clear();
        Console.WriteLine("--------CARE--------");
        Console.WriteLine("Who will {0} {1} {2} eat?", petToFeed.name, petToFeed.monsterStatus, petToFeed.species);
        int i = 1;
        foreach (Animal p in ediblePets)
        {
            Console.WriteLine("{0}. {1} {4} {2}, Size: {3}", i, p.name, p.species, p.size, p.monsterStatus);
            i++;
        }
        string choice = Console.ReadLine();
        if (Int32.TryParse(choice, out int c) && c <= pets.Count && c > 0)
        {
            petToBeFood = ediblePets[c - 1];
        }
        else
        {
            InvalidInput();
            exit = true;
        }
    }

    void InvalidInput()
    {
        Console.Clear();
        Console.WriteLine("--------CARE--------");
        Console.WriteLine("Invalid Input! Returning home");
        Console.ReadLine();
        return;
    }

}

void ListPets()
{
    int i = 1;
    foreach (Animal p in pets)
    {
        Console.WriteLine("{0}. {1} {4} {2}, Size: {3}", i, p.name, p.species, p.size, p.monsterStatus);
        i++;
    }
}


Animal generateAnimal()
{
    int randName = random.Next(0,10);
    int randSpecies = random.Next(0, 10);
    int randSize = random.Next(1, 11);
    return new Animal(possibleNames[randName], possibleSpecies[randSpecies], randSize);
}

