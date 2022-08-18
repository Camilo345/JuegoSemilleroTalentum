using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicadores : MonoBehaviour
{

    public static int numeroOleada;
    public static int enemigosDerrotados;
    public static float puntaje;


    public static int energiaRecogida;
    public static int salasLimpiadas;
    public static int numeroPociones;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPuntaje(float nuevoPuntaje)
    {
        puntaje = nuevoPuntaje;
    }

    public float GetPuntaje()
    {
        return puntaje;
    }

    public void SetEnemigosDerrotados(int numeroEnemigos)
    {
        enemigosDerrotados = numeroEnemigos;
    }

    public int GetEnemigosDerrotados()
    {
        return enemigosDerrotados;
    }

    public void SetNumeroOleada(int oleada)
    {
        numeroOleada = oleada;
    }

    public int GetNumeroOleada()
    {
        return numeroOleada;
    }

    public int GetSalasLimpiadas()
    {
        return salasLimpiadas;
    }

    public void SetSalasLimpiadas(int salas)
    {
        salasLimpiadas = salas;
    }

    public int GetEnergiaRecogida()
    {
        return energiaRecogida;
    }

    public void SetEnergiaRecogida(int energia)
    {
        energiaRecogida = energia;
    }

    public void SetPociones(int pocion)
    {
        numeroPociones = pocion;
    }

    public int GetPociones()
    {
        return numeroPociones;
    }
}
