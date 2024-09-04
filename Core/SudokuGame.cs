namespace my_sudoku_game.Core;

public class SudokuGame
{
    private const int _size = GlobalSettings.SUDOKU_SIZE;
    private static int[,] _board = new int[_size, _size];
    private static SudokuGame _instance = null;

    private SudokuGame() { }

    public static SudokuGame Instance()
    {
        if (_instance == null)
        {
            _instance = new SudokuGame();
            InitializeBoard();
        }
        return _instance;
    }

    public static void InitializeBoard()
    {
        // Initialize 
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                _board[i, j] = 0; // Zero can represent an empty cell
            }
        }
    }

    private void PrintBoard()
    {
        for (int i = 0; i < _size; i++)
        {
            if (i != 0 && i % 3 == 0)
                Console.WriteLine("- - - - - - - - - - -");
            for (int j = 0; j < _size; j++)
            {
                if (j != 0 && j % 3 == 0)
                    Console.Write("| ");
                Console.Write(_board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public bool IsValidMove(int row, int col, int num)
    {
        for (int i = 0; i < _size; i++) // validate through the whole col and row respectively
        {
            if (_board[row, i] == num || _board[i, col] == num)
                return false;
        }

        int startRow = row / 3 * 3;
        int startCol = col / 3 * 3;

        for (int i = startRow; i < startRow + 3; i++) // validate inside the 3x3 matrix
        {
            for (int j = startCol; j < startCol + 3; j++)
            {
                if (_board[i, j] == num)
                    return false;
            }
        }

        return true;
    }

    private void PlaceNumber(int row, int col, int num)
    {
        if (IsValidMove(row, col, num))
        {
            _board[row, col] = num;
        }
        else
        {
            Console.WriteLine("Invalid move!");
        }
    }

    public void Play()
    {
        while (true)
        {
            PrintBoard();
            Console.Write("Enter row (1-9): ");
            int row = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Enter column (1-9): ");
            int col = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Enter number (1-9): ");
            int num = int.Parse(Console.ReadLine());

            PlaceNumber(row, col, num);

            if (IsGameWon())
            {
                Console.WriteLine("Congratulations! You've solved the sudoku.");
                break;
            }
        }
    }

    private bool IsGameWon() // not won until all positions are filled
    {
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if (_board[i, j] == 0)
                    return false;
            }
        }
        return true;
    }
}
