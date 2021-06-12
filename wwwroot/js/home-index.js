window.onload = () => {
	var productsObject = JSON.parse(localStorage.getItem("productsBasketObject"));
	if (productsObject == null) {
		productsObject = {
			productIds: []
		}
		localStorage.setItem("productsBasketObject", JSON.stringify(productsObject));
	}
	updateBusketCounter();
	let addToBasketButtons = document.querySelectorAll('.btn-add-to-basket');
	for (let i = 0; i < addToBasketButtons.length; i++) {
		let productId = addToBasketButtons[i].getAttribute('data-productId');
		if (productsObject.productIds.includes(productId))
			setDeleteButtonStatus(addToBasketButtons[i]);
		else
			setAddButtonStatus(addToBasketButtons[i])
		addToBasketButtons[i].addEventListener("click", () => {
			let productId = addToBasketButtons[i].getAttribute('data-productId');
			if (addToBasketButtons[i].classList.contains("btn-primary") && !productsObject.productIds.includes(productId)) {
				productsObject.productIds.push(productId);
				switchButtonStatus(addToBasketButtons[i]);
			}
			else if (productsObject.productIds.includes(productId)) {
				productsObject.productIds.splice(productsObject.productIds.indexOf(productId), 1);
				switchButtonStatus(addToBasketButtons[i]);
			}
			localStorage.setItem("productsBasketObject", JSON.stringify(productsObject));
			updateBusketCounter();
		});
	}
};

function switchButtonStatus(button) {
	if (button.classList.contains("btn-primary")) {
		setDeleteButtonStatus(button);
	}
	else {
		setAddButtonStatus(button);
	}
}

function setAddButtonStatus(button) {
	button.classList.remove('btn-warning');
	button.classList.add('btn-primary');
	button.innerHTML = "<i class='fa fa-shopping-cart'></i> Добавить в корзину";
}

function setDeleteButtonStatus(button) {
	button.classList.remove('btn-primary');
	button.classList.add('btn-warning');
	button.innerHTML = "<i class='fa fa-shopping-cart'></i> Удалить из корзины";
}

function updateBusketCounter() {
	let basketCounter = document.getElementById("basketCounter");
	let productsObject = JSON.parse(localStorage.getItem("productsBasketObject"));
	if (basketCounter != null) {
		basketCounter.innerText = productsObject.productIds.length;
		if (productsObject.productIds.length > 0)
			basketCounter.classList.remove('d-none');
		else
			basketCounter.classList.add('d-none');
	}
	else
		basketCounter.classList.add('d-none');
}