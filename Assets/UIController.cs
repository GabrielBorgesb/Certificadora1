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

    //UI Questão
    [SerializeField] private TMP_Text questaoText;
    [SerializeField] private Image questaoImagem;
    

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
    }

    
}
