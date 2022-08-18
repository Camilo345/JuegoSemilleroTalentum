using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesMenu : MonoBehaviour
{
    public indicadores indi;
    public progresionNiveles progresion;
    public Animator anim;
    public GameObject particulas;
    public GameObject boton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtJugar()
    {
        anim.Play("salir");
        Invoke("irATutorial", 1);
        particulas.SetActive(false);
        boton.SetActive(false);
    }

    public void BtReintentar()
    {
      
        Invoke("irAJugar", 1);
        irAJugar();
    }

    public void BtMenu()
    {
        anim.Play("Salir");
        SceneManager.LoadScene(0);
    }

    void reiniciarValores()
    {
        indi.SetNumeroOleada(1);
        indi.SetEnemigosDerrotados(0);
        indi.SetPuntaje(0);
        indi.SetEnergiaRecogida(0);
        indi.SetSalasLimpiadas(0);
        progresion.setNivel(1);
    }

    void irATutorial()
    {
        reiniciarValores();
        SceneManager.LoadScene(4);
    }

    void irAJugar()
    {
        reiniciarValores();
        SceneManager.LoadScene(2);
    }
}
