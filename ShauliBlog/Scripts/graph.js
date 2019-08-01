var riceData = {
    labels: ["January", "February", "March", "April", "May", "June"],
    datasets:
        [
            {
                label: 'rice production',
                fillColor: "rgba(172,194,132,0.4)",
                strokeColor: "#ACC26D",
                pointColor: "#fff",
                pointStrokeColor: "#9DB86D",
                data: [203000, 15600, 99000, 25100, 30500, 24700],
            }
        ]
}

var pieData = {
    labels: ["2015", "2016", "2017", "2018"],
    datasets:
        [
            {
                label: 'pie production',
                fillColor: "rgba(172,194,132,0.4)",
                strokeColor: "#ACC26D",
                pointColor: "#fff",
                pointStrokeColor: "#9DB86D",
                data: [800, 500, 600, 500],
                backgroundColor: ['rgba(205, 0, 0, 0.1)', 'rgba(0, 69, 123, 0.1)', 'rgba(0, 100, 123, 0.1)', 'rgba(0, 0, 123, 0.1)']
            }
        ]
}

$(document).ready(function(){ 
    var rice = document.getElementById('rice').getContext('2d');
    new Chart(rice, {
        type: "line",
        data: riceData,
    });

    var pie = document.getElementById('pie').getContext('2d');
    new Chart(pie, {
        type: 'doughnut',
        data: pieData,
    });
})