using CommunityToolkit.Mvvm.ComponentModel;
using HTTPClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClient.ViewModels
{
    public partial class PostViewModel : ObservableObject
    {
        [ObservableProperty]
        List<Post>? posts;

        public void getPosts()
        {

        }
    }
}
