using System;
using System.Text;
using System.Text.Json.Serialization;

namespace Apitestailua
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string page = "https://www.fruityvice.com/api/fruit/";
                Console.WriteLine("Which fruit would you like to know about? Input 0 to exit.");
                string fruitinput = Console.ReadLine();

                if (fruitinput == "0")
                {
                    break;
                }
                
                Fruit fruit = APIHelper.RunAsync<Fruit>(page, fruitinput).GetAwaiter().GetResult();

                try
                {
                    Console.WriteLine($"\nGenus: {fruit.genus}\nName: {fruit.name}\nFamily: {fruit.family}\nOrder: {fruit.order}\n");
                    string ind = "     ";
                    Console.WriteLine($"{ind}Carbohydrates: {fruit.nutritions.carbohydrates}\n{ind}Protein: {fruit.nutritions.protein}\n{ind}Fat: {fruit.nutritions.fat}\n{ind}Calories: {fruit.nutritions.calories}\n{ind}Sugar: {fruit.nutritions.sugar}\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Fruit not found.");
                }
            }
        }
    }
}
