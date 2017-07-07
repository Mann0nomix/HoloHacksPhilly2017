using System;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class SpiderMover : MonoBehaviour, IInputHandler {
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

        if (Input.GetMouseButtonDown(0)) {
            OnInputClicked(null);
        }
    }

    private void ManageHealth() {
        if(GameManager.instance.playerHealth > 0) {
            GameManager.instance.playerHealth -= 2;
            GameManager.instance.playerHealthText.text = "Player Health: " + GameManager.instance.playerHealth.ToString() + "%";
        }
    }

    public void OnInputClicked(InputClickedEventData eventData) {
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>()) {
            spiderSound.Play();
            Rigidbody rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.AddForce(Vector3.forward * 1000);
            GameManager.instance.killCount += 1;
            //GameManager.instance.killedText.text = "Spiders Killed: " + GameManager.instance.killCount;
        }
    }

    public void OnInputUp(InputEventData eventData) {
    }

    public void OnInputDown(InputEventData eventData) {
    }
}
