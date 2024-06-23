using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class Quiz
{

    public static Dictionary<string, int> QuizPointsList = new Dictionary<string, int> // Очки
    {
        { "PickupBattleQuiz",  0},
        { "VladimirHillQuiz", 0},
        { "Veterans", 0},
        { "MamaQuiz", 0 }
    };


    public enum quizList
    {
        PickupBattleQuiz,
        VladimirHillQuiz,
        Veterans,
        MamaQuiz
    };

    public static quizList quizModes;
    

    public static int getQuizPoints(string quizName)
    {
        return QuizPointsList[quizName];
    }
    public static void setQuizPoints(string quizName, int count)
    {
   
        QuizPointsList[quizName] += count;
        Debug.Log($"Викторина {quizName} изменила свои очки на {count}. Теперь кол-во очков: {QuizPointsList[quizName]}");
    }




}
