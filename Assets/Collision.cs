using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character"))
        {
            GameManager.instance.AddScore(1);
            Destroy(gameObject); // remove fruit after collecting
        }
    }
}