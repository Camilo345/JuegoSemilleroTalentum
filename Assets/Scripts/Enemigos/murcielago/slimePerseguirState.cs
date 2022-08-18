using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimePerseguirState : MonoBehaviour
{
    //Este script pertenecia originalmente a un enemigo slime pero
    //fue desechado y reutilizado para desarrollar a los murcielagos
    public slimeAnimatorController animatorSlime;
    public Transform spriteSlime;
    public Transform Player;
    public float Velocidad;
    public float distanciaPlayer = 0;

    private Vector2 target;
    private slimeStateMachine stateMachine;
    private void OnEnable()
    {
        animatorSlime.cambiarAnimacion(animatorSlime.SlimeMove);
        escogerTarget();
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        stateMachine = GetComponent<slimeStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        ajustarEscalaEnX();
        bool puedeAtacar = verificarSiPuedeAtacar();
        if (!puedeAtacar)
        {
            //transform.position = Vector3.MoveTowards(transform.position, Player.position, Velocidad * Time.deltaTime);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, Velocidad * Time.deltaTime);
        }
        else
        {
            stateMachine.cambiarState("Atacar");
        }
        
    }

    void ajustarEscalaEnX()
    {
        if (Player.transform.position.x < transform.position.x)
        {
            spriteSlime.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            spriteSlime.localScale = new Vector3(1, 1, 1);
        }
    }

    bool verificarSiPuedeAtacar()
    {
        bool puedeAtacar = false;
        float distancia = calcularDistanciaConJugador();
        if (distancia < 1)
        {
            puedeAtacar = true;
        }
        return puedeAtacar;
    }
    float calcularDistanciaConJugador()
    {
        distanciaPlayer = 0;
        distanciaPlayer = Vector2.Distance(transform.localPosition, target);
        return distanciaPlayer;
    }

    void escogerTarget()
    {
        target.y = Random.Range(-4.5f, 4.5f);
        target.x = Random.Range(-8.5f, 8.5f);
    }
}
