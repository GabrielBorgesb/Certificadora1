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
        // Encontra todos os objetos com o componente InputValue e os adiciona à lista
        InputValue[] inputs = FindObjectsOfType<InputValue>();
        inputValues.AddRange(inputs);
    }

    // Método chamado quando o botão "Responder" é pressionado
    public void OnResponderButtonPressed()
    {
        bool todasCorretas = true;

        // Verifica se todos os InputValue estão com isCorrect == true
        foreach (InputValue inputValue in inputValues)
        {
            if (!inputValue.IsCorrect())
            {
                todasCorretas = false;
                break;
            }
        }

        // Executa a ação com base no resultado
        if (todasCorretas)
        {
            telaQuestao.gameObject.SetActive(false);
            telaCorreto.gameObject.SetActive(true);
            // Aqui você pode adicionar ações para resposta correta (ex: feedback visual, som, etc.)
        }
        else
        {
            telaQuestao.gameObject.SetActive(false);
            telaIncorreto.gameObject.SetActive(true);
            // Aqui você pode adicionar ações para resposta incorreta (ex: feedback visual, som, etc.)
        }
    }


    // Método para trocar de cena com base no índice da cena
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