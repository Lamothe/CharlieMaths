using CharlieMaths.Models;
using CharlieMaths.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace CharlieMaths.ViewModels
{
    public class LessonViewModel : INotifyPropertyChanged
    {
        public ImageSource IconCompleted { get; set; }

        public Lesson Lesson { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsCompleted
        {
            get
            {
                return Lesson.IsCompleted;
            }
            set
            {
                Lesson.IsCompleted = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsCompleted)));
            }
        }
    }
}
