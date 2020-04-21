
using UnityEngine.UI;
using UnityEngine;


public class HexCell : MonoBehaviour
{
    public HexCoordinates coordinates;
    public Vector3 worldPosition;

    public RectTransform uiRect;
    public Image cellIconPrefab;
    

    public HexGridChunk chunk;

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
                    new Vector3(worldPosition.x, 0.2f, worldPosition.z);
                icon.transform.SetParent(transform, true);
                icon.rectTransform.SetParent(chunk.GridCanvas.transform, true);

                // chunk.AddIcon(this);



            } else
            {
                Debug.Log("trying to destroy icon");
                Destroy(icon);
                
            }
            
        }
    }

    bool hasTown;



    [SerializeField]
    HexCell[] neighbors;

    

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
