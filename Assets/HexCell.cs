
using UnityEngine.UI;
using UnityEngine;


public class HexCell : MonoBehaviour
{
    public HexCoordinates coordinates;
    public Vector3 worldPosition;

    public RectTransform uiRect;
    public Image cellIconPrefab;

    public Color Color
    {
        get
        {
            return color;
        }
        set
        {
            if (color == value)
            {
                return;
            }
            color = value;
            Refresh();
        }
    }

    Color color;

    Image icon; 

    public bool HasTown
    {
        get
        {
            return hasTown;
        }
        set
        {
            if (HasTown == value)
            {
                return;
            }
            hasTown = value;
            Debug.Log("hasTown set to " + value);
            if (hasTown)
            {
                Debug.Log("town value is set");
                icon = Instantiate<Image>(cellIconPrefab);
                icon.rectTransform.anchoredPosition3D = 
                    new Vector3(worldPosition.x, 1f, worldPosition.z);
                Refresh();
                

            } else
            {
                Debug.Log("destroying icon");
                Destroy(icon);
                Refresh();
            }
            
        }
    }

    bool hasTown;



    [SerializeField]
    HexCell[] neighbors;

    public HexGridChunk chunk;

    public HexCell GetNeighbor (HexDirection direction)
    {
        return neighbors[(int)direction];
    }

    public void SetNeighbor (HexDirection direction, HexCell cell)
    {
        neighbors[(int)direction] = cell;
        cell.neighbors[(int)direction.Opposite()] = this;
    }

    public void RemoveTown()
    {
        if (!hasTown)
        {
            return;
        }
        hasTown = false;
        Refresh();
    }

    void Refresh ()
    {
        if (chunk)
        {
            chunk.Refresh();
        }
    }




}
