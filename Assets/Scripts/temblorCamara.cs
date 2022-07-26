using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class temblorCamara : MonoBehaviour
{
    public CinemachineImpulseSource impulse;

    private void OnEnable()
    {
        VidaPlayer.jugadorDaņado += temblor;
        eventosEnemigosDerrotados.enemigoMuerto += enemigoDaņado;
    }

    private void OnDisable()
    {
        VidaPlayer.jugadorDaņado -= temblor;
        eventosEnemigosDerrotados.enemigoMuerto -= enemigoDaņado;
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

    void enemigoDaņado(Vector2 d)
    {

        impulse.GenerateImpulse();
    }
}
