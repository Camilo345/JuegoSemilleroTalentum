using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atacarStateCalavera : MonoBehaviour
{
    public AnimationController_Calavera anim;
    public GameObject BalaPrefab;
    public Transform spawnBalas;
    public List<GameObject> listaBalas;

    private int numeroBalas = 2;
    private Transform player;
    private CalaveraStateMachine stateMachine;
    private void OnEnable()
    {
        StartCoroutine("atacar");
    }
    // Start is called before the first frame update
    void Start()
    {
        instanciarBalas();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stateMachine = GetComponent<CalaveraStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void shoot()
    {
        GameObject balaGameObject = traerBala();
        balaGameObject.transform.position = spawnBalas.position;
        apuntarAlJugador(balaGameObject);
        balaGameObject.SetActive(true);
    }
    void instanciarBalas()
    {
        listaBalas = new List<GameObject>();
        GameObject balaAux;
        for (int i = 0; i < numeroBalas; i++)
        {
            balaAux = Instantiate(BalaPrefab);
            balaAux.SetActive(false);
            balaAux.transform.parent = transform;
            listaBalas.Add(balaAux);
        }

    }
    public GameObject traerBala()
    {
        for (int i = 0; i < numeroBalas; i++)
        {
            if (!listaBalas[i].activeInHierarchy)
            {
                return listaBalas[i];
            }
        }
        return null;
    }

    IEnumerator atacar()
    {
        anim.cambiarAnimacion(anim.CalaveraAtaque);
        yield return new WaitForSeconds(0.62f);
        shoot();
        yield return new WaitForSeconds(1.38f);
        if(stateMachine.estado=="Atacar")
        stateMachine.cambiarState("perseguir");
    }

    void apuntarAlJugador(GameObject bala)
    {
        Vector2 lookDic = player.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDic.y, lookDic.x) * Mathf.Rad2Deg;
        angle = angle + 90;
        bala.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        //transform.LookAt(mousePosition,Vector2.up);
    }

}
