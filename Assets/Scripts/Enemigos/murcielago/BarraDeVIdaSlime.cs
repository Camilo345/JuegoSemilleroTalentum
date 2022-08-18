using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraDeVIdaSlime : MonoBehaviour
{

    //Este script pertenecia originalmente a un enemigo slime pero
    //fue desechado y reutilizado para desarrollar a los murcielagos
    public slimeVida vidaSlime;
    public GameObject barraVida;

    private float escalaMaxima;
    private float vidaActual;
    private float vidaMaxima;
    // Start is called before the first frame update
    void Start()
    {
        escalaMaxima = barraVida.transform.localScale.x;
        vidaMaxima = vidaSlime.vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        reducirEscalaBarraVida();
    }

    void reducirEscalaBarraVida()
    {
        Vector3 escalaNueva = barraVida.transform.localScale;
        escalaNueva.x = (escalaMaxima * vidaSlime.vidaActual) / vidaMaxima;
        escalaNueva.x = Mathf.Clamp(escalaNueva.x, 0, escalaMaxima);
        barraVida.transform.localScale = escalaNueva;
    }
}
