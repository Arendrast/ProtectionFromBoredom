using UnityEngine;

public class LightBullet : MonoBehaviour
{
    [SerializeField] private GameObject _particle;
    private ShootingSystemLibrary _shootingSystemLibraryScript;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<Asteroid>(out var MoveAsteroidScript))
        {
            _shootingSystemLibraryScript.PoolBullet.Release(gameObject);
            CancelInvoke(nameof(ReturnBulletInPool));
            Instantiate(_particle, transform.position, Quaternion.identity);
        }
    }
    private void Start()
    {
        _shootingSystemLibraryScript = FindObjectOfType<ShootingSystemLibrary>();
        Invoke(nameof(ReturnBulletInPool), 2);  
    }
    private void ReturnBulletInPool() => _shootingSystemLibraryScript.PoolBullet.Release(gameObject);
}
