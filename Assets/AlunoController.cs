using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlunoController : MonoBehaviour
{
    //Stats
    public int pontuacao;

    //Inputs
    public string respostaInput;

    //Controladores
    public int questaoAtual;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            
            
        }
    }

    public void UpdateInput(string input)
    {
        respostaInput = input;
    }

    
    //Ações
    public void EnviarResposta()
    {
        //Acertou
        if(respostaInput == UIController.instance.bdQuestoes.questoes[questaoAtual].resposta)
        {
            pontuacao += 100;
            UIController.instance.UpdatePontuacao(pontuacao);
        }
        else
        {

        }

    }

}
