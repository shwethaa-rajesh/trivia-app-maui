namespace Quiz.Views;

public partial class ScorePage : ContentPage
{
	public ScorePage(int score)
	{
		InitializeComponent();
		scoreLabel.Text = score.ToString();
	}

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		Navigation.PopToRootAsync();
    }
}
