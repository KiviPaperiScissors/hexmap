// Class: HexMesh
// A mesh that will hold our HexGrid. 



using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]

public class HexMesh : MonoBehaviour
{

    Mesh hexMesh;
    static List<Vector3> vertices = new List<Vector3>();
    static List<int> triangles = new List<int>(); 
    MeshCollider meshCollider;
    static List<Color> colors = new List<Color>();

    private void Awake()
    {
        GetComponent<MeshFilter>().mesh = hexMesh = new Mesh();
        meshCollider = gameObject.AddComponent<MeshCollider>();
        hexMesh.name = "Hex Mesh";
        //vertices = new List<Vector3>();
        //colors = new List<Color>();
        //triangles = new List<int>();
    }


    // Function: Triangulate
    // Receives an array of cells from HexGridChunk, and passes it to another Triangulate
    // method, which creates a hexagon out of 6 triangles. 

    public void Triangulate(HexCell[] cells)
    {
        hexMesh.Clear();
        vertices.Clear();
        colors.Clear();
        triangles.Clear();
        for (int  i= 0; i < cells.Length; i++) {
            Triangulate(cells[i]);
        }
        hexMesh.vertices = vertices.ToArray();
        hexMesh.colors = colors.ToArray();
        hexMesh.triangles = triangles.ToArray();
        hexMesh.RecalculateNormals();
        meshCollider.sharedMesh = hexMesh;
    }

    // Function: AddTriangle
    // Provide Triangulate with triangels for the creation of hexagons.

    void AddTriangle (Vector3 v1, Vector3 v2, Vector3 v3)
    {
        int vertexIndex = vertices.Count;
        vertices.Add(v1);
        vertices.Add(v2);
        vertices.Add(v3);
        triangles.Add(vertexIndex);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 2);
    }

    void Triangulate (HexCell cell)
    {
        Vector3 center = cell.transform.localPosition;
        for (int i = 0; i < 6; i++)
        {

            AddTriangle(
                center,
                center + HexMetrics.corners[i],
                center + HexMetrics.corners[i+1]
            );

            AddTriangleColor(cell.Color);
        }
    }

    // Function: AddTriangleColor
    // Colors the triangle.

    void AddTriangleColor (Color color)
    {
        colors.Add(color);
        colors.Add(color);
        colors.Add(color);
    }

}
