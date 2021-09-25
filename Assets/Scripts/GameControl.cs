using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
	public static int playerHp;
	public static float distance;
	public static int levl;
	
	static GameObject hpField;
	static GameObject disField;
	static GameObject levField;
	static GameObject level;
	
	public GameObject hpFild;
	public GameObject disFild;
	public GameObject levFild;
	public GameObject levelObj;
	
	static GameObject thisLevel;
	public GameObject curLevel;
	
	void Start(){
		playerHp = 100;
		distance = 0;
		levl = 1;
		
		hpField = hpFild;
		disField = disFild;
		levField = levFild;
		level = levelObj;
		
		thisLevel = curLevel;
		Debug.Log(""+thisLevel.GetComponent<LevelGenerator>().startZ);
	}
	
	void Update(){
		distance += 2 * Time.deltaTime;
		disField.GetComponent<Text>().text=""+(int)distance;
	}
	
	public static void levelComplete(){
		
		levelComplete(thisLevel.GetComponent<LevelGenerator>().startZ + 100);
	}
	
	public static void levelComplete(int nextLevelStartZ){
		Debug.Log(""+nextLevelStartZ);
		levl++;
		levField.GetComponent<Text>().text=""+levl;
		Destroy(thisLevel);
		
		thisLevel = Instantiate (level, new Vector3(0,0,nextLevelStartZ+50), Quaternion.identity);
		thisLevel.GetComponent<LevelGenerator>().startZ = nextLevelStartZ;
	}
	
	public static void hpChange(int hp){
		playerHp += hp;
		if(playerHp <=0) restart();
		else 
			hpField.GetComponent<Text>().text=""+playerHp;
	}
	
    public static void restart(){
		SceneManager.LoadScene(0);
	}
}
