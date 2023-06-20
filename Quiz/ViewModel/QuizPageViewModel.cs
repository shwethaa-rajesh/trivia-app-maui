using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;
using Android.Gestures;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Org.Json;
using Quiz.Models;
using Quiz.Views;

namespace Quiz.ViewModel
{
	public partial class QuizPageViewModel:ObservableObject
	{
        HttpClient client;
        JsonSerializerOptions _serializerOptions;
        string baseUrl = "https://opentdb.com/api.php?amount=10&category=31&difficulty=easy&type=multiple";
        public INavigation Navigation { get; set; }
        QuestionList questionList;


        string correctAnswer;

        [ObservableProperty]
        bool isLoading = true;

        [ObservableProperty]
        bool showQuestions = false;

        [ObservableProperty]
        int score = 0;

        [ObservableProperty]
        RadioButton selectedButton;

        public QuizPageViewModel(INavigation navigation)
		{
            client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions();
            fetchQuestions();
            Answers = new ObservableCollection<string>();
            this.Navigation = navigation;
        }

        async void fetchQuestions()
        {
            var res = await client.GetStringAsync(baseUrl);
            questionList = JsonSerializer.Deserialize<QuestionList>(res);
            updateQuestion(0);
            No = 0;
            IsLoading = false;
            ShowQuestions = true;
        }

        void updateQuestion(int qno)
        {
            Random rnd = new Random();
            Question = questionList.results[qno].question;
            
            Answers.Add(questionList.results[qno].correct_answer);
            foreach (string wrong_answer in questionList.results[qno].incorrect_answers)
            {
                Answers.Add(wrong_answer);
            }
            string[] answerslist=Answers.ToArray();
            string[] MyRandomArray = answerslist.OrderBy(x => rnd.Next()).ToArray();
            Answers.Clear();
            foreach (string answer in MyRandomArray)
            {
                Answers.Add(answer);
            }
            correctAnswer = questionList.results[qno].correct_answer;

            System.Diagnostics.Debug.WriteLine(correctAnswer);
        }

        [ObservableProperty]
        ObservableCollection<string> answers;

        [ObservableProperty]
        string question;

      
        public string SelectedValue;

        [ObservableProperty]
        int no=0;

        [RelayCommand]
        async void SubmitAnswer()
        {
            if(SelectedButton == null)
            {
                await  Application.Current.MainPage.DisplayAlert("Error", "You have to select an answer choice", "OK");
                return;
            }
            
            System.Diagnostics.Debug.WriteLine(SelectedValue, "Selected");
            System.Diagnostics.Debug.WriteLine(correctAnswer, "correct");
            SelectedButton.IsChecked = false;
            if (SelectedValue == correctAnswer)
            {

                Score += 1;
            }
            No += 1;

            if (No <= 9)
            {
                Answers.Clear();
                SelectedButton = null;
                updateQuestion(No);
              
            }
            else if (No == 10)
            {
                Navigation.PushAsync(new ScorePage(Score));
            }
            
        }
    }
}

