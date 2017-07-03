using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMover : MonoBehaviour {
    float step;
    float speed = 3f;
    AudioSource spiderSound;

	// Use this for initialization
	void Start () {
        spiderSound = GetComponent<AudioSource>();
        //spiderSound.Play();
    }

    // Update is called once per frame
    void Update() {
        step = speed * Time.deltaTime;
        transform.LookAt(new Vector3(0, -3, 0));
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -3, 0), step);
        if (transform.position.y == -3) {
            ManageHealth();
            Destroy(gameObject);
            //spiderSound.Play();
        }
    }

    private void ManageHealth() {
        if(GameManager.instance.playerHealth > 0) {
            GameManager.instance.playerHealth -= 2;
            GameManager.instance.playerHealthText.text = "Player Health: " + GameManager.instance.playerHealth.ToString() + "%";
        }
    }

    public void OnSelect() {
        spiderSound.Play();
        gameObject.AddComponent<Rigidbody>().useGravity = true;
        GameManager.instance.killCount += 1;
        //GameManager.instance.killedText.text = "Spiders Killed: " + GameManager.instance.killCount;
    }
}
