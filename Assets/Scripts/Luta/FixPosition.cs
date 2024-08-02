using UnityEngine;

public class FixPosition : MonoBehaviour
{
    public Animator animator;
    public float initialX;
    public float initialZ;
    public float initialY;

    public bool trocandoPosicao;


    void Start()
    {
        initialX = transform.position.x;
        initialY = transform.position.y;
        initialZ = transform.position.z;
    }

    void LateUpdate()
    {
            
            if(animator.GetBool("atk1"))
            {
                if(trocandoPosicao)
                {
                    initialX = Random.Range(-2.19f, 2.08f);
                }
                transform.position = new Vector3(initialX, transform.position.y, initialZ);
                trocandoPosicao = false;
            } 
            else if(animator.GetBool("atk2"))
            {
                if(trocandoPosicao)
                {
                    initialY = Random.Range(-2.41f, 2.11f);
                }
                transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
                trocandoPosicao = false;
            }
        
    }
}
