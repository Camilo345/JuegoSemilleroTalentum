using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPociones : MonoBehaviour
{
    public GameObject pocionPrefab;
    public List<GameObject> listaPociones;
    public int numeroPociones = 4;
    public int probabilidadPocion = 2;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        
        eventosEnemigosDerrotados.enemigoMuerto += generarPocion;
    }

    private void OnDisable()
    {
        eventosEnemigosDerrotados.enemigoMuerto -= generarPocion;
    }
    // Start is called before the first frame update
    void Start()
    {
     // Invoke("instanciarPociones",3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generarPocion(Vector2 pos)
    {
       
        int probabilidad = Random.Range(1, 101);
        if(probabilidad <= probabilidadPocion)
        {
            GameObject pocion = Instantiate(pocionPrefab);
            pocion.transform.parent = transform;
            pocion.transform.position = pos;
            pocion.SetActive(true);
        }
      
    }

    void instanciarPociones()
    {
        listaPociones = new List<GameObject>();
        GameObject balaAux;
        for (int i = 0; i < numeroPociones; i++)
        {
            balaAux = Instantiate(pocionPrefab);
            balaAux.SetActive(false);
            balaAux.transform.parent = transform;
            listaPociones.Add(balaAux);
        }

    }
    public GameObject traerPocion()
    {
        for (int i = 0; i < listaPociones.Count; i++)
        {
            if (!listaPociones[i].activeInHierarchy)
            {
                return listaPociones[i];
            }
        }
        return null;
    }

}
