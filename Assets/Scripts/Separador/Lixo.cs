using System.Collections;
using UnityEngine;

public class Lixo : MonoBehaviour
{
    [SerializeField]
    private RectTransform _transform;
    private float velocidade = 3f;
    private Animator animator;
    public DragAndDrop dragAndDrop;
    void Start()
    {
        float randomX = Random.Range(-533f, 923f);

        Vector2 anchoredPosition = _transform.anchoredPosition;

        anchoredPosition.x = randomX;

        _transform.anchoredPosition = anchoredPosition;

        animator = GetComponent<Animator>();
    }

    public void SetVelocidade(float novaVelocidade)
    {
        velocidade = novaVelocidade;
    }

    void Update()
    {
        if (!GetComponent<DragAndDrop>().isDragging)
        {
            transform.Translate(Vector3.down * velocidade * Time.deltaTime);

            if (transform.position.y < -6f)
            {
                Destruir();
                dragAndDrop.Passou();
            }
        }
    }
    

    public void PauseAnimation()
    {
        if (animator != null)
        {
            animator.speed = 0;
        }
    }

    public void ResumeAnimation()
    {
        if (animator != null)
        {
            animator.speed = 1;
        }
    }

    public void Destruir()
    {
        Destroy(this.gameObject);
    }
}
