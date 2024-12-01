export function toggleFullscreen() {
    const board = document.querySelector('.board__container');
    const controlBar = document.querySelector('.board__control-bar');
    
    board.classList.toggle('fullscreen');
    controlBar.classList.toggle('hidden');
}