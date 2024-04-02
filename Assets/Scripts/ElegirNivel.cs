using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElegirNivel : MonoBehaviour
{
    public int numero;
    void Awake()
    {
        DontDestroyOnLoad (this);
    }
    // Ejecución de elegir una opción
    public void ElegirOpcion(int id)
    {
        numero = id;
    }
    public string DevolverOpcion(){
        return numero.ToString();
    }

    
}
