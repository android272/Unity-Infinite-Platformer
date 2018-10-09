using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public GameObject platform;
    public float distanceBetween;
    public bool displayGridGizmos;

    public Transform rightBoundry;
    public Transform leftBoundry;
    public Transform upBoundry;

    public Transform rightGenerationPoint;
    public Transform leftGenerationPoint;
    public Transform upGenerationPoint;

    public Transform rightDistructionPoint;
    public Transform leftDistructionPoint;
    public Transform upDistructionPoint;

    private float platformWidth;



    void Start() {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
    }

    void Update() {
        if(rightBoundry.position.x > rightGenerationPoint.position.x) {
            rightGenerationPoint.position = new Vector3(rightBoundry.position.x + platformWidth,
                                                        rightGenerationPoint.position.y,
                                                        rightBoundry.position.z);

            leftGenerationPoint.position = new Vector3(leftBoundry.position.x - platformWidth,
                                                        leftGenerationPoint.position.y,
                                                        leftBoundry.position.z);

            var newPlatform = Instantiate(platform, new Vector3(rightBoundry.position.x, rightGenerationPoint.position.y), rightGenerationPoint.rotation);
            newPlatform.transform.parent = GameObject.Find("Ground").transform;

            //newPlatform = Instantiate(platform, new Vector3(leftGenerationPoint.position.x, leftBoundry.position.y), leftGenerationPoint.rotation);
            //newPlatform.transform.parent = GameObject.Find("Ground").transform;
        }

        if(leftBoundry.position.x < leftGenerationPoint.position.x) {
            rightGenerationPoint.position = new Vector3(rightBoundry.position.x + platformWidth,
                                                        rightGenerationPoint.position.y,
                                                        rightBoundry.position.z);

            leftGenerationPoint.position = new Vector3(leftBoundry.position.x - platformWidth,
                                                        leftGenerationPoint.position.y,
                                                        leftBoundry.position.z);

            var newPlatform = Instantiate(platform, new Vector3(leftBoundry.position.x, leftGenerationPoint.position.y), leftGenerationPoint.rotation);
            newPlatform.transform.parent = GameObject.Find("Ground").transform;

            //newPlatform = Instantiate(platform, new Vector3(leftGenerationPoint.position.x, leftBoundry.position.y), leftGenerationPoint.rotation);
            //newPlatform.transform.parent = GameObject.Find("Ground").transform;
        }

        /*
        if(rightBoundry.position.x < RightGenerationPoint.position.x) {
            rightBoundry.position = new Vector3(rightBoundry.position.x + platformWidth + distanceBetween,
                rightBoundry.position.y, rightBoundry.position.z);

            leftBoundry.position = new Vector3(leftBoundry.position.x - platformWidth - distanceBetween,
                leftBoundry.position.y, leftBoundry.position.z);

            var newPlatform = Instantiate(platform, rightBoundry.position, rightBoundry.rotation);

            newPlatform.transform.parent = GameObject.Find("Ground").transform;
        }

        if(leftBoundry.position.x > LeftGenerationPoint.position.x) {
            leftBoundry.position = new Vector3(leftBoundry.position.x - platformWidth - distanceBetween,
                leftBoundry.position.y, leftBoundry.position.z);

            rightBoundry.position = new Vector3(leftBoundry.position.x + platformWidth + distanceBetween,
                leftBoundry.position.y, leftBoundry.position.z);

            var newPlatform = Instantiate(platform, leftBoundry.position, leftBoundry.rotation);

            newPlatform.transform.parent = GameObject.Find("Ground").transform;
        }
        */
    }

    private void OnDrawGizmos() {
        if(displayGridGizmos) {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(rightBoundry.position, new Vector3(0.5f, 30, 0));
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(leftBoundry.position, new Vector3(0.5f, 30, 0));
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(upBoundry.position, new Vector3(40, 0.5f, 0));

            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(rightGenerationPoint.position, new Vector3(0.5f, 30, 0));
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(leftGenerationPoint.position, new Vector3(0.5f, 30, 0));
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(upGenerationPoint.position, new Vector3(40, 0.5f, 0));

            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(rightDistructionPoint.position, new Vector3(0.5f, 30, 0));
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(leftDistructionPoint.position, new Vector3(0.5f, 30, 0));
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(upDistructionPoint.position, new Vector3(40, 0.5f, 0));
        }
    }
}