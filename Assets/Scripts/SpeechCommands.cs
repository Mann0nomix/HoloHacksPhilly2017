using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class SpeechCommands : MonoBehaviour, IInputClickHandler {
    GameObject spiderCollection;

    // Use this for initialization
    void Start() {
        spiderCollection = GameObject.Find("Spiders");
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    public void OnInput() {

    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            OnInputClicked(null);
        }
    }

    // Called by SpeechManager when the user says the "Reset world" command
    public void OnReset() {
        EndGame();
        RestoreHealth();
    }

    // Called by SpeechManager when the user says the "Drop sphere" command
    public void OnDrop() {
        // Just do the same logic as a Select gesture.
    }

    public void EndGame() {
        spiderCollection.SetActive(false);
        //foreach (Transform child in spiderCollection.transform) {
        //  Destroy(child.gameObject);
        //}
    }

    public void RestoreHealth() {
        GameManager.instance.playerHealth = 100;
    }

    public void OnInputClicked(InputClickedEventData eventData) {
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (!GetComponent<Rigidbody>()) {
            Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
            rigidbody.AddForce(Vector3.forward * 1000);
            GameManager.instance.killCount += 1;
            AudioSource spiderSound = GetComponent<AudioSource>();
            spiderSound.Play();
            //GameManager.instance.killedText.text = "Spiders Killed: " + GameManager.instance.killCount;
        }
    }
}
