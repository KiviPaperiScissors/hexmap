
using UnityEngine;
using UnityEngine.EventSystems;

public class HexMapEditor : MonoBehaviour
{
    public Color[] colors;

    public HexGrid hexGrid;

    public HexUnit unitPrefab; 

    private Color activeColor;

    HexCell currentCell;

    private void Awake()
    {
        SelectColor(0);
        SetEditMode(true);
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
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    DestroyUnit();
                }
                else
                {
                    CreateUnit();
                    return;
                }
            }
        }
    }

    void HandleInput()
    {
        currentCell = GetCellUnderCursor();
        if (currentCell)
        {
            {
                EditCell(currentCell);

            }
        }
    }

    HexCell GetCellUnderCursor()
    {
        return
            hexGrid.GetCell(Camera.main.ScreenPointToRay(Input.mousePosition));
    }



    void CreateUnit ()
    {
        HexCell cell = GetCellUnderCursor();
        if (cell && cell.units.Count < 6) 
        {
            hexGrid.AddUnit(Instantiate(unitPrefab), cell, Random.Range(0f, 360f));
        }
    }

    void DestroyUnit()
    {
        HexCell cell = GetCellUnderCursor();
        if (cell && cell.units.Count > 0)
        {
            HexUnit markedForDeath = cell.units[cell.units.Count - 1];
            Debug.Log("Target position: " + markedForDeath.Position.ToString());
            cell.units.Remove(markedForDeath);
            hexGrid.RemoveUnit(markedForDeath);
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

    public void SetEditMode (bool toggle)
    {
        enabled = toggle;
    }

    bool UpdateCurrentCell()
    {
        HexCell cell =
            hexGrid.GetCell(Camera.main.ScreenPointToRay(Input.mousePosition));
        if (cell != currentCell)
        {
            currentCell = cell;
            return true;
        }
        return false;
    }

  
    public void AdvanceTurn()
    {
        hexGrid.MakeMoves();
    }
}


