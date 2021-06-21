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
using System.Windows.Threading;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfsecondsElapsed;
        int matchesFound;

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfsecondsElapsed++;
            timeTextBlock.Text = (tenthsOfsecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + "- Play again?";
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
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
                if (textBlock.Name != "timeTextBlock")
                {
                    int index = random.Next(animalEmoji.Count); //pick a random number between 0 and the number of emoji left in the list and call it "index"
                    string nextEmoji = animalEmoji[index]; //use a random number called index to get a random emoji from the list
                    textBlock.Text = nextEmoji; //Update the textBlock with the random emoji from the list
                    animalEmoji.RemoveAt(index); //remove the random emoji from the list
                }
            }
            timer.Start();
            tenthsOfsecondsElapsed = 0;
            matchesFound = 0;
        }
        

        TextBlock lastTextBlockClikcked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClikcked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClikcked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClikcked.Visibility = Visibility.Visible;
                findingMatch = false;
            }

        }

        private void timeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}
