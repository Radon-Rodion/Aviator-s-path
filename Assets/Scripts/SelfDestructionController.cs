using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructionController : MonoBehaviour
{
    public float livingTime = 2f;
	float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft  = livingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
			timeLeft -= Time.deltaTime;
		else Destroy(gameObject);
    }
}
