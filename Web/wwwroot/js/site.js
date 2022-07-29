

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
      name: i.address,
      location: { lat: i.location.lat, lng: i.location.lng },
      details1: `Event Time: ${i.eventDate}`,
      details2: `Temperature: ${w.temp}`,
      details3: i.description
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
      var header = document.createElement("h3");
      header.textContent = place1.name;
      content.appendChild(header);
      var p1 = document.createElement("p");
      p1.textContent = place1.details1;
      content.appendChild(p1);
      var p2 = document.createElement("p");
      p2.textContent = place1.details2;
      content.appendChild(p2);
      var p3 = document.createElement("p");
      p3.textContent = place1.details3;
      content.appendChild(p3);
      infowindow.setContent(content);
      infowindow.open(map, marker1);
  });
  }
  
  window.initMap = initMap;
  