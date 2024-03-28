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

    
    public void EnviarResposta(GameObject telaResultado)
    {
        GameObject telaAcerto = telaResultado.transform.GetChild(0).gameObject;
        GameObject telaErro = telaResultado.transform.GetChild(1).gameObject;

        //Acertou
        if(respostaInput == UIController.instance.bdQuestoes.questoes[questaoAtual].resposta)
        {
            telaAcerto.SetActive(true);
            
            pontuacao += UIController.instance.bdQuestoes.questoes[questaoAtual].xp;
            UIController.instance.bdQuestoes.questoes[questaoAtual].vezesCorreta++;
            UIController.instance.UpdatePontuacao(pontuacao);
        }
        else
        {
            telaErro.SetActive(true);
        }

    }

    public void ChecarVezesAcertada(){
        
        if(UIController.instance.bdQuestoes.questoes[questaoAtual].vezesCorreta > 0){
            UIController.instance.AcionarTelaAviso();
        }
    }


}
