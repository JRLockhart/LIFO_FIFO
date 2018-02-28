using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumberjack
{
    enum Flapjack
    {
        Crispy,
        Soggy,
        Browned,
        Banana
    }

    class Lumberjack
    {

        
        private string name;
        public string Name { get { return name; } }

        //stack of food for each lumberjack
        private Stack<Flapjack> meal;
        public Lumberjack(string name)
        {
            this.name = name;
            meal = new Stack<Flapjack>();
        }

        public int FlapjackCount { get { return meal.Count; } }

        //push the chosen food on top of the stack
        public void TakeFlapJacks(Flapjack food, int howMany)
        {
            for (int i = 0; i < howMany; i++)
            {
                meal.Push(food);
            }
        }

        //print the stack of food to be eaten LIFO to console
        public void EatFlapjacks()
        {
            Console.WriteLine(name + "'s eating flapjacks");
            while (meal.Count > 0)
            {
                Console.WriteLine(name + " ate a " + meal.Pop().ToString().ToLower() + " flapjack");
            }
        }
    }
}
