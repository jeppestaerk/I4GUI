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
using System.ComponentModel;

namespace _04TriggerAndStyle
{
   // TODO: update prose implementation of this class
   // TODO: update prose that talks about how this doesn't use INPC ('cuz now it does)
   public class PlayerMove : INotifyPropertyChanged
   {
      string playerName;
      public string PlayerName
      {
         get { return playerName; }
         set
         {
            if (string.Compare(playerName, value) == 0) { return; }
            playerName = value;
            Notify("PlayerName");
         }
      }

      int moveNumber;
      public int MoveNumber
      {
         get { return moveNumber; }
         set
         {
            if (moveNumber == value) { return; }
            moveNumber = value;
            Notify("MoveNumber");
         }
      }

      bool isPartOfWin = false;
      public bool IsPartOfWin
      {
         get { return isPartOfWin; }
         set
         {
            if (isPartOfWin == value) { return; }
            isPartOfWin = value;
            Notify("IsPartOfWin");
         }
      }

      public PlayerMove(string playerName, int moveNumber)
      {
         this.playerName = playerName;
         this.moveNumber = moveNumber;
      }

      // INotifyPropertyChanged Members
      public event PropertyChangedEventHandler PropertyChanged;
      void Notify(string propName)
      {
         if (PropertyChanged != null)
         {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
         }
      }
   }

   public partial class Window1 : System.Windows.Window
   {
      // Track the current player (X or O)
      string currentPlayer;

      // Track the move sequence per game
      int moveNumber;

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
            cell.ClearValue(Button.ContentProperty);
         }
         CurrentPlayer = "X";
         this.moveNumber = 0;
      }

      void cell_Click(object sender, RoutedEventArgs e)
      {
         Button button = (Button)sender;

         // Don't let multiple clicks change the player for a cell
         if (button.Content != null) { return; }

         // Set button content
         button.Content = new PlayerMove(this.CurrentPlayer, ++this.moveNumber);

         // Only allow each player to have three moves on at once
         Button[] currentPlayerButtons = Array.FindAll(
               this.cells,
               delegate(Button it) { return it.Content != null && ((PlayerMove)it.Content).PlayerName == this.currentPlayer; });
         if (currentPlayerButtons.Length == 4)
         {
            Button earliestButton = currentPlayerButtons[0];
            Array.ForEach(
              currentPlayerButtons,
              delegate(Button it)
              {
                 if (((PlayerMove)it.Content).MoveNumber < ((PlayerMove)earliestButton.Content).MoveNumber)
                 {
                    earliestButton = it;
                 }
              });
            earliestButton.Content = null;
         }

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
               if (possibleWins[i, j].Content == null || ((PlayerMove)possibleWins[i, j].Content).PlayerName != player)
               {
                  hasWon = false;
                  break;
               }
            }

            if (hasWon)
            {
               for (int j = 0; j != possibleWins.GetLength(1); ++j)
               {
                  ((PlayerMove)possibleWins[i, j].Content).IsPartOfWin = true;
               }

               return true;
            }
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
