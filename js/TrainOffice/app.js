

// Fichier: app.js

// Fonction pour appeler l'API et afficher les résultats
async function fetchData() {
  try {
    const response = await fetch('https://293a-88-171-24-164.ngrok-free.app/'); // Remplace par l'URL de ton API
    if (!response.ok) {
      throw new Error('Erreur dans la requête API');
    }
    const data = await response.json();
    displayData(data); // Fonction pour afficher les données sur la page
  } catch (error) {
    console.error('Erreur:', error);
  }
}

// Fonction pour afficher les données récupérées dans la page HTML
function displayData(data) {
  const contentDiv = document.getElementById('content');
  contentDiv.innerHTML = `
    <pre>${JSON.stringify(data, null, 2)}</pre>
  `;
}

// Exécuter la fonction après le chargement de la page
// window.onload = fetchData;
