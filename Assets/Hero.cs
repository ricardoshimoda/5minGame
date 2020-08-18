using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float speed;
    private bool alive = true;
    private bool right = true;
    public Transform originalTransform;
    private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        if(speed <= 0){
            speed = 1;
        }
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(alive){
            float currentInput = Input.GetAxis("Horizontal");
            if(currentInput > 0 && !right){
                // turn right
                transform.rotation = Quaternion.Euler(0,0,0);
                right = true;
            }
            if(currentInput < 0 && right){
                //Debug.Log("Rotate");
                transform.rotation = Quaternion.Euler(0,180,0);
                right = false;
            }
            transform.position += new Vector3(speed * currentInput * Time.deltaTime,0,0);
        }
    }
    void OnCollisionEnter(Collision collision){
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Enemy" && alive){
            alive = false;
            GetComponent<AudioSource>().Play();
        }
    }
    public bool IsAlive () {
        return alive;
    }
    public void Restart(){
        Debug.Log("Restart Player!");
        alive = true;
        transform.position = originalTransform.position;
        transform.rotation = originalTransform.rotation;
        Debug.Log(originalTransform.position);
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        body.position = originalTransform.position;
        body.rotation = originalTransform.rotation;
        //body.isKinematic = true;
        //GetComponent<Collider>().enabled = false;
        right = true;
        Debug.Log("Restart Player Finished!");
    }
}
