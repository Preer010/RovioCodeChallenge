using UnityEngine;

public class Asteroid : Projectile
{
    [SerializeField]
    int score = 25;
    [SerializeField]
    Asteroid asteriodToSpawn;
    [SerializeField]
    int amountToSpawn = 2;

    public float size = 1;
    public GameManager gameManager;
    public AsteroidManager asteroidManager;

    public void Spawn()
    {
        float sizeExp= Mathf.Pow(2, size - 1.0f);
        transform.localScale = new Vector3(sizeExp, sizeExp, sizeExp);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (size > 1)
        {
            for (int i = 0; i < amountToSpawn; i++)
            {
                Vector3 offset = Random.insideUnitSphere * 0.5f;
                Asteroid newAsteroid = Instantiate(asteriodToSpawn, transform.position + offset, transform.rotation);
                
                newAsteroid.size = size - 1;
                newAsteroid.Spawn();
                newAsteroid.Project(Random.onUnitSphere);

                asteroidManager.RegisterAsteroid(newAsteroid.gameObject);
            }
        }
        gameManager.scoreManager.AddScore(score * (int)size);
        asteroidManager.DestroyAsteroid(this.gameObject);
    }
}
