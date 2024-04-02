using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string nuevaEscena;

    public void OnClickBoton(){
        if (nuevaEscena == "Niveles" || nuevaEscena == "Menu"){
            Destroy (FindObjectOfType<ElegirNivel>().gameObject);
        }
        SceneManager.LoadScene(nuevaEscena);
    }


}
