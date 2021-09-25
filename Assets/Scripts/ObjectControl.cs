using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl : MonoBehaviour
{
	public int hp = 50; public bool triggered = false;
	public GameObject destructed;
	
	
    private void OnTriggerEnter(Collider collider){
		
		if(collider.gameObject.tag == "Plane" && (!triggered)){
			triggered = true;
			Debug.Log("Trig "+triggered);
			
			if(gameObject.tag == "Wall"){
				Debug.Log("Collision");
				GameControl.restart();
			} else if(gameObject.tag == "Barrier"){
				Debug.Log("Trigger!");
				destruct();
				GameControl.hpChange(-hp);
				
			} else if(gameObject.tag == "Portal"){
				GameControl.levelComplete();
			}
		} else if(collider.gameObject.tag == "Bullet" && gameObject.tag == "Barrier"){
			Debug.Log("Shot!");
			gameObject.GetComponent<ObjectControl>().changeHp(-collider.gameObject.GetComponent<BulletControl>().damage);
		}
	}
	
	public void changeHp(int hpChange){
		hp += hpChange;
		if(hp <= 0){
			destruct();
		}
	}
	
	void destruct(){
		Vector3 position = transform.position;
		Quaternion rotation = transform.rotation;
		Destroy(gameObject);
		Debug.Log("Destructed");
		Instantiate(destructed, position, rotation);
	}
	
	/*private void OnCollisionEnter(Collision collision){
		
		if(collision.gameObject.tag == "Plane"){
			Debug.Log("Collision");
			GameControl.restart();
		}
	}*/
}
