let array = document.getElementsByTagName('input');
sessionStorage.setItem('cart');
for (let i = 0; i < array.length; i++) {

    array[i].addEventListener('click', function (e) {

        let items = sessionStorage.getItem('cart');
        let arr = [];
        if (items === null) {
            
        }
        else {
            items.add()
        }
        alert('Data saved to localStorage!');
    });
}

