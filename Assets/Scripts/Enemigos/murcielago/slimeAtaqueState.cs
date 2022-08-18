using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeAtaqueState : MonoBehaviour
{
    //Este script pertenecia originalmente a un enemigo slime pero
    //fue desechado y reutilizado para desarrollar a los murcielagos
    public float velocidad;
    public float daño;
    public slimeAnimatorController animatorSlime;

    private Vector2 target;
    private slimeStateMachine stateMachine;
    private Transform player;
    private bool puedoAtacar = true;
    private progresionNiveles progresion;

    public delegate void slimeGolpeaJugador(float daño);
    public static event slimeGolpeaJugador golpear;

    private void OnEnable()
    {
        progresion = GameObject.FindGameObjectWithTag("Tipo").GetComponent<progresionNiveles>();
        velocidad = progresion.velocidadMurcielago;
        animatorSlime.cambiarAnimacion(animatorSlime.SlimeAtack);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.position;
        puedoAtacar = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        stateMachine = GetComponent<slimeStateMachine>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector2.Distance(transform.position, target);
        if (dis > 0.3f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, velocidad * Time.deltaTime);
        }
        else if (puedoAtacar)
        {
            puedoAtacar =false ;
            animatorSlime.cambiarAnimacion(animatorSlime.SlimeMove);
            Invoke("volverAPerseguir", 1.5f);     
        }
    }
    public  void dañarJugador()
    {
        golpear(daño);
    }

    void volverAPerseguir()
    {
        if (stateMachine.currentState == this)
            stateMachine.cambiarState("perseguir");
    }
}
