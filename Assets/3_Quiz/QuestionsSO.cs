using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Quiz Questions", fileName = "New Questions")]
public class Questions : ScriptableObject
{
    [TextArea(2,5)]
    [SerializeField]string question = "Enter new question";
    [SerializeField]string[] answers = new string[4];
    [SerializeField]int correctAnswerIndex = 0;
    public string GetQuestion()
    {
        return question;
    }
    public string GetAnswer(int index)
    {
        return answers[index];
    }
    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
}
