using CharlieMaths.Models;
using CharlieMaths.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharlieMaths.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Lesson> Items { get; set; }

        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(App).GetTypeInfo().Assembly;

            var imageSourceCompleted = ImageSource.FromResource("CharlieMaths.Assets.completed.png", assembly);
            var viewModels = Lesson.AllLessons.Select(l => new LessonViewModel
            {
                Lesson = l,
                IconCompleted = imageSourceCompleted
            });
            listViewLessons.ItemsSource = new ObservableCollection<LessonViewModel>(viewModels);
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as LessonViewModel;

            if (item == null)
            {
                return;
            }

            await Navigation.PushModalAsync(new QuestionPage(this, item));

            ((ListView)sender).SelectedItem = null;
        }
    }
}
