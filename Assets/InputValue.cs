using UnityEngine;

public class InputValue : MonoBehaviour
{
    // Variável para armazenar a porta lógica encontrada
    public PortaLogica portaLogicaSelecionada;

    // Variável para definir o tipo de porta lógica desejada (configurável no Editor)
    [SerializeField] private PortaLogica.TipoPortaLogica portaLogicaDesejada;

    // Variável para indicar se a porta lógica encontrada é a correta
    [SerializeField] private bool isCorrect = false;

    private void Update()
    {
        // Verifica se o botão esquerdo do mouse foi solto
        if (Input.GetMouseButtonUp(0))
        {
            VerificarPortaLogica();
        }
    }

    // Método público para acessar o valor de isCorrect
    public bool IsCorrect()
    {
        return isCorrect;
    }


    private void VerificarPortaLogica()
    {
        bool encontrouPorta = false;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, GetComponent<BoxCollider2D>().size, 0);

        // Reseta a variável isCorrect antes de verificar
        isCorrect = false;

        foreach (Collider2D collider in colliders)
        {
            PortaLogica portaLogica = collider.GetComponent<PortaLogica>();
            if (portaLogica != null)
            {
                portaLogicaSelecionada = portaLogica;

                // Verifica se o tipo da porta lógica encontrada é o desejado
                if (portaLogica.TipoPorta == portaLogicaDesejada)
                {
                    isCorrect = true;
                }
                else
                {
                }

                encontrouPorta = true;
                break;
            }
        }

        // Se não encontrou nenhuma porta, limpa a referência
        if (!encontrouPorta)
        {
            portaLogicaSelecionada = null;
        }
    }
}