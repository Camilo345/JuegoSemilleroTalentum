using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController_Calavera : MonoBehaviour
{

    public Animator anim;

    public string CalaveraIddle = "Iddle";
    public string CalaveraDa�o = "Da�o";
    public string CalaveraAtaque = "ataque";
    public string CalaveraMuere = "Muere";

    private string animacionActual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarAnimacion(string nuevaAnimacion)
    {
        if (animacionActual == nuevaAnimacion) return;

        anim.Play(nuevaAnimacion);
        animacionActual = nuevaAnimacion;
    }
}
