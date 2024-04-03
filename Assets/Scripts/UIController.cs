using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public BDQuestoes bdQuestoes;
    [SerializeField] private AlunoController aluno;


    //UI Geral
    [SerializeField] private TMP_Text pontuacaoUI;
    [SerializeField] private TMP_Dropdown dropdownDificuldade;
    [SerializeField] private GameObject questoesCrescente;
    [SerializeField] private GameObject questoesDecrescente;

    //UI Questão
    [SerializeField] private TMP_Text questaoText;
    [SerializeField] private Image questaoImagem;
    [SerializeField] private string respostaCorreta;
    [SerializeField] private TMP_Text respostaCorretaTexto;

    //UI Tela Aviso
    [SerializeField] private GameObject telaAviso;
    [SerializeField] private TMP_Text textoAviso;

    private void Awake() {
        if(instance == null && instance != this){
            instance = this;
        }else
        {
            Destroy(gameObject);
        }
    }


    public void UpdatePontuacao(int pontuacaoNova){

        //string pontuacaoNovaTexto = pontuacaoNova.ToString();
        pontuacaoUI.SetText("Pontuação: " + pontuacaoNova);

    }

    public void UpdateQuestao(int questaoIndex){
        questaoText.SetText(bdQuestoes.questoes[questaoIndex].enunciado);
        questaoImagem.sprite = bdQuestoes.questoes[questaoIndex].imagem;
        aluno.questaoAtual = questaoIndex;
        respostaCorreta = bdQuestoes.questoes[questaoIndex].resposta;
    }

    public void UpdateRespostaAcerto(){
        respostaCorretaTexto.SetText("A resposta correta é "+ respostaCorreta);
    }

    public void ResetarPontuacao(){
        aluno.pontuacao = 0;
        UpdatePontuacao(0);

        for(int i = 0; i < bdQuestoes.questoes.Count; i++){
            bdQuestoes.questoes[i].vezesCorreta = 0;
        }
    }

    public void AcionarTelaAviso(){

        telaAviso.SetActive(true);
        
        if(bdQuestoes.questoes[aluno.questaoAtual].vezesCorreta > 0 && bdQuestoes.questoes[aluno.questaoAtual].vezesCorreta < 5){
            textoAviso.SetText("Você já respondeu esta pergunta. em caso de acerto a pontuação será menor! Pontuação Atual da questão: "+ bdQuestoes.questoes[aluno.questaoAtual].xp/(bdQuestoes.questoes[aluno.questaoAtual].vezesCorreta+1) + "\n\nDeseja resolver novamente?");
        }else if(bdQuestoes.questoes[aluno.questaoAtual].vezesCorreta >= 5){
            textoAviso.SetText("Você já respondeu esta pergunta no limite de vezes (5), Ela não te dará mais pontos em caso de acerto.\n\nDeseja resolver mesmo assim? ");
        }
        
    }

    public void SelecionarOrdemDificuldade()
    {
        switch(dropdownDificuldade.value)
        {
            case 0: 
                questoesCrescente.SetActive(true);
                questoesDecrescente.SetActive(false);
                break;

            case 1:
                questoesDecrescente.SetActive(true);
                questoesCrescente.SetActive(false);
                break;
        }
    }
    
}
