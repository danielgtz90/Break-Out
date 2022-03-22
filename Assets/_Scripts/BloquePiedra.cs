using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloquePiedra : Bloque
{
    // Start is called before the first frame update
    void Start()
    {
        resistencia = 4;
    }

    public override void rebotarPelota(Collision collision)
    {
        base.rebotarPelota(collision);
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
