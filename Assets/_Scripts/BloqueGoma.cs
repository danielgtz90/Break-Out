using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueGoma : Bloque
{
    // Start is called before the first frame update
    void Start()
    {
        resistencia = 1;
    }
    public override void rebotarPelota(Collision collision)
    {
        base.rebotarPelota(collision);
    }

    // Update is called once per frame
    public virtual void acelerarPelota()
    {
        
    }
}
