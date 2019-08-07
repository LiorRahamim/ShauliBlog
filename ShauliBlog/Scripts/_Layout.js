window.onload = function () {
    drawOnCanvas();
};

function drawOnCanvas() {
    var c = document.getElementById("ShauliCanvas");
    var ctx = c.getContext("2d");
    ctx.beginPath();
    ctx.arc(95, 50, 40, 0, 2 * Math.PI);
    ctx.stroke();
}