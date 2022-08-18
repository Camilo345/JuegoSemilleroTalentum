using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigosEnLaSala : MonoBehaviour
{
    public List<GameObject> listaEnemigos;
    public List<GameObject> colliderPuerta;
    public List<GameObject> listaEnemigosPreFabs;
    public int tiposEnemigos;
    public GameObject minisala;

    private bool calcularIndicador = false;

    public delegate void abrirCerrarPuerta(bool deboAbrir);
    public static event abrirCerrarPuerta abrirCerrar;

    public delegate void EventosalaLimpia();
    public static event EventosalaLimpia salaLimpia;

    private void Awake()
    {
        spawnearEnemigos();
    }
    private void OnEnable()
    {
        calcularIndicador = false;
        Invoke("cambiarCalcularIndicador",0.5f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool co = comprobarEnemigos();
        if (co)
        {
            abrirPuertas();
        }
    }

    bool comprobarEnemigos()
    {
        bool todosDerrotados = true;
        /* if (listaEnemigos.Count == 0)
         {
             todosDerrotados = true;
         }*/
        for (int i = 0; i < listaEnemigos.Count; i++)
        {
            if (listaEnemigos[i].activeInHierarchy)
            {
                todosDerrotados = false;

            }
        }

        return todosDerrotados;
    }

    void abrirPuertas()
    {
        for (int i = 0; i < colliderPuerta.Count; i++)
        {
            colliderPuerta[i].SetActive(false);
        }
       
        if (calcularIndicador)
        {
            salaLimpia();
        }
      
        abrirCerrar(true);
        this.enabled = false;
    }

    public void cerrarPuerta()
    {
        for (int i = 0; i < colliderPuerta.Count; i++)
        {
            colliderPuerta[i].SetActive(true);
        }

        abrirCerrar(false);
    }

    public void spawnearEnemigos()
    {

        int numEnemigos = Random.Range(4, 7);
        tiposEnemigos = GameObject.FindGameObjectWithTag("Tipo").GetComponent<enemigosPorPiso>().tipoEnemigo;
        for (int i = 0; i < numEnemigos; i++)
        {

            int tipoEnemigo = Random.Range(0, tiposEnemigos);

            GameObject enemigo = Instantiate(listaEnemigosPreFabs[tipoEnemigo]);
            int posX = Random.Range(-8, 8);
            int posY = Random.Range(-4, 4);
            enemigo.transform.position = new Vector2(transform.position.x + posX, transform.position.y + posY);
            listaEnemigos.Add(enemigo);
            enemigo.SetActive(false);
            enemigo.transform.parent = transform;
        }


    }

    public void activarEnemigos(bool activar)
    {
        for (int i = 0; i < listaEnemigos.Count; i++)
        {
            listaEnemigos[i].SetActive(activar);
        }
    }

    void cambiarCalcularIndicador()
    {
        calcularIndicador = true;
    }
   
}
