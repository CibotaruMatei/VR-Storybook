using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class animContr : MonoBehaviour {

    public Animator anim;
    public float waitTime = 10.0f;
    float initTime;
    public float moveSpeed = 5.0f;
	public int triggerDistance = 20;
	//public string trigger = "Walk";

    Rigidbody rb;
	GameObject player;
	bool changetowalk = true;
	Transform oldTF;
	public float cooldown = 1.0f;
	float cooldownCopy = 1.0f;

    // Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        initTime = waitTime;
		player = GameObject.Find("OVRPlayerController");
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, player.transform.position) > triggerDistance)
		{
			if(cooldown <= 0)
			{
				if (!changetowalk)
				{
					transform.rotation = oldTF.rotation;
					anim.Play("Walk");
					changetowalk = true;
				}
				transform.position += transform.forward * Time.deltaTime * moveSpeed;
				waitTime -= Time.deltaTime;
				if (waitTime <= 0)
				{
					transform.Rotate(Vector3.up, Random.value * 360);
					waitTime = initTime;
					//anim.Play(trigger);
				}
			} else
			{
				cooldown -= Time.deltaTime;
			}
		} else if(changetowalk)
		{
			oldTF = transform;
			transform.LookAt(player.transform, Vector3.up);
			anim.Play("Attack");
			changetowalk = false;
			cooldown = cooldownCopy;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(!collision.gameObject.name.Contains("Terrain"))
		{
			transform.Rotate(Vector3.up, 180);
		}
	}
}
