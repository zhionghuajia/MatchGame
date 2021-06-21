using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()  
            {
                "🐄","🐄",
                "🐍","🐍",
                "🐿","🐿",
                "🐙","🐙",
                "🐘","🐘",
                "🐳","🐳",
                "🐇","🐇",
                "🐒","🐒",
            };
            Random random = new Random();  //create a random number generator

            /*find every TextBlock in the grid and repeat the following statements for each of them*/
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>()) 
            {
                int index = random.Next(animalEmoji.Count); //pick a random number between 0 and the number of emoji left in the list and call it "index"
                string nextEmoji = animalEmoji[index]; //use a random number called index to get a random emoji from the list
                textBlock.Text = nextEmoji; //Update the textBlock with the random emoji from the list
                animalEmoji.RemoveAt(index); //remove the random emoji from the list
            }
        }
    }
}
