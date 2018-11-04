using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMapper : MonoBehaviour {

    public GameObject ground;

    public GameObject testEnemy;

    Mesh groundMesh;
    float highestX = 0;
    float highestZ = 0;
    float lowestX = 0;
    float lowestZ = 0;

    float[,] grid;

    Vector2 alignValues;

    public GameObject[] obstacles;
	// Use this for initialization
	void Start () {
        groundMesh = ground.GetComponent<MeshCollider>().sharedMesh;
        Vector3[] meshVerts = groundMesh.vertices;
        Transform tr = ground.transform;
        highestX = tr.TransformPoint(meshVerts[0]).x;
        highestZ = tr.TransformPoint(meshVerts[0]).z;
        lowestX = tr.TransformPoint(meshVerts[0]).x;
        lowestZ = tr.TransformPoint(meshVerts[0]).z;
        //Find the boundaries of the level mesh
        for (int x = 0; x < meshVerts.Length; x++)
        {
            if (tr.TransformPoint(meshVerts[x]).x > highestX)
                highestX = tr.TransformPoint(meshVerts[x]).x;
            if (tr.TransformPoint(meshVerts[x]).x < lowestX)
                lowestX = tr.TransformPoint(meshVerts[x]).x;
            if (tr.TransformPoint(meshVerts[x]).z > highestZ)
                highestZ = tr.TransformPoint(meshVerts[x]).z;
            if (tr.TransformPoint(meshVerts[x]).z < lowestZ)
                lowestZ = tr.TransformPoint(meshVerts[x]).z;
        }
        //Create grid to represent level, with each
        grid = new float[Mathf.FloorToInt(highestX) - Mathf.FloorToInt(lowestX) + 1, Mathf.FloorToInt(highestZ) - Mathf.FloorToInt(lowestZ) + 1];
        print(Mathf.FloorToInt(highestX) + " " + Mathf.FloorToInt(lowestX) + " " + Mathf.FloorToInt(highestZ) + " " + Mathf.FloorToInt(lowestZ));
        print((Mathf.FloorToInt(highestX) - Mathf.FloorToInt(lowestX)) + " " + (Mathf.FloorToInt(highestZ) - Mathf.FloorToInt(lowestZ)));
        //print(grid.Length + " " + grid.GetLength(1));
        //Populate grid with 0s to represent open space
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for(int y = 0; y < grid.GetLength(1); y++)
            {
                grid[x, y] = 0;
            }
        }

        alignValues = new Vector2(Mathf.RoundToInt(lowestX), Mathf.RoundToInt(lowestZ));

        
        
        for(int x = 0; x < obstacles.Length; x++)
        {
            obstacles[x].SendMessage("MapConstructionCall", this.gameObject);
        }

        testEnemy.SendMessage("GiveGrid", grid);

        /*for (int x = 0; x < grid.GetLength(0); x++)
        {
            string row = "";
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                row = row + " " + grid[x, y];
            }
            print(row);
        }*/
        print("Finished with groundmapper");


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateGrid(MeshCollider input)
    {
        Vector3[] obsVerts = input.sharedMesh.vertices;
        Transform tr = input.gameObject.transform;
        for(int x = 0; x < obsVerts.Length; x++)
        {
            try
            {
                int alignedX = Mathf.FloorToInt(tr.TransformPoint(obsVerts[x]).x) - Mathf.FloorToInt(lowestX);
                int alignedZ = Mathf.FloorToInt(tr.TransformPoint(obsVerts[x]).z) - Mathf.FloorToInt(lowestZ);
                if (grid[alignedX, alignedZ] != 1)
                    grid[alignedX, alignedZ] = 1;
            }
            catch (System.Exception)
            {
                print("object vertice out of expected bounds!");
                //throw;
            }
        }
    }
}
