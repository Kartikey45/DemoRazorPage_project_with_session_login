$(document).ready(function () {
    window.alert = function (text) { console.log('tried to alert: ' + text); return true; };
    alert(new Date());


}