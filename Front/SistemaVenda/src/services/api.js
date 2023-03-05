import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:7162',
});
// 'json-server server.json -p 3333 comando rodar api'
export default api;
