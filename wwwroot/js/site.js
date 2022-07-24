

/**
 * @license
 * Copyright 2019 Google LLC. All Rights Reserved.
 * SPDX-License-Identifier: Apache-2.0
 */

 async function initMap() {
    
    var d;

    await $.get("/Map")
      .done(function (data) {
        d = data;
      })
      .fail(function() {alert("Error loading incident data;")});

    var i = d.incident;
    var w = d.weather;

    const place1 = {
      name: i.fireDepartment,
      location: { lat: i.address.lat, lng: i.address.lng },
      details1: i.eventDate,
      details2: w.temp
    }
    const map = new google.maps.Map(document.getElementById("map"), {
      zoom: 11,
      center: place1.location,
    });
  
    const infowindow = new google.maps.InfoWindow();
    var marker1 = new google.maps.Marker({
      position: place1.location,
      map,
    });

    google.maps.event.addListener(marker1, "click", function () {
      var content = document.createElement("div");
      var nameElement = document.createElement("h2");
      nameElement.textContent = place1.name;
      content.appendChild(nameElement);
      var placeIdElement = document.createElement("p");
      placeIdElement.textContent = place1.details1;
      content.appendChild(placeIdElement);
      var placeAddressElement = document.createElement("p");
      placeAddressElement.textContent = `Temperature: ${place1.details2}`;
      content.appendChild(placeAddressElement);
      infowindow.setContent(content);
      infowindow.open(map, marker1);
  });
  }
  
  window.initMap = initMap;
  