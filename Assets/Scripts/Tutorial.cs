using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tutorial : MonoBehaviour
{
    public List<GameObject> listaInstrucciones;
    public List<Animator> listaAnim;
    public GameObject botonSiguiente;
    public GameObject botonPlay;

    private int index=0;
    // Start is called before the first frame update
    void Start()
    {
        botonPlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pasarPagina()
    {
        listaAnim[index].Play("desaparecer");
        index++;
        index = Mathf.Clamp(index, 0,2);
      

        if (index == (listaInstrucciones.Count - 1))
        {
            botonPlay.SetActive(true);
            botonSiguiente.SetActive(false);
        }

        Invoke("activarDesactivar", 1.2f);
    }

    public void irAjugar()
    {
        SceneManager.LoadScene(2);
    }

   void activarDesactivar()
    {
        for(int i = 0; i < listaInstrucciones.Count; i++)
        {
            listaInstrucciones[i].SetActive(false);
            if (i == index)
            {
                listaInstrucciones[i].SetActive(true);
            }
         
        }
    }
}
