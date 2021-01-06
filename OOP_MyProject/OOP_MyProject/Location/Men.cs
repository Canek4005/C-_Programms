using System;

public class Men
{
	public string name;
   
    private int speed;
    public int Speed
    {
        get
        {
            return speed;
        }
        set
        {
            if(value>0&&value<=3)
            speed = value;
        }
    }
	
	public Men(string n,int s)
    {
        name = n;
        
        Speed = s;
    }
}
