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
    public LixoController lixoController;
    public bool isDragging = false;
    public Lixeira currentLixeira = null;
    public Lixo lixoScript;

    public void OnBeginDrag(PointerEventData eventData)
    {  
        _canvasGroup.alpha = 0.5f;
        _canvasGroup.blocksRaycasts = false;

        isDragging = true;
        lixoScript.ResumeAnimation();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
                
        isDragging = false;
        lixoScript.PauseAnimation();

        if (currentLixeira != null)
        {
            currentLixeira.AddPonto(GetComponent<Collider2D>());
        }

        currentLixeira = null; 

    }
    public void OnDrag(PointerEventData eventData)
    {
       _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        _animator.enabled = false;
    }
    void Start()
    {
        if (lixoController == null)
        {
            lixoController = FindObjectOfType<LixoController>();
        }
        lixoScript = GetComponent<Lixo>();
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
    }

    public void Passou()
    {
        if (lixoController != null)
        {
            lixoController.pontos -= 1;
        }
    }
}