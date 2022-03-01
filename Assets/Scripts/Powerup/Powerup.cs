using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] [Tooltip("Velocidad de movimiento en Y")] [Range(0,10)]
    private float _speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.up * -_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerPowerups player = other.GetComponent<PlayerPowerups>();
            if (player != null)
            {
                player.canTripleShoot = true;
            }

            player.TripleShootPowerupOn();
            Destroy(gameObject);
        }    
    }
}
