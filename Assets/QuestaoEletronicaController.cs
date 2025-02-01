using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestaoEletronicaController : MonoBehaviour
{
    // Lista para armazenar todos os objetos com InputValue
    private List<InputValue> inputValues = new List<InputValue>();

    [Header("Telas")]
    public GameObject telaQuestao;
    public GameObject telaCorreto;
    public GameObject telaIncorreto;

    private void Start()
    {
        // Encontra todos os objetos com o componente InputValue e os adiciona � lista
        InputValue[] inputs = FindObjectsOfType<InputValue>();
        inputValues.AddRange(inputs);
    }

    // M�todo chamado quando o bot�o "Responder" � pressionado
    public void OnResponderButtonPressed()
    {
        bool todasCorretas = true;

        // Verifica se todos os InputValue est�o com isCorrect == true
        foreach (InputValue inputValue in inputValues)
        {
            if (!inputValue.IsCorrect())
            {
                todasCorretas = false;
                break;
            }
        }

        // Executa a a��o com base no resultado
        if (todasCorretas)
        {
            telaQuestao.gameObject.SetActive(false);
            telaCorreto.gameObject.SetActive(true);
            // Aqui voc� pode adicionar a��es para resposta correta (ex: feedback visual, som, etc.)
        }
        else
        {
            telaQuestao.gameObject.SetActive(false);
            telaIncorreto.gameObject.SetActive(true);
            // Aqui voc� pode adicionar a��es para resposta incorreta (ex: feedback visual, som, etc.)
        }
    }


    // M�todo para trocar de cena com base no �ndice da cena
    public void TrocarCena(int indiceCena)
    {
        // Verifica se o �ndice da cena � v�lido
        if (indiceCena >= 0 && indiceCena < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(indiceCena); // Carrega a cena pelo �ndice
            Debug.Log("Cena carregada: " + indiceCena);
        }
        else
        {
            Debug.LogError("�ndice de cena inv�lido: " + indiceCena);
        }
    }
}