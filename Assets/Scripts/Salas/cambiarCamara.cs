using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class cambiarCamara : MonoBehaviour
{
    public CinemachineVirtualCamera cmvc;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            cmvc.Priority = 9;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cmvc.Priority = 7;
        }
    }
}
