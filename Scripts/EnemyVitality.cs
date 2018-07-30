using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVitality : MonoBehaviour {

	public float HP, maxHP, cdwn, maxCdwn;
    public enum EnemySize {small, medium, large};

    private Transform tf;

	void Start () {
        HP = maxHP;
        tf = GetComponent<Transform>();
	}
	
	void Update () {
		if(cdwn == 0) {
            if (HP < maxHP && HP + Time.deltaTime < maxHP)
            {
                HP += Time.deltaTime;
            } else if(HP < maxHP && HP + Time.deltaTime >= maxHP) {
                HP = maxHP;
            }
        } else {
            cdwn -= Time.deltaTime;
        }
		if(HP <= 0) Destroy(gameObject); 
	}

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Weapon") {
            HP -= collision.gameObject.GetComponent<WeaponCtrl>().dmg;
            cdwn = maxCdwn;
        }
    }
}
