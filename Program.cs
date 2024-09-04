using my_sudoku_game.Core;

namespace my_sudoku_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello to my sudoku! \n");           
            
            SudokuGame instanceSudokuGame = SudokuGame.Instance();
            instanceSudokuGame.Play();
        }
    }
}
