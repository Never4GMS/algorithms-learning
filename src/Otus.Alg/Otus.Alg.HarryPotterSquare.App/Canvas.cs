namespace Otus.Alg.HarryPotterSquare.App;

internal class Canvas
{
    private readonly int _width;
    private readonly int _hight;

    public int Width => _width;
    public int Hight => _hight;

    public int Y { get; set; }
    public int X { get; set; }

    public Canvas(int width, int hight)
    {
        _width = width;
        _hight = hight;
    }

    public void Write(string text)
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(text);
    }

    public void FillWithFilter(Func<int, int, bool> filter, char positive, char negative)
    {
        for (var x = X; x < X + _hight; x++)
        {
            for (var y = Y; y < Y + _width; y++)
            {
                FillCell(x, y, filter(x - X, y - Y) ? positive : negative);
            }
            Console.WriteLine();
        }
        Console.SetCursorPosition(X, Y);
    }

    public void FillCell(int x, int y, char symbol)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(symbol);
    }
}
