
using UnityEngine;

public class HexUnit : MonoBehaviour
{
public HexCell Location
    {
        get
        {
            return location;
        }
        set
        {
            location = value;
            value.Unit = this;
            transform.localPosition = value.Position;
        }
    }

    HexCell location;

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

    public void OffsetLocation(int index)
    {
        switch (index)
        {
            case 5:
                Debug.Log("Case 0");
                break;

            case 0:
                Debug.Log("Case 1");
                transform.localPosition = 
                    new Vector3(location.Position.x, location.Position.y, location.Position.z + 4);
                break;
            case 1:
                Debug.Log("Case 2");
                transform.localPosition =
                    new Vector3(location.Position.x+4, location.Position.y, location.Position.z);
                break;
            case 2:
                transform.localPosition =
                    new Vector3(location.Position.x, location.Position.y, location.Position.z - 4);
                break;
            case 3:
                transform.localPosition =
                    new Vector3(location.Position.x-4, location.Position.y, location.Position.z);
                break;
        }

    }
}
