using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {
    TerrainData terrainData;
    int hmW;
    int hmH;
    float[,] heights;

    Transform headObject;

    // Use this for initialization
    void Awake () {
        TerrainData terrainDataCopy = GameObject.Find("Terrain").GetComponent<Terrain>().terrainData;
        hmW = terrainDataCopy.heightmapWidth;
        hmH = terrainDataCopy.heightmapHeight;
        heights = terrainDataCopy.GetHeights(0, 0, hmW, hmH);
        headObject = this.transform.parent.Find("Camera (eye)");
        //Grid grid = new Grid();
        //grid.Generate();
        
        
    }

    void Start()
    {
        //this.transform.GetComponent<Terrain>().terrainData = terrainData;
        this.transform.GetComponent<Terrain>().terrainData.SetHeights(0, 0, heights);
        this.transform.GetComponent<Terrain>().drawTreesAndFoliage = false;
        this.transform.GetComponent<Terrain>().terrainData.size = new Vector3(1f,1f,1f);
        //this.transform.GetComponent<Terrain>().terrainData.size.Set(1f, 1f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        //this.transform.position = new Vector3 (headObject.position.x, headObject.position.y, headObject.position.z);
        float rad = 0.5f;
        //this.transform.rotate(new Vector3(0.0f, 1, 0.0f), headObject.transform.rotation.y);
        //float tempPosOffset = (headObject.rotation.y + 180) / 360 - 0.5f;
        Vector3 eulerAngleRot = headObject.rotation.eulerAngles;
        float x = rad * Mathf.Cos(Mathf.Deg2Rad * eulerAngleRot.y);
        float z = rad * Mathf.Sin(Mathf.Deg2Rad * eulerAngleRot.y);
        //Vector2 normalizedOffset = new Vector2(x, z).normalized;
        //normalizedOffset = new Vector2(normalizedOffset.x - 0.5f, normalizedOffset.y - 0.5f);
        //Debug.Log("X: " + normalizedOffset.x + " Z: " + normalizedOffset.y + " Degrees: " + eulerAngleRot.y);
        this.transform.position = new Vector3(headObject.position.x + z - 0.5f, headObject.position.y - 0.6f, headObject.position.z + x - 0.5f);
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, eulerAngleRot.y, this.transform.eulerAngles.z);
        Debug.Log(eulerAngleRot.y);
	}
}
