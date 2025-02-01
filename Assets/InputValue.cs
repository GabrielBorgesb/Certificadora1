using UnityEngine;

public class InputValue : MonoBehaviour
{
    // Vari�vel para armazenar a porta l�gica encontrada
    public PortaLogica portaLogicaSelecionada;

    // Vari�vel para definir o tipo de porta l�gica desejada (configur�vel no Editor)
    [SerializeField] private PortaLogica.TipoPortaLogica portaLogicaDesejada;

    // Vari�vel para indicar se a porta l�gica encontrada � a correta
    [SerializeField] private bool isCorrect = false;

    private void Update()
    {
        // Verifica se o bot�o esquerdo do mouse foi solto
        if (Input.GetMouseButtonUp(0))
        {
            VerificarPortaLogica();
        }
    }

    // M�todo p�blico para acessar o valor de isCorrect
    public bool IsCorrect()
    {
        return isCorrect;
    }


    private void VerificarPortaLogica()
    {
        bool encontrouPorta = false;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, GetComponent<BoxCollider2D>().size, 0);

        // Reseta a vari�vel isCorrect antes de verificar
        isCorrect = false;

        foreach (Collider2D collider in colliders)
        {
            PortaLogica portaLogica = collider.GetComponent<PortaLogica>();
            if (portaLogica != null)
            {
                portaLogicaSelecionada = portaLogica;

                // Verifica se o tipo da porta l�gica encontrada � o desejado
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

        // Se n�o encontrou nenhuma porta, limpa a refer�ncia
        if (!encontrouPorta)
        {
            portaLogicaSelecionada = null;
        }
    }
}