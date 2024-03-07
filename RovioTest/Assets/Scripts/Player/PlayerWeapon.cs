using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    float rateOfFire = 0.35f;

    [SerializeField]
    string bulletPrefab = "Assets/Prefabs/Bullet.prefab";
    
    float cooldown;
    AddressableLoader addressableLoader;

    private void Start()
    {
        addressableLoader = ScriptableObject.CreateInstance<AddressableLoader>();
        addressableLoader.prefabAddress = bulletPrefab;
        addressableLoader.OnLoadComplete += OnBulletCreated;
    }

    private void Update()
    {
        cooldown += Time.deltaTime;
    }

    public void Shoot()
    {
        if(cooldown > rateOfFire)
        {
            addressableLoader.SpawnPrefab(transform.position, transform.rotation); 
        }
    }

    void OnBulletCreated(GameObject gameObject)
    {
        Bullet newBullet = gameObject.GetComponent<Bullet>();  
        newBullet.Project(transform.up);
        cooldown = 0;
    }    
}
