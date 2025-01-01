'use strict';

import {createCookie} from "../cookies.js";



const loginFormContainer = document.querySelector('#login-form__container');
const signupFormContainer = document.querySelector('#signup-form__container');

const goToSignupButton = document.querySelector('#go-to-signup');
const goToLoginButton = document.querySelector('#go-to-login');

goToSignupButton.addEventListener('click', toggleForms);
goToLoginButton.addEventListener('click', toggleForms);

function toggleForms() {
    loginFormContainer.classList.toggle('hidden');
    signupFormContainer.classList.toggle('hidden');
} 



const loginForm = document.querySelector('#login-form');
const signupForm = document.querySelector('#signup-form');

loginForm.addEventListener('submit', (event) => {
    event.preventDefault();
});

signupForm.addEventListener('submit', (event) => {
    event.preventDefault();
});



const loginButton = document.querySelector('#login-button');

loginButton.addEventListener('click', () => {
    const username = document.querySelector('#login-username').value;
    const password = document.querySelector('#login-password').value;

    fetch('/api/Token/generate', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ username, password })
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Ошибка авторизации');
        }
        return response.json();
    })
    .then(data => {
        console.log(data.accessToken);
        createCookie('accessToken', data.accessToken, 0);
        createCookie('username', data.username, 0);
        window.location.href = '/';
    })
    .catch(error => {
        alert(error.message);
    });
});



const signupButton = document.querySelector('#signup-button');

signupButton.addEventListener('click', () => {
    const username = document.querySelector('#signup-username').value;
    const password = document.querySelector('#signup-password').value;
    const passwordRepeat = document.querySelector('#signup-password-repeat').value;
    
    if (password !== passwordRepeat) {
        alert('Passwords do not match');
        return;
    }
    
    fetch('/api/Users/create', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ username, password })
    })
    .then(response => {
        if (!response.ok) {
            throw new Error(response.statusText);
        }
        
        toggleForms();
    })
    .catch(error => {
        alert('Registration failed' + error);
    });
});