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
    

    float tiempoEntreDisparos;
    int numeroBalas=10;

    public delegate void actionDisparar();
    public static event actionDisparar dispararArco;
    // Start is called before the first frame update
    void Start()
    {
        instanciarBalas();
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoEntreDisparos <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Invoke("shoot",0.3f);
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
}
