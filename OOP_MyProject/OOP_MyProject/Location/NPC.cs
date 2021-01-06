using System;

public class NPC:Player
{
	public NPC(string n,int s,int pos) : base(n, s, pos)
    {
        name = n;
        Speed = s;
        Position = pos;
    }

    public int Move()
    {
        var rand = new Random();
        switch (rand.Next(1, 4))
        {
            case 1: return 1;
            case 2: return -1;
            case 3: return (int)Math.Sqrt(GameOption.sizeOfMap);
            case 4: return -(int)Math.Sqrt(GameOption.sizeOfMap);
            default: return 0;
        }
    }
}
