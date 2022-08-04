using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animPlayer;
    public Animator animArco;

    private Vector2 movement;
    private bool playerMuerto = false;
    private void OnEnable()
    {
        BalasManager.dispararArco += disparar;
        VidaPlayer.jugadorMurio += lose;
        VidaPlayer.jugadorDañado += daño;
    }

    private void OnDisable()
    {
        BalasManager.dispararArco -= disparar;
        VidaPlayer.jugadorMurio -= lose;
        VidaPlayer.jugadorDañado -= daño;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement.x!=0 || movement.y != 0)
        {
            animacionCaminar(true);
        }
        else
        {
            animacionCaminar(false);
        }
    }

    public void animacionCaminar(bool estaCaminando) 
    {
       
        animPlayer.SetBool("walking", estaCaminando);
    }
 
    public void lose()
    {
        Invoke("animacionMorir",1f);
    }

    void animacionMorir()
    {
        animPlayer.SetTrigger("playerDie");
        playerMuerto = true;
    }

    public void daño(float daño)
    {
        if (!playerMuerto)
        {
            animPlayer.SetTrigger("playerDamage");
        }
       
    }

    public void disparar()
    {
       // Debug.Log("aqui estoy");
      //  animArco.SetTrigger("disparar");
    }
}
