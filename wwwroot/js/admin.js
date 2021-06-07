window.onload = () => {
    let navAccordion = document.getElementById("navAccordion");
    let currentActionName = window.location.href.split('/').pop();
    let lies = navAccordion.children;
    console.log(navAccordion);
    console.log(lies);
    for (let li of lies) {
        let link = li.children[0];
        if (link.href.split('/').pop() == currentActionName)
            link.classList.add('active');
    }
}