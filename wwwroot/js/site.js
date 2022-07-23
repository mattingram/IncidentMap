
/**
 * @license
 * Copyright 2019 Google LLC. All Rights Reserved.
 * SPDX-License-Identifier: Apache-2.0
 */
 function initMap() {
    const place1 = {
      name: "FD 1",
      location: { lat: -25.363, lng: 131.044 },
      details1: "some details",
      details2: "more"
    }
    const map = new google.maps.Map(document.getElementById("map"), {
      zoom: 4,
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
      placeAddressElement.textContent = place1.details2;
      content.appendChild(placeAddressElement);
      infowindow.setContent(content);
      infowindow.open(map, marker1);
  });
  }
  
  window.initMap = initMap;
  