using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recibirBalasPlayer : MonoBehaviour
{
    public VidaPlayer playerVida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaEnemigo"))
        {
            float da�o = collision.gameObject.GetComponent<Bala>().da�o;
            collision.gameObject.SetActive(false);
            playerVida.bajarVida(da�o);
        }
    }
}
