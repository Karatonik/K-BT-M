var latlngt;
var popup = L.popup();
var map = L.map('map').setView([52.13, 21], 5);
var tiles = L.esri.basemapLayer("Streets").addTo(map);
var resultsMarker = L.layerGroup().addTo(map);

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://osm.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);


export function onButtonGet() {
    // console.log(addressText);
    var addressText = document.getElementById('address').innerHTML;
    //działa
    L.esri.Geocoding.geocode().text(addressText).run(function (err, results, response) {
        console.log(results.results[0].latlng.lat);
        latlngt = results.results[0].latlng;
        document.getElementById('xy').innerHTML = latlngt.toString().slice(6);
        map.setView([results.results[0].latlng.lat, results.results[0].latlng.lng], 16);
        resultsMarker.addLayer(L.marker(results.results[0].latlng));
    });
}

export function getX() {
    return latlngt.lat;
}

export function getY() {
    return latlngt.lng;
}

function onButtonSet() {
    console.log("wysłane");
}

function onMapClick(e) {
    resultsMarker.clearLayers();
    popup.setLatLng(e.latlng)
        .setContent("GEOCODE:" + e.latlng.toString().slice(6))
        .openOn(map);
    resultsMarker.addLayer(L.marker(e.latlng));
    latlngt = e.latlng;
    document.getElementById('xy').innerHTML = latlngt.toString().slice(6);
}

map.on('click', onMapClick);
