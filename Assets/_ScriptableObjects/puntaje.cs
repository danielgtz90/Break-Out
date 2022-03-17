using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class puntaje : MonoBehaviour
{
    public Transform transformRecord;
    public Transform transformPuntaje;
    public TMP_Text textoRecord;
    public TMP_Text textoActual;
    public Record RecordSO;
   // public int puntos;
   // public int record;
    // Start is called before the first frame update
    void Start()
    {
        transformPuntaje = GameObject.Find("Puntaje").transform;
        transformRecord = GameObject.Find("Record").transform;
        textoActual = transformPuntaje.GetComponent<TMP_Text>();
        textoRecord = transformRecord.GetComponent<TMP_Text>();
        //if (PlayerPrefs.HasKey("Puntaje"))
       // {
            //record = PlayerPrefs.GetInt("Record");
            //}
        RecordSO.Cargar();
        textoRecord.text = $"Record: {RecordSO.record}";
        RecordSO.puntaje = 0;
        
    }

    private void FixedUpdate()
    {
        RecordSO.puntaje += 50;
    }

    // Update is called once per frame
    void Update()
    {
        textoActual.text = $"Puntaje: {RecordSO.puntaje}";
        if (RecordSO.puntaje > RecordSO.record)
        {
            RecordSO.record = RecordSO.puntaje;
            textoRecord.text = $"Record: {RecordSO.record}";
            RecordSO.Guardar();
           // PlayerPrefs.SetInt("Record",puntos);
        }
        
    }
}
