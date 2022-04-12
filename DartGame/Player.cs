internal class Player
{
    public string Name { get; set; }
    private List<Turns> turns = new List<Turns>();
    
    public void AddTurn(int dartOne, int dartTwo, int dartThree)
    {
        Turns turn = new(dartOne, dartTwo, dartThree);
        turns.Add(turn);
    }
    public int Calculatepoints()
    {
        int score = 0;
        foreach(Turns turn in turns)
        {
            score += turn.GetScore();
        }
        if (score > 301)
        {
            turns.RemoveAt(turns.Count - 1);
        }
        if(score == 301)
        {
            PrintTurns();
        }
        return score;
    }
    private void PrintTurns()
    {
        foreach(Turns turn in turns)
        {
            Console.WriteLine(turn.ToString());
        }
    }
}