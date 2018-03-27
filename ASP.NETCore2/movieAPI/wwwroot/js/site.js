$(document).ready(function(){
    $("#search").on("keyup", function(){
        var search = $("#search").val();
        $.get(`getMoviedata/${search}`, function(res){
            res = res.slice(0,10)
           liString = "";
            for(var movie of res){
                liString +=  "<div class='movie'>"
                liString += `<img class='poster' src='https://image.tmdb.org/t/p/w500/${movie.posterPath}' alt='${movie.title}'>`
                liString += `<h6>${movie.title}</h6>`
                liString += `<p>${movie.releaseDate}</p>`
                for(var i = 1; i <= movie.rating; i++){
                    liString += "<span class='glyphicon glyphicon-star'></span>"
                }
                for(var i = 1; i <= (10-movie.rating); i++){
                    liString += "<span class='glyphicon glyphicon-star-empty'></span>"
                }
                liString += "</div>"
            };
            document.getElementById("results").innerHTML = liString;
        })
    })

})