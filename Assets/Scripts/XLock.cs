﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XLock : MonoBehaviour {
  
    Renderer rend;
    Renderer rend1;
    GameObject bone;
    GameObject part;
    bool direction = true;
    // Quaternion lockrot;
    // Use this for initialization
    void Start () {
        // lockrot.eulerAngles = new Vector3(0,0,0);
        bone = GameObject.Find("bone");
        part = GameObject.Find("part");
        rend = bone.GetComponent<Renderer>();
        rend1 = part.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        //  transform.localPosition = new Vector3(transform.localPosition.x, LockY , lockZ);
        //  float newx = 0f - transform.localPosition.x * 0.0008f - 0.0267574f;

        //Debug.Log("Real World PlaneX" + transform.position.x );
        // Debug.Log("Virtual Plane"+ newx);
        if (direction)
        {
            Left();
        }
        else
        {
            Right();
        }
        
    }
    public void Change()
    {
        if (direction)
        {
            direction = false;
        }
        else
        {
            direction = true;
        }
    }
    void Left() {

        float newx = transform.position.x;
        float newy = transform.position.y;
        float newz = transform.position.z;

        rend.material.SetVector("_PlaneNormal", new Vector4(-transform.right.x, -transform.right.y, -transform.right.z, 0));
        rend.material.SetVector("_PlanePoint", new Vector4(newx, newy, newz, 0));
        rend1.material.SetVector("_PlaneNormal", new Vector4(-transform.right.x, -transform.right.y, -transform.right.z, 0));
        rend1.material.SetVector("_PlanePoint", new Vector4(newx, newy, newz, 0));
    }

    void Right()
    {

        float newx = transform.position.x;
        float newy = transform.position.y;
        float newz = transform.position.z;

        rend.material.SetVector("_PlaneNormal", new Vector4(transform.right.x, transform.right.y, transform.right.z, 0));
        rend.material.SetVector("_PlanePoint", new Vector4(newx, newy, newz, 0));
        rend1.material.SetVector("_PlaneNormal", new Vector4(transform.right.x, transform.right.y, transform.right.z, 0));
        rend1.material.SetVector("_PlanePoint", new Vector4(newx, newy, newz, 0));
    }
}
