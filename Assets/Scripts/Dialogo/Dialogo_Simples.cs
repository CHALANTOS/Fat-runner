using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Dialogo_Simples : MonoBehaviour
{
    [SerializeField] Dialogo[] TodosDialogos;

    [Header("Outras Coisas")]
    [SerializeField] Text interagir;
    [SerializeField] int h, v;

    [SerializeField] DialogoController dialogo;
    private bool emDialogo;

    [SerializeField] int qualFala;

    public GameObject Player;
    public GameObject Balao_Velho;
    public GameObject Balao_Velho2;
    public PlayerJson playerJ;
    public GameObject Painel;
    public bool conversou;

    private void Awake()
    {
        qualFala = 0;
        Player = GameObject.FindWithTag("Player");
        Balao_Velho = GameObject.FindWithTag("BALAO");
        Balao_Velho2 = GameObject.FindWithTag("BALAO2");
        Painel = GameObject.Find("Painel");
    }

    private void Start()
    {
        playerJ = new PlayerJson();
        playerJ.LoadGame();
        Balao_Velho2.SetActive(false);
    }

    private void LateUpdate()
    {
        playerJ.LoadGame();
        if (Input.GetKeyDown(KeyCode.Space) && emDialogo == true)
        {
            
            if(playerJ.VezesConversadas == "0")
            {
                conversou = true;
                playerJ.VezesConversadas = "1";
                playerJ.faseAtual = "veio";
                playerJ.SaveGame();
            }
            else if(playerJ.VezesConversadas != "0")
            {
                playerJ.VezesConversadas = "1";
                playerJ.SaveGame();
            }
            StartCoroutine(Andar());
            Player.GetComponent<Player>().podeAndar = false;
            if (dialogo.aindaFalando == false)
            {
                dialogo.Dialogo(TodosDialogos[qualFala].dialogos);
                dialogo.MudarExpressao(TodosDialogos[qualFala].quemFala, TodosDialogos[qualFala].qualExpressao);
            }
            //interagir.gameObject.SetActive(false);

            if (!(dialogo.indexFala < TodosDialogos[qualFala].dialogos.Length - 1))
            {
                emDialogo = false;
                qualFala += 1;
                Player.GetComponent<Player>().podeAndar = true;
            }

            /*if (distance.x < -0.7)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }*/

        }
        if (qualFala > (TodosDialogos.Length - 1))
        {
            qualFala = TodosDialogos.Length - 1;
        }
        if(dialogo.aindaFalando == true)
        {
            Balao_Velho2.SetActive(true);
            Balao_Velho.SetActive(false);
        }
        else if (dialogo.aindaFalando == false)
        {
            Balao_Velho.SetActive(true);
            Balao_Velho2.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log(qualFala);
            emDialogo = true;
            dialogo.indexFala = 0;
             if (interagir != null) // Verificação de null antes de ativar
            {
                interagir.gameObject.SetActive(true);
            }

            //interagir.gameObject.SetActive(true);
            StopAllCoroutines();
        }

       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (interagir != null) // Verificação de null antes de desativar
            {
                interagir.gameObject.SetActive(false);
            }
            //interagir.gameObject.SetActive(false);
            emDialogo = false;
            dialogo.EncerrarDialogo();
            StartCoroutine(PararDialogo());
        }
    }

    IEnumerator PararDialogo()
    {
        yield return new WaitForSeconds(3f);
        if (h == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    IEnumerator Andar()
    {
        yield return new WaitForSeconds(1.5f);
        Player.GetComponent<Player>().podeAndar = true;
    }
}