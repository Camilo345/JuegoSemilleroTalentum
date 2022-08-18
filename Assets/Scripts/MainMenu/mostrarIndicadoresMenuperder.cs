using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class mostrarIndicadoresMenuperder : MonoBehaviour
{
    public indicadores ind;
    public TMP_Text puntaje;
    public TMP_Text enemigosDerrotados;
    public TMP_Text niveles;
    public TMP_Text energia;
    public TMP_Text salas;
    public TMP_Text objetos;
    // Start is called before the first frame update
    void Start()
    {
        puntaje.text = ind.GetPuntaje()+"";
        enemigosDerrotados.text = ind.GetEnemigosDerrotados() + "";
        niveles.text = ind.GetNumeroOleada() + "";
        salas.text = ind.GetSalasLimpiadas()+"";
        energia.text = ind.GetEnergiaRecogida() + "";
        objetos.text = ind.GetPociones()+"";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
