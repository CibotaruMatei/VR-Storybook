using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class animContrCrab : MonoBehaviour {

    public Animator anim;
    public float waitTime = 10.0f;
    float initTime;
    public float moveSpeed = 5.0f;
    
    // Use this for initialization
    void Start()
    {
        initTime = waitTime;
        anim = gameObject.GetComponent<Animator>();
        anim.Play("Walk");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            transform.Rotate(Vector3.up, Random.value * 360);
            waitTime = initTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.name.Contains("Terrain"))
        {
            transform.Rotate(Vector3.up, 180);
        }
    }
}
