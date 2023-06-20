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

    void RadioButton_CheckedChanged(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
        if (sender== null)
        {
            return;
        }
        RadioButton rb = sender as RadioButton;
        string content = rb.Content.ToString();
        instance.SelectedValue = content;
        instance.SelectedButton = rb;
       
    }

}
