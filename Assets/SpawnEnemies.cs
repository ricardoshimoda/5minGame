using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> enemyPrefabs;
    public float timer;
    private float counter = 0.0f;
    private Hero player;
    void Start()
    {
        if(timer <= 0)
            timer = 0.5f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter > timer && enemyPrefabs.Count > 0 /*&& player.IsAlive()*/){
            int enemyId = Random.Range(0, enemyPrefabs.Count);
            float randomX = Random.Range(-9.5f, 9.5f);
            Instantiate(enemyPrefabs[enemyId], transform.position + new Vector3(randomX,0,0), Quaternion.EulerAngles(0,0,0));
            counter -= timer;
        }
    }
}
