
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// Class: HexGrid
// This class houses our hex grid chunks, which in turn house the individual 
// cells. This class also keeps a global list of all active units.

public class HexGrid : MonoBehaviour
{
    // Variable: chunkCountX
    // Sets the number of chunks we want on the x axis.

    // Variable: chunkCountZ
    // Sets the number of chunks we want on the z axis.

    public int chunkCountX = 4, chunkCountZ = 3;

    int cellCountX, cellCountZ;

    // Variable: cellPrefab
    // A reference to the prefab for hex cells.
    public HexCell cellPrefab;
    List<HexUnit> units = new List<HexUnit>();


    HexCell[] cells;

    // Variable: cellLabelPrefab
    // A reference to the UI elsement for the label showing the coordinates of a cell
    public Text cellLabelPrefab;
    
    // Variable: cellIconPrefab;
    // A reference to the only currently existing icon that can be added to cells.
    public Image cellIconPrefab;

    // public Image blankPrefab;

    // Canvas gridCanvas;
    // HexMesh hexMesh;

    // Variable: defaultColor
    // The color that is selected if no color is set on the color picker in the UI.

    public Color defaultColor = Color.white;


    // Variable: chunkPrefab
    // Reference to the prefab for the grid chunk game object.
    public HexGridChunk chunkPrefab;
    HexGridChunk[] chunks;

    HexCell[] hasTowns;

    private void Awake()
    {
     //   gridCanvas = GetComponentInChildren<Canvas>();
     //   hexMesh = GetComponentInChildren<HexMesh>();

        cellCountX = chunkCountX * HexMetrics.chunkSizeX;
        cellCountZ = chunkCountZ * HexMetrics.chunkSizeZ;

        CreateChunks();
        CreateCells();
    }

    void CreateChunks () {
         chunks = new HexGridChunk[chunkCountX * chunkCountZ];

         for (int z= 0, i=0; z < chunkCountZ; z++) {
             for (int x = 0; x < chunkCountX; x++) {
                HexGridChunk chunk = chunks[i++] = Instantiate(chunkPrefab);
                chunk.transform.SetParent(transform);
              }
          }
        
    }

    void CreateCells()
    {
        cells = new HexCell[cellCountZ * cellCountX];

        for(int z = 0, i=0; z < cellCountZ; z++)
        {
            for (int x = 0; x < cellCountX; x++)
            {
                CreateCell(x, z, i++);
            }
        }
    }

    
    /*
     * Function: GetCell
     * This method returns the cell in the position given by finding out the
     * coordinates of the cell in the grid, and using them to find the cell in the 
     * master array of all cells. 
     * 
     * When called on with a Ray, it feeds the ray's hit.point as the position.
     * 
     * Parameters:
     *  
     *      position - the position vector for where we are looking for a cell
     *      ray - a ray that checks if there is a cell there-
     *  
     *  Returns:
     *  
     *      The hex in that position, if any.
     *  
     */

    public HexCell GetCell(Vector3 position)
    {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        int index = coordinates.X + coordinates.Z * cellCountX + coordinates.Z / 2;
        return cells[index];
        
    }
    
    public HexCell GetCell(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return GetCell(hit.point);
        }
        return null;
    }

    //public void Refresh ()
    //{
    //    hexMesh.Triangulate(cells);
    //}

    void CreateCell (int x, int z, int i)
    {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f);

        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.localPosition = position;
        cell.worldPosition = position;

        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
        cell.Color = defaultColor;

        if (x>0)
        {
            cell.SetNeighbor(HexDirection.W, cells[i - 1]);
        }
        if (z>0)
        {
            if ((z & 1) ==0)
            {
                cell.SetNeighbor(HexDirection.SE, cells[i - cellCountX]);
                if (x>0)
                {
                    cell.SetNeighbor(HexDirection.SW, cells[i - cellCountX - 1]);
                }
            } 
            else
            {
                cell.SetNeighbor(HexDirection.SW, cells[i - cellCountX]);
                if (x < cellCountX -1) {
                    cell.SetNeighbor(HexDirection.SE, cells[i - cellCountX + 1]);
                }
            }
        }

        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
        label.text = cell.coordinates.ToStringOnSeparateLines();
        cell.uiRect = label.rectTransform;

        //Image icon = Instantiate<Image>(cellIconPrefab);
        //icon.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
        //cell.uiRect = icon.rectTransform;


        AddCellToChunk(x, z, cell);
    }

    void AddCellToChunk(int x, int z, HexCell cell)
    {
        int chunkX = x / HexMetrics.chunkSizeX;
        int chunkZ = z / HexMetrics.chunkSizeZ;
        HexGridChunk chunk = chunks[chunkX + chunkZ * chunkCountX];

        int localX = x - chunkX * HexMetrics.chunkSizeX;
        int localZ = z - chunkZ * HexMetrics.chunkSizeZ;
        chunk.AddCell(localX + localZ * HexMetrics.chunkSizeX, cell);

    }

    /* Function: AddUnit
     * 
     * Adds a unit to the grid.
     * 
     * Parameters:
     *  
     *  unit - the unit in question
     *  location - the unit's location
     *  orientation - the orientation of the unit (purely for looks)
     *  
     */


    public void AddUnit (HexUnit unit, HexCell location, float orientation)
    {
        units.Add(unit);

        unit.transform.SetParent(transform, false);
        unit.Location = location;
        unit.Orientation = orientation;
    }

    /*
     * Function: RemoveUnit
     * 
     * parameters: 
     * 
     *  unit - the unit to be removed
     *  
     */

    public void RemoveUnit (HexUnit unit)
    {
        units.Remove(unit);
        unit.Die();
    }


    /* 
     * Function: getUnit
     * 
     * Parameters: 
     * 
     *  index - the index of the unit in the master list
     *  
     * Returns:
     * 
     *  the HexUnit in that index of the master list.
     */

    public HexUnit getUnit (int index)
    {
        return units[index];
    }

    /*
     * Function: MakeMoves
     * 
     * Initiates move orders for all units in the master list.
     * 
     */
     
    public void MakeMoves()
    {
        for (int i = 0; i < units.Count; i++)
        {
            units[i].MakeMove();
        }
    }
}
