using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.DestroyPlayer(this.gameObject);
    }
}
