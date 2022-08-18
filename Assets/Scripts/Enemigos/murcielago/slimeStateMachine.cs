using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeStateMachine : MonoBehaviour
{
    //Este script pertenecia originalmente a un enemigo slime pero
    //fue desechado y reutilizado para desarrollar a los murcielagos
    public string estado;
    public MonoBehaviour currentState;

    public MonoBehaviour paradoState;
    public MonoBehaviour perseguirState;
    public MonoBehaviour atacarState;

    private void OnEnable()
    {
        VidaPlayer.jugadorMurio += JugadorMuerto;
    }

    private void OnDisable()
    {
        VidaPlayer.jugadorMurio -= JugadorMuerto;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        cambiarState("perseguir");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarState(string state)
    {
        estado = state;

        switch (state)
        {
            case "parado":
                actualizarEstado(paradoState);
                break;
            case "perseguir":
                actualizarEstado(perseguirState);
                break;
            case "Atacar":
                actualizarEstado(atacarState);
                break;
            
        }
    }
        public void actualizarEstado(MonoBehaviour script)
        {

            if (currentState != null) currentState.enabled = false;
            currentState = script;
            currentState.enabled = true;

        }

        private void JugadorMuerto()
        {
          //  apagarChecks();
        
            cambiarState("parado");
        }
    }

