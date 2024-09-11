using CommunityToolkit.Mvvm.ComponentModel;
using HTTPClient.Models;
using HTTPClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace HTTPClient.ViewModels
{
    internal partial class TodoViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Todo>? todos;

        public ICommand getTodosCommand { get; set; }

        public TodoViewModel()
        {
            getTodosCommand = new Command(getTodos);
        }

        public async void getTodos()
        {
            TodoService todoService = new();
            Todos = await todoService.FetchTodosAsync();
        }
    }
}