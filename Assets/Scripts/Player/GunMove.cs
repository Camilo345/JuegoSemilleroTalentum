using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{
 
    public Camera cam;
    //numero que cambiara multiplicara la escala para que el sprite mire a la izquierda o derecha
    public float direccion;
    public GameObject mirilla;

    private bool jugadorMuerto = false;
    Vector3 mousePosition;
    GameObject player;

    private void OnEnable()
    {
        VidaPlayer.jugadorMurio += jugadorMurio;
    }

    private void OnDisable()
    {
        VidaPlayer.jugadorMurio -= jugadorMurio;
        Cursor.visible = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
            mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(cam.transform.position);
       // mirilla.transform.position = mousePosition - cam.transform.position;


    }
    private void FixedUpdate()
    {
       // cambiarScalaY();
       if(!jugadorMuerto)
        apuntarAlMouse();
    }

    void cambiarScalaY()
    {
        if (mousePosition.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1f, -1f, 1);
        }
        else
        {  
            transform.localScale = new Vector3(1f, 1f, 1);
        }
    }
    void apuntarAlMouse()
    {
         Vector2 lookDic = mousePosition - transform.position;
       
         float angle = Mathf.Atan2(lookDic.y, lookDic.x) * Mathf.Rad2Deg;
        angle = angle + 90;
         transform.rotation = Quaternion.Euler(0f, 0f, angle);
        //transform.LookAt(mousePosition,Vector2.up);
    }


    void jugadorMurio()
    {
        jugadorMuerto = true;
    }
}
