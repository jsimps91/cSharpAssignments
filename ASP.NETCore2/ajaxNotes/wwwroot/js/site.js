$(document).ready(function(){
    $('.description').click(function(){
        var id = $(this).attr('data-id')
        document.getElementById(id).style.visibility = "visible";
        $(this).hide();
    })
})