using System;

public class Player:Men,IMovable
{
    private int position;
    public int Position
    {
        get
        {
            return position;
        }
        set
        {
            if (value > 0 && value <= GameOption.sizeOfMap)
                position = value;
        }
    }
    
    public Player(string n,int s,int p):base(n,s)
    {
        name = n;
        
        Speed = s;
        position = p;
    }
    
    public int Move(char direction)
    {
        switch (direction)
        {
            case 'w':
                {
                    return -(int)Math.Sqrt(GameOption.sizeOfMap)*Speed;
                }
            case 's':
                {
                    return +(int)Math.Sqrt(GameOption.sizeOfMap)*Speed;
                }
            case 'a':
                {
                    return -Speed;
                }
            case 'd':
                {
                    return Speed;
                }
            default:
                return 0;
        }

    }

}
public interface IMovable
{
    int Move(char direction);
}
