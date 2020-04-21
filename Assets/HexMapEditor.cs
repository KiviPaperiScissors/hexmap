
using UnityEngine;
using UnityEngine.EventSystems;

public class HexMapEditor : MonoBehaviour
{
    public Color[] colors;

    public HexGrid hexGrid;

    private Color activeColor;

    private void Awake()
    {
        SelectColor(0);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) &&
            !EventSystem.current.IsPointerOverGameObject())
        {
            HandleInput();
            
        }
    }

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            EditCell(hexGrid.GetCell(hit.point));
           
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
