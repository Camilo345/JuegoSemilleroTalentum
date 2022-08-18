using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject panelPause;
    public paginasTutorial tutorial;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        cambiarEstadoPausa();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        

            if (!isPaused)
            {
                tutorial.reiniciar();
            }

            cambiarEstadoPausa();
            Cursor.visible = isPaused;
        }

        
    }

    void cambiarEstadoPausa()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
            panelPause.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            panelPause.SetActive(false);
        }
    }
}
