using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlIndicadores : MonoBehaviour
{
    public indicadores indicadores;
    public float puntaje = 0;

    public puerta scriptPuerta;
    private void OnEnable()
    {
        eventosEnemigosDerrotados.enemigoMuerto += enemigoMuerto;
        VidaPlayer.jugadorDañado += calcularPuntaje;
        enemigosEnLaSala.salaLimpia += salaLimpia;
        pocion.agarroPocion += sumarPocion;
    }
    private void OnDisable()
    {
        eventosEnemigosDerrotados.enemigoMuerto -= enemigoMuerto;
        VidaPlayer.jugadorDañado -= calcularPuntaje;
        enemigosEnLaSala.salaLimpia -= salaLimpia;
        pocion.agarroPocion -= sumarPocion;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void enemigoMuerto(Vector2 pos)
    {
        int enemigosMuer = indicadores.GetEnemigosDerrotados();
        enemigosMuer++;
        indicadores.SetEnemigosDerrotados(enemigosMuer);
        calcularPuntaje(8);

        float energia = indicadores.GetEnergiaRecogida();
        energia += scriptPuerta.energiaPorEnemigo;
        indicadores.SetEnergiaRecogida((int)energia);
    }

  void  calcularPuntaje(float sumar)
    {
        float valorAsumar = sumar;
        if (valorAsumar < 0)
        {
            valorAsumar = Mathf.Abs(valorAsumar);
            valorAsumar *= 0.1f;
        }
        puntaje = indicadores.GetPuntaje();
        puntaje += valorAsumar;
     
        indicadores.SetPuntaje(puntaje);
    }

    void salaLimpia()
    {
        int salas = indicadores.GetSalasLimpiadas();
        salas++;
        indicadores.SetSalasLimpiadas(salas);
    }

    void sumarPocion()
    {
        int numeroPocion = indicadores.GetPociones();
        numeroPocion++;
        indicadores.SetPociones(numeroPocion);
    }
}
