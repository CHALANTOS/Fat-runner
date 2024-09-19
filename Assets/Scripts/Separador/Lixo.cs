using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixo : MonoBehaviour
{
    [SerializeField]
    private RectTransform _transform;

    void Start()
    {        
        float randomX = Random.Range(-533f, 923f);

        Vector2 anchoredPosition = _transform.anchoredPosition;

        anchoredPosition.x = randomX;

        _transform.anchoredPosition = anchoredPosition;
    }

    void Update()
    {

    }
}
