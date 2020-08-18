using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float xAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xAngle += 1 * Time.deltaTime;
        this.transform.rotation = Quaternion.Euler(xAngle,0,0);
    }
    void OnTriggerEnter(Collider other){
        Debug.Log(other.tag);
        if(other.tag == "RemoveEnemy"){
            Destroy(this.gameObject);
        }
    }
}
