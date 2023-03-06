import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:7162',
});

export default api;
