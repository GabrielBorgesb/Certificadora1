using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BDQuestoes", menuName = "BDQuestoes", order = 0)]
public class BDQuestoes : ScriptableObject {
    
    public List<SOQuestao> questoes = new List<SOQuestao>();


    public List<GameObject> questoesAcertadas = new List<GameObject>();

}

