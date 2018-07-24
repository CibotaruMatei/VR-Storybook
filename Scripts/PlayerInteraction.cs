using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

	public LayerMask MovementMask;
	public int lookRange = 100;
	private Camera cam;
    public int lookMultiplier = 10;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, lookRange, MovementMask))
			{
				Debug.Log("We hit " + hit.collider.name + " " + hit.point);
			}
		}
        float x = Input.GetAxis("Mouse X");
        if(x != 0)
        {
            transform.Rotate(Vector3.up, x * lookMultiplier);
        }
	}
}
