using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
	public int damage = 15;
	
	
	private void OnCollisionEnter(Collision collision){
		processCollision(collision.gameObject);
	}
	
	private void OnTriggerEnter(Collider collider){
		processCollision(collider.gameObject);
	}
	
	void processCollision(GameObject go){
		/*if(go.tag == "Barrier"){
			Debug.Log("Shot!");
			go.GetComponent<ObjectControl>().changeHp(-damage);
		}*/
		Destroy(gameObject);
	}
}
