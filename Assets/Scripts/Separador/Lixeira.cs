using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lixeira : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private RectTransform _transform;
    public LixoController lixoController;

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = _transform.anchoredPosition;
    }

    void Start()
    {
        if (_transform == null)
        {
            _transform = GetComponent<RectTransform>();
        }
    }
}
