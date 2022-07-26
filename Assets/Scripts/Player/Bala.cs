﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad=60;
    public float daño;

    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);
    }
    private void FixedUpdate()
    {
       
    }
    void destruirBala()
    {
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            destruirBala();

        }
       /* if (collision.gameObject.CompareTag("Enemigo"))
        {
            destruirBala();
        }*/
    }
}