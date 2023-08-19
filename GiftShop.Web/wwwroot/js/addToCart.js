function addToCart(button, productId, controllerName) {

    const data = {
        productId: productId,
        controllerName: controllerName
    };

    $.ajax({
        contentType: "application/json",
        type: 'POST',
        url: '/Product/AddToCart',
        data: JSON.stringify(data),
        success: function () {
            alert('Item added to the cart successfully!');
        },
        error: function (xhr) {
            
            if (xhr.status === 302) {
                alert('Item added to the cart successfully!');
            } 
        }
    });

}