using UnityEngine;

public class PortaLogica : MonoBehaviour
{
    public enum TipoPortaLogica
    {
        AND,
        OR,
        NOT,
        NAND,
        NOR,
        XOR,
        XNOR
    }

    [Header("Configura��o da Porta L�gica")]
    [Tooltip("Selecione o tipo de porta l�gica")]
    [SerializeField] private TipoPortaLogica tipoPorta = TipoPortaLogica.AND;

    // Propriedade p�blica para acessar o tipo da porta
    public TipoPortaLogica TipoPorta => tipoPorta;

}
