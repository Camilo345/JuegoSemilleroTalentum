using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System;
using System.IO;
using Newtonsoft.Json;

public class pruebaEnvioPHP : MonoBehaviour
{
    public TMP_InputField txtJuego;
    public TMP_Text listaJuegos;

     //private string url = "192.168.18.9/api/claseUAO/php/";
     private string url = "https://pruebaphp-unity.web.app/php/";
    [Serializable]
    public class estructuraDatos
    {
        public int puntaje;
        public int oleadas;
        public int enemigos;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(leerJson());
        StartCoroutine(TraerJuegos());
        //  leerJson();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void bt_enviarDatos()
    {
        //string nombreJuego = txtJuego.text;
        //Debug.Log(nombreJuego);
      //  StartCoroutine(enviarJuego(nombreJuego));
        //StartCoroutine(TraerJuegos());
    }

    public void traerDatos()
    {
        StartCoroutine(TraerJuegos());
    }

    IEnumerator enviarJuego(string nombre)
    {
        WWWForm form = new WWWForm();
        form.AddField("enemigos", 20);
        form.AddField("puntaje", 300);
        form.AddField("oleada", 2);
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

    IEnumerator TraerJuegos()
    {

        WWWForm form = new WWWForm();
        form.AddField("id", 1);
        using (UnityWebRequest www = UnityWebRequest.Post(url + "getJuegos.php",form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.error);
                Debug.Log("Form upload complete!");
                string d = www.downloadHandler.text;
                Debug.Log(d);
               // dividirString(d);
            }
        }
    }

    void dividirString(string datos)
    {
        string[] numeroObjetos = datos.Split("*");
        List<estructuraDatos> listaJuegos = new List<estructuraDatos>();
        for(int i = 0; i < numeroObjetos.Length-1; i++)
        {
            string objActual = numeroObjetos[i];
            string[] obj = objActual.Split("-");
            estructuraDatos juegoNue = new estructuraDatos();
            juegoNue.puntaje = int.Parse(obj[0]);
            juegoNue.enemigos = int.Parse(obj[1]);
            juegoNue.oleadas = int.Parse(obj[2]);
            listaJuegos.Add(juegoNue);
        }
        mostrarListaJuegos(listaJuegos);
    }

    void mostrarListaJuegos(List<estructuraDatos> lista)
    {
        string cadena = "";
        for(int i = 0; i < lista.Count; i++)
        {
            cadena += lista[i].puntaje + "        " +  lista[i].enemigos+"        " + lista[i].oleadas+"\n";
        }
        Debug.Log(cadena);
        listaJuegos.text = cadena;
    }

    public class datamodel
    {
        public int id;
    }


    IEnumerator leerJson()
    {
        //String ur = "D:/Users/Acer/Documents/Proyectos juegos/JuegoSemilleroTalentum/Assets/Scripts/Back/";
        String ur = "http://localhost:3000/";
              using (UnityWebRequest www = UnityWebRequest.Get(ur + "prueba.json"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string d = www.downloadHandler.text;
                datamodel m = JsonConvert.DeserializeObject<datamodel>(d);
                Debug.Log(m.id + "p");
            }
        }

        ur = "./";
        using (UnityWebRequest www = UnityWebRequest.Get(ur + "prueba.json"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string d = www.downloadHandler.text;
                datamodel m = JsonConvert.DeserializeObject<datamodel>(d);
                Debug.Log(m.id + "d");
            }
        }

    }
}
