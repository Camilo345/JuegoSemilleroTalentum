using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnviarDatos : MonoBehaviour
{

    public class estructuraDatos
    {
        public float puntaje;
        public int oleadas;
        public int enemigos;
    }

    public indicadores indi;
    private string url = "http://localhost:3000/php/";
    //private string url = "192.168.18.9/api/claseUAO/php/";
    private estructuraDatos indicadoresPartida;
    // Start is called before the first frame update
    void Start()
    {
        indicadoresPartida = new estructuraDatos();
        indicadoresPartida.puntaje = indi.GetPuntaje();
        indicadoresPartida.enemigos = indi.GetEnemigosDerrotados();
        indicadoresPartida.oleadas = indi.GetNumeroOleada();
        StartCoroutine(EnviarIndicadores());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator EnviarIndicadores()
    {
        WWWForm form = new WWWForm();
        form.AddField("enemigos", indicadoresPartida.enemigos);
        form.AddField("puntaje", ((int)indicadoresPartida.puntaje+""));
        form.AddField("oleada", indicadoresPartida.oleadas);
        form.AddField("id", 1);

        using (UnityWebRequest www = UnityWebRequest.Post(url + "insertarJuego.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
