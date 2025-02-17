'use strict';

const modalContainer = document.querySelector('#modal__container');
const modals = document.querySelectorAll('.modal');

modalContainer.addEventListener('click', event => {
    if (event.target.classList.contains("modal")) {
        closeAllModals();
    }
});

modals.forEach(modal => {
    const closeButton = modal.querySelector('.modal__close-button');
    
    closeButton.addEventListener('click', () => {
        modal.classList.add('hidden');
    });
});

export function openModal(modalId) {
    const modal = Array
        .from(modals)
        .find(modal => modal.id === modalId);
    
    modal.classList.remove('hidden');
}

export function closeAllModals() {
    modals.forEach(modal => modal.classList.add('hidden'));
}