using CharlieMaths.Models;
using CharlieMaths.ViewModels;
using Plugin.SimpleAudioPlayer;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharlieMaths.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionPage : ContentPage
    {
        private int questionCount { get; set; } = 0;

        private int correctQuestionCount = 0;

        private Question currentQuestion { get; set; } = null;

        private ISimpleAudioPlayer playerCorrect { get; set; }

        private ISimpleAudioPlayer playerWrong { get; set; }

        private LessonViewModel model { get; set; }

        private MainPage mainPage { get; set; }

        public QuestionPage(MainPage mainPage, LessonViewModel lessonViewModel)
        {
            InitializeComponent();

            this.mainPage = mainPage;

            model = lessonViewModel;
            entryAnswer.Completed += EntryAnswer_Completed;
            buttonNext.Clicked += ButtonNext_Clicked;
            labelLessonHeader.Text = lessonViewModel.Lesson.Label;

            playerCorrect = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            playerWrong = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();

            var assembly = typeof(App).GetTypeInfo().Assembly;
            playerCorrect.Load(assembly.GetManifestResourceStream("CharlieMaths.Assets.correct.ogg"));
            playerWrong.Load(assembly.GetManifestResourceStream("CharlieMaths.Assets.wrong.ogg"));

            PresentQuestion();
        }

        private void EntryAnswer_Completed(object sender, EventArgs e)
        {
            ProcessAnswer();
        }

        private bool IsComplete => questionCount >= 10 && correctQuestionCount == questionCount;

        private void ButtonNext_Clicked(object sender, EventArgs e)
        {
            if (IsComplete)
            {
                model.Lesson.IsCompleted = true;
                model.IsCompleted = true;
                Navigation.PopModalAsync();
            }

            PresentQuestion();
        }

        protected override void OnAppearing()
        {
            entryAnswer.Focus();
            base.OnAppearing();
        }

        private void PresentQuestion()
        {
            questionCount++;

            BackgroundColor = Color.White;
            currentQuestion = model.Lesson.QuestionGenerator.GetQuestion();
            labelQuestionHeader.Text = $"Question {questionCount}";
            labelQuestion.Text = currentQuestion.Text;
            labelResult.Text = "";
            buttonNext.IsVisible = false;

            entryAnswer.Text = "";
            entryAnswer.Focus();
        }

        private void ProcessAnswer()
        {
            ISimpleAudioPlayer player = null;

            var responseText = entryAnswer.Text.Trim('\n');
            if (responseText == currentQuestion.Answer)
            {
                correctQuestionCount++;
                labelResult.Text = "Correct";
                BackgroundColor = Color.FromHex("92ff92");
                player = playerCorrect;
            }
            else
            {
                labelResult.Text = "Wrong";
                BackgroundColor = Color.FromHex("feb6b7");
                player = playerWrong;
            }

            labelQuestion.Text = $"{currentQuestion.Text} {currentQuestion.Answer}";
            player.Play();

            if (IsComplete)
            {
                buttonNext.Text = "Finish!";
            }

            buttonNext.IsVisible = true;
        }
    }
}