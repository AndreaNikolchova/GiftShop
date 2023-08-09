$(document).ready(function () {
    $(".quantity-input").on('input', function () {
        var inputVal = $(this).val();
       
        if (inputVal.trim() === '' || isNaN(inputVal)) {
            
            $(this).val(1);
        }
        
        $(this).trigger('change');
    });
});
$(document).ready(function () {
    $(".quantity-input").on('change', function () {
        var productId = $(this).data('product-id');
        var productPrice = parseFloat($(this).data('product-price'));
        var newQuantity = parseInt($(this).val());
        var newSum = productPrice * newQuantity;
        $(".product-price[data-product-id='" + productId + "']").text(newSum.toFixed(2) + " BGN");
        updateTotalSum(); 
    });

    $("#plusBtn, #minusBtn").on('click', function () {
        var inputField = $(this).closest('.input-group').find('.quantity-input');
        var currentVal = parseInt(inputField.val());
        var step = 1; 

        if ($(this).attr('id') === 'plusBtn') {
            inputField.val(currentVal + step);
        } else {
            if (currentVal > step) {
                inputField.val(currentVal - step);
            }
        }

       
        inputField.trigger('change');
    });

    
    function updateTotalSum() {
        var totalSum = 0;
        $(".product-price[data-product-id]").each(function () {
            var productId = $(this).data('product-id');
            var productPrice = parseFloat($("input[data-product-id='" + productId + "']").data('product-price'));
            var quantity = parseInt($("input[data-product-id='" + productId + "']").val());
            var sum = productPrice * quantity;
            totalSum += sum;
        });
        $("#totalSum").text(totalSum.toFixed(2) + " BGN");
    }

    updateTotalSum();
});
$(document).ready(function () {
    $(".quantity-input").on('change', function () {
        var maxQuantity = parseInt($(this).attr('max'));
        var inputQuantity = parseInt($(this).val());

        var errorMessage = $(this).data('error-message');
        var productId = $(this).data('product-id');
        var errorMessageElement = $("#quantityErrorMessage_" + productId);

        if (inputQuantity > maxQuantity) {
            errorMessageElement.text(errorMessage);
        } else {
            errorMessageElement.text('');
        }
    });
});