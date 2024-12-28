import {createCookie} from "../cookies.js";

const loginFormContainer = document.querySelector('#login-form__container');
const signupFormContainer = document.querySelector('#signup-form__container');

const goToSignupButton = document.querySelector('#go-to-signup');
const goToLoginButton = document.querySelector('#go-to-login');

goToSignupButton.addEventListener('click', () => {
    loginFormContainer.classList.add('hidden');
    signupFormContainer.classList.remove('hidden');
});

goToLoginButton.addEventListener('click', () => {
    loginFormContainer.classList.remove('hidden');
    signupFormContainer.classList.add('hidden');
});



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

    fetch('/api/Auth/login', {
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
        window.location.href = '/board';
    })
    .catch(error => {
        alert('Ошибка авторизации' + error);
    });
});



const signupButton = document.querySelector('#signup-button');

signupButton.addEventListener('click', () => {
    const username = document.querySelector('#signup-username').value;
    const password = document.querySelector('#signup-password').value;
    const passwordRepeat = document.querySelector('#signup-password-repeat').value;
    
    if (password !== passwordRepeat) {
        alert('Пароли не совпадают');
        return;
    }
    
    fetch('/api/Auth/register', {
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
        return response.json();
    })
    .then(data => {
        alert('Успешная регистрация: ' + data.message);
    })
    .catch(error => {
        console.error('Ошибка:', error);
        alert('Ошибка регистрации' + error);
    });
});