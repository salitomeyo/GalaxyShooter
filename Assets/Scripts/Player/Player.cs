using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] [Tooltip("Player movement speed")] [Range(0,100)]
    private float _speed = 2.0f;

    [SerializeField] [Tooltip("Laser prefab")]
    private GameObject _bulletPrefab; 

    [SerializeField] [Tooltip("Fire cooldown time")] [Range(0,2)]
    private float _fireRateTime = 0.25f;

    [SerializeField] [Tooltip("Player lives")]
    private int _playerLives = 3;
    private float _canFire = 0f;
    private bool _isDestroyed = false;
    private Animator _animator;
    private PlayerPowerups _playerPowerups;

    private void Awake() {
        _playerPowerups = gameObject.GetComponent<PlayerPowerups>();
        _animator = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        //set the position of the game object
        transform.position = new Vector3 (0f, 0f, 0f);
    }

    void Update()
    {
        if (!_isDestroyed)
        {
            Movement();
            Shooting();
        }
    }

    private void Movement()
    {
        //obtaining the player input with the input manager
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (!_playerPowerups.canSpeedUp)
        {
            //set the translation of the game object to the sides
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * _speed);
            //set the translation of the game object up or down
            transform.Translate(Vector3.up * Time.deltaTime * verticalInput * _speed);
        }
        else
        {
            //set the translation of the game object to the sides
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * _speed * 2);
            //set the translation of the game object up or down
            transform.Translate(Vector3.up * Time.deltaTime * verticalInput * _speed * 2);
        }
        BarrierControl();
    }

    private void BarrierControl()
    {
        if (Mathf.Abs(transform.position.y) > 4.16f)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Sign(transform.position.y)*4.16f, 0f);
        }
        if (Mathf.Abs(transform.position.x) > 9f)
        {
            transform.position = new Vector3(Mathf.Sign(transform.position.x)*-1*9f, transform.position.y, 0f);
        }
    }

    private void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (Time.time > _canFire)
            {
                if (!(_playerPowerups.canTripleShoot)) {
                    Vector3 bulletPosition = transform.position + new Vector3 (0f, 0.88f, 0f);
                    Instantiate(_bulletPrefab, bulletPosition, Quaternion.identity);
                }
                else
                {
                    _playerPowerups.TripleShoot();
                }
                _canFire = Time.time + _fireRateTime;
            }
        }
    }

    public void TakeLife()
    {
        _playerLives -= 1;

        if (_playerLives < 1)
        {
            StartCoroutine(PlayerExplosionController());
        }
    }

    IEnumerator PlayerExplosionController()
    {
        _animator.SetTrigger("Explote");
        _isDestroyed = true;
        yield return new WaitForSeconds(2.6f);
        Destroy(gameObject);
    }
}
