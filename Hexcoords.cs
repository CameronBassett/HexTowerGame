using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Hexcoords
{
    public int X { get; private set; }

    public int Z { get; private set; }

    public int Y
    {
        get
        {
            return -X - Z;
        }
    }

    public Hexcoords(int x, int z)
    {
            X = x;
            Z = z;
    }

    public static Hexcoords FromOffsetCoordinates(int x, int z)
    {
        return new Hexcoords(x - z / 2, z);
    }



    public override string ToString()
    {
        return "(" + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
    }

    public string ToStringOnSeparateLines()
    {
        return X.ToString() + "\n" + Y.ToString() + "\n" + Z.ToString();
    }





}
    

