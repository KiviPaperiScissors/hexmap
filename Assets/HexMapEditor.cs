
using UnityEngine;
using UnityEngine.EventSystems;

public class HexMapEditor : MonoBehaviour
{
    public Color[] colors;

    public HexGrid hexGrid;

    public HexUnit unitPrefab; 

    private Color activeColor;

    private void Awake()
    {
        SelectColor(0);
    }

    private void Update()
    {



        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButton(0) &&
                !EventSystem.current.IsPointerOverGameObject())
            {
                HandleInput();
                return;
            }

            if(Input.GetKeyDown(KeyCode.U))
            {
                CreateUnit();
                return;
            }
        }
    }

    void HandleInput()
    {
        HexCell currentCell = GetCellUnderCursor();
        if (currentCell)
        {
            {
                EditCell(currentCell);

            }
        }
    }

    HexCell GetCellUnderCursor()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            return hexGrid.GetCell(hit.point);

        }
        return null;
    }

    void CreateUnit ()
    {
        HexCell cell = GetCellUnderCursor();
        if (cell)
        {
            HexUnit unit = Instantiate(unitPrefab);
            unit.transform.SetParent(hexGrid.transform, false);
            unit.Location = cell;
            unit.Orientation = Random.Range(0f, 360f);
        }
    }


    bool applyColor;


    void EditCell (HexCell cell)
    {
        if (applyColor)
        {
            cell.Color = activeColor;
        }
        
        if (buildTown)
        {
            cell.HasTown = true;
        } else
        {
            cell.HasTown = false;
        }
        

     //    hexGrid.Refresh();
    }

    public void SelectColor (int index)
    {
        applyColor = index >= 0;
        if (applyColor)
        {
            activeColor = colors[index];
        }
    }

    bool buildTown;

    public void SetBuildTown(bool toggle)
    {
        Debug.Log("Build Town set to" + toggle);
        buildTown = toggle;
    }


}
