using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class puerta : MonoBehaviour
{
    public float divisorEnergia;
    public float energia;
    public int energiaTotal=100;
    public Slider barraEnergia;
    public GameObject textoPuerta;
    public TMP_Text textoCantidadNecesaria;
    public TMP_Text textoPuedesAbrir;
    public GenerarSalas salas;
    public float energiaPorEnemigo;
    public GameObject colliderPuerta;

    [SerializeField]
    private GameObject[] listaEnemigos;
    private Transform player;
    private Animator anim;
    private bool energiaLlena = false;

    private void OnEnable()
    {
        eventosEnemigosDerrotados.enemigoMuerto += sumarEnergia;
    }

    private void OnDisable()
    {
        eventosEnemigosDerrotados.enemigoMuerto -= sumarEnergia;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
      //  textoCantidadNecesaria.text = "33";
        Invoke("asignarPuntosPuertas",1f);
    }

    // Update is called once per frame
    void Update()
    {
        barraEnergia.value = energia;
        distanciaJugador();
    }

    void distanciaJugador()
    {
        float dis = Vector2.Distance(player.position, transform.position);
       
        if (dis < 1.5f)
        {
          
            verificarPasarDeNivel();
        }
    }

    void verificarPasarDeNivel()
    {
        if (Input.GetKey(KeyCode.E) && energia>=energiaTotal)
        {
            anim.Play("AbrirPuerta");
            colliderPuerta.SetActive(false);
            textoPuerta.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && energia < energiaTotal)
        {
            textoCantidadNecesaria.gameObject.SetActive(true);
            Invoke("desactivarTxt", 2f);
        }
    }

    void desactivarTxt()
    {
        textoCantidadNecesaria.gameObject.SetActive(false);
        textoPuedesAbrir.gameObject.SetActive(false);
    }

    void asignarPuntosPuertas()
    {
        int numeEnemigos = 0;
        for(int i = 1; i < salas.listaSalas.Count; i++)
        {
         numeEnemigos += salas.listaSalas[i].GetComponent<enemigosEnLaSala>().listaEnemigos.Count;
        }
        energiaTotal = 100;
        energiaPorEnemigo = energiaTotal / (numeEnemigos - 0.1f);
       
        energiaTotal = (int)(energiaTotal / divisorEnergia);
        barraEnergia.maxValue = energiaTotal;
        //textoCantidadNecesaria.text = energiaTotal + "";
    }

    void sumarEnergia(Vector2 pos)
    {

        energia +=energiaPorEnemigo;
       energia = Mathf.Clamp(energia, 0, energiaTotal);
        if (energia >= energiaTotal && !energiaLlena)
        {
            energiaLlena = true;
            textoPuedesAbrir.gameObject.SetActive(true);
            Invoke("desactivarTxt", 2f);
        }
    }
}
