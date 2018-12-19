using UnityEngine;

public class Coin : MonoBehaviour {

    public int tiempoExtra = 5;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // GO											// Component				// Method
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().addTime(tiempoExtra);
            Destroy(gameObject);
        }
    }
}
