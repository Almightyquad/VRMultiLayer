using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minime : MonoBehaviour {
    Transform headObject;
    int terrainScale = 500;
    float meshScale = 0.6f;
    Vector3 halfMeshScale;
    Transform minimap;
    Transform pivotPoint;
	// Use this for initialization
	void Start () {
        //This is a stupid line that should be fixed. No need to look for the parent parent parent to find the Eye.
        headObject = this.transform.parent.parent.parent.FindChild("Camera (eye)").transform;
        //Need the half mesh scale as there is a offset. The terrain starts at (-250,-250) and the player is standing at (0,0), so there is a slight offset that is needed.
        halfMeshScale = new Vector3(meshScale / 2f, 0f, meshScale / 2f);
        minimap = this.transform.parent.transform;
        pivotPoint = this.transform.parent.parent.transform;
    }
	
	// Update is called once per frame
	void Update () {
        
        //this.transform.rotation = headObject.transform.rotation;
        if(this.GetComponent<VRTK.VRTK_InteractableObject>().IsGrabbed())
        {
            headObject.parent.transform.position = this.getTruePosition();
            Ray ray = new Ray(headObject.parent.transform.position, Vector3.down);
            RaycastHit rayHit = new RaycastHit();
            Physics.Raycast(ray, out rayHit);
            if(rayHit.collider)
            {
                if (rayHit.collider.tag == "Terrain")
                {
                    headObject.parent.transform.position = new Vector3(headObject.parent.transform.position.x, rayHit.point.y + 2f, headObject.parent.transform.position.z);
                }
            }
            if (!rayHit.collider)
            {
                ray.direction = Vector3.up;
                Physics.Raycast(ray, out rayHit);
                
                if (rayHit.collider)
                {
                    if (rayHit.collider.tag == "Terrain")
                    {
                        headObject.parent.transform.position = new Vector3(headObject.parent.transform.position.x, rayHit.point.y + 2f, headObject.parent.transform.position.z);
                    }
                }

            }
            this.transform.position = getScaledPosition();


        }
        if(!this.GetComponent<VRTK.VRTK_InteractableObject>().IsGrabbed())
        {
            this.transform.position = getScaledPosition();
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.05f, this.transform.position.z);
        }
        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        if(headObject.parent.transform.position.x < -1000 || headObject.parent.transform.position.x > 1000 || headObject.parent.transform.position.z < -1000 || headObject.parent.transform.position.z > 1000)
        {
            headObject.parent.position = Vector3.zero;
        }

	}
    //The mesh size if 0.6, that would be 500 / (5/6 * 1000). 500 being the terrain scale
    // (5/6 * 1000) being used to divide by to get the aspect ratio from 500 to 0.6
    //The range of the terrain goes from vec3(-250, 0, -250) to vec3(250,0,250)
    private Vector3 getScaledPosition()
    {
        return ((headObject.position) / (5f / 6f * 1000f)) + minimap.localPosition + pivotPoint.position + this.halfMeshScale;
    }

    private Vector3 getTruePosition()
    {
        Vector3 tempVec3 = (this.transform.position - minimap.localPosition - pivotPoint.position - this.halfMeshScale) * (5f / 6f * 1000f);
        return new Vector3(tempVec3.x, tempVec3.y * (5f / 6f * 1000f), tempVec3.z);
    }
}
