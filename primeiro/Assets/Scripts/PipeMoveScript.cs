using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    
    public float moveSpeed = 7;
    public float deadZone = -45;
    public GameObject birdScriptGO;
    public BirdScript birdScript;

    // Start is called before the first frame update
    void Start()
    {
        birdScriptGO = GameObject.FindGameObjectWithTag("Bird");
        birdScript = birdScriptGO.GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (birdScript.birdIsAlive) {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }
        if (transform.position.x < deadZone) {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
