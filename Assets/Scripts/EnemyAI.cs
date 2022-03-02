using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] [Tooltip("Enemy movement speed")] [Range(0, 100)]
    private float _speed = 5f;

    private Animator _animator;
    private bool _isDestroyed = false;

    private void Awake() {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (!_isDestroyed)
        {
            transform.Translate(Vector3.down * _speed  * Time.deltaTime);

            if (transform.position.y < -5.7f)
            {
                float randomX = Random.Range(-8.34f, 8.34f);
                transform.position =  new Vector3(randomX,  5.39f, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeLife();
            }
            StartCoroutine(ExplotionController());
        }
        else if (other.tag == "Laser")
        {
            StartCoroutine(ExplotionController());
        }
    }

    IEnumerator ExplotionController()
    {
        _isDestroyed = true;
        _animator.SetTrigger("Explote");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
