using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Velocidad de movimiento del player")]
    [Range(0,100)]
    private float speed = 2.0f;

    void Start()
    {
        //get the name of the game object
        Debug.Log(name);
        //set the position of the game object
        transform.position = new Vector3 (0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    private void movement()
    {
        //obtaining the player input with the input manager
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //set the translation of the game object to the sides
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        //set the translation of the game object up or down
        transform.Translate(Vector3.up * Time.deltaTime * verticalInput * speed);
        barrierControl();
    }

    private void barrierControl()
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
}
