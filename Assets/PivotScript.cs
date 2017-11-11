using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        minimap.Rotate(new Vector3(-90f, 0f, 0f));
        float rad = 0.2f;
        Vector3 eulerAngleRot = headObject.rotation.eulerAngles;
        float x = rad * Mathf.Cos(Mathf.Deg2Rad * eulerAngleRot.y);
        float z = rad * Mathf.Sin(Mathf.Deg2Rad * eulerAngleRot.y);
        this.transform.position = new Vector3(headObject.position.x + z, headObject.position.y - 0.6f, headObject.position.z + x);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        
        minimap.Rotate(new Vector3(90f, 0f, 0f));
    }
}
