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



const loginButton = document.querySelector('#login-button');

loginButton.addEventListener('click', () => {
    console.log("submitted");
    
    const username = document.querySelector('#login-username').value;
    const password = document.querySelector('#login-password').value;

    fetch('/api/login', {
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
        alert('Успешная авторизация: ' + data.message);
    })
    .catch(error => {
        console.error('Ошибка:', error);
        alert('Ошибка авторизации' + error);
    });
});