﻿var global_result;
function OnSuccess(data) {
    var result = $('#result');
    result.empty();
    global_result = data;
    on_create_g();
}
$(document).ready(function () {
    $('#Submit').click(function (e) {
        e.preventDefault();
        $('#result').load('@Url.Action("getData")');
    })
})

function on_create_g() {
    var arr = global_result;
    var arr_convert = [];
    if (arr !== null) {
        for (var i = 0; i < arr.length; i++) {
            arr_convert.push({
                label: arr[i].parameter_name,
                value: arr[i].parameter_value,
                date_time: moment(arr[i].date_time, "YYYY.MM.DD HH:mm")
            });
        }
        console.log("Изначальные данные - ");
        console.log(arr_convert);
    }
    arr_convert.sort(function compare(a, b) {
        if (a.date_time < b.date_time) {
            return -1;
        }
        if (a.date_time > b.date_time) {
            return 1;
        }
        return 0;
    });
    var data_xy = [], data_lable = [], data_lable_time_y = [];
    var config_data = [];
    var datasets = [];
    for (var i = 0; i < arr_convert.length; i++) {
        data_xy.push({ x: arr_convert[i].date_time, y: arr_convert[i].value });
        data_lable.push(arr_convert[i].label);
        data_lable_time_y.push(arr_convert[i].date_time);

    }
    function unique(arr) {
        var obj = {};

        for (var i = 0; i < arr.length; i++) {
            var str = arr[i];
            obj[str] = true;
        }

        return Object.keys(obj);
    }

    var uniqueLabel = unique(data_lable);
    for (var i = 0; i < uniqueLabel.length; i++) {
        datasets.push({ label: uniqueLabel[i], data: [] });
    }
    for (var i = 0; i < uniqueLabel.length; i++) {
        for (var j = 0; j < arr_convert.length; j++) {
            if (uniqueLabel[i] == arr_convert[j].label) {
                datasets[i].data.push({
                    x: arr_convert[j].date_time,
                    y: arr_convert[j].value
                });
            }
        }
    }
    console.log(datasets);
    function rgb_random() {
        var r = Math.floor(Math.random() * (256));
        var g = Math.floor(Math.random() * (256));
        var b = Math.floor(Math.random() * (256));
        if (r > 220 && g > 220 && b > 220) {
            r -= 50;
            g -= 75;
            b -= 36;
        }
        var str_rgb = '#' + r.toString(16) + g.toString(16) + b.toString(16);

        return str_rgb;
    }
    for (var i = 0; i < datasets.length; i++) {
        config_data.push({
            label: datasets[i].label,
            backgroundColor: "rgba(0,0,0,0)",
            borderColor: rgb_random(),
            fill: false,
            data: datasets[i].data
        });

    }
    var ctx = document.getElementById("myChart").getContext('2d');
    var config = {
        type: 'line',
        data: {
            datasets: config_data
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'Measurement'
            },
            scales: {
                xAxes: [{
                    type: 'time',
                    distribution: 'series',
                    ticks: {
                        source: data_lable_time_y
                    }
                }],
                yAxes: [{
                    ticks: {
                        min: 0,
                        max: 300
                    }
                }]
            }
        }
    };
    console.log(config);
    var lineChart = new Chart(ctx, config);

}

function OnComplete() {



}
setInterval(() => {
    var req = $.ajax({
        url: '/Home/getDataJson',
        dataType: "json",
        success: function (data, textStatus) {
            OnSuccess(data);
            console.log("Был запрос" + data);
        }
    });
}, 10000);