using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirillaSigueMouse : MonoBehaviour
{
    public GameObject salaActual;

    private Vector3 mousePosition;
    private Camera cam;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        pos= mousePosition;
        pos.z= 0;
       
        transform.position = pos;
    }
}
