using UnityEngine;
using UnityEngine.Serialization;

public class WizzardFire : MonoBehaviour
{
    public GameObject bulletPrefab; // Préfabriqué de la balle
    public Transform firePoint; // Point d'où la balle est tirée
    public float bulletSpeed = 20f; // Vitesse de la balle
    [SerializeField] private float _bulletRange;

    public float BulletRange => _bulletRange;

    private Transform player; // Transform du joueur

    void Start()
    {
        // Trouver le Transform du joueur
        player = player = GameObject.FindGameObjectWithTag("Player").transform;;
    }

    void Update()
    {
        
    }

    public void Shoot()
    {
        // Calculer la direction de la balle vers le joueur
        Vector2 direction = (player.position - firePoint.position).normalized;

        // Instancier une balle depuis le préfabriqué
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Appliquer un mouvement continu à la balle dans la direction du joueur
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}