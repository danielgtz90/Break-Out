using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueBonus : Bloque
{
    // Start is called before the first frame update
    void Start()
    {
        resistencia = 3;
    }
    
    public override void rebotarPelota(Collision collision)
    {
        base.rebotarPelota(collision);
    }

    // Update is called once per frame
    public virtual void doblePelota()
    {
        
    }
}
