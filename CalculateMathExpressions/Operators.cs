public static class Operators
{
    public static Dictionary<char, int> OperationPriority = new() {
        {'(', 0},
        {'+', 1},
        {'-', 1},
        {'*', 2},
        {'/', 2},
        {'^', 4},
        {'~', 5},
        {'$', 5}
    };
}