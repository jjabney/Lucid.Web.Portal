using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lucid.Web.Portal.Models
{
    public class ComposeEmailViewModel
    {
        public ComposeEmailViewModel()
        {

        }

        public ComposeEmailViewModel(IEnumerable<Video> videos)
        {

            Videos = videos.ToList();
            Message = new Message();

        }

        public List<Video> Videos { get; private set; }

        public List<Video> Selected { get; set; }

        public Message Message { get; private set; }
    }
}