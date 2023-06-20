using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;
using Android.Gestures;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Org.Json;
using Quiz.Models;

namespace Quiz.ViewModel
{
	public partial class QuizPageViewModel:ObservableObject
	{
        HttpClient client;
        JsonSerializerOptions _serializerOptions;
        string baseUrl = "https://opentdb.com/api.php?amount=10&difficulty=easy&type=multiple";
        QuestionList questionList;


        string correctAnswer;
        int score = 0;
     
        public QuizPageViewModel()
		{
            client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions();
            fetchQuestions();
            Answers = new ObservableCollection<string>();
        }

        async void fetchQuestions()
        {
            var res = await client.GetStringAsync(baseUrl);
            questionList = JsonSerializer.Deserialize<QuestionList>(res);
            updateQuestion(0);
            No = 0;
            Console.WriteLine(questionList);
        }

        void updateQuestion(int qno)
        {
            Question = questionList.results[qno].question;
            Answers.Add(questionList.results[qno].correct_answer);
            foreach (string wrong_answer in questionList.results[qno].incorrect_answers)
            {
                Answers.Add(wrong_answer);
            }
            correctAnswer = questionList.results[qno].correct_answer;

        }

        [ObservableProperty]
        ObservableCollection<string> answers;

        [ObservableProperty]
        string question;

        [ObservableProperty]
        int no=0;

        [RelayCommand]
        void SubmitAnswer()
        {
            score += 1;
            No += 1;
            if (No <= 9)
            {
                Answers.Clear();
                updateQuestion(No);
              
            }
            
        }
    }
}

