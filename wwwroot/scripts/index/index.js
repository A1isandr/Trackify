const authorizeButton = document.querySelector('#authorize-button');

authorizeButton.addEventListener('click', () => {
    window.location.href = '/authorize';
});