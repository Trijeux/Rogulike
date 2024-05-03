using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Bombe : MonoBehaviour
{
       private StartAssetInputPlayer _player; // Référence au transform du joueur
       [SerializeField][Range(0.1f, 15f)] private float vitesseInitiale = 5f; // Vitesse de déplacement initiale
       [SerializeField][Range(0.1f, 5f)]private float facteurDeVitesse = 1f; // Facteur de modulation de la vitesse
       [SerializeField] private bool _isDead = false;
       [SerializeField] private GameObject _rayonExplotion;
       [SerializeField] private GameObject _explotionCollision;
       [SerializeField] private Animator _explotionAnimator;
       [SerializeField][Range(0.1f, 10f)] private float _tempExplotion;
       [SerializeField][Range(0.1f, 10f)] private float _tempEndExplotion;
       [SerializeField] private GameObject _sprit;
       [SerializeField] private GameObject _hitzone;
       [FormerlySerializedAs("_kill")] [SerializeField] private HitEnnemie hit;
       private bool _explotion;

       private bool _explotionStart = false;
       private Rigidbody2D rb;
   
       void Start()
       {
           rb = GetComponent<Rigidbody2D>();
           _player = FindFirstObjectByType<StartAssetInputPlayer>();
       }
   
       void Update()
       {
           _isDead = hit.IsHit;
           if (_isDead)
           {
               _explotion = true;
           }
           if (!_explotion)
           {
               Vector2 direction = (_player.transform.position - transform.position).normalized;

          
               float vitesse = vitesseInitiale * facteurDeVitesse;

          
               rb.MovePosition(rb.position + direction * vitesse * Time.deltaTime);

               // Rotation pour faire face au joueur sur l'axe Z uniquement
               Vector2 directionSansY = new Vector2(_player.transform.position.x - transform.position.x, _player.transform.position.y - transform.position.y);
               float angle = Mathf.Atan2(directionSansY.y, directionSansY.x) * Mathf.Rad2Deg + 90f; // Ajout de 90 degrés
               Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
               transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
           }

           if (_explotion && !_explotionStart)
           {
               StartCoroutine(Explotion());
               _explotionStart = true;
           }
       }
       
       IEnumerator Explotion()
       {
           _rayonExplotion.SetActive(true);
           yield return new WaitForSeconds(_tempExplotion);
           _explotionAnimator.SetFloat("Explotion", 1f);
           _rayonExplotion.SetActive(false);
           _explotionCollision.SetActive(true);
           _hitzone.SetActive(true);
           yield return new WaitForSeconds(_tempEndExplotion);
           _sprit.SetActive(false);
           _explotionAnimator.SetFloat("Explotion", 0f);
           yield return new WaitForSeconds(0.5f);
           Destroy(gameObject);
       }
}
