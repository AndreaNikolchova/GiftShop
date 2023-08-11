function calculate(a, price) {
    document.getElementById('hiddenPrice').hidden = true;
    let packagingValue = parseFloat(document.getElementById('packaging').value);
    let deliveryValue = parseFloat(document.getElementById('delivery').value);
    if (deliveryValue === 0) {
        document.getElementById('error').textContent = "Please choose a delivery company";
        return;
    }
    if (document.getElementById('error').textContent == "Please choose a delivery company" && deliveryValue !== 0) {
        document.getElementById('error').textContent = "";
    }
    let sum = parseFloat(packagingValue) + parseFloat(deliveryValue) + parseFloat(price);
    document.getElementById('hiddenPrice').hidden = false;
    let span = document.getElementById('sum');
    span.textContent = sum.toFixed(2);
}
