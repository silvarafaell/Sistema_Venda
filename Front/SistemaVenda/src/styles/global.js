import { createGlobalStyle } from 'styled-components';

import 'react-toastify/dist/ReactToastify.css';
import background from '../assets/images/image_fundo.jpg';

export default createGlobalStyle`
@import url ('https://fonts.googleapis.com/css2? family = Oswald: wght @ 200; 300; 400; 500; 600; 700 & family = Roboto + Mono: wght @ 100 & display = troca');
* {
  margin:0;
  padding:0;
  outline:0;
  box-sizing:border-box;
}

body {
  background: #191920 url(${background}) no-repeat center top;
  -webkit-font-smoothing: antialiased;
}

body, input, button {
  font: 14px Roboto, sans-serif;
}

#root {
  max-width:1020px;
  margin: 0 auto;
  padding: 0 20px 50px;
}

h1 {
  color: #ccc;
}

button {
  cursor: pointer;
}

.bZFZZh {
    margin-left: 800px;
}

#home {
  text-decoration: none;
  color: #000;
}

#product {
  text-decoration: none;
  color: #000;
}
`;
