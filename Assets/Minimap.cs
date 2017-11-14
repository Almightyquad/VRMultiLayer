using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Minimap : MonoBehaviour {
    TerrainData terrainData;
    int hmW;
    int hmH;
    float[,] heights;
    Mesh mesh;

    Transform headObject;

    bool parentSet = false;

    // Use this for initialization
    void Awake() {
        //We get the terrain so we can extract the information that we need: Height, Widgt, heightdata.
        TerrainData terrainDataCopy = GameObject.Find("Terrain").GetComponent<Terrain>().terrainData;
        hmW = terrainDataCopy.heightmapWidth;
        hmH = terrainDataCopy.heightmapHeight;
        heights = terrainDataCopy.GetHeights(0, 0, hmW, hmH);
        Debug.Log("heights: " + heights.Length + " W = " + hmW + " H = " + hmH);
        //Find the camera position, important for calculating position of the minimap as it is a 3d object.
        headObject = this.transform.parent.Find("Camera (eye)");
        //Create a new grid mesh (flat mesh) for use as the minimap
        Grid grid = new Grid();
        //Need a mesh filter
        MeshFilter tempMF = this.GetComponent<MeshFilter>();
        //The way the generator is set up is stupid, so we reduce the height and width by one to get the correct number of vertices
        //Generates the mesh
        this.mesh = grid.Generate(ref tempMF, hmW - 1, hmH - 1);
        tempMF.mesh = this.mesh;
        //Rotate it so it is not on its side.
        this.transform.Rotate(new Vector3(90f, 0f, 0f));
        Debug.Log("vertexcount: " + mesh.vertexCount);
        Debug.Log("heightlength: " + heights.Length);
        
        
        
    }

    void Start()
    {
        //Get the vertices of the mesh
        Vector3[] vec3List = this.mesh.vertices;
        int tempCount = 0;
        //Set all the heights for the mesh.
        for (int i = 0; i < 129; i++)
        {
            for (int j = 0; j < 129; j++)
            {
                tempCount = (i * 129) + j;
                vec3List[tempCount] = new Vector3(vec3List[tempCount].x, vec3List[tempCount].y, -heights[i, j] * 150);
            }
            //Debug.Log(vec3List[tempCount]);
            //vec3List[i] = 
        }
        this.mesh.vertices = vec3List;
        //Recalculating bounds is important
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        //Scale the heck out of the mesh, or it would be as big as the terrain and that wouldn't make it a minimap
        this.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);

        //Debug.Log(vec3List.Count);
        //this.transform.GetComponent<Terrain>().terrainData = terrainData;
        //this.transform.GetComponent<Terrain>().terrainData.SetHeights(0, 0, heights);
        //this.transform.GetComponent<Terrain>().drawTreesAndFoliage = false;
        //this.transform.GetComponent<Terrain>().terrainData.size = new Vector3(1f,1f,1f);
        //this.transform.GetComponent<Terrain>().terrainData.size.Set(1f, 1f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        
        /*if (!parentSet)
        {
            if (GameObject.Find("PivotingPoint").GetComponent<Transform>())
            {
                this.transform.SetParent(GameObject.Find("PivotingPoint").GetComponent<Transform>());
                parentSet = true;
            }
        }*/

        
    }
}
