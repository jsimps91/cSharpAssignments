$(document).ready(function () {
    function changeQuantity() {
        var id = $("#item-select").val();
        $.get(`/getProductQuantity/${id}`, function (res) {
            var htmlString = "<select asp-for='Quantity' class='form-control'>";
            for (var i = 1; i <= res; i++) {
                htmlString += `<option value='${i}'>${i}</option>`
            }
            htmlString += "</select>"
            $("#quantity-select").html(htmlString)
        })
    }
    $(".thumbnail").hover(function () {
        var name = $(this).data('name');
        var quantity = $(this).data('quantity')
    })
    $("#item-select").change(function () {
        changeQuantity();
        var name = $("#item-select :selected").text()
        console.log(name)
        
    })
    $(".stripe-button").click(function(){
        console.log("SDFLKJSDLKJ")
    })
    $("#filter-products").on("keyup", function () {
        var filter = $(this).val();
        $.get(`filterProducts/${filter}`, function (res) {
            var htmlString = "";
            for (var p of res) {
                htmlString += `<div class="thumbnail" style="background-image: url(${p.imageUrl})">
                <div class="product-info">
            <h5 class="product-label">${p.title}  <span class="badge">${p.quantity}</span></h5>
                </div>
            </div> `
            }
            if(filter == ""){
                htmlString += '<a href="#" id="show-more" data="2">Show more...</a>`'
            }
            document.getElementById("display-products").innerHTML = htmlString;
        })
    })
    $(document).on("click", "#show-more", function (e) {
        e.preventDefault();
        var num = $(this).attr('data')
        $.get(`/showmore/${num}`, function (res) {
            var htmlString = "";
            for (var p of res[0]) {
                htmlString += `<div class="thumbnail" style="background-image: url(${p.imageUrl})">
                <div class="product-info">
                <h5 class="product-label">${p.title}  <span class="badge">${p.quantity}</span></h5>
                </div>
            </div> `
            }
            if(parseInt(num)*4 < res[1])
            {
                var newNum = parseInt(num) +1
                htmlString += `<a href="#" id="show-more" data="${newNum}">Show more...</a>`
            }   
            document.getElementById("display-products").innerHTML = htmlString;

        })
    })

})

