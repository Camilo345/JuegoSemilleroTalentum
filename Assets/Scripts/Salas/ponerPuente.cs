using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ponerPuente : MonoBehaviour
{
    public List<SpriteRenderer> listaPuentes;
    public List<GameObject> listaBlqueos;
    public CinemachineVirtualCamera cmvc;
    public bool esCentral;

    private List<SpriteRenderer> listaSpriteColor;
    private void OnEnable()
    {
        if(!esCentral)
        cmvc.Priority = 7;
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void quitarBloqueoNuevo(int dir)
    {
       
         switch (dir)
         {
             case 0:
                activarPuente(2);
                break;
             case 1:
                activarPuente(3);
                break;
             case 2:
                activarPuente(0);
                break;
             case 3:
                activarPuente(1);
                break;
         }
        
    }

    public void quitarBloqueoViejo(int dir)
    {
        switch (dir)
        {
            case 0:
                activarPuente(0);
                break;
            case 1:
                activarPuente(1);
                break;
            case 2:
                activarPuente(2);
                break;
            case 3:
                activarPuente(3);
                break;
        }

    }

    void activarPuente(int ind)
    {
        Color c = listaPuentes[ind].color;
        listaBlqueos[ind].SetActive(false);
        c.a = 1;
        listaPuentes[ind].color = c;
    }
}
