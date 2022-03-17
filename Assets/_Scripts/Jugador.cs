using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private Transform transform;
    private Vector3 mousePos2D;
    private Vector3 mousePos3D;
    [SerializeField] private float velocidadPaddle = 30f;
    [SerializeField] private int limitX = 23;
    // Start is called before the first frame update
    void Start()
    {
        transform = this.gameObject.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bola")
        {
            Vector3 direccion = collision.contacts[0].point - transform.position;
            direccion = direccion.normalized;
            collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().velocidadBola * direccion;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.down*velocidadPaddle*Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.up*velocidadPaddle*Time.deltaTime);
        }
        Vector3 pos = transform.position;
       // pos.x = mousePos3D.x;
        if (pos.x < -limitX)
        {
            pos.x = -limitX;
        }
        else if (pos.x > limitX)
        {
            pos.x = limitX;
        }
        transform.position = pos;
        

    }
}
