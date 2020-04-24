
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;


public class HexCell : MonoBehaviour
{
    public HexCoordinates coordinates;
    public Vector3 worldPosition;

    public List<HexUnit> units;
    /*  public HexUnit Unit
      {
          get { return Unit; }

          set
          {
              units.Add(value);
              if (units.Count > 1)
              {
                  Debug.Log("Units in List:" + units.Count);
                  for (var i = 0; i < units.Count; i++)
                  {
                      units[i].OffsetLocation(i);
                  }
              }

          }
      }
      */

    int unitsInCell;

    public void UnitEnters(HexUnit unit)
    {
        unitsInCell++;
        Debug.Log("Units in cell count: " + unitsInCell);
        unit.OffsetLocation(unitsInCell);
        units.Add(unit);

    }

    public void UnitLeaves(HexUnit unit)
    {
        unitsInCell--;
        units.Remove(unit);
        for (var i = 1; i <= units.Count; i++)
        {
            units[i-1].OffsetLocation(i);
        }
    }


    public Vector3 Position
    {
        get
        {
            return transform.localPosition;
        }
    }

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
