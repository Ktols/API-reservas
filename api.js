const express = require('express');
const axios = require('axios');

const app = express();
const baseURL = 'https://restful-booker.herokuapp.com';

// Endpoint para obtener la lista de reservas
app.get('/reservas', async (req, res) => {
  try {
    const response = await axios.get(`${baseURL}/booking`);
    res.json(response.data);
  } catch (error) {
    res.status(500).json({ error: 'Error al obtener la lista de reservas' });
  }
});

// Endpoint para obtener los detalles de una reserva específica
app.get('/reservas/:id', async (req, res) => {
  const { id } = req.params;
  try {
    const response = await axios.get(`${baseURL}/booking/${id}`);
    res.json(response.data);
  } catch (error) {
    res.status(404).json({ error: 'Reserva no encontrada' });
  }
});

// Iniciar el servidor en el puerto 3000
const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
  console.log(`Servidor API corriendo en el puerto ${PORT}`);
});
