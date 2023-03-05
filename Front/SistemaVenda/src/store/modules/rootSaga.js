import { all } from 'redux-saga/effects';

import cart from './cart/sagas';
import product from './product/sagas';

export default function* rootSaga() {
  return yield all([cart, product]);
}
