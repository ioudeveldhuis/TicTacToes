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

namespace TicTacToes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool direction;
        public int moves;
        // Make sure that initial the fields have a different value because of the 3 way comparision
        string[,] gameBoard = new string[3, 3] { { "A", "B", "C" }, { "B", "C", "D" }, { "C", "D", "E" } };
        public MainWindow()
        {
            InitializeComponent();
            direction = true;
            moves = 0;
        }

        public bool CheckWin()
        {
            return true;
        }


        public void Button_Click(object sender, RoutedEventArgs e)
        {
            // Code here to act upon
            var clickedButton = sender as Button;
            List<string> mylist = new List<string>();
            bool allElementsAreEqual = false;

            if (direction == false)
            {
                clickedButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#811717"));
                clickedButton.Content = "X";
                direction = true;
            }
            else if (direction == true)
            {
                clickedButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#126712"));
                clickedButton.Content = "O";
                direction = false;
            }
            //
            gameBoard[Grid.GetRow(clickedButton), Grid.GetColumn(clickedButton)] = clickedButton.Content.ToString();
            // Disable button field so it can't be clicked anymore
            clickedButton.IsHitTestVisible = false;
            moves++;
            this.Title = "TicTacToes - Moves: " + moves.ToString();

            if (moves > 4)
            {
                // Check for win horizontal
                for (int i = 0; i < gameBoard.GetLength(0); i++)
                {
                    mylist.Clear();
                    mylist.Add(gameBoard[i, 0]);
                    mylist.Add(gameBoard[i, 1]);
                    mylist.Add(gameBoard[i, 2]);
                    allElementsAreEqual = mylist.All(x => (x == mylist.First()));

                    if (allElementsAreEqual)
                    {
                        MessageBox.Show($"Player {gameBoard[i, 0]} wins");
                        moves = 9;
                        break;
                    }
                }

                // Check for win vertical
                for (int i = 0; i < gameBoard.GetLength(0); i++)
                {
                    mylist.Clear();
                    mylist.Add(gameBoard[0, i]);
                    mylist.Add(gameBoard[1, i]);
                    mylist.Add(gameBoard[2, i]);
                    allElementsAreEqual = mylist.All(x => (x == mylist.First()));

                    if (allElementsAreEqual)
                    {
                        MessageBox.Show($"Player {gameBoard[i, 0]} wins");
                        moves = 9;
                        break;
                    }
                }

                // Diagonal check 1
                mylist.Clear();
                mylist.Add(gameBoard[0, 0]);
                mylist.Add(gameBoard[1, 1]);
                mylist.Add(gameBoard[2, 2]);
                allElementsAreEqual = mylist.All(x => (x == mylist.First()));

                if (allElementsAreEqual)
                {
                    MessageBox.Show($"Player {gameBoard[0, 0]} wins");
                    moves = 9;
                }

                // Diagonal check 2
                mylist.Clear();
                mylist.Add(gameBoard[0, 2]);
                mylist.Add(gameBoard[1, 1]);
                mylist.Add(gameBoard[2, 0]);
                allElementsAreEqual = mylist.All(x => (x == mylist.First()));

                if (allElementsAreEqual)
                {
                    MessageBox.Show($"Player {gameBoard[0, 2]} wins");
                    moves = 9;
                }
            }

            if (moves == 9)
            {
                MessageBox.Show("END");
            }
        }
    }
}
