using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler,IEndDragHandler, IDragHandler
{
    [SerializeField]
    private RectTransform _transform;
    [SerializeField]
    private Canvas _canvas;
    [SerializeField]
    private CanvasGroup _canvasGroup;

    private float posRandomX;

    public Animator _animator;

    public void OnBeginDrag(PointerEventData eventData)
    {  
        _canvasGroup.alpha = 0.5f;
        _canvasGroup.blocksRaycasts = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
       _canvasGroup.blocksRaycasts = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
       _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Apertou");
        _animator.enabled = false;
    }
    void Start()
    {
        if (_canvas == null)
        {
            _canvas = FindObjectOfType<Canvas>();
        }

        if (_transform == null)
        {
            _transform = GetComponent<RectTransform>();
        }

        if (_canvasGroup == null)
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
    }
    void Update()
    {
        posRandomX = Random.Range(-429f, 898f);
    }

    public void RandomX()
    {
        posRandomX = Random.Range(-429f, 898f); 

        Vector3 currentPosition = _transform.anchoredPosition;

        _transform.anchoredPosition = new Vector3(posRandomX, currentPosition.y);
    
        Debug.Log($"Posição aleatória aplicada: {posRandomX}");
    }
}
