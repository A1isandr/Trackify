import { toggleMenu } from './menu.js';
import { toggleFullscreen } from './board.js';


const hideMenuButtons = document.querySelectorAll('.toggle-menu-button');

hideMenuButtons
    .forEach(button => button.addEventListener('click', () => {
        toggleMenu();
        toggleFullscreen();
    }));


const categoryTitles = document.querySelectorAll('.category__title');

categoryTitles
    .forEach(title => title.addEventListener('input', () => {
        title.style.height = 'auto';
        title.style.height = `${title.scrollHeight}px`;
    }));