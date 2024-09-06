console.log("app loaded")
document.getElementById('load-forecast').addEventListener('click', function () {
    console.log("Loading forecast...")
    fetch('https://localhost:7116/WeatherForecast/json')  // Ensure the URL matches your local or server configuration
        .then(response => {
            console.log("Response: ", response)
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            console.log("Data: ", data)
            const tableBody = document.getElementById('forecast').getElementsByTagName('tbody')[0];
            tableBody.innerHTML = '';  // Clear existing table rows
            data.Data.forEach(forecast => {
                const row = tableBody.insertRow();
                row.insertCell(0).textContent = forecast.date;
                row.insertCell(1).textContent = forecast.temperatureC;
                row.insertCell(2).textContent = forecast.temperatureF;
                row.insertCell(3).textContent = forecast.summary;
            });
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        });
});