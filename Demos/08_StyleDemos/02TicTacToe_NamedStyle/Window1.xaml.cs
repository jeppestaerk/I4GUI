using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _02TicTacToe_NamedStyle
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window
   {
      // Track the current player (X or O)
      string currentPlayer;

      // Track the list of cells for finding a winner etc.
      Button[] cells;

      public Window1()
      {
         InitializeComponent();

         // Cache the list of buttons and handle their clicks
         this.cells = new Button[] { this.cell00, this.cell01, this.cell02, this.cell10, this.cell11, this.cell12, this.cell20, this.cell21, this.cell22 };
         foreach (Button cell in this.cells)
         {
            cell.Click += cell_Click;
         }

         // Initialize a new game
         NewGame();
      }

      string CurrentPlayer
      {
         get { return this.currentPlayer; }
         set
         {
            this.currentPlayer = value;
            this.statusTextBlock.Text = "It's your turn, " + this.currentPlayer;
         }
      }

      // Use the buttons to track game state
      void NewGame()
      {
         foreach (Button cell in this.cells)
         {
            cell.Content = null;
         }
         CurrentPlayer = "X";
      }

      void cell_Click(object sender, RoutedEventArgs e)
      {
         //MessageBox.Show(string.Format("statusTextBlock.IsCancelProperty= {0}", statusTextBlock.GetValue(Button.IsCancelProperty)));

         Button button = (Button)sender;

         // Don't let multiple clicks change the player for a cell
         if (button.Content != null) { return; }

         // Set button content
         button.Content = CurrentPlayer;

         // Check for winner or a tie
         if (HasWon(this.currentPlayer))
         {
            MessageBox.Show("Winner!", "Game Over");
            NewGame();
            return;
         }
         else if (TieGame())
         {
            MessageBox.Show("No Winner!", "Game Over");
            NewGame();
            return;
         }

         // Switch player
         if (CurrentPlayer == "X")
         {
            CurrentPlayer = "O";
         }
         else
         {
            CurrentPlayer = "X";
         }
      }

      // Use this.cells to find a winner or a tie
      bool HasWon(string player)
      {
         Button[,] possibleWins = {
      // row
      { this.cell00, this.cell01, this.cell02, },
      { this.cell10, this.cell11, this.cell12, },
      { this.cell20, this.cell21, this.cell22, },

      // column
      { this.cell00, this.cell10, this.cell20, },
      { this.cell01, this.cell11, this.cell21, },
      { this.cell02, this.cell12, this.cell22, },

      // diagonal
      { this.cell00, this.cell11, this.cell22, },
      { this.cell02, this.cell11, this.cell20, },
    };

         for (int i = 0; i != possibleWins.GetLength(0); ++i)
         {
            bool hasWon = true;
            for (int j = 0; j != possibleWins.GetLength(1); ++j)
            {
               if (possibleWins[i, j].Content == null || (string)possibleWins[i, j].Content != player)
               {
                  hasWon = false;
                  break;
               }
            }
            if (hasWon) { return true; }
         }

         return false;
      }

      bool TieGame()
      {
         foreach (Button cell in this.cells)
         {
            if (cell.Content == null)
            {
               return false;
            }
         }
         return true;
      }
   }
}
