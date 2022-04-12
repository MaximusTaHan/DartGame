internal class Turns
{
    private int dartOne;
    private int dartTwo;
    private int dartThree;

    public Turns(int first, int second, int third)
    {
        dartOne = first;
        dartTwo = second;
        dartThree = third;
    }

    public int GetScore()
    {
        return dartOne + dartTwo + dartThree;
    }

    public override string ToString()
    {
        return $"First throw: {dartOne}. Second throw: {dartTwo}. Third throw: {dartThree}";
    }
}