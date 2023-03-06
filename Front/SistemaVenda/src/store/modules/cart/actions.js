export function addToCartRequest(id) {
  return {
    type: '@cart/ADD_REQUEST',
    id,
  };
}

export function addToCartSuccess(product) {
  return {
    type: '@cart/ADD_SUCCESS',
    product,
  };
}

export function removeFromCart(id) {
  return {
    type: '@cart/REMOVE',
    id,
  };
}

export function updateAmountRequest(id, amount) {
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
  return {
    type: '@cart/UPDATE_RESERVATION_REQUEST',
    id,
    reservation
  };
}

export function updateReservationSuccess(id, reservation) {
  return {
    type: '@cart/UPDATE_RESERVATION_SUCCESS',
    id,
    reservation,
  };
}
