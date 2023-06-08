using System;

namespace haberPortaliAPI.ViewModel
{
    public class HaberModel
    {
        public int haberId { get; set; }
        public string baslik { get; set; }
        public string icerik { get; set; }
        public DateTime tarih { get; set; }
        public int kategoriId { get; set; }
    }
}
