using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class txtNivel : MonoBehaviour
{
    public TMP_Text texto;
    public progresionNiveles progresion;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("desactivar", 2);
    }

    // Update is called once per frame
    void Update()
    {
        texto.text = "Piso "+progresion.getNivel();
    }

    void desactivar()
    {
        this.gameObject.SetActive(false);
    }
}
