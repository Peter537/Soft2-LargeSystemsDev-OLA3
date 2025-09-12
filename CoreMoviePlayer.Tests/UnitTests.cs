using System;
using Xunit;
using CorePlayer = CoreMoviePlayer.Services.CoreMoviePlayer;

namespace CoreMoviePlayer.Tests
{
    public class UnitTests
    {
        [Fact]
        public void PlayMovie_ValidPath_ReturnsPlayingMessage()
        {
            var player = new CorePlayer();
            var result = player.PlayMovie("test.mp4");
            Assert.Equal("Playing test.mp4", result);
        }

        [Fact]
        public void PlayMovie_EmptyPath_ReturnsError()
        {
            var player = new CorePlayer();
            var result = player.PlayMovie("");
            Assert.Equal("Error: No path", result);
        }

        [Fact]
        public void PlayMovie_NullPath_ReturnsError()
        {
            var player = new CorePlayer();
            var result = player.PlayMovie(null);
            Assert.Equal("Error: No path", result);
        }

        [Fact]
        public void IsValidMovie_ValidExtension_ReturnsTrue()
        {
            var player = new CorePlayer();
            Assert.True(player.IsValidMovie("movie.mp4"));
        }

        [Fact]
        public void IsValidMovie_InvalidExtension_ReturnsFalse()
        {
            var player = new CorePlayer();
            Assert.False(player.IsValidMovie("movie.txt"));
        }

        [Fact]
        public void IsValidMovie_Null_ReturnsFalse()
        {
            var player = new CorePlayer();
            Assert.False(player.IsValidMovie(null));
        }

        [Fact]
        public void Pause_NotPlaying_ThrowsException()
        {
            var player = new CorePlayer();
            Assert.Throws<InvalidOperationException>(() => player.Pause());
        }

        [Fact]
        public void Pause_AfterPlay_DoesNotThrow_ThenSecondPauseThrows()
        {
            var player = new CorePlayer();
            player.PlayMovie("movie.mp4");

            var firstPauseException = Record.Exception(() => player.Pause());
            Assert.Null(firstPauseException);

            Assert.Throws<InvalidOperationException>(() => player.Pause());
        }

        /*
        // This test is intended to fail to demonstrate test failure handling
        [Fact]
        public void FailingTestExample()
        {
            var player = new CorePlayer();
            var result = player.PlayMovie("test.mp4");
            Assert.Equal("This will fail", result);
        }
        */
    }
}