using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaQuestãoBehaviour : MonoBehaviour
{
    [SerializeField] private AlunoController aluno;

    private void OnEnable() {
        aluno.ChecarVezesAcertada();
    }
}
