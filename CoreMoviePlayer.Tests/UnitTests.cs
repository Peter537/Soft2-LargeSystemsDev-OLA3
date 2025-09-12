namespace CoreMoviePlayer.Tests
{
    public class UnitTests
    {
        [Fact]
        public void PlayMovie_ValidPath_ReturnsPlayingMessage()
        {
            var player = new Services.CoreMoviePlayer();
            var result = player.PlayMovie("test.mp4");
            Assert.Equal("Playing test.mp4", result);
        }

        [Fact]
        public void PlayMovie_EmptyPath_ReturnsError()
        {
            var player = new Services.CoreMoviePlayer();
            var result = player.PlayMovie("");
            Assert.Equal("Error: No path", result);
        }

        [Fact]
        public void IsValidMovie_ValidExtension_ReturnsTrue()
        {
            var player = new Services.CoreMoviePlayer();
            Assert.True(player.IsValidMovie("movie.mp4"));
        }

        [Fact]
        public void IsValidMovie_InvalidExtension_ReturnsFalse()
        {
            var player = new Services.CoreMoviePlayer();
            Assert.False(player.IsValidMovie("movie.txt"));
        }

        /* Uden denne Test er der ikke 80% line coverage
        [Fact]
        public void Pause_NotPlaying_ThrowsException()
        {
            var player = new Services.CoreMoviePlayer();
            Assert.Throws<InvalidOperationException>(() => player.Pause());
        }
        */
    }
}