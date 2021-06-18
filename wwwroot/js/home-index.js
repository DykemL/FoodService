window.addEventListener("load", () => {
    parseFilterArguments();
    handleFilterInsertion();
}, false);

function parseFilterArguments() {
    try {
        console.log("try");
        let arguments = decodeURI(document.location.href).split('?')[1].split('&');
        console.log(document.location.href);
        console.log(document.location.href.split('?'));
        console.log(arguments);
        nameFilterIndex = arguments.findIndex(argument => argument.match("nameFilter"));
        if (nameFilterIndex != -1)
            document.getElementById("nameFilter").value = arguments[nameFilterIndex].split('=')[1];
        shopFilterIndex = arguments.findIndex(argument => argument.match("shopFilter"));
        if (shopFilterIndex != -1)
            document.getElementById("nameFilter").value = arguments[shopFilterIndex].split('=')[1];
    }
    catch (exception){}
}

function handleFilterInsertion() {
    let filterButton = document.getElementById("filterButton");
    filterButton.addEventListener("click", () => {
        let productFilter = document.getElementById("nameFilter").value;
        let shopFilter = document.getElementById("shopFilter").value;
        let link = document.location.protocol + "//" + document.location.host + "/Home/Index/?";
        if (productFilter != "")
            link += "nameFilter=" + productFilter;
        if (shopFilter != "")
            link += "shopFilter=" + shopFilter;
        document.location.href = link;
    });
}