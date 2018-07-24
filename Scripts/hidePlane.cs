using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidePlane : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Material>().color = Color.clear;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
