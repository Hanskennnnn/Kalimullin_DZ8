namespace Tumakov_DZ
{
    class Song
    {
        #region Поля
        private string name;
        private string author;
        private Song prev;
        #endregion

        #region Конструкторы
        public Song(string songName, string songAuthor)
        {
            name = songName;
            author = songAuthor;
            prev = null;
        }

        public Song(string songName, string songAuthor, Song previousSong)
        {
            name = songName;
            author = songAuthor;
            prev = previousSong;
        }

        public Song()
        {
            name = "Unknown";
            author = "Unknown";
            prev = null;
        }
        #endregion

        #region Методы
        public void SetName(string songName)
        {
            name = songName;
        }

        public void SetAuthor(string songAuthor)
        {
            author = songAuthor;
        }

        public void SetPrev(Song previousSong)
        {
            prev = previousSong;
        }

        public string Title()
        {
            return $"{name} by {author}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Song otherSong)
            {
                return this.name == otherSong.name && this.author == otherSong.author;
            }
            return false;
        }
        #endregion
    }
}
