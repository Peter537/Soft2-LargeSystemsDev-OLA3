namespace CoreMoviePlayer.Services
{
    public class CoreMoviePlayer
    {
        private bool isPlaying;

        public string PlayMovie(string moviePath)
        {
            if (string.IsNullOrEmpty(moviePath)) return "Error: No path";
            isPlaying = true;
            return "Playing " + moviePath;
        }

        public void Pause()
        {
            if (!isPlaying)
            {
                throw new InvalidOperationException("Not playing");
            }
            isPlaying = false;
        }

        public bool IsValidMovie(string path)
        {
            return path?.EndsWith(".mp4") ?? false;
        }
    }
}