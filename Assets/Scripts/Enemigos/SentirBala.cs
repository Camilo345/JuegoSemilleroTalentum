using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentirBala : MonoBehaviour
{
    public slimeAnimatorController Animator;
    public slimeStateMachine stateMachine;
    public slimeVida vidaSlime;

    public slimeAtaqueState ataqueSlime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            float da�o = collision.gameObject.GetComponent<Bala>().da�o;
            collision.gameObject.SetActive(false);
            vidaSlime.bajarVida(da�o);
            stateMachine.cambiarState("parado");
            if (vidaSlime.vidaActual > 0)
                Animator.cambiarAnimacion(Animator.SlimeDa�o);
            Invoke("pasarAperseguir", 1f);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
           if(ataqueSlime.enabled==true)
            {
                ataqueSlime.da�arJugador();
            }
        }
    }

    void pasarAperseguir()
    {
        if(vidaSlime.vidaActual>0)
        stateMachine.cambiarState("perseguir");
    }
}
