using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoorControl : MonoBehaviour
{
	public float yOpened;
	public bool topDoor;
	public float openingSpeed = 1;
	public bool openDoor = true; //necesity to open
	
	delegate bool CheckFullOpening();
	Vector3 openingDirection;
	CheckFullOpening checkFunc;
	
    // Start is called before the first frame update
    void Start()
    {
        openDoor = false;
		//checkFunc = topDoor ? checkTop : checkBot;
		if(topDoor) {
			checkFunc = checkTop;
		}
		else checkFunc = checkBot;
		
		openingDirection = topDoor ? Vector3.up : Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {
        if(openDoor && (!checkFunc())){
			transform.Translate(openingDirection * openingSpeed * Time.deltaTime);
		}
    }
	
	bool checkBot(){
		return transform.position.y <= yOpened;
	}

	bool checkTop(){
		return transform.position.y >= yOpened;
	}
}
