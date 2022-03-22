using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bloque : MonoBehaviour
{
    public int resistencia = 3;
    public UnityEvent aumentarPuntaje;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Bola")
        {
            rebotarPelota(collision);
        }
    }
    public virtual void rebotarPelota(Collision collision)
    {
        Vector3 direccion = collision.contacts[0].point - transform.position;
        direccion = direccion.normalized;
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().velocidadBola*direccion;
        Debug.Log("se redujo la resistencia " + resistencia--);
        //resistencia--;
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (resistencia<=0)
        {
            aumentarPuntaje.Invoke();
            Destroy(gameObject);
        }
        
    }

    
}
