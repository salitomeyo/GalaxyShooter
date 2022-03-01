using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    [SerializeField] [Tooltip("Velocidad de movimiento en Y")] [Range(0,100)]
    private float _forwardSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector3.up * _forwardSpeed * Time.deltaTime);

        if (Mathf.Abs(transform.position.y) > 5.9f)
        {
            Destroy(gameObject);
        }
    }
}
