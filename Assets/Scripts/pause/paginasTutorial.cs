using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paginasTutorial : MonoBehaviour
{
    
    public List<GameObject> listaPaginas;
    public List<Animator> listaAnim;
    public GameObject botonSiguiente;
    public GameObject botonCerrar;

    [SerializeField]
    private int index = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   public  void reiniciar()
    {
        index = 0;
        activarDesactivar();
        this.gameObject.SetActive(false);
    }
    public void cerrar()
    {
        this.gameObject.SetActive(false);
    }

    public void incrementar()
    {
        pasarPagina(1);
    }

    public void reducir()
    {
        pasarPagina(-1);
    }



    public void pasarPagina(int dir)
    {
        listaAnim[index].Play("desaparecer");
        index += dir;
        index = Mathf.Clamp(index, 0, 2);


        if (index == (listaPaginas.Count - 1))
        {
            botonCerrar.SetActive(true);
            botonSiguiente.SetActive(false);
        }

        activarDesactivar();
    }

    void activarDesactivar()
    {
       
        for (int i = 0; i < listaPaginas.Count; i++)
        {
            listaPaginas[i].SetActive(false);
            if (i == index)
            {
                listaPaginas[i].SetActive(true);
            }

        }
    }
}
