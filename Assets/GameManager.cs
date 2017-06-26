using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public int playerHealth = 100;
    public Text playerHealthText;
    public static GameManager instance;

    private void Awake() {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", 0f, 2f);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void Spawn() {
        GameObject newSpider = Instantiate(Resources.Load<GameObject>("Prefabs/SpiderAndWeb"));
        //newSpider.transform.rotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), 0);
        newSpider.transform.rotation = Quaternion.Euler(0, Random.Range(0, 180), 0);
    }
}
