window.addEventListener("load", () => {
    navAccordionHandler();
    bodyMarginTopHandler();
}, false);

function navAccordionHandler() {
    let navAccordion = document.getElementById("navAccordion");
    let currentActionName = window.location.href.split('/').pop();
    let lies = navAccordion.children;
    for (let li of lies) {
        let link = li.children[0];
        if (link.href.split('/').pop() == currentActionName)
            link.classList.add('active');
    }
}

function bodyMarginTopHandler() {
    let navbar = document.getElementsByClassName("navbar fixed-top")[0];
    let bodyContent = document.getElementById("bodyContent");

    onResizeAction();
    window.addEventListener("resize", () => {
        onResizeAction();
    })

    function onResizeAction() {
        let baseMargin = "0.5rem"
        if (window.innerWidth < 992) {
            let cssProperty = "calc(" + navbar.clientHeight + "px + " + baseMargin + ")";
            bodyContent.style.setProperty("margin-top", cssProperty);
        }
        else {
            bodyContent.style.setProperty("margin-top", 0);
        }
    }
}