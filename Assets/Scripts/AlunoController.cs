using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            
            if(UIController.instance.bdQuestoes.questoes[questaoAtual].vezesCorreta < 5){
                pontuacao += UIController.instance.bdQuestoes.questoes[questaoAtual].xp/(UIController.instance.bdQuestoes.questoes[questaoAtual].vezesCorreta+1);
            }
            
            UIController.instance.bdQuestoes.questoes[questaoAtual].vezesCorreta++;
            UIController.instance.UpdatePontuacao(pontuacao);

            //Adiciona o botão da questão acertada numa lista
            var botaoAtual = UIController.instance.bdQuestoes.questoes[questaoAtual].botao;

            // Verifica se a lista já contém o botão antes de adicionar
            if (!UIController.instance.bdQuestoes.questoesAcertadas.Contains(botaoAtual))
            {
                //Adiciona na lista de questoes acertadas
                UIController.instance.bdQuestoes.questoesAcertadas.Add(botaoAtual);

                //Cria o botão da questão resolvida na tela de questões resolvidas
                Instantiate(botaoAtual, UIController.instance.questoesAcertadasPainel.transform);
            }
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

    public void AtualizarNivelQuestao()
    {
        if(UIController.instance.bdQuestoes.questoes[questaoAtual].nivel < 4)
        {
            //Aumenta o nivel da questao em 1
            UIController.instance.bdQuestoes.questoes[questaoAtual].nivel++;

            //Atualiza a pontuação que a questao da dependendo do nivel
            switch (UIController.instance.bdQuestoes.questoes[questaoAtual].nivel)
            {
                case 1:
                    UIController.instance.bdQuestoes.questoes[questaoAtual].xp = 100;
                    break;

                case 2:
                    UIController.instance.bdQuestoes.questoes[questaoAtual].xp = 250;
                    break;

                case 3:
                    UIController.instance.bdQuestoes.questoes[questaoAtual].xp = 500;
                    break;
                case 4:
                    UIController.instance.bdQuestoes.questoes[questaoAtual].xp = 1000;
                    break;
            }

        }
        else
        {
            UIController.instance.bdQuestoes.questoes[questaoAtual].nivel = 1;
            UIController.instance.bdQuestoes.questoes[questaoAtual].xp = 100;
        }

        UIController.instance.UpdateQuestaoNivelTexto(UIController.instance.bdQuestoes.questoes[questaoAtual].nivel);
        
    }

    public void TrocarCena(int indiceCena)
    {
        // Verifica se o índice da cena é válido
        if (indiceCena >= 0 && indiceCena < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(indiceCena); // Carrega a cena pelo índice
            Debug.Log("Cena carregada: " + indiceCena);
        }
        else
        {
            Debug.LogError("Índice de cena inválido: " + indiceCena);
        }
    }

}
