using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDisctuctionPoint : MonoBehaviour {
    private GameObject leftGenerationPoint;
    private GameObject rightGenerationPoint;

    void Start () {
        leftGenerationPoint = GameObject.Find("LeftDistructionPoint");
        rightGenerationPoint = GameObject.Find("RightDistructionPoint");
    }
	
	void Update () {
        if(transform.position.x < leftGenerationPoint.transform.position.x 
            || transform.position.x > rightGenerationPoint.transform.position.x) {
            Destroy(gameObject);
        }
    }
}
