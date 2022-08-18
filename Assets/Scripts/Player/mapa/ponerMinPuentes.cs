using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ponerMinPuentes : MonoBehaviour
{
    public List<GameObject> listaPuentes;
    public Color c;
    public Color c2;
    public bool esPrimeta = false;

    private GameObject target;
    private List<SpriteRenderer> listaSprite;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("target");
        listaSprite = new List<SpriteRenderer>();
        listaSprite.Add(GetComponent<SpriteRenderer>());
        listaSprite.Add(listaPuentes[0].GetComponent<SpriteRenderer>());
        listaSprite.Add(listaPuentes[1].GetComponent<SpriteRenderer>());
        listaSprite.Add(listaPuentes[2].GetComponent<SpriteRenderer>());
        listaSprite.Add(listaPuentes[3].GetComponent<SpriteRenderer>());

        if (esPrimeta)
        {
            ponerBlancos();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitarBloqueoNuevo(int dir)
    {

        switch (dir)
        {
            case 0:
                activarPuente(2);
                break;
            case 1:
                activarPuente(3);
                break;
            case 2:
                activarPuente(0);
                break;
            case 3:
                activarPuente(1);
                break;
        }

    }

    public void quitarBloqueoViejo(int dir)
    {
        switch (dir)
        {
            case 0:
                activarPuente(0);
                break;
            case 1:
                activarPuente(1);
                break;
            case 2:
                activarPuente(2);
                break;
            case 3:
                activarPuente(3);
                break;
        }

    }

    void activarPuente(int ind)
    {
   
        listaPuentes[ind].SetActive(true);
 
    }

 public   void ponerBlancos()
    {
        listaSprite[0].color = c;
        listaSprite[1].color = c;
        listaSprite[2].color = c;
        listaSprite[3].color = c;
        listaSprite[4].color = c;
    }

    public void estaAqui()
    {
        Vector3 pos = transform.localPosition;
        pos.z = -0.5f;
        target.transform.localPosition = pos;
        listaSprite[0].color = c2;
        listaSprite[1].color = c2;
        listaSprite[2].color = c2;
        listaSprite[3].color = c2;
        listaSprite[4].color = c2;
    }


}
