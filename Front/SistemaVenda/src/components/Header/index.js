import React from 'react';
import { connect } from 'react-redux';
import { NavLink } from 'react-router-dom'

import { MdShoppingBasket } from 'react-icons/md';

import { Container, Cart } from './styles';

function Header({ cartSize }) {
  return (
    <Container>
      <NavLink className="nav-link active" aria-current="page" to="/" id="home">
      <strong>Home</strong>
      </NavLink>
      <Cart to="/cart">
        <div>
          <strong>Meu carrinho</strong>
          <span>{cartSize} itens</span>
        </div>
        <MdShoppingBasket size={36} color="#000" />
      </Cart>
    </Container>
  );
}

export default connect((state) => ({ cartSize: state.cart.length }))(Header);
