using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class temblorCamara : MonoBehaviour
{
    public CinemachineImpulseSource impulse;

    private void OnEnable()
    {
        VidaPlayer.jugadorDañado += temblor;
        eventosEnemigosDerrotados.enemigoMuerto += enemigoDañado;
    }

    private void OnDisable()
    {
        VidaPlayer.jugadorDañado -= temblor;
        eventosEnemigosDerrotados.enemigoMuerto -= enemigoDañado;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void temblor(float d)
    {
        impulse.GenerateImpulse();
    }

    void enemigoDañado(Vector2 d)
    {

        impulse.GenerateImpulse();
    }
}
