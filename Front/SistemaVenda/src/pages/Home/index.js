import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { MdAddShoppingCart } from 'react-icons/md';
import { formatPrice } from '../../util/format';
import api from '../../services/api';

import * as CartActions from '../../store/modules/cart/actions';

import { ProductList } from './styles';

class Home extends Component {
  constructor(props) {
    super(props);
    this.state = { products: [] };
  }

  async componentDidMount() {
    debugger; // eslint-disable-line no-debugger
    const response = await api.get('api/produto/');

    const data = response.data.map((product) => ({
      // pegando todos os dados do produto
      ...product,
      priceFormatted: formatPrice(product.price),
    }));

    this.setState({ products: data });
  }

  handleAddProduct = (id) => {
    debugger; // eslint-disable-line no-debugger
    const { addToCartRequest } = this.props;

    addToCartRequest(id);
  };

  handleAddReservation = (id) => {
    debugger; // eslint-disable-line no-debugger
    const { updateReservationRequest } = this.props;

    updateReservationRequest(id, true);
  };

  render() {
    const { products } = this.state;
    const { amount } = this.props;

    return (
      <ProductList>
        {products.map((product) => (
          <li key={product.id}>
            <img src={product.image} alt={product.description} />
            <strong>{product.description}</strong>
            <span>{product.priceFormatted}</span>

            <button
              type="button"
              onClick={() => this.handleAddProduct(product.id)}
            >
              <div>
                <MdAddShoppingCart size={16} color="#fff" />{' '}
                {amount[product.id] || 0}
              </div>

              <span>ADICIONAR AO CARRINHO</span>
            </button>
            
            <button
              type="button"
              onClick={() => this.handleAddReservation(product.id)}
            >
              <span>RESERVAR</span>
            </button>
          
            
          </li>
        ))}
      </ProductList>
    );
  }
}

const mapStateToProps = (state) => ({
  amount: state.cart.reduce((amount, product) => {
    amount[product.id] = product.amount;
    return amount;
  }, {}),
});

const mapDispatchToProps = (dispatch) =>
  bindActionCreators(CartActions, dispatch);


export default connect(mapStateToProps, mapDispatchToProps)(Home);
