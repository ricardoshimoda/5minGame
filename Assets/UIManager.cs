using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private float timeScore;
    private Hero player;
    public TextMeshProUGUI txtScore;
    public GameObject pnlDeath;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
        timeScore = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.IsAlive()){
            timeScore += Time.deltaTime;
            string currentTime = timeScore.ToString("F", CultureInfo.InvariantCulture);
            txtScore.text = currentTime;
            txtScore.ForceMeshUpdate(true);
        }
        else{
            if(!pnlDeath.active){
                pnlDeath.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.Space)){
                Restart();
            }
        }
    }

    public void Restart(){
        // Deletes all fruit
        var fruits = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject fruit in fruits){
            Destroy(fruit);
        }
        Debug.Log("Restart!");
        // Reposition Player
        player.Restart();
        // Zeroes score
        timeScore = 0.0f;
        // Removes death message
        pnlDeath.SetActive(false);
        
    }
}
