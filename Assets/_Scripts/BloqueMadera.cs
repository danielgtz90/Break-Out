using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueMadera : Bloque
{
    // Start is called before the first frame update
    void Start()
    {
        resistencia = 3;
    }

    public override void rebotarPelota()
    {
        base.rebotarPelota();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
