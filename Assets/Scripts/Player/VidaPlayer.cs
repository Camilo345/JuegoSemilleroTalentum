using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public float vidaMaxima = 0;
    public static float vidaActual;


    public delegate void jugadorMuerto();
    public static event jugadorMuerto jugadorMurio;

    public delegate void eventoDaño(float daño);
    public static event eventoDaño jugadorDañado;

    private bool estoyMuerto = false;
    private void OnEnable()
    {
        slimeAtaqueState.golpear += bajarVida;
    }

    private void OnDisable()
    {
        slimeAtaqueState.golpear -= bajarVida;
    }
    // Start is called before the first frame update
    void Start()
    {
        progresionNiveles progresion = GameObject.FindGameObjectWithTag("Tipo").GetComponent<progresionNiveles>();
        if(progresion.getNivel()<2)
        vidaActual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bajarVida(float daño)
    {
        vidaActual -= daño;
        vidaActual = Mathf.Clamp(vidaActual, -1, vidaMaxima);
        jugadorDañado(-daño);
        if (vidaActual <= 0 && !estoyMuerto)
        {
            estoyMuerto = true;
            morir();

        }
    }

    void morir()
    {    
            estoyMuerto = true;
            jugadorMurio();     
    }

    public float getVida()
    {
        return vidaActual;
    }
}
