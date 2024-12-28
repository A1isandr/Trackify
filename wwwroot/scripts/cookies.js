'use strict';

export function createCookie(name,value,days) {
    let expires;
    
    if (days) {
        const date = new Date();
        date.setTime(date.getTime()+(days * 24 * 60 * 60 * 1000));
        expires = "; expires="+date.toUTCString();
    }
    else {
        expires = "";
    } 
    
    document.cookie = name+"="+value+expires+"; path=/";
}

export function readCookie(name) {
    const nameEQ = name + "=";
    const cookieParts = document.cookie.split(';');
    
    for (let i=0;i < cookieParts.length;i++) {
        let cookiePart = cookieParts[i];
        
        while (cookiePart.charAt(0) === ' ') {
            cookiePart = cookiePart.substring(1, cookiePart.length);
        }
        
        if (cookiePart.indexOf(nameEQ) === 0) {
            return cookiePart.substring(nameEQ.length,cookiePart.length);
        }
    }
    
    return null;
}

export function eraseCookie(name) {
    createCookie(name,"",-1);
}