using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarSalas : MonoBehaviour
{
    public int numeroSalas;
    public GameObject salaCentral;
    public GameObject salaPreFab;
    public List<GameObject> listaSalas;

    private int indiceSala = 1;
    private int intDireccion;
    private GameObject salaActual;
    // Start is called before the first frame update
    void Start()
    {
        listaSalas = new List<GameObject>();
        listaSalas.Add(salaCentral);
        salaActual = listaSalas[0];
        GenerarSala();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerarSala()
    {
        Vector2 actualPos = transform.position;
        Vector2 dir = generarDireccionAlAzar();
        transform.position = actualPos + dir;
        bool estaOcupada = revisarSalaEnPosicion(transform.position);
        if(estaOcupada ==false)
        {
            spawnearSala();   
        }
        if(indiceSala < numeroSalas)
        {
         
            //Invoke("GenerarSala", 1f);
            GenerarSala();
        }
    }

    Vector2 generarDireccionAlAzar()
    {
        Vector2 dir = Vector2.zero;
        int num=2;
        bool otroNumero = true;
        while (otroNumero)
        {
            num = Random.Range(0, 4);
            if (salaActual.transform.position == Vector3.zero && num==0)
            {
                otroNumero = true;
            }
            else
            {
                otroNumero = false;
            }
        }
        switch (num)
        {
            case 0:
                dir = new Vector2(0, 18);
                intDireccion = 0;
                break;
            case 1:
                dir = new Vector2(26, 0);
                intDireccion = 1;
                break;
            case 2:
                dir = new Vector2(0, -18);
                intDireccion = 2;
                break;
            case 3:
                dir = new Vector2(-26, 0);
                intDireccion = 3;
                break;
        }
        return dir;
    }

    bool revisarSalaEnPosicion(Vector2 posAgente)
    {
        bool estaOcupada = false;
        for(int i = 0; i < listaSalas.Count; i++)
        {
            Vector2 posSala = listaSalas[i].transform.position;
            if (posSala == posAgente)
            {
                estaOcupada = true;
                salaActual = listaSalas[i];
            } 
        }
      
        return estaOcupada;
    }

    void spawnearSala()
    {
        salaActual.transform.GetChild(0).GetComponent<ponerPuente>().quitarBloqueoViejo(intDireccion);
        
        indiceSala++;
        GameObject salaNueva = Instantiate(salaPreFab);
        salaNueva.transform.position = transform.position;
        salaNueva.transform.GetChild(0).GetComponent<ponerPuente>().quitarBloqueoNuevo(intDireccion);
        listaSalas.Add(salaNueva);
        salaActual = listaSalas[indiceSala - 1];
    }

}
