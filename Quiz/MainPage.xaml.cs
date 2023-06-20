using Quiz.Views;

namespace Quiz;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnStartClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new QuizPage(new ViewModel.QuizPageViewModel(Navigation)));
	}
}


