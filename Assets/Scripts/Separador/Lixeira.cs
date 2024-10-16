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
    public LixoController lixoController;
    public Lixo lixo;
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

            AddPonto(eventData.pointerDrag.GetComponent<Collider2D>());
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

 private void OnTriggerEnter2D(Collider2D other)
{
    DragAndDrop dragScript = other.GetComponent<DragAndDrop>();

    if (dragScript != null)
    {
        dragScript.currentLixeira = this;
    }
    Debug.Log("entrou_Lixeira");
}

private void OnTriggerExit2D(Collider2D other)
{
    DragAndDrop dragScript = other.GetComponent<DragAndDrop>();

    if (dragScript != null && dragScript.isDragging == false)
    {
        dragScript.currentLixeira = null;
    }
    Debug.Log("Saiu_Lixeira");
}

    public void AddPonto(Collider2D other)
    {
        
        if (other != null)
        {
            if (other.CompareTag("Metal") && this.CompareTag("Metal"))
            {
                lixoController.pontos += 1;
            }
            else if (other.CompareTag("Plastico") && this.CompareTag("Plastico"))
            {
                lixoController.pontos += 1;
            }
            else if (other.CompareTag("Papel") && this.CompareTag("Papel"))
            {
                lixoController.pontos += 1;
            }
            else if (other.CompareTag("Vidro") && this.CompareTag("Vidro"))
            {
                lixoController.pontos += 1;
            }
            else if (other.CompareTag("Organico") && this.CompareTag("Organico"))
            {
                lixoController.pontos += 1;
            }
            Destroy(other.gameObject);
        }
    }
}

