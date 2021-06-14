window.addEventListener("load", () => {
    let imageLinks = document.getElementsByClassName("image-link");
    for (let link of imageLinks) {
        link.addEventListener("click", () => {
            let image = document.getElementById("imageImg");
            image.src = link.getAttribute("data-imageLink");
        })
    }

    let changeProductButtons = document.getElementsByClassName("change-product-button");
    for (let button of changeProductButtons) {
        button.addEventListener("click", () => {
            let parent = button.parentElement.parentElement.parentElement;
            let children = parent.children;
            document.getElementById("productIdChange").value = children[0].innerText;
            document.getElementById("productNameChange").value = children[1].innerText;
            document.getElementById("productDescriptionChange").innerText = children[2].innerText;
            document.getElementById("productPriceChange").value = children[4].innerText;
            document.getElementById("productShopNameChange").value = children[3].innerText;
        });
    }
}, false);