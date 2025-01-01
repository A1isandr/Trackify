'use strict';

import { toggleMenu, updateMenu } from './menu.js';
import { toggleFullscreen } from './board.js';
import { readCookie } from '../cookies.js'; 


const toggleMenuButtons = document.querySelectorAll('.toggle-menu-button');

toggleMenuButtons
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



updateMenu();