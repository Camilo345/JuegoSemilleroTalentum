using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasManager : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform spawnBalas;
    public float fuerza;
    public float iniciarTiempoEntreDisparos;
    public List<GameObject> listaBalas;


    private float tiempoEntreDisparos;
    private int numeroBalas =15;
    private bool jugadorMuerto=false;

    public delegate void actionDisparar();
    public static event actionDisparar dispararArco;

    private void OnEnable()
    {
        VidaPlayer.jugadorMurio += jugadorMurio;
    }

    private void OnDisable()
    {
        VidaPlayer.jugadorMurio -= jugadorMurio;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        instanciarBalas();
    }

    // Update is called once per frame
    void Update()
    {
        if (!jugadorMuerto)
            revisarBotonDisparar();


    }

    void revisarBotonDisparar()
    {
        if (tiempoEntreDisparos <= 0)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
            {
                Invoke("shoot", 0.3f);
                tiempoEntreDisparos = iniciarTiempoEntreDisparos;
                dispararArco();
            }
        }
        else
        {
            tiempoEntreDisparos -= Time.deltaTime;
        }
    }
    void shoot()
    {
       
        GameObject balaGameObject= traerBala();
        balaGameObject.transform.position = spawnBalas.position;
        balaGameObject.transform.rotation = spawnBalas.rotation;
        balaGameObject.SetActive(true);
       // GameObject bullet = Instantiate(balaPrefab, spawnBalas.position, spawnBalas.rotation);
    }
    void instanciarBalas()
    {
        listaBalas = new List<GameObject>();
        GameObject balaAux;
        for (int i = 0;i < numeroBalas; i++)
        {
            balaAux = Instantiate(balaPrefab);
            balaAux.SetActive(false);
            listaBalas.Add(balaAux);
        }

    }
    public GameObject traerBala()
    {
        for(int i=0; i < numeroBalas; i++)
        {
            if (!listaBalas[i].activeInHierarchy)
            {
                return listaBalas[i];
            }
        }
        return null;
    }

    void jugadorMurio()
    {
        jugadorMuerto = true;
    }
}
