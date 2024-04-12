using UnityEngine;

public class FireBullet : MonoBehaviour
{
    private Transform player; // Transform du joueur

    void Start()
    {
        // Trouver le Transform du joueur
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Stocker la position du joueur à la création de la balle
        if (player != null)
        { 
            // Tourner la balle vers le joueur
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }
    }

    void Update()
    {
        
    }
}