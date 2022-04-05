using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject _player;
    public GameObject _gun;
    public GameObject spawnPosition;
    Rigidbody rb;


    #region move
    private Vector3 _direction;
    public float _speed = 7f;
    #endregion

    #region mouseMove
    private float rotationX;
    private float rotationY;

    float rotationXCurrent;
    float rotationYCurrent;

    float currentVelocityX;
    float currentVelocityY;

    public float smoothTime = 0.1f;
    public float _sensetivity = 4f;

    public Camera _playerCamera;
    public Camera _gunCamera;
    
    #endregion

    #region Jump

    public float _jumpForce = 30f;
    private readonly Vector3 jumpDirection = Vector3.up;

    public bool _isGrounded = true;

    #endregion

    #region Fire
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    [SerializeField] public float B_cooldown = 0;
    public bool _isFired = false; 
    #endregion

    #region SetMine
    [SerializeField] public Transform mineSpawn;
    [SerializeField] public GameObject minePrefab;
    [SerializeField] public float _cooldown = 0;
    public bool _mineset = false;

    #endregion

    #region Grenade
    [SerializeField] public Transform grenadeSpawn;
    [SerializeField] public GameObject grenadePrefab;
    [SerializeField] public float G_cooldown = 0;
    public bool _isGrenaded = false;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
        MouseMove();
        Fire();
        SetMine();
        FireGrenade();
        Jump();
    }

    private void Move()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        var speed = _direction * _speed * Time.deltaTime;
        transform.Translate(speed);
    }

    private void MouseMove()
    {
        rotationX += Input.GetAxis("Mouse X") * _sensetivity;
        rotationY += Input.GetAxis("Mouse Y") * _sensetivity;

        rotationY = Mathf.Clamp(rotationY, -90, 90);

        rotationXCurrent = Mathf.SmoothDamp(rotationXCurrent, rotationX, ref currentVelocityX, smoothTime);
        rotationYCurrent = Mathf.SmoothDamp(rotationYCurrent, rotationY, ref currentVelocityY, smoothTime);

        _playerCamera.transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0f);
        _gunCamera.transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0f);

        _player.gameObject.transform.rotation = Quaternion.Euler(0, rotationX, 0f);
        _gun.gameObject.transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0f);

        spawnPosition.gameObject.transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0f);


    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0) && _isFired == false)
        {
            _ = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            B_cooldown = 0.1f;
            _isFired = true;
        } else
        {
            B_cooldown -= Time.deltaTime;
            if (B_cooldown <= 0)
            {
                _isFired = false;
                B_cooldown = 0;
            }
        }
    }

    private void SetMine()
    {
        if (Input.GetKeyDown(KeyCode.E) && _mineset == false)
        {
            var myMine = Instantiate(minePrefab, mineSpawn.position, mineSpawn.rotation);
            _cooldown = 3;
            _mineset = true;
        }
        else
        {
            _cooldown -= Time.deltaTime;
            if (_cooldown <= 0)
            {
                _mineset = false;
                _cooldown = 0;
            }
        }
    }

   private void FireGrenade()
    {
        if (Input.GetKeyDown(KeyCode.G) && _isGrenaded == false)
        {
            var grenadeObj = Instantiate(grenadePrefab, grenadeSpawn.position, grenadeSpawn.rotation);

            G_cooldown = 3;
            _isGrenaded = true;

        } else
        {
            G_cooldown -= Time.deltaTime;
            if (G_cooldown <= 0)
            {
                _isGrenaded = false;
                G_cooldown = 0;
            }
        }
    }

    private void Jump()
    {
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpDirection * _jumpForce, ForceMode.Impulse);
            
        }
    }

    private void OnCollisionEnter()
    {
        var ground = GameObject.FindGameObjectWithTag("Ground");
        if (ground)
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit()
    {
        var ground = GameObject.FindGameObjectWithTag("Ground");
        if (ground)
        {
            _isGrounded = false;
        }
    }
}
