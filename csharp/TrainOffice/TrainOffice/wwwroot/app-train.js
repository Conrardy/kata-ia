console.log("app trainloaded")

document.addEventListener('DOMContentLoaded', () => {
    fetch('/api/Trains')
        .then(response => response.json())
        .then(dataWrapped => {
            console.log("Data: ", dataWrapped)
            const data = dataWrapped.Data;
            const container = document.getElementById('trains-container');
            data.forEach(train => {
                const trainDiv = document.createElement('div');
                trainDiv.classList.add('train');

                const trainInfo = document.createElement('div');
                trainInfo.innerHTML = `<h2>${train.name}</h2><p>Departure: ${train.departure}</p><p>Arrival: ${train.arrival}</p>`;
                trainDiv.appendChild(trainInfo);

                train.coaches.forEach(coach => {
                    const coachDiv = document.createElement('div');
                    coachDiv.classList.add('coach');
                    coachDiv.innerHTML = `<h3>Coach ${coach.name}</h3>`;

                    const seatsDiv = document.createElement('div');
                    seatsDiv.classList.add('seats');
                    coach.seats.forEach(seat => {
                        const seatDiv = document.createElement('div');
                        seatDiv.classList.add('seat', seat.reserved ? 'reserved' : 'available');
                        seatDiv.textContent = seat.name;
                        seatsDiv.appendChild(seatDiv);
                    });
                    coachDiv.appendChild(seatsDiv);
                    trainDiv.appendChild(coachDiv);
                });

                container.appendChild(trainDiv);
            });
        });
});