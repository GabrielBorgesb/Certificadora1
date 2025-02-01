using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "SOQuestao", order = 0)]
public class SOQuestao : ScriptableObject {
    
    public string enunciado;
    public string resposta;
    public int repostaEletronica1;
    public int repostaEletronica2;
    public int nivel;
    public int xp;
    public int vezesCorreta;
    public Sprite imagem;
    

    public GameObject botao;

}

