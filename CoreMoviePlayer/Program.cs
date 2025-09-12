namespace CoreMoviePlayer
{
    class program
    {
        static void Main(string[] args)
        {
            var player = new Services.CoreMoviePlayer();
            Console.WriteLine("Playing movie: " + player.PlayMovie("example.mp4"));
            player.Pause();
            Console.WriteLine("Is valid movie? " + player.IsValidMovie("invalid"));
        }
    }
}