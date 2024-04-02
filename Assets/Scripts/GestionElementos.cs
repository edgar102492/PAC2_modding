using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionElementos : MonoBehaviour
{
    public ElementosNivel elementosNivel;
    public GameObject jugador, caja, punto, pared;
    private string elegirNivel = "";

    void Awake()
    {
        elegirNivel = FindObjectOfType<ElegirNivel>().DevolverOpcion();
    }

    void Start()
    {
        if (System.IO.File.Exists(Application.dataPath + "/Resources/nivel_" + elegirNivel + ".json"))
        {
            Cargar();
        }
    }

    public void Guardar()
    {
        elementosNivel.Reset();
        Transform colocadosContainer = GameObject.FindGameObjectWithTag("Colocados").transform;
        foreach (Transform elemento in colocadosContainer)
        {
            if (elemento != colocadosContainer) // Ignorar el transform del contenedor padre
                elementosNivel.AgregarElemento(elemento.gameObject);
        }
        string json = JsonUtility.ToJson(elementosNivel, true);
        System.IO.File.WriteAllText(Application.dataPath + "/Resources/nivel_" + elegirNivel + ".json", json);
    }

    public void Cargar()
    {
        elementosNivel.Reset();
        bool hayJugador = false;
        JsonUtility.FromJsonOverwrite(System.IO.File.ReadAllText(Application.dataPath + "/Resources/nivel_" + elegirNivel + ".json"), elementosNivel);
        Scene scene = SceneManager.GetActiveScene();

        for (int i = 0; i < elementosNivel.CantidadElementos(); i++)
        {
            elementosNivel.ObtenerElemento(i, out Vector3 posicion, out string tipo);

            GameObject tipoElementoNuevo = null;
            switch (tipo)
            {
                case "Jugador": tipoElementoNuevo = jugador; hayJugador = true; break;
                case "Punto": tipoElementoNuevo = punto; break;
                case "Caja": tipoElementoNuevo = caja; break;
                case "Pared": tipoElementoNuevo = pared; break;
            }

            GameObject objetoNuevo = Instantiate(tipoElementoNuevo, posicion, Quaternion.identity);
            if (scene.name == "Editor")
            {
                objetoNuevo.transform.SetParent(GameObject.FindGameObjectWithTag("Colocados").transform, false);
            }
        }

        if (hayJugador && scene.name == "Editor")
        {
            Destroy(jugador);
        }
    }
}
