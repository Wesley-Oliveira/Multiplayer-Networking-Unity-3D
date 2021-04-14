using System;

public class BadGuy : IComparable<BadGuy>
{
    public string name;
    public int strength;

    public int CompareTo(BadGuy other)
    {
        if(other == null)
        {
            return 1;
        }

        return strength - other.strength;
    }

    public BadGuy(string name, int strength)
    {
        this.name = name;
        this.strength = strength;
    }

    public override string ToString()
    {
        return string.Format("Bad Guy ({0}, {1})", name, strength);
    }
}

