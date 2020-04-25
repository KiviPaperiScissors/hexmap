
using UnityEngine;

[System.Serializable]

// Struct: HexCoordinates
// This struct defines the coordinates (x,y,z) in the hex grid. As the third coordinate
// in the grid is derived from the other two, only two variables need to be given.
public struct HexCoordinates
{
    [SerializeField]
    private int x, z;

    public int X
    {
        get
        {
            return x;
        }
    }

    public int Z
    {
        get
        {
            return z;
        }
    }

    
    public int Y
    {
        get
        {
            return -X - Z;
        }
    }
    
    public HexCoordinates (int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    

    public static HexCoordinates FromOffsetCoordinates (int x, int z)
    {
        return new HexCoordinates(x -z / 2, z);
    }

    public override string ToString()
    {
        return "(" + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
    }

    public string ToStringOnSeparateLines()
    {
        return X.ToString() + "\n" + Y.ToString() + "\n" + Z.ToString();
    }

    // Function: FromPosition
    // This function returns the coordinates of a certain position in the worldspace.

    public static HexCoordinates FromPosition (Vector3 position)
    {
        float x = position.x / (HexMetrics.innerRadius * 2f);
        float y = -x;

        float offset = position.z / (HexMetrics.outerRadius * 3f);
        x -= offset;
        y -= offset;

        int iX = Mathf.RoundToInt(x);
        int iY = Mathf.RoundToInt(y);
        int iZ = Mathf.RoundToInt(-x -y);

        if (iX + iY + iZ != 0)
        {
            float dX = Mathf.Abs(x - iX);
            float dY = Mathf.Abs(y - iY);
            float dZ = Mathf.Abs(-x - y - iZ);

            if (dX > dY && dX > dZ) {
                iX = -iY - iZ;
            }
            else if (dZ > dY)
            {
                iZ = -iX - iY;
            }

        }

        return new HexCoordinates(iX, iZ);


    }
}
