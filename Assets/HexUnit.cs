
using UnityEngine;

// Class: HexUnit
// This class defines the qualities of a generic unit.

public class HexUnit : MonoBehaviour
{
    // Variable: Position
    // This variable relates the position of the unit's transform.

    public Vector3 Position
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
            transform.localPosition = position;
        }

    }

    Vector3 position;


    // Variable: Location
    // This variable relates to the cell in which the unit is currently in.

    public HexCell Location
    {
        get
        {
            return location;
        }
        set
        {
            location = value;
            Position = value.Position;
            value.UnitEnters(this);
            
        }
    }

    HexCell location;


    // Variable: Orientation
    // This variable determines the orientation of the unit. Purely cosmetic.

    public float Orientation
    {
        get
        {
            return orientation;
        }
        set
        {
            orientation = value;
            transform.localRotation = Quaternion.Euler(0f, value, 0f);
        }
    }

    float orientation;

    /* Function: OffsetLocation
     * 
     * This function moves the unit in a cell to accomodate multiple units
     * in the same cell without overlapping. 
     * 
     */

    public void OffsetLocation(int index)
    {
        switch (index)
        {
            case 1:
                Debug.Log("Case 0");
                break;

            case 2:
                Debug.Log("Case 1");
                transform.localPosition =
                    new Vector3(location.Position.x, location.Position.y, location.Position.z + 4);
                position = transform.localPosition;
                break;
            case 3:
                Debug.Log("Case 2");
                transform.localPosition =
                    new Vector3(location.Position.x+4, location.Position.y, location.Position.z);
                position = transform.localPosition;
                break;
            case 4:
                transform.localPosition =
                    new Vector3(location.Position.x, location.Position.y, location.Position.z - 4);
                position = transform.localPosition;
                break;
            case 5:
                transform.localPosition =
                    new Vector3(location.Position.x-4, location.Position.y, location.Position.z);
                position = transform.localPosition;
                break;
        }

    }

    // Function: Die
    // Destroys a unit game object.

    public void Die()
    {
        location.UnitLeaves(this);
        Destroy(gameObject);
    }

    // Function: MakeMove
    // Moves the unit. 

    public void MakeMove()
    {
        HexDirection direction = (HexDirection)Random.Range(0, 6);
        if (location.GetNeighbor(direction) != null)
        {
            location.UnitLeaves(this);
            Location = location.GetNeighbor(direction);
        }
    }
}
