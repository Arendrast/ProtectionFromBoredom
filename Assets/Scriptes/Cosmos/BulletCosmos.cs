using UnityEngine;

public class BulletCosmos : MonoBehaviour
{
    [SerializeField] private GameObject Particle;
    private ShootingSystemLibrary ShootingSystemLibraryScript;
    private void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.TryGetComponent<MoveAsteroid>(out var MoveAsteroidScript))
        {
            ShootingSystemLibraryScript.PoolBullet.Release(gameObject);
            CancelInvoke(nameof(ReturnBulletInPool));
            Instantiate(Particle, transform.position, Quaternion.identity);
        }
    }

    private void Start()
    {
        ShootingSystemLibraryScript = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingSystemLibrary>();
        Invoke(nameof(ReturnBulletInPool), 2);  
    }
    private void ReturnBulletInPool() => ShootingSystemLibraryScript.PoolBullet.Release(gameObject);
}
