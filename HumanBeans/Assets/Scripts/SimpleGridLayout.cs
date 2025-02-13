using UnityEngine;
using System.Collections.Generic;

//Simple linear grid, fast to generate but don't deal with custom shape grounds
//Where in games like the sims 3 the grid extends one block more than the current ground
//To deal with this and terrain leveling we can make a function that receives a custom shape
public class SimpleGridLayout : MonoBehaviour
{
    [SerializeField] private float horizontalGap;
    [SerializeField] private float verticalGap;
    [SerializeField] private int lines = 5;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private MeshFilter meshFilter;



    private void Update()
    {
        GenerateLayout(horizontalGap, verticalGap, lines);

    }

    public void GenerateLayout(float horizontalGap, float verticalGap, int lines)
    {
        ///TODO: Tem que criar um vertice para cada interseção;
        var vertices = new Vector3[lines * lines];
        var indices = new List<int>();
        for (int j = 0; j < lines; j++)
        {
            for (int i = 0; i < lines; i++)
            {
                vertices[i + lines * j] = new Vector3(horizontalGap * i, 0, verticalGap * j);
                if (i < lines - 1)
                {
                    indices.Add(i + j * lines);
                    indices.Add(i + 1 + j * lines);
                }
                if (j < lines - 1)
                {
                    indices.Add(i + j * lines);
                    indices.Add(i + (j + 1) * lines);
                }
            }
            //indices.Add(j * lines);
        }
        meshFilter.mesh.vertices = vertices;
        //meshFilter.mesh.uv = new Vector2[2];
        meshFilter.mesh.normals = new Vector3[vertices.Length];
        meshFilter.mesh.SetIndices(indices.ToArray(), MeshTopology.Lines, 0);

    }
}
