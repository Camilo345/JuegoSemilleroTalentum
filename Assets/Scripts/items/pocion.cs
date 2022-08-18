using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pocion : MonoBehaviour
{
    public VidaPlayer playerVida;

    private GameObject player;
    private Transform transformPlayer;

    public delegate void eventoPocion();
    public static event eventoPocion agarroPocion;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerVida = player.transform.parent.GetComponent<VidaPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector2.Distance(transform.position, player.transform.position);
        if (dis < 1.5f && Input.GetKeyDown(KeyCode.E))
        {
            playerVida.bajarVida(-40);
            agarroPocion();
            this.gameObject.SetActive(false);
        }
    }
}
