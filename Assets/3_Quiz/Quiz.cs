using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Quiz : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField] QuestionsSO question;
    [SerializeField] TextMeshProUGUI[] answers;
    void Start()
    {
        questionText.text = question.GetQuestion();
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].text = question.GetAnswer(i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
