using Quiz.ViewModel;

namespace Quiz.Views;

public partial class QuizPage : ContentPage
{
	QuizPageViewModel instance;
	public QuizPage(QuizPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        instance = vm;

    }

	
}
