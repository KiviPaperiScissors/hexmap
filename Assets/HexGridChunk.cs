using UnityEngine.UI;
using UnityEngine;

//Class: HexGridChunk
//
// This class describes the chunks that hold meshes and cells in our hex grid.



public class HexGridChunk : MonoBehaviour
{
    HexCell[] cells;

    HexMesh hexMesh;

    // Varíable: GridCanvas
    // A reference to the canvas of the hex grid.

    public Canvas GridCanvas
    {
        get
        {
            return gridCanvas;
        }
    }

    Canvas gridCanvas;
    

     

    private void Awake()
    {
        gridCanvas = GetComponentInChildren<Canvas>();
        hexMesh = GetComponentInChildren<HexMesh>();
        

        cells = new HexCell[HexMetrics.chunkSizeX * HexMetrics.chunkSizeZ];
    }

    private void Start()
    {
        hexMesh.Triangulate(cells);
    }

    /* 
     * Function: AddCell
     * 
     * This function adds a cell to a chunk.
     * 
     * Parameters: 
     * 
     *  index - the index of the cell in the cell array.
     *  cell - the created cell to be added.
     *  
     */

    public void AddCell(int index, HexCell cell)
    {
        cells[index] = cell;
        cell.chunk = this;
        cell.transform.SetParent(transform, false);
        cell.uiRect.SetParent(gridCanvas.transform, false);
        
    }
    /*
    public void AddIcon(HexCell cell)
    {
        Image icon = Instantiate<Image>(cell.cellIconPrefab);
        icon.rectTransform.anchoredPosition3D =
            new Vector3(cell.worldPosition.x, 0.2f, cell.worldPosition.z);
        icon.transform.SetParent(transform, false);
        icon.rectTransform.SetParent(gridCanvas.transform, true);

    }
    
    public void RemoveIcon(HexCell cell)
    {

    }
    */

    // Function: Refresh
    //
    // This function retriangulates the cells in the chunk's mesh.

    public void Refresh()
    {
        hexMesh.Triangulate(cells);
    }

}
