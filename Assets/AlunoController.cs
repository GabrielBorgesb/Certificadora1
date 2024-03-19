using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlunoController : MonoBehaviour
{
    public int pontuacao;


    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            pontuacao += 100;
            UIController.instance.UpdatePontuacao(pontuacao);
        }
    }
}
