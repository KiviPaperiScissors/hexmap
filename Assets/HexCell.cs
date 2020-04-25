
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

// Class: HexCell
// This class determines the characteristics of a single hexagonal cell in the grid.


public class HexCell : MonoBehaviour
{
    // Variable: coordinates
    // The cell's coordinates in the hex grid.
    public HexCoordinates coordinates;

    // Variable: worldPosition
    // The cells exaxt position in the scene.
    // Rendered obsolete by the Position variable.
    public Vector3 worldPosition;

    // Variable: units
    // The amount of units present in the cell.
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

    /* Function: UnitEnters
     * 
     * Reacts when a unit enters the cell. If more than one unit is present
     * their positions will be offset so that they do not overlap, as long as 
     * there are no more than five units in the same cell.
     * 
     * Parameters:
     * 
     *  unit - The unit currently entering the cell.
     *  
    */ 

    public void UnitEnters(HexUnit unit)
    {
        unitsInCell++;
        Debug.Log("Units in cell count: " + unitsInCell);
        unit.OffsetLocation(unitsInCell);
        units.Add(unit);

    }

    /* Function: UnitEnters
    * 
    * Reacts when a unit leaves the cell. The remaining units, if any
    * readjust their positions. 
    * 
    * Parameters:
    * 
    *  unit - The unit currently leaving the cell.
    *  
    */
    public void UnitLeaves(HexUnit unit)
    {
        unitsInCell--;
        units.Remove(unit);
        for (var i = 1; i <= units.Count; i++)
        {
            units[i-1].OffsetLocation(i);
        }
    }

    /*
     * Variable: Position
     * Returns the position of the cell's transform.
     * 
     */
      
    public Vector3 Position
    {
        get
        {
            return transform.localPosition;
        }
    }


    // Variable: Position
    // Added just to make the code work with how the tutorial was written
    // not so necessary, since we do not feature heighdifferences and such
    // in our version of the hex map project.
    //
    // Left in because I have not figured out how to leave it out yet.
    


    public RectTransform uiRect;

    // Variable: cellIconPrefab
    // This variable holds the icon image for the cell, if any.

    public Image cellIconPrefab;
    
    // Variable: chunk
    // This variable keeps track of which grid chunk the cell belongs to.
    public HexGridChunk chunk;


    // Variable: Color
    // this keeps track of the cell's color.
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

    // Variable: HasTown
    // This variable tracks whether a cell has an icon on it
    // Currently the only available icon is the town icon
    //
    // If a town icon is set on the cell, this variable's setter
    // instantiates a prefab icon, and sets on top of the cell.
    // The setter also can remove the town icon, when needed.

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

    /* Function: GetNeighbor
    * This function returns the neighboring cell, if one exists, in a particular direction.
    *
    * Parameters:
    * 
    *   directions - The direction in which the method looks for a neighbor.
    *   
    * Returns:
    * 
    *   The neighboring cell in the requested direction.
    */

    public HexCell GetNeighbor (HexDirection direction)
    {
        return neighbors[(int)direction];
    }

    /* Function: SetNeighbor
     * This function records the neighbors of the current cell into an array.
     *
     * Parameters:
     *   directions - The direction in which the method looks for a neighbor.
     *   cell - The cell that will be set as a neighbor to the current cell.
     */

    public void SetNeighbor (HexDirection direction, HexCell cell)
    {
        neighbors[(int)direction] = cell;
        cell.neighbors[(int)direction.Opposite()] = this;
    }

    // Function: RemoveTown
    // This function removes a town icon from the cell.
    public void RemoveTown()
    {
        if (!hasTown)
        {
            return;
        }
        hasTown = false;
        Refresh();
    }

    // Function: Refresh
    // Because the cell's color is created in the HexMesh, this method calls 
    // the refresh method of the grid chunk, which in turn retriangulates the chunk.

    void Refresh ()
    {
        if (chunk)
        {
            chunk.Refresh();
        }
    }




}
