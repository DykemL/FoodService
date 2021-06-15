window.addEventListener("load", () => {
    let filterButton = document.getElementById("filterButton");
    filterButton.addEventListener("click", () => {
        let productFilter = document.getElementById("nameFilter").value;
        let shopFilter = document.getElementById("shopFilter").value;
        let link = document.location.protocol + "//" + document.location.host + "/Home/Index/?";
        if (productFilter != "")
            link += "nameFilter=" + productFilter;
        if (shopFilter != "")
            link += "shopFilter=" + shopFilter;
        console.log(link);
        document.location.href = link;
    });
}, false);