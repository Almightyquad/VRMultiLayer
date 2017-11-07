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
        TerrainData terrainDataCopy = GameObject.Find("Terrain").GetComponent<Terrain>().terrainData;
        hmW = terrainDataCopy.heightmapWidth;
        hmH = terrainDataCopy.heightmapHeight;
        heights = terrainDataCopy.GetHeights(0, 0, hmW, hmH);
        Debug.Log("heights: " + heights.Length + " W = " + hmW + " H = " + hmH);
        headObject = this.transform.parent.Find("Camera (eye)");
        Grid grid = new Grid();
        MeshFilter tempMF = this.GetComponent<MeshFilter>();
        //The way the generator is set up is stupid, so we reduce the height and width by one to get the correct number of vertices
        this.mesh = grid.Generate(ref tempMF, hmW - 1, hmH - 1);
        tempMF.mesh = this.mesh;
        this.transform.Rotate(new Vector3(90f, 0f, 0f));
        Debug.Log("vertexcount: " + mesh.vertexCount);
        Debug.Log("heightlength: " + heights.Length);
        
        
        
    }

    void Start()
    {
        Vector3[] vec3List = this.mesh.vertices;
        int tempCount = 0;
        for (int i = 0; i < 129; i++)
        {
            for (int j = 0; j < 129; j++)
            {
                tempCount = (i * 129) + j;
                vec3List[tempCount] = new Vector3(vec3List[tempCount].x, vec3List[tempCount].y, -heights[i, j] * 200);
            }
            //Debug.Log(vec3List[tempCount]);
            //vec3List[i] = 
        }
        this.mesh.vertices = vec3List;
        mesh.RecalculateBounds();
        this.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

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
