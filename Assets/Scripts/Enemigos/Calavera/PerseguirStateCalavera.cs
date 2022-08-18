using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerseguirStateCalavera : MonoBehaviour
{
    public AnimationController_Calavera anim;
    public Transform spriteCalavera;

    private CalaveraStateMachine stateMachine;
    public float velocidad = 0;
    private Transform player;
   private bool puedoMoverme = false;
    private Vector2 target;


    private void OnEnable()
    {
        anim.cambiarAnimacion(anim.CalaveraIddle);
        puedoMoverme = false;
        escogerTarget();
        cambiarPuedoMoverme();
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stateMachine = GetComponent<CalaveraStateMachine>();
      
    }

    // Update is called once per frame
    void Update()
    {
        ajustarEscalaEnX();
        if (puedoMoverme)
        moverse();
    }

    void moverse()
    {
        float dis = Vector2.Distance(transform.localPosition, target);
        
        if (dis < 1)
        {
             stateMachine.cambiarState("Atacar");
        }
        else
        {
            
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, velocidad * Time.deltaTime);
        }
    }

    void cambiarPuedoMoverme()
    {
        puedoMoverme = true;
    }

    void ajustarEscalaEnX()
    {
        if (player.transform.position.x > transform.position.x)
        {
            spriteCalavera.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            spriteCalavera.localScale = new Vector3(-1, 1, 1);
        }
    }

    void escogerTarget()
    {
        target.y = Random.Range(-4.5f, 4.5f);
        target.x = Random.Range(-8.5f, 8.5f);
    }
}
