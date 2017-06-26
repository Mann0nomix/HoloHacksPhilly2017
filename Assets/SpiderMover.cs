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
        spiderSound.Play();
    }

    // Update is called once per frame
    void Update() {
        step = speed * Time.deltaTime;
        transform.LookAt(new Vector3(0, -3, 0));
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -3, 0), step);
        if (transform.position.y == -3) {
            GameManager.instance.playerHealth -= 2;
            GameManager.instance.playerHealthText.text = "Player Health: " + GameManager.instance.playerHealth.ToString() + "%";
            Destroy(gameObject);
        }
    }
}
