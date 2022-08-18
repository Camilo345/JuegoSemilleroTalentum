using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeVida : MonoBehaviour
{ //Este script pertenecia originalmente a un enemigo slime pero
    //fue desechado y reutilizado para desarrollar a los murcielagos
    public float vidaMaxima;
    public float vidaActual;

    private bool estaMuerto = false;

    public slimeStateMachine stateMachine;
    public slimeAnimatorController animator;

    public delegate void slimeMuerto(Vector2 pos);
    public static event slimeMuerto muerto;
    private void OnEnable()
    {
        vidaActual = vidaMaxima;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bajarVida(float daño)
    {
        if (!estaMuerto)
        {
            vidaActual -= daño;
            if (vidaActual <= 0)
            {
                estaMuerto = true;
                animator.cambiarAnimacion(animator.SlimeDeath);
                stateMachine.cambiarState("Parado");
                muerto(transform.position);
                Invoke("morir", 2f);

            }
        } 
    }

    void morir()
    {
        stateMachine.cambiarState("Perseguir");
   
        this.gameObject.SetActive(false);
    }
}
