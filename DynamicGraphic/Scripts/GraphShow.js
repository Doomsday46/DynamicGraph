var global_result;
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
var config;
var lineChart;
function unique(arr) {
    var obj = {};

    for (var i = 0; i < arr.length; i++) {
        var str = arr[i];
        obj[str] = true;
    }

    return Object.keys(obj);
}
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
function on_create_g() {
    var arr = global_result;
    var arr_convert = [];
    if (arr !== null) {
        for (var i = 0; i < arr.length; i++) {
            arr_convert.push({
                label: arr[i].parameter_name.trim(),
                value: arr[i].parameter_value,
                date_time: moment(arr[i].date_time, "YYYY.MM.DD HH:mm:ss")
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
    var uniqueDate = unique(data_lable_time_y);
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
    config = {
        type: 'line',
        labels: uniqueDate,
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
                        min: 400,
                        max: 600
                    }
                }]
            }
        }
    };
    console.log(config);
    lineChart = new Chart(ctx, config);
    setInterval(() => {
        var req = $.ajax({
            url: '/Home/getDataJson',
            dataType: "json",
            success: function (data, textStatus) {
                RenderGraph(data);
                console.log("Был запрос");
            }
        });
    }, 1000);
}

function OnComplete() {

}
function containt_values(arr_data, values) {
    for (var i = 0; i < arr_data.length; i++) {
        if (arr_data[i].y == values.parameter_value &&
            arr_data[i].x.toString() == values.date_time.toString()) {
            return false;
        }
    }
    return true;
}
function RenderGraph(data) {
    var arr_convert = [];
   if (config.data.datasets.length > 0) {
        
        for (var i = 0; i < data.length; i++) {
            arr_convert.push({
                label: data[i].parameter_name.trim(),
                value: data[i].parameter_value,
                date_time: moment(data[i].date_time, "YYYY.MM.DD HH:mm:ss")
            });
            config.data.labels.push(arr_convert[i].date_time);
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
       config.data.labels = unique(config.data.labels);
       var flag = false;
       var config_data ;
        for (var index = 0; index < arr_convert.length; ++index) {
            for (var j = 0; j < config.data.datasets.length; ++j) {
                if (config.data.datasets[j].label == arr_convert[index].label) {
                    if (containt_values(config.data.datasets[j].data, { parameter_value: arr_convert[index].value, date_time: arr_convert[index].date_time })) {
                        config.data.datasets[j].data.push({
                            x: arr_convert[index].date_time,
                            y: arr_convert[index].value
                        });
                        console.log("Добавлено");
                    }
                    flag = true;
                    break;
                }
            }
            if (!flag) {
                var datasets_element = {
                    label: arr_convert[index].label,
                    backgroundColor: "rgba(0,0,0,0)",
                    borderColor: rgb_random(),
                    fill: false,
                    data: [{
                        x: arr_convert[index].date_time,
                        y: arr_convert[index].value
                    }]
                };
                config.data.datasets.push(datasets_element);
            }
            if (flag) flag = false;
        }
        lineChart.update();
    }
}
