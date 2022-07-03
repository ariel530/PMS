

// if (localStorage.CountryCustomerMapColors) {
//  // localStorage.CountryCustomerMapColors = Number(localStorage.CountryCustomerMapColors) + 1;

// } else {
//   localStorage.CountryCustomerMapColors = 1;
// }
//var temp =localStorage.CountryCustomerMapColors; //To get total previous count
// var object = 'pink';
// localStorage.setItem('CCML_' + 1, JSON.stringify(object));
// object = 'orange';
// localStorage.setItem('CCML_' + 2, JSON.stringify(object));
// object = 'green';
// localStorage.setItem('CCML_' + 3, JSON.stringify(object));
// object = 'brown';
// localStorage.setItem('CCML_' + 4, JSON.stringify(object));
// object = 'black';
// localStorage.setItem('CCML_' + 5, JSON.stringify(object));

//AIzaSyDqfrM8nvuaiGzVHOBiqZufzLV3OqMh-Gk
google.charts.load('current', {
    'packages': ['geochart'],
    'mapsApiKey': 'YOUR GOOGLE API KEY'
    //'mapsApiKey': 'AIzaSyDqfrM8nvuaiGzVHOBiqZufzLV3OqMh-Gk'
});
google.charts.setOnLoadCallback(drawRegionsMap);


///CountryCustomerMapColors   CCML_
//$.get('/Customer/GetCustomersForMapCount', {}, function (d) {
    //    console.log(d);
    //    $.each(d, function (v, i) {
    //        console.log(i.CountryCode +' '+ i.CountryName+' '+ i.CustomersCount);
    //        data.addRow([i.CountryCode,i.CountryName, i.CustomersCount]);
    //     //   countryList.push([i.CountryCode, i.CustomersCount]);
    //        console.log(v);
    //    });


function drawRegionsMap() {
    var data =new google.visualization.DataTable();
    data.addColumn('string', 'Country');
    data.addColumn('string', 'Country Name');
    data.addColumn('number', 'Customers');
    $.get('GetCustomersForMapCount', {}, function (d) {
        console.log(d);
        $.each(d, function (v, i) {
            console.log(i.CountryCode + ' ' + i.CountryName + ' ' + i.CustomersCount);
            var name = i.CountryCode;
            var val = i.CustomersCount;
            //  data.addRow([i.CountryCode, i.CustomersCount]);
            data.addRow([i.CountryCode, i.CountryName, i.CustomersCount]);
       //     data.addRow(['AE', 600]);
        //    data.addRow(['IN', i.CustomersCount]);
         //   data.addRow(['RU', 700]);
            //   countryList.push([i.CountryCode, i.CustomersCount]);
            console.log(v);
        });

        //data.addRow(['AG', 200]);
        //data.addRow(['AE', 300]);
        //data.addRow(['RU', 400]);
        //data.addRow(  ['Canada', 500]);
        //data.addRow(['France', 600]);
        //data.addRow(['RU', 700]);


        var temp = localStorage.CountryCustomerMapColors;
        console.log("list  " + temp);
        var colors = [];
        if (temp !== undefined) {
            for (var i = 1; i <= temp; i++) {
                var retrievedObject = localStorage.getItem("CCML_" + i);
                var obj = JSON.parse(retrievedObject);
                console.log(obj + "  " + retrievedObject);
                colors.push(obj);

            }
        }
        else {
            colors.push('black');
            colors.push('black');

        }

        // colors.push('pink');
        // colors.push('orange');
        // colors.push('black');
        // colors.push('yellow');
        // colors.push('red');



        var options = { colors };


        var chart = new google.visualization.GeoChart(document.getElementById('country_customer'));

        chart.draw(data, options);
    });
}
