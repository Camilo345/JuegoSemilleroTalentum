using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeAnimatorController : MonoBehaviour
{

    //Este script pertenecia originalmente a un enemigo slime pero
    //fue desechado y reutilizado para desarrollar a los murcielagos
    public Animator anim;

    public string SlimeIddle = "Iddle";
    public string SlimeMove = "Move";
    public string SlimeDaño = "Daño";
    public string SlimeAtack = "Atack";
    public string SlimeDeath = "Death";

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
