
function initMap() {
  var location = document.getElementById("map").getAttribute('data');
  var geocoder = new google.maps.Geocoder();
    var map = new google.maps.Map(document.getElementById('map'), {
      zoom: 10,
    });
    geocoder.geocode( {'address' : location}, function(results, status){
      if(status == 'OK'){
          map.setCenter(results[0].geometry.location);
          var marker = new google.maps.Marker({
              map: map,
              position: results[0].geometry.location
          });
      } else {
          alert("Could not load map for this address");
      }
  });
  }
