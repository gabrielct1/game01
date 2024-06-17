using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{

    public GameObject pipe;
    private readonly float spawnRate = 2.5f;
    private float timer = 0;
    public float heighOffSet = 10;
    public BirdScript birdScript;

    // Start is called before the first frame update
    void Start()
    {
        birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        SpawnPipe();

    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            SpawnPipe();
            timer = 0;
        }
    }

    void SpawnPipe() {
        
        float lowestPoint = transform.position.y - heighOffSet;
        float highestPoint = transform.position.y + heighOffSet;

        if (birdScript.birdIsAlive) {
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }
    }
}
