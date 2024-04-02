using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionJuego : MonoBehaviour
{
    public Sprite cajaColocada;
    public GestionElementos gestionElementos;
    private GameObject[] cajas;
    private int totalCajas;
    private int totalColocadas;
    private bool finalizado = false;
    private ElegirNivel elegirNivel;
    private int primerResultado = -1;
    
    private void Awake(){
        cajas =  null;
        totalCajas = 100;
        totalColocadas = 0;

    }
    public void ComprobarCajas(){
        totalColocadas = 0;
        cajas =  GameObject.FindGameObjectsWithTag("Caja");
        totalCajas = cajas.Length;
       
        for (int i = 0; i < cajas.Length; i++)
        {
            if (cajas[i].GetComponent<SpriteRenderer>().sprite == cajaColocada)
            {
                totalColocadas = totalColocadas + 1;
            }
        }
        if(totalCajas == totalColocadas){
            elegirNivel = FindObjectOfType<ElegirNivel>();
            var nivelElegido = elegirNivel.DevolverOpcion();
            int nuevoNivel = 1;
            if(int.Parse(nivelElegido)<10){
                nuevoNivel = int.Parse(nivelElegido) + 1;
            }
            elegirNivel.ElegirOpcion(nuevoNivel);
            SceneManager.LoadScene("Juego");
        }

    }

}
