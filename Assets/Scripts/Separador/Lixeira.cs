using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lixeira : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private RectTransform _transform;

    [SerializeField]
    private Vector2 coordenada;

    
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            RectTransform draggedRect = eventData.pointerDrag.GetComponent<RectTransform>();

            Animator _animator = eventData.pointerDrag.GetComponent<Animator>();
            if (_animator != null)
            {
                _animator.enabled = false;
            }

            draggedRect.anchoredPosition = _transform.parent.InverseTransformPoint(coordenada);
            coordenada = new Vector2(Random.Range(-4.0f, 7.47f), 7.13f); 

            if (_animator != null)
            {
                _animator.enabled = true;
                _animator.Play("Lixos", -1, 0f);
            }
        }
    }

    void Start()
    {
        if (_transform == null)
        {
            _transform = GetComponent<RectTransform>();
        }
        coordenada = new Vector2(Random.Range(-4.0f, 7.47f), 7.13f); 
    }
}
