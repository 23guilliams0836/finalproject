using System;
using System.Reflection;

public class Animal
{

	public string name;
	public string species;
	public int size;
	public string monsterStatus = "the";

	public Animal(string name, string species, int size)
	{
		this.name = name;
		this.species = species;
		this.size = size;
	}

	public void Eat(Animal food)
	{
		Console.WriteLine("{0} {5} {1} ate {2} {6} {3} and grew {4} sizes bigger. {2} the {3} has been removed from your pets list.", this.name, this.species, food.name, food.species, food.size, this.monsterStatus, food.monsterStatus);
		this.size += food.size;
		if (this.size >= 20 && monsterStatus == "the")
		{
			this.monsterStatus = "'THE MONSTER'";
			Console.WriteLine("{0} {1} {2} has gained monster status!", this.name, this.monsterStatus, this.species);
		}
	}
}
