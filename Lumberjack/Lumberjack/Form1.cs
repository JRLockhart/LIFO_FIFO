using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lumberjack
{
    public partial class Form1 : Form
    {

        //creating a que so that the first lumberjack is always helped first
        private Queue<Lumberjack> breakfastLine = new Queue<Lumberjack>();

        //add the lumberjacks to the list box in order of queue
        private void RedrawList()
        {
            int number = 1;
            line.Items.Clear();
            foreach (Lumberjack lumberjack in breakfastLine)
            {
                line.Items.Add(number + ". " + lumberjack.Name);
                number++;
            }

            if (breakfastLine.Count == 0)
            {
                groupBox1.Enabled = false;
                nextLumberjack.Text = "";
            }
            else
            {
                //peek at who is at the front of the que and add to textbox
                groupBox1.Enabled = true;
                Lumberjack currentLumberJack = breakfastLine.Peek();
                textBox1.Text = currentLumberJack.Name + " has "
                    + currentLumberJack.FlapjackCount + " flapjacks";
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        //check selection and flapjack to lumbjack at the front of the queue
        //add food to stack
        private void addFlapjacks_Click(object sender, EventArgs e)
        {
            if (breakfastLine.Count == 0)
                return;
            Flapjack food;
            if (crispy.Checked == true)
            {
                food = Flapjack.Crispy;
            }
            else if (soggy.Checked == true)
            {
                food = Flapjack.Crispy;
            }
            else if (browned.Checked == true)
            {
                food = Flapjack.Browned;
            }else
	        {
                food = Flapjack.Banana;
            }

            Lumberjack currentLumberjack = breakfastLine.Peek();
            currentLumberjack.TakeFlapJacks(food, (int)howMany.Value);

            RedrawList();
        }

        //add lumberjack to queue
        private void addLumberjack_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nameText.Text)) return;
            breakfastLine.Enqueue(new Lumberjack(nameText.Text));
            nameText.Text = "";
            RedrawList();
        }

        //take the next in line lumber jack of the list and move everyone else up one
        private void nextLumberjack_Click(object sender, EventArgs e)
        {
            if (breakfastLine.Count == 0)
                return;
            Lumberjack nextLumberjack = breakfastLine.Dequeue();
            nextLumberjack.EatFlapjacks();
            line.Text = "";
            RedrawList();
           
        }
    }
}
