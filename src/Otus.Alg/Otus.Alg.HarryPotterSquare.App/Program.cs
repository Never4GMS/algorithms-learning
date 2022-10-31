const int Columns = 3;
const int spacing = 4;
const int SquareSize = 25;
const int Size = SquareSize - 1; // Начало от 0
var canvas = new SquareCanvas(SquareSize);

var spellBook = new Dictionary<byte, (Func<int, int, bool> spell, string description)>
{
    //[1] = ((x, y) => x > y, "x > y"),
    //[2] = ((x, y) => x == y, "x = y"),
    //[3] = ((x, y) => y == Size - x, "y = S-x"),
    //[4] = ((x, y) => y < Size + 5 - x, "y < S+5-x"),
    //[6] = ((x, y) => x < 10 || y < 10, "x<10 | y<10"),
    //[7] = ((x, y) => x > Size - 9 && y > Size - 9, "x>S-9 & y>S-9"),
    //[8] = ((x, y) => Math.Abs(x - y) == (x + y), "|x-y| = x+y"),
    //[9] = ((x, y) => x + 10 < y || x - 10 > y, "x+10<y | x-10>y"),
    //[10] = ((x, y) => x > y && x - 2 < Size / 12 * y, "x>y & x-2<S/12*y"),
    //[11] = ((x, y) => (x - 1) % (Size - 2) == 0 || (y - 1) % (Size - 2) == 0, "(x-1)%(S-2)=0|(y-1)%(S-2)=0"),
    //[12] = ((x, y) => Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(Size - 4, 2), "x^2+y^2 <= (S-4)^2"),
    //[13] = ((x, y) => y - 5 < Size - x && y + 5 > Size - x, "y-5<S-x & y+5>S-x"),
    [14] = ((x, y) => Math.Pow(Size - x, 2) + Math.Pow(Size - y, 2) >= Math.Pow(Size - 4, 2), "(S-x)^2+(S-y)^2 >= (S-4)^2")
};

var column = 0;
foreach (var page in spellBook)
{
    var (spell, description) = page.Value;

    canvas.X = column * canvas.Width + column * spacing;
    canvas.Y = 0;

    canvas.Write($"Spell #{page.Key}");
    canvas.Y++;
    canvas.Write(description);
    canvas.Y++;

    canvas.FillWithFilter(spell, '#', '.');

    column = (column + 1) % Columns;

    if (column == 0)
    {
        Console.ReadKey();
        Console.Clear();
    }
}

Console.SetCursorPosition(0, canvas.Hight + 1);
Console.ReadKey();
