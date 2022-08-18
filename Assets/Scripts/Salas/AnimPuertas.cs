using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPuertas : MonoBehaviour
{
    public Animator anim;
    private void OnEnable()
    {
        enemigosEnLaSala.abrirCerrar += cambiarEstadoPuerta;
        anim = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        enemigosEnLaSala.abrirCerrar -= cambiarEstadoPuerta;
    }
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void cambiarEstadoPuerta(bool estado)
    {
        anim.SetBool("AbrirPuerta", estado);
    }
}
