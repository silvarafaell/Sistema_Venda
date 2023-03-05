export function addToCartRequest(id) {
  debugger; // eslint-disable-line no-debugger
  return {
    type: '@cart/ADD_REQUEST',
    id,
  };
}

export function addToCartSuccess(product) {
  debugger; // eslint-disable-line no-debugger
  return {
    type: '@cart/ADD_SUCCESS',
    product,
  };
}

export function removeFromCart(id) {
  debugger; // eslint-disable-line no-debugger
  return {
    type: '@cart/REMOVE',
    id,
  };
}

export function updateAmountRequest(id, amount) {
  debugger; // eslint-disable-line no-debugger
  return {
    type: '@cart/UPDATE_AMOUNT_REQUEST',
    id,
    amount,
  };
}

export function updateAmountSuccess(id, amount) {
  return {
    type: '@cart/UPDATE_AMOUNT_SUCCESS',
    id,
    amount,
  };
}

export function updateReservationRequest(id, reservation) {
  debugger; // eslint-disable-line no-debugger
  return {
    type: '@cart/UPDATE_RESERVATION_REQUEST',
    id,
    reservation
  };
}
