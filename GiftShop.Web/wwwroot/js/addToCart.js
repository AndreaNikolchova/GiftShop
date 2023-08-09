function addToCart(button, productId, controllerName) {

    const data = {
        productId: productId,
        controllerName: controllerName
    };

    $.ajax({
        contentType: "application/json",
        type: 'POST',
        url: '/Product/AddToCart',
        data: JSON.stringify(data)
    });

}