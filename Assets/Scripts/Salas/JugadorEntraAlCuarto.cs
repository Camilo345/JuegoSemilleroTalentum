using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorEntraAlCuarto : MonoBehaviour
{
    public enemigosEnLaSala scriptControlEnemigos;
    public ponerMinPuentes miniPuente;
    public bool esCentral=false;
    private bool yaEntro = false;

    private mirillaSigueMouse mirilla;
    // Start is called before the first frame update
    void Start()
    {
        mirilla = GameObject.FindGameObjectWithTag("mirilla").GetComponent<mirillaSigueMouse>();
        if (!esCentral)
        {
           miniPuente = scriptControlEnemigos.minisala.GetComponent<ponerMinPuentes>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!yaEntro && !esCentral)
            {
                yaEntro = true;
                mirilla.salaActual = transform.parent.gameObject;
                scriptControlEnemigos.enabled = true;
                scriptControlEnemigos.activarEnemigos(true);
                scriptControlEnemigos.cerrarPuerta();
            }
           
            miniPuente.estaAqui();
        
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            miniPuente.ponerBlancos();
            
        }
    }
}
