using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {
    TerrainData terrainData;
    int hmW;
    int hmH;
    float[,] heights;
    // Use this for initialization
    void Awake () {
        TerrainData terrainDataCopy = GameObject.Find("Terrain").GetComponent<Terrain>().terrainData;
        hmW = terrainDataCopy.heightmapWidth;
        hmH = terrainDataCopy.heightmapHeight;
        heights = terrainDataCopy.GetHeights(0, 0, hmW, hmH);
        

    }

    void Start()
    {
        Debug.Log("I AM RUNNING");
        //this.transform.GetComponent<Terrain>().terrainData = terrainData;
        this.transform.GetComponent<Terrain>().terrainData.SetHeights(0, 0, heights);
        this.transform.GetComponent<Terrain>().drawTreesAndFoliage = false;
        this.transform.GetComponent<Terrain>().terrainData.size = new Vector3(1f,1f,1f);
        //this.transform.GetComponent<Terrain>().terrainData.size.Set(1f, 1f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
