window.addEventListener("load", () => {
    let buttonsProductRemove = document.getElementsByClassName("btn-add-to-basket")
    for (let button of buttonsProductRemove) {
        button.addEventListener("click", () => {
            let parent = button.parentElement.parentElement;
            parent.parentElement.removeChild(parent);
        })
    }
}, false);