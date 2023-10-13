const audio = document.getElementById('audio');
const playButton = document.getElementById('playButton');

let isPlaying = false;

playButton.addEventListener('click', () => {
    if (isPlaying) {
        audio.pause();
        playButton.textContent = 'Play';
    } else {
        audio.play();
        playButton.textContent = 'Pause';
    }

    isPlaying = !isPlaying;
});
