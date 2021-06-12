window.addEventListener("load", () => {
    let imageLinks = document.getElementsByClassName("image-link");
    for (let link of imageLinks) {
        link.addEventListener("click", () => {
            let image = document.getElementById("imageImg");
            image.src = link.getAttribute("data-imageLink");
        })
    }
}, false);