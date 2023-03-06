import { call, select, put, all, takeLatest } from 'redux-saga/effects';
import { toast } from 'react-toastify';

import api from '../../../services/api';
import history from '../../../services/history';
import { formatPrice } from '../../../util/format';

import { addToCartSuccess, updateAmountSuccess } from './actions';

function* addToCart({ id }) {
  const productExists = yield select((state) =>
    state.cart.find((p) => p.id === id)
  );

  const stock = yield call(api.get, `api/produto/${id}`);

  const stockAmount = stock.data.stock;
  const currentAmount = productExists ? productExists.amount : 0;

  const amount = currentAmount + 1;

  if (amount > stockAmount) {
    toast.error('Quantidade solicitada fora de estoque');
    return;
  }

  if (productExists) {
    yield put(updateAmountSuccess(id, amount));
  } else {
    const response = yield call(api.get, `api/produto/${id}`);

    const data = {
      ...response.data,
      amount: 1,
      priceFormatted: formatPrice(response.data.price),
    };

    yield put(addToCartSuccess(data));
    history.push('/cart');
  }
}

function* updateAmount({ id, amount }) {
  if (amount <= 0) return;

  const stock = yield call(api.get, `api/produto/${id}`);
  const stockAmount = stock.data.amount;

  if (amount > stockAmount) {
    toast.error('Quantidade solicitada fora de estoque');
    return;
  }

  yield put(updateAmountSuccess(id, amount));
}

function* updateReservation({ id, reservation }) {

 const filterproduct = yield call(api.get, `api/produto/${id}`);

  if (filterproduct.data.reserved === true) {
    toast.error('Produto já reservado');
    return;
  }

  const product = yield call(api.put, `api/produto/reservation?id=${id}&resevation=${reservation}`);
  if (product.request.status === 200) {
    toast.success('Produto reservado com sucesso!');
  }

  refreshPage();
}

function refreshPage() {
  setTimeout(()=>{
      window.location.reload(false);
  }, 1000);
  console.log('page to reload')
}

export default all([
  takeLatest('@cart/ADD_REQUEST', addToCart),
  takeLatest('@cart/UPDATE_AMOUNT_REQUEST', updateAmount),
  takeLatest('@cart/UPDATE_RESERVATION_REQUEST', updateReservation),
]);