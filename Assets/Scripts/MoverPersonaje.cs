using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    public Sprite empujandoVertical;
    public Sprite empujandoHorizontal;
    public Sprite caminandoHorizontal;
    public Sprite caminandoVertical;
    public Sprite cajaColocada;
    public Sprite cajaDescolocada;
    private GestionJuego gestionJuego;
    void Start()
    {
        gestionJuego = FindObjectOfType<GestionJuego>();
    }
    void Update ()
    {
        RaycastHit hit;
        RaycastHit hit2;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {   
            gameObject.GetComponent<SpriteRenderer>().sprite = caminandoHorizontal;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;         
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 30))
            {   
                gameObject.GetComponent<SpriteRenderer>().sprite = empujandoHorizontal;
                if(hit.transform.tag == "Caja"){
                    if (!Physics.Raycast(hit.transform.position, hit.transform.TransformDirection(Vector3.left), out hit2, 30)){
                        hit.transform.position += Vector3.left * 40;
                        transform.position += Vector3.left * 40;
                        hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = cajaDescolocada;
                    }
                    else{
                        if (hit2.transform.tag == "Punto"){
                            hit.transform.position += Vector3.left * 40;
                            transform.position += Vector3.left * 40;
                            hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = cajaColocada;
                        }
                    }
                    gestionJuego.ComprobarCajas();
                }
                else if(hit.transform.tag != "Pared"){
                    transform.position += Vector3.left * 40;
                }
            }
            else{
                gameObject.GetComponent<SpriteRenderer>().sprite = caminandoHorizontal;
                transform.position += Vector3.left * 40;
            }
            gestionJuego.ComprobarCajas();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = caminandoHorizontal;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;         
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 30))
            {   
                gameObject.GetComponent<SpriteRenderer>().sprite = empujandoHorizontal;
                if(hit.transform.tag == "Caja"){
                    if (!Physics.Raycast(hit.transform.position, hit.transform.TransformDirection(Vector3.right), out hit2, 30)){
                        hit.transform.position += Vector3.right * 40;
                        transform.position += Vector3.right * 40;
                        hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = cajaDescolocada;
                    }
                    else{
                        if (hit2.transform.tag == "Punto"){
                            hit.transform.position += Vector3.right * 40;
                            transform.position += Vector3.right * 40;
                            hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = cajaColocada;
                        }
                    }
                    gestionJuego.ComprobarCajas();
                }
                else if(hit.transform.tag != "Pared"){
                    transform.position += Vector3.right * 40;
                }
            }
            else{
                gameObject.GetComponent<SpriteRenderer>().sprite = caminandoHorizontal;
                transform.position += Vector3.right * 40;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = caminandoVertical;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;         
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, 30))
            {   
                gameObject.GetComponent<SpriteRenderer>().sprite = empujandoVertical;
                if(hit.transform.tag == "Caja"){
                    if (!Physics.Raycast(hit.transform.position, hit.transform.TransformDirection(Vector3.up), out hit2, 30)){
                        hit.transform.position += Vector3.up * 54;
                        transform.position += Vector3.up * 54;
                        hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = cajaDescolocada;
                    }
                    else{
                        if (hit2.transform.tag == "Punto"){
                            hit.transform.position += Vector3.up * 54;
                            transform.position += Vector3.up * 54;
                            hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = cajaColocada;
                        }
                    }
                    gestionJuego.ComprobarCajas();
                }
                else if(hit.transform.tag != "Pared"){
                    transform.position += Vector3.up * 54;
                }
            }
            else{
                gameObject.GetComponent<SpriteRenderer>().sprite = caminandoVertical;
                transform.position += Vector3.up * 54;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = caminandoVertical;
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;         
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 30))
            {   
                gameObject.GetComponent<SpriteRenderer>().sprite = empujandoVertical;
                if(hit.transform.tag == "Caja"){
                    if (!Physics.Raycast(hit.transform.position, hit.transform.TransformDirection(Vector3.down), out hit2, 30)){
                        hit.transform.position += Vector3.down * 54;
                        transform.position += Vector3.down * 54;
                        hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = cajaDescolocada;
                    }
                    else{
                        if (hit2.transform.tag == "Punto"){
                            hit.transform.position += Vector3.down * 54;
                            transform.position += Vector3.down * 54;
                            hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = cajaColocada;
                        }
                    }
                    gestionJuego.ComprobarCajas();
                }
                else if (hit.transform.tag != "Pared"){
                    transform.position += Vector3.down * 54;
                }
            }
            else{
                gameObject.GetComponent<SpriteRenderer>().sprite = caminandoVertical;
                transform.position += Vector3.down * 54;
            }
            
        }
    }
}
