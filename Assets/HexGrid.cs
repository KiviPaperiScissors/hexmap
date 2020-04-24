
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class HexGrid : MonoBehaviour
{
    public int chunkCountX = 4, chunkCountZ = 3;

    int cellCountX, cellCountZ;

    public HexCell cellPrefab;
    List<HexUnit> units = new List<HexUnit>();


    HexCell[] cells;


    public Text cellLabelPrefab;
    public Image cellIconPrefab;

    // public Image blankPrefab;

    // Canvas gridCanvas;
    // HexMesh hexMesh;

    public Color defaultColor = Color.white;

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

    public void AddUnit (HexUnit unit, HexCell location, float orientation)
    {
        units.Add(unit);

        unit.transform.SetParent(transform, false);
        unit.Location = location;
        unit.Orientation = orientation;
    }

    public void RemoveUnit (HexUnit unit)
    {
        units.Remove(unit);
        unit.Die();
    }

    public HexUnit getUnit (int index)
    {
        return units[index];
    }

    public void MakeMoves()
    {
        for (int i = 0; i < units.Count; i++)
        {
            units[i].MakeMove();
        }
    }
}
