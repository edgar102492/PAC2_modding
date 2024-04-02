using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
[Serializable]

public class ElementosNivel : ScriptableObject
{
    [SerializeField]List<Vector3> posicionesElementos;
    [SerializeField]List<String> tiposElementos;
    public void AgregarElemento(GameObject elemento){
        if(elemento.tag != "Colocados"){
            posicionesElementos.Add(elemento.transform.position);
            tiposElementos.Add(elemento.tag);
        }
    }
    public void ObtenerElemento(int indice, out Vector3 posicion, out String tipo)
    {
        posicion = posicionesElementos[indice];
        tipo = tiposElementos[indice];
    }
    public void Reset()
    {
        posicionesElementos.Clear();
        tiposElementos.Clear();
    }
    public int CantidadElementos()
    {
        return tiposElementos.Count;
    }
}
