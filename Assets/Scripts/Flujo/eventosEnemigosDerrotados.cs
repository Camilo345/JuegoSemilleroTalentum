using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventosEnemigosDerrotados : MonoBehaviour
{

    public delegate void enemigosDerrotado(Vector2 pos);
    public static event enemigosDerrotado enemigoMuerto;

    private void OnEnable()
    {
        slimeVida.muerto += enemigosMuerto;
        vidaCalavera.muerto += enemigosMuerto;
    }
    private void OnDisable()
    {
        slimeVida.muerto -= enemigosMuerto;
        vidaCalavera.muerto -= enemigosMuerto;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void enemigosMuerto(Vector2 pos)
    {
        Vector2 posicion = pos;
        enemigoMuerto(posicion);
    }
}
