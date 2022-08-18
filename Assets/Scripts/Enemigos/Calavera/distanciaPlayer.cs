using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanciaPlayer : MonoBehaviour
{
    private CalaveraStateMachine stateMachine;
    private Transform player;
    private bool puedoMoverme = false;
    private void OnEnable()
    {
        puedoMoverme = false;
        Invoke("cambiarPuedoMoverme", 2);
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
        if(puedoMoverme)
        moverse();
    }

    void moverse()
    {
        float dis = Vector2.Distance(transform.position, player.transform.position);
        if (dis > 5)
        {
            // stateMachine.cambiarState("Atacar");
        }
        else
        {
            stateMachine.cambiarState("perseguir");
        }
    }

    void cambiarPuedoMoverme()
    {
        puedoMoverme = true;
    }
}
