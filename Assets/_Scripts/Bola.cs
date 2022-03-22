using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bola : MonoBehaviour
{
    public bool isGameStarted = false;
    [SerializeField] public float velocidadBola = 12f;
    private Vector3 ultimaPosicion = Vector3.zero;
    Vector3 direccion = Vector3.zero;
    private Rigidbody rigidbody;
    private ControlBorde control;
    public UnityEvent BolaDestruida;

    private void Awake()
    {
        control = GetComponent<ControlBorde>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 posicionInicial = GameObject.FindGameObjectWithTag("Player").transform.position;
        posicionInicial.y += 1.0f;
        transform.position = posicionInicial;
        transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void HabilitarControl()
    {
        control.enabled = true;
    }

    private void FixedUpdate()
    {
        ultimaPosicion = transform.position;
    }
    private void LateUpdate()
    {
        // ReSharper disable once RedundantCheckBeforeAssignment
        if (direccion != Vector3.zero) direccion = Vector3.zero;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isGameStarted)
            {
                isGameStarted = true;
                transform.SetParent(null);
                GetComponent<Rigidbody>().velocity = velocidadBola * Vector3.up;
            }
        }
        if (control.salioAbajo)
        {
            BolaDestruida.Invoke();
            Destroy(gameObject);
        }

        if (control.salioArriba)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola ha salido del borde");
            direccion.y *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioArriba = false;

            control.enabled = false;
            Invoke("HabilitarControl",0.5f);
        }
        if (control.salioDerecha)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola ha salido del borde");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioDerecha = false;
            control.enabled = false;
            Invoke("HabilitarControl",0.5f);
        }
        if (control.salioIzquierda)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola ha salido del borde");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioIzquierda = false;
            control.enabled = false;
            Invoke("HabilitarControl",0.5f);
        }
        
    }

    

  
}
