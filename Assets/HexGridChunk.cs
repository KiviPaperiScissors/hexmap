using UnityEngine.UI;
using UnityEngine;

public class HexGridChunk : MonoBehaviour
{
    HexCell[] cells;

    HexMesh hexMesh;

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
    */
    public void RemoveIcon(HexCell cell)
    {

    }

    public void Refresh()
    {
        hexMesh.Triangulate(cells);
    }

}
