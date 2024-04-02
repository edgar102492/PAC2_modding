using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrastrarElemento : MonoBehaviour, IDropHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // Se declara el propio objeto para poder hacerle duplicados
    public GameObject objetoBase;

    // Se define la esquina superior izquierda en que podrá ser arrastrado y la derecha para que no permita colocarlo fuera de estos márgenes
    public GameObject esquinaSuperiorIzquierda;
    public GameObject esquinaInferiorDerecha;

    // Se definen las variables necesarias para que el arrastre se vea en transparente y se ancle luego al lugar adecuado al soltar
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    // Se define el valor inicial del elemento para poderlo duplicar en el mismo sitio al ser arrastrado a otro lugar
    private Vector2 inicial;
    
    // Se define la posición inicial y otras propiedades necesarias del elemento para poder crear el siguiente elemento igual y para que se coloque luego en el lugar adecuado
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        inicial = rectTransform.anchoredPosition;
    }

    // Al empezar el arrastre del objeto con el ratón se crea uno nuevo en el lugar en el que este se encontraba y se pone ligeramente transparente para que se distinga cuál se está moviendo
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (rectTransform.parent.tag == "Canvas" && !objetoBase.name.Contains("Jugador")){
            GameObject objetoNuevo = Instantiate(objetoBase, rectTransform.anchoredPosition, Quaternion.identity) as GameObject;
            objetoNuevo.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }
        canvasGroup.alpha = .7f;
        canvasGroup.blocksRaycasts = false;
    }
    // Mientras se arrastra se va viendo el elemento por la pantalla para que sepa el usuario dónde está
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    // Al finalizar el arrastre se vuelve a poner sin transparencia, se ancla a un sitio y si no está dentro de los márgenes establecidos se destruye para evitar elementos fuera de lugar
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        // Se pone dentro del GameObject colocados para luego poderlos guardar
        gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Colocados").transform, false);
        if (rectTransform.anchoredPosition.x < esquinaSuperiorIzquierda.GetComponent<RectTransform>().anchoredPosition.x || rectTransform.anchoredPosition.x > esquinaInferiorDerecha.GetComponent<RectTransform>().anchoredPosition.x || rectTransform.anchoredPosition.y < esquinaInferiorDerecha.GetComponent<RectTransform>().anchoredPosition.y || rectTransform.anchoredPosition.y > esquinaSuperiorIzquierda.GetComponent<RectTransform>().anchoredPosition.y)
        {
            if(objetoBase.name.Contains("Jugador"))
            {
                GameObject objetoNuevo = Instantiate(objetoBase, inicial, Quaternion.identity) as GameObject;
                objetoNuevo.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

            }
            Destroy(gameObject);
        }
        
    }
    // Si se suelta un elemento encima de otro ya existente ese que se ha soltado encima se destruye
    public void OnDrop(PointerEventData eventData)
    {
        Destroy(eventData.pointerDrag);        
    }
}
