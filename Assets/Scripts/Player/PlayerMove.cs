using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform playerControl;
    public Camera cam;
   
    public GameObject playerSprite;
    public LayerMask pared;

    
    private bool puedeAvanzar = true;
    private Vector2 mousePosition;
    private Vector2 direccionRay=Vector2.zero;
    private RaycastHit2D hit;
    private Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
   
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
       
    }

    private void FixedUpdate()
    {
        comprobarParedes();
        moverse();
        cambiarEscala();
        
    }

    

    void comprobarParedes()
    {
        hit = Physics2D.Raycast(transform.position, movement, 0.5f, pared);
        Debug.DrawRay(transform.position, movement, Color.green);
        if (hit.collider != null)
        {
            puedeAvanzar = false;
        }
        else
        {
            puedeAvanzar = true;
        }
    }

    void moverse()
    {
        if (puedeAvanzar)
        {
            playerControl.Translate(movement * moveSpeed * Time.fixedDeltaTime);
           
        }
    }
    void cambiarEscala()
    {
        if (mousePosition.x < transform.position.x)
        {
           transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1);
        }
    }

    
}
