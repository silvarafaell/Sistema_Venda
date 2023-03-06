export function updateReservationRequest(id, reservation) {
    debugger; // eslint-disable-line no-debugger
    return {
      type: '@product/UPDATE_RESERVATION_REQUEST',
      id,
      reservation
    };
  }