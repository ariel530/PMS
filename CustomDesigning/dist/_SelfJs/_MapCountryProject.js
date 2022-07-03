

// if (localStorage.ProjectCountryMapColors) {
//  // localStorage.ProjectCountryMapColors = Number(localStorage.ProjectCountryMapColors) + 1;

// } else {
//   localStorage.ProjectCountryMapColors = 1;
// }
//var temp =localStorage.ProjectCountryMapColors; //To get total previous count
// var object = 'pink';
// localStorage.setItem("PCML_" + 1, JSON.stringify(object));
// object = 'orange';
// localStorage.setItem("PCML_" + 2, JSON.stringify(object));
// object = 'green';
// localStorage.setItem("PCML_" + 3, JSON.stringify(object));
// object = 'brown';
// localStorage.setItem("PCML_" + 4, JSON.stringify(object));
// object = 'black';
// localStorage.setItem("PCML_" + 5, JSON.stringify(object));


google.charts.load('current', {
    'packages': ['geochart'],
    'mapsApiKey': 'YOUR GOOGLE API KEY'
});
google.charts.setOnLoadCallback(drawRegionsMap);




function drawRegionsMap() {
    //var data = google.visualization.arrayToDataTable([
    //  ['Country', 'Projects'],
    //  ['Germany', 200],
    //  ['United States', 300],
    //  ['Brazil', 400],
    //  ['Canada', 500],
    //  ['France', 600],
    //  ['RU', 700]
    //]);

    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Country');
    data.addColumn('string', 'Country Name');
    data.addColumn('number', 'Projects');
    $.get('GetProjectsForMapCount', {}, function (d) {
        console.log(d);
        $.each(d, function (v, i) {
            console.log(i.CountryCode + ' ' + i.CountryName + ' ' + i.ProjectsCount);
            //var name = i.CountryCode;
            //var val = i.CustomersCount;
            ////  data.addRow([i.CountryCode, i.CustomersCount]);
            data.addRow([i.CountryCode, i.CountryName, i.ProjectsCount]);
            //     data.addRow(['AE', 600]);
            //    data.addRow(['IN', i.CustomersCount]);
            //   data.addRow(['RU', 700]);
            //   countryList.push([i.CountryCode, i.CustomersCount]);
            console.log(v);
        });
    });
    var temp = localStorage.ProjectCountryMapColors;
    console.log("list  " + temp);
    var colors = [];
    if (temp !== undefined) {
        for (var i = 1; i <= temp; i++) {
            var retrievedObject = localStorage.getItem("PCML_" + i);
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


    var chart = new google.visualization.GeoChart(document.getElementById('project_customer'));

    chart.draw(data, options);
}
