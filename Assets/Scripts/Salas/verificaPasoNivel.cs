using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class verificaPasoNivel : MonoBehaviour
{
    public GameObject panel;
    private bool jugadorPaso = false;

    public delegate void eventoPasarNivel();
    public static event eventoPasarNivel pasarNivel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !jugadorPaso)
        {
            jugadorPaso = true;
            panel.SetActive(true);
            Invoke("cambiarNivel", 1.5f);
        }
    }

    void cambiarNivel()
    {
        pasarNivel();
        SceneManager.LoadScene(2);
    }
}
