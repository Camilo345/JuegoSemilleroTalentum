using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progresionNiveles : MonoBehaviour
{
    public static int nivel;
    public int velocidadMurcielago;
    public int velocidadCalavera;

    public enemigosPorPiso tipoEne;
    public puerta scriptPuerta;
    public GenerarSalas salas;
    public indicadores indi;


    private void OnEnable()
    {
        verificaPasoNivel.pasarNivel += aumentarNivel;
    }

    private void OnDisable()
    {
        verificaPasoNivel.pasarNivel -= aumentarNivel;
    }

    private void Awake()
    {
        escogerNumeroSalas();
    }
    // Start is called before the first frame update
    void Start()
    {
        nivel = indi.GetNumeroOleada();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void escogerNumeroSalas()
    {

        switch (nivel)
        {
            case 1:
                ajustarParametrosNivel(3, 3,1,10,6);
                break;
            case 2:
                ajustarParametrosNivel(5, 2.5f,1,8,8);
                break;
            case 3:
                ajustarParametrosNivel(6, 2,2,8,10);
                break;
            case 4:
                ajustarParametrosNivel(7, 1.5f,2,10,11);
                break;
            case 5:
                ajustarParametrosNivel(10, 1,2,12,12);
                break;
        }
        if (nivel > 5)
        {
            ajustarParametrosNivel(10, 1,2,14,13);
        }
    }

    void ajustarParametrosNivel(int numSalas,float divisor,int tipo,int velCal,int velMur)
    {
        scriptPuerta.divisorEnergia = divisor;
        salas.numeroSalas = numSalas;
        tipoEne.tipoEnemigo = tipo;
        velocidadCalavera = velCal;
        velocidadMurcielago = velMur;
    }

    void aumentarNivel()
    {
        nivel++;
        indi.SetNumeroOleada(nivel);
    }

    public void setNivel(int nuevoNivel)
    {
        nivel = nuevoNivel;
    }

    public int getNivel()
    {
        return nivel;
    }
}
