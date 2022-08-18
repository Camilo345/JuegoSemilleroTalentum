using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraDeVidaCalavera : MonoBehaviour
{
    public vidaCalavera vidCalaver;
    public GameObject barraVida;

    private float escalaMaxima;
    private float vidaActual;
    private float vidaMaxima;
    // Start is called before the first frame update
    void Start()
    {
        escalaMaxima = barraVida.transform.localScale.x;
        vidaMaxima = vidCalaver.vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        reducirEscalaBarraVida();
    }

    void reducirEscalaBarraVida()
    {
        Vector3 escalaNueva = barraVida.transform.localScale;
        escalaNueva.x = (escalaMaxima * vidCalaver.vidaActual) / vidaMaxima;
        escalaNueva.x = Mathf.Clamp(escalaNueva.x, 0, escalaMaxima);
        barraVida.transform.localScale = escalaNueva;
    }
}
