using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "SOQuestao", order = 0)]
public class SOQuestao : ScriptableObject {
    
    public string enunciado;
    public string resposta;
    public int nivel;
    public int xp;
    public Sprite imagem;

}

