
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class CharacterController2D : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;

    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;

    [SerializeField] private StartAssetInputPlayer _input;
    [FormerlySerializedAs("_state")] [SerializeField] private StatsPlayer stats;
    [SerializeField] private CharacterControllerAnimation _caste;
    [SerializeField] private bool _pauseOn;
    [SerializeField] private bool _inputUp;
    [SerializeField] private GameObject Pause;

    public bool IsGrounded => isGrounded;

    // Use this for initialization
    void Start()
    {
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.pause == 0)
        {
            _inputUp = true;
        }
        else if (_input.pause > 0 && !_pauseOn && _inputUp)
        {
            _pauseOn = true;
            _inputUp = false;
            Time.timeScale = 0;
            Pause.SetActive(true);
        }
        else if (_input.pause > 0 && _pauseOn && _inputUp)
        {
            _pauseOn = false;
            _inputUp = false;
            Time.timeScale = 1;
            Pause.SetActive(false);
        }


        if (!_pauseOn)
        {
            if (stats.Life <= 0)
            {
                _input.walk = 0;
                _input.jump = 0;
                _input.caste = 0;
                _input.attack = 0;
            }

            if (!_caste.Caste)
            {
                // Movement controls
                if ((_input.walk < 0 || _input.walk > 0) /*&& (isGrounded || Mathf.Abs(r2d.velocity.x) > 0.01f)*/)
                {
                    moveDirection = _input.walk < 0 ? -1 : 1;
                }
                else
                {
                    if (isGrounded || r2d.velocity.magnitude < 0.01f)
                    {
                        moveDirection = 0;
                    }
                }
            }

            // Change facing direction
            if (moveDirection != 0)
            {
                if (moveDirection > 0 && !facingRight)
                {
                    facingRight = true;
                    t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
                }

                if (moveDirection < 0 && facingRight)
                {
                    facingRight = false;
                    t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
                }
            }

            if (!_caste.Caste)
            {
                // Jumping
                if (_input.jump > 0 && isGrounded)
                {
                    r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
                }
            }
        }
    }

    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos =
            colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    break;
                }
            }
        }

        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);

        // Simple debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0),
            isGrounded ? Color.green : Color.red);
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0),
            isGrounded ? Color.green : Color.red);
    }
}