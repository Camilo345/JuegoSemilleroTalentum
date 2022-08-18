using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaCalavera : MonoBehaviour
{

    public float vidaMaxima;
    public float vidaActual;
    private bool estaMuerto = false;

    public CalaveraStateMachine stateMachine;
    public AnimationController_Calavera animator;

    public delegate void CalaveraMuerta(Vector2 pos);
    public static event CalaveraMuerta muerto;
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bajarVida(float da�o)
    {
        if (!estaMuerto)
        {


            vidaActual -= da�o;
            if (vidaActual <= 0)
            {
                estaMuerto = true;
                animator.cambiarAnimacion(animator.CalaveraMuere);
                stateMachine.cambiarState("parado");
                muerto(transform.position);
                Invoke("morir", 2f);
            }
            else
            {
                stateMachine.cambiarState("parado");
                animator.cambiarAnimacion(animator.CalaveraDa�o);
                Invoke("pasarAperseguir", 1f);
            }
        }
       
    }

    void morir()
    {
        stateMachine.cambiarState("parado");
        
       transform.parent.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            float da�o = collision.gameObject.GetComponent<Bala>().da�o;
            collision.gameObject.SetActive(false);
            bajarVida(da�o);
        }
    }

    void pasarAperseguir()
    {
        if (!estaMuerto)
            stateMachine.cambiarState("perseguir");
    }
}
