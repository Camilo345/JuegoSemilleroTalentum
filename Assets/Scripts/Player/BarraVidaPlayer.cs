using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaPlayer : MonoBehaviour
{
    public Slider barraVida;
    public VidaPlayer playerVida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.value = playerVida.getVida();
    }
}
