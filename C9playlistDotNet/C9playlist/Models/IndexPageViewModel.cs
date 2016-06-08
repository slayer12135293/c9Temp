using System.Collections.Generic;

namespace C9playlist.Models
{
    public class IndexPageViewModel
    {
        public IEnumerable<SongListItemViewModel> DisplayedList { get; set; }

        public SearchParamViewModel SearchParams { get; set; }
        
    }
}