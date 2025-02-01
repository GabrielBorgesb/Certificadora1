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

    [Header("Configuração da Porta Lógica")]
    [Tooltip("Selecione o tipo de porta lógica")]
    [SerializeField] private TipoPortaLogica tipoPorta = TipoPortaLogica.AND;

    // Propriedade pública para acessar o tipo da porta
    public TipoPortaLogica TipoPorta => tipoPorta;

}
