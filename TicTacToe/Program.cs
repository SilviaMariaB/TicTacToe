using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        static char[] spaces = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag;

        /// <summary>
        /// Draws the game board
        /// </summary>
        static void DrawBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", spaces[0], spaces[1], spaces[2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", spaces[3], spaces[4], spaces[5]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", spaces[6], spaces[7], spaces[8]);
            Console.WriteLine("     |     |     ");
        }

        static bool CheckLine(int a, int b, int c)
        {
            return (spaces[a] == spaces[b] && spaces[b] == spaces[c]);
        }
        static bool CheckTie()
        {
            int check = 0;
            for (int i = 0; i < spaces.Length; i++) {
                if(spaces[i].ToString() != (i + 1).ToString())
                {
                    check++;
                }
            } 
            
            return check==9;
        }
        /// <summary>
        /// Checks if the game was won, tied or should continue
        /// </summary>
        /// <returns></returns>
        static int CheckWin()
        {
            if (CheckLine(0, 1, 2) || CheckLine(3, 4, 5) || CheckLine(6, 7, 8) ||
               CheckLine(0, 3, 6) || CheckLine(1, 4, 7) || CheckLine(2, 5, 8) ||
                CheckLine(0, 4, 8) || CheckLine(2, 4, 6))
            {
                return 1;
            }
            else if (CheckTie()) { return -1; }
            else { return 0; }
        }

        static void DrawSign(int pos, char sign)
        {
            spaces[pos] = sign;
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1 : X and Player 2 : O" + "\n");

                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2's turn");
                }
                else
                {
                    Console.WriteLine("Player 1's turn");
                }
                Console.WriteLine("\n");
                DrawBoard();

                choice = int.Parse(Console.ReadLine()) - 1;

                if (spaces[choice] != 'X' && spaces[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        DrawSign(choice, 'O');
                    }
                    else
                    {
                        DrawSign(choice, 'X');
                    }
                    player++;
                }
                else
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1} \n", choice, spaces[choice]);
                    Console.WriteLine("Please wait 2 seconds, the board is loading again...");
                    Thread.Sleep(2000);
                }
                flag = CheckWin();
            } while (flag != 1 && flag != -1);

            Console.Clear();
            DrawBoard();

            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won!", (player%2)+1);
            }
            else { Console.WriteLine("Tie game"); }

            Console.ReadLine();
        }
    }
}
