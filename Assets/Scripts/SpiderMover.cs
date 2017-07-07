using UnityEngine;

public class SpiderMover : MonoBehaviour {
    float step;
    float speed = 3f;

    // Update is called once per frame
    void Update() {
        step = speed * Time.deltaTime;
        transform.LookAt(new Vector3(0, -3, 0));
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -3, 0), step);
        if (transform.position.y == -3) {
            ManageHealth();
            Destroy(gameObject);
        }
    }

    private void ManageHealth() {
        if(GameManager.instance.playerHealth > 0) {
            GameManager.instance.playerHealth -= 2;
            GameManager.instance.playerHealthText.text = "Player Health: " + GameManager.instance.playerHealth.ToString() + "%";
        }
    }
}
