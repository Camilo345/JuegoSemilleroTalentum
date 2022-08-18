using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalaveraStateMachine : MonoBehaviour
{
    public string estado;
    public MonoBehaviour currentState;

    public MonoBehaviour paradoState;
    public MonoBehaviour perseguirState;
    public MonoBehaviour AtacarState;
    private void OnEnable()
    {
        VidaPlayer.jugadorMurio += JugadorMuerto;
        cambiarState("perseguir");
    }

    private void OnDisable()
    {
        VidaPlayer.jugadorMurio -= JugadorMuerto;
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
                actualizarEstado(AtacarState);
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
        cambiarState("parado");
    }
}
