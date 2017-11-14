using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A pivotscript for the minimap
/// </summary>
public class PivotScript : MonoBehaviour {
    Transform headObject;
    Transform minimap;
    // Use this for initialization
    void Awake () {
        headObject = this.transform.parent.FindChild("Camera (eye)").transform;
        minimap = this.transform.FindChild("Minimap");
    }
	
	// Update is called once per frame
	void Update () {

        //This pretty much just keeps the minimap at the correct rotation and distance from player, Somewhat hardcoded atm.

        minimap.Rotate(new Vector3(-90f, 0f, 0f));
        float rad = 0.2f;
        Vector3 eulerAngleRot = headObject.rotation.eulerAngles;
        float x = rad * Mathf.Sin(Mathf.Deg2Rad * eulerAngleRot.y);
        float z = rad * Mathf.Cos(Mathf.Deg2Rad * eulerAngleRot.y);
        this.transform.position = new Vector3(headObject.position.x + x, headObject.position.y - 0.6f, headObject.position.z + z);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        
        minimap.Rotate(new Vector3(90f, 0f, 0f));
    }
}
