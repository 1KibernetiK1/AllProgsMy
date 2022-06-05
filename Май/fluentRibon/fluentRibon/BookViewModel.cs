using fluentRibon.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fluentRibon
{
    public class BookViewModel : EntityViewModel<Book>
    {
        public BookViewModel(Book model) : base(model)
        {
        }

        public string GenreString
        {
            get => string.Join(", ", _model.Genres.Select(g => g.Name));
        }

        public string Title
        {
            get => _model.Title;
            set
            {
                if (_model.Title == value)
                {
                    return;
                }
                _model.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }


        public int PublishYear
        {
            get => _model.PublishYear;
            set
            {
                if (_model.PublishYear == value)
                {
                    return;
                }
                _model.PublishYear = value;
                OnPropertyChanged(nameof(PublishYear));
            }
        }
    }
}
