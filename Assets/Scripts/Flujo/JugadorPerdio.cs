using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorPerdio : MonoBehaviour
{
    public indicadores scriptIndicadores;
    private void OnEnable()
    {
        VidaPlayer.jugadorMurio += jugadorPerdio;
    }

    private void OnDisable()
    {
        VidaPlayer.jugadorMurio -= jugadorPerdio;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void jugadorPerdio()
    {
        Invoke("llamarMetodosDerrota", 5f);
    }

    void llamarMetodosDerrota()
    {
        cambiarEscena();
        guardarindicadores();
    }

    void guardarindicadores()
    {
        
    }

    void cambiarEscena()
    {
        int nivel = scriptIndicadores.GetNumeroOleada();
        nivel--;
        scriptIndicadores.SetNumeroOleada(nivel);
        SceneManager.LoadScene(3);
    }
}
