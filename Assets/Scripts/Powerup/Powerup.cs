using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] [Tooltip("Velocidad de movimiento en Y")] [Range(0,10)]
    private float _speed = 2f;

    [SerializeField] [Tooltip("Powerup id")] [Range(0, 2)]
    private int _powerupId = 0;

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
                if (_powerupId == 0)
                {
                    player.TripleShootPowerupOn();
                }
                else if (_powerupId == 1)
                {
                    player.SpeedUpPowerupOn();
                }
            }
            Destroy(gameObject);
        }    
    }
}
