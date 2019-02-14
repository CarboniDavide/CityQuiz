// Davide Carboni
// Main classes for the data

using System;
using System.Collections.Generic;
using UnityEngine;

public static class ApiData
{
    #region Classes

    [Serializable]
    public class GameQuizzes
    {
        public List<IndexQuizzes> quizzes = new List<IndexQuizzes>();
    }

    [Serializable]
    public class Answer
    {
        public string name;
        public bool value;
    }

    [Serializable]
    public class Question
    {
        public string question;
        public string image;
        public List<Answer> answers = new List<Answer>();
    }


    [Serializable]
    public class Creator
    {
        string id;
        string username;
    }

    [Serializable]
    public class GameQuizze
    {
        public string id;
        public string title;
        public string description;
        public string created_by;
        public List<Question> questions = new List<Question>();
        public int number_participants;
    }

    [Serializable]
    public class IndexQuizzes
    {
        public string title;
        public string image;
        public string description;
        public Creator created_by = new Creator();
        public int number_participants;
        public string id;
    }


    #endregion
}
