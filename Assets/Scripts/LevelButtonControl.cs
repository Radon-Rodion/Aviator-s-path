using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonControl : MonoBehaviour
{
	public GameObject topDoor, botDoor;
	public bool pressed;
	public float moveTime;
    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
		moveTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(pressed){
			pressReaction();
		}
    }
	
	void pressReaction(){
		if(moveTime>0){
			moveTime -= Time.deltaTime;
			transform.Translate(Vector3.down * Time.deltaTime);
		}
	}
	
	private void OnTriggerEnter(Collider collider){
		
		if(collider.gameObject.tag == "Bullet"){
			pressed = true;
			topDoor.GetComponent<LevelDoorControl>().openDoor = true;
			botDoor.GetComponent<LevelDoorControl>().openDoor = true;
		}
	}
}
