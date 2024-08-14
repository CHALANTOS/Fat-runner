using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoLixo : MonoBehaviour
{
    public float Velocidade;

    void Start()
    {
        Velocidade = 2.0f;
    }

    void Update()
    {
        transform.Translate(Vector3.down * Velocidade * Time.deltaTime);
       
        if ( transform.position.y < -7.35 ){
            Destroy(this.gameObject);
        }
    }
}
