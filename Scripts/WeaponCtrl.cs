using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCtrl : MonoBehaviour {
	public int dmg;

    Transform tf;

    public void Start()
    {
        tf = GetComponent<Transform>();
        tf.rotation = new Quaternion();
        tf.position = Camera.main.transform.position + new Vector3(1.1f, -0.66f, 0.87f);
        tf.Rotate(Vector3.up, Camera.main.transform.rotation.eulerAngles.y);
    }
}
