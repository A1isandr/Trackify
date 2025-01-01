'use strict';

import {readCookie} from "../cookies.js";



const menuContainer = document.querySelector('aside');
const menuList = document.querySelector('.menu__list');

menuList.addEventListener('click', (event) => {
    const target = event.target;
    
    if (!target.classList.contains('menu__list-item')) {
        return;
    }
    
    const boardId = target.id.split('-')[1];
    
    fetch(`api/Boards/${boardId}`, {
        method: "GET",
        headers: {
            "Accept": "application/json",
            "Authorization": `Bearer ${readCookie('accessToken')}`
        }
    })
    .then(response => {
        if (!response.ok) {
            window.location.href = '/auth';
        }

        return  response.json()
    })
    .then(data => {
        
    })
    .catch(error => {
        console.error('Error fetching board:', error);
    })
});

export function toggleMenu() {
    menuContainer.classList.toggle('hidden');
}

export function updateMenu() {
    fetch("api/Boards?offset=0&limit=20", {
        method: "GET",
        headers: {
            "Accept": "application/json",
            "Authorization": `Bearer ${readCookie('accessToken')}`
        }
    })
    .then(response => {
        if (!response.ok) {
            window.location.href = '/auth';
        }

        return  response.json()
    })
    .then(data => {
        data.forEach((board, index) => {
            const listItem = document.createElement('div');
            listItem.classList.add('menu__list-item');
            listItem.innerHTML = `
                <input type="radio" name="board" id="board-${index + 1}">
                <label for="board-${index + 1}">${board.name}</label>`;

            menuList.appendChild(listItem);
        });
    })
    .catch(error => {
        console.error('Error fetching boards:', error);
    })
}