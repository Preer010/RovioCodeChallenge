using UnityEngine;
public class Bullet : Projectile
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}

