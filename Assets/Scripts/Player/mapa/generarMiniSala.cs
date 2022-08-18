using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarMiniSala : MonoBehaviour
{

    public GameObject miniSalaPreFab;
    public List<GameObject> listaSalas;

    private int direccionMove;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void moverse(int direccion)
    {
        direccionMove = direccion;
        Vector2 actualPos = transform.localPosition;
        Vector2 pos = Vector2.zero;
        switch (direccion)
        {
            case 0:
                pos.y = 1.7f;
                break;
            case 1:
                pos.x = 2.3f;
                break;
            case 2:
                pos.y = -1.7f;
                break;
            case 3:
                pos.x = -2.3f;
                break;
        }

        transform.localPosition = actualPos + pos;
    }

    public GameObject ponerSala(int dir,int indi)
    {
        GameObject newSala = Instantiate(miniSalaPreFab);
        newSala.transform.parent = transform;
        newSala.transform.localPosition = Vector3.zero;
        newSala.transform.localPosition = transform.localPosition;
      
        listaSalas[indi].GetComponent<ponerMinPuentes>().quitarBloqueoViejo(dir);
        listaSalas.Add(newSala);
        newSala.GetComponent<ponerMinPuentes>().quitarBloqueoNuevo(dir);
        return newSala;
    }

 
}
