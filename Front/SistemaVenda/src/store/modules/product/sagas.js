import { call, select, put, all, takeLatest } from 'redux-saga/effects';
import { toast } from 'react-toastify';

import api from '../../../services/api';
import history from '../../../services/history';
import { formatPrice } from '../../../util/format';

import { addToCartSuccess, updateAmountSuccess } from './actions';

function* updateReservation({ id, reservation }) {
  debugger; // eslint-disable-line no-debugger

  const stock = yield call(api.put, `api/produto/${id}`);
  

  //yield put(updateAmountSuccess(id, reservation));
}

export default all([ 
  takeLatest('@product/UPDATE_RESERVATION_REQUEST', updateReservation),
]);
