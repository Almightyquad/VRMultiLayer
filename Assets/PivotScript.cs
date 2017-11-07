using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotScript : MonoBehaviour {
    Transform headObject;
    // Use this for initialization
    void Awake () {
        headObject = this.transform.parent.transform;
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
        //this.transform.position = new Vector3(headObject.position.x + z, headObject.position.y - 0.6f, headObject.position.z + x);
        //this.transform.localPosition = new Vector3(0 + 0.5f, 0f, 0 + 0.5f);
        this.transform.localPosition = new Vector3(0, 0 - 0.6f, 1);
        this.transform.position = new Vector3(this.transform.position.x, headObject.position.y - 0.6f, this.transform.position.z);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        //this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, eulerAngleRot.y, this.transform.eulerAngles.z);
        //this.transform.position = new Vector3(this.transform.position.x - 0.5f, this.transform.position.y - 0.6f, this.transform.position.z);
        //this.transform.position = new Vector3(headObject.position.x - z + 0.5f, headObject.position.y - 0.6f, headObject.position.z - x + 0.5f);
        //Debug.Log(eulerAngleRot.y);
    }
}
