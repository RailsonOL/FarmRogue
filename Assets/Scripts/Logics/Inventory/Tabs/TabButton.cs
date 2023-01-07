using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TabsGroup tabGroup;
    public Image background;
    public Text text;
    public Color originalColor;

    public UnityEvent onTabSelected;
    public UnityEvent onTabDeselected;

    private void Start() {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData) {
        tabGroup.OnTabExit(this);
    }

    public void OnPointerClick(PointerEventData eventData) {
        tabGroup.OnTabSelected(this);
    }

    
    public void Select(){
        if(onTabSelected != null){
            onTabSelected.Invoke();
        }
    }

    public void Deselect(){
        if(onTabDeselected != null){
            onTabDeselected.Invoke();
        }
    }
}
