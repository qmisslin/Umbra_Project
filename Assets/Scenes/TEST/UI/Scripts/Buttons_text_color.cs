using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buttons_text_color : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text texte;

    public void OnPointerEnter(PointerEventData eventData)
    {
        texte.color = new Color(0.0f,0.5f,1.0f,1.0f) ; // 0 128 255 255
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        texte.color = Color.black;
    }
}