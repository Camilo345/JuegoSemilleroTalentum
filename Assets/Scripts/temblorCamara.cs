using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class temblorCamara : MonoBehaviour
{
    public CinemachineImpulseSource impulse;

    private void OnEnable()
    {
        VidaPlayer.jugadorDa�ado += temblor;
        eventosEnemigosDerrotados.enemigoMuerto += enemigoDa�ado;
    }

    private void OnDisable()
    {
        VidaPlayer.jugadorDa�ado -= temblor;
        eventosEnemigosDerrotados.enemigoMuerto -= enemigoDa�ado;
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

    void enemigoDa�ado(Vector2 d)
    {

        impulse.GenerateImpulse();
    }
}
