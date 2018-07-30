using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class EnemySpawner : MonoBehaviour {

    public Object original;
    public GameObject enemies;
    int distance = 30, maxcount = 10;
	
	void Update () {
		if(enemies.transform.childCount < maxcount && Vector3.Distance(Camera.main.transform.position, GetComponent<Transform>().position) > distance)
        {
            Vector3 pos = GetComponent<Transform>().position;
            pos.x += Random.insideUnitSphere.x * 10;
            pos.z += Random.insideUnitSphere.z * 10;
            Instantiate(original, pos, GetComponent<Transform>().rotation, enemies.transform);
        }
	}
}
